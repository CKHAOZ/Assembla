using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Amazon.S3;
using Amazon.S3.Model;
using RGC.Tools;
using RGC.BusinessEntitiesLayer;
using System.Xml.Linq;
using Amazon.S3.IO;
using System.Data.SqlClient;

namespace RGC.BusinessLogicLayer
{
    public class BLLAdjuntosAmazon : BLLBaseClass
    {
        /// <summary>
        /// Wraps the url or link of an amazon object, allowing to parse
        /// or generate it
        /// </summary>
        public class AmazonObjectUrl
        {
            #region [ Constructor ]

            public AmazonObjectUrl()
            {

            }

            public AmazonObjectUrl(string url)
            {
                Analyze(url);
            }

            public AmazonObjectUrl(string bucket, string key)
            {
                Bucket = bucket;
                Key = key;
            }

            #endregion

            #region [ Properties ]

            public string Region { get; set; }

            public string Bucket { get; set; }

            public string Key { get; set; }

            public bool IsValid
            {
                get { return Bucket.IsNullOrEmpty() == false && Key.IsNullOrEmpty() == false; }
            }

            public string UrlRegex
            {
                get { return @"https{0,1}:\/\/s3(-(?<region>[a-zA-Z0-9\-]+)){0,1}\.amazonaws\.com\/(?<bucket>[a-zA-Z0-9_\-\.]+)\/(?<key>.*)"; }
            }

            #endregion

            #region [ Methods ]

            public bool Analyze(string url)
            {
                bool result = false;
                Match match = Regex.Match(url, UrlRegex);
                if (match.Success)
                {
                    result = true;
                    Bucket = match.Groups["bucket"].Value;
                    Key = match.Groups["key"].Value;

                    if (match.Groups["region"].Success)
                    {
                        Region = match.Groups["region"].Value;
                    }
                }
                return result;
            }

            public string ToString()
            {
                return String.Format(@"https://s3.amazonaws.com/{0}/{1}", Bucket, Key);
            }

            #endregion
        }

        #region [ Attributes ]

        private static BLLAdjuntosAmazon obj = new BLLAdjuntosAmazon();

        #endregion

        #region [ Properties ]

        public static BLLAdjuntosAmazon Instance
        {
            get { return obj; }
        }

        #endregion
        
        #region [ Methods ]

        public string ObtenerUrlPublicaTemporal(string urlAmazon)
        {
            string url = null;
            AmazonObjectUrl amazonUrl = new AmazonObjectUrl(urlAmazon);
            if (amazonUrl.IsValid)
            {
                try
                {
                    Amazon.RegionEndpoint region = Amazon.RegionEndpoint.GetBySystemName(Constants.RegionDefecto);
                    Amazon.Runtime.AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials(Constants.PerfilSoportesSDKStore);
                    IAmazonS3 s3Client = new AmazonS3Client(credentials, region);

                    GetPreSignedUrlRequest request = new GetPreSignedUrlRequest()
                    {
                        BucketName = amazonUrl.Bucket,
                        Key = amazonUrl.Key,
                        Expires = DateTime.Now.AddSeconds(Constants.SegundosVigenciaUrl)
                    };

                    url = s3Client.GetPreSignedURL(request);
                }
                catch (Exception ex)
                {
                    Activa.Trace.Trace.WriteLineLine_Error(ex);
                }
            }
            return url;
        }

        public List<vEntityAdjuntoCargaNube> ObtenerAdjuntosCargaMasiva()
        {
            List<vEntityAdjuntoCargaNube> res = new List<vEntityAdjuntoCargaNube>();

            using (SqlConnection con = new SqlConnection(Constants.AppAuditoria))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SPNET_OBTENER_ADJUNTOS_CARGA_MASIVA_NUBE", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandTimeout = 600;
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    res.Add(new vEntityAdjuntoCargaNube
                    {
                        Ruta = rd.IsDBNull(rd.GetOrdinal("Ruta")) ? null : (string)rd.GetString(rd.GetOrdinal("Ruta")),
                        CheckSum = rd.IsDBNull(rd.GetOrdinal("CheckSum")) ? null : (string)rd.GetString(rd.GetOrdinal("CheckSum")),
                        IdAdjunto = rd.IsDBNull(rd.GetOrdinal("IdAdjunto")) ? 0 : rd.GetInt32(rd.GetOrdinal("IdAdjunto")),
                        Mirror = rd.IsDBNull(rd.GetOrdinal("Mirror")) ? false : rd.GetBoolean(rd.GetOrdinal("Mirror"))
                    });
                }
                con.Close();
            }
            return res;
        }

        public vEntityRespuestaCargaNube CargarArchivo(string ruta, string checkSum, string bucket, string key)
        {
            vEntityRespuestaCargaNube resultado = null;

            AmazonObjectUrl urlAmazon = new AmazonObjectUrl()
            {
                Bucket = bucket,
                Key = key
            };

            try
            {
                Amazon.Runtime.AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials(Constants.PerfilSoportesSDKStore);

                using (IAmazonS3 s3Client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.GetBySystemName(Constants.RegionDefecto)))
                {
                    string tagCheckSum = "x-amz-meta-checksum";

                    var fileInfo = new Amazon.S3.IO.S3FileInfo(s3Client, urlAmazon.Bucket, urlAmazon.Key);
                    if (fileInfo.Exists)
                    {
                        var respGet = s3Client.GetObjectMetadata(urlAmazon.Bucket, urlAmazon.Key);
                        if (respGet.Metadata[tagCheckSum] == checkSum)
                        {
                            resultado = new vEntityRespuestaCargaNube()
                            {
                                Exito = true,
                                Link = urlAmazon.ToString()
                            };
                        }
                        else
                        {
                            resultado = new vEntityRespuestaCargaNube()
                            {
                                Exito = false,
                                Link = urlAmazon.ToString(),
                                Mensaje = "Hay un archivo con la misma ruta en el servidor, pero tienen checksum diferente"
                            };
                        }
                    }

                    if (resultado == null)
                    {
                        using (var reader = new System.IO.StreamReader(ruta))
                        {
                            var request = new PutObjectRequest()
                            {
                                BucketName = urlAmazon.Bucket,
                                Key = urlAmazon.Key,
                                CannedACL = S3CannedACL.Private,
                                InputStream = reader.BaseStream
                            };
                            request.Metadata.Add(tagCheckSum, checkSum);

                            var respIns = s3Client.PutObject(request);

                            var fileInfo2 = new Amazon.S3.IO.S3FileInfo(s3Client, urlAmazon.Bucket, urlAmazon.Key);
                            if (fileInfo2.Exists)
                            {
                                resultado = new vEntityRespuestaCargaNube()
                                {
                                    Exito = true,
                                    Link = urlAmazon.ToString()
                                };
                            }
                            else
                            {
                                resultado = new vEntityRespuestaCargaNube()
                                {
                                    Exito = false,
                                    Link = urlAmazon.ToString(),
                                    Mensaje = "Se ejecuto el proceso de cargue del archivo, pero no se pudo confirmar su existencia en la nube."
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new vEntityRespuestaCargaNube()
                {
                    Exito = false,
                    Link = urlAmazon.ToString(),
                    Mensaje = String.Format("Error al cargar archivo a Amazon. Excepción: {0}", ex.ToString())
                };
            }

            return resultado;
        }

        #endregion
    }
}
