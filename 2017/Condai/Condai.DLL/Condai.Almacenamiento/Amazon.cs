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

        #region [ Constructor ]

        public BLLAdjuntosAmazon() { }

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

        public TransactionResult<bool> ActualizarAdjunto(int idAdjunto, string ruta, string checkSum, bool mirror)
        {
            Func<XDocument, bool> CustomFunction = xDoc =>
            {
                bool resultado = false;
                if (xDoc.Descendants("row").Count() > 0)
                {
                    resultado = xDoc.Descendants("row").Attributes("RESULTADO").Any() ? xDoc.Descendants("row").First().Attribute("RESULTADO").Value.ToBoolean() : false;
                }
                return resultado;
            };

            return GetAbstractData<bool>("SPNET_ACTUALIZAR_ADJUNTO", new DataService.ServiceSpParameter[] { 
                new DataService.ServiceSpParameter
					{
						ParameterName = "@ID",
						ParameterType = System.Data.SqlDbType.Int,
						ParameterValue = idAdjunto
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@PATH",
						ParameterType = System.Data.SqlDbType.VarChar,
						ParameterValue = ruta
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@CHECKSUM",
						ParameterType = System.Data.SqlDbType.VarChar,
						ParameterValue = checkSum
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@MIRROR",
						ParameterType = System.Data.SqlDbType.Bit,
						ParameterValue = mirror
					}
            }, CustomFunction);
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

        public TransactionResult<bool> InsertarAdjuntoDesaparecido(string ruta)
        {
            return InsertarAdjuntoDesaparecido(ruta, null, null, null);
        }

        public TransactionResult<bool> InsertarAdjuntoDesaparecido(string path, decimal? facNroInt, string tipoProceso, string rutaAbsoluta)
        {
            Func<XDocument, bool> CustomFunction = xDoc =>
            {
                bool resultado = false;
                if (xDoc.Descendants("row").Count() > 0)
                {
                    resultado = xDoc.Descendants("row").Attributes("RESULTADO").Any() ? xDoc.Descendants("row").First().Attribute("RESULTADO").Value.ToBoolean() : false;
                }
                return resultado;
            };

            return GetAbstractData<bool>("SPNET_CARGA_MASIVA_NUBE_INS_ADJ_DESAPARECIDO", new DataService.ServiceSpParameter[] { 
                new DataService.ServiceSpParameter
					{
						ParameterName = "@PATH",
						ParameterType = System.Data.SqlDbType.VarChar,
						ParameterValue = path  
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@FAC_NRO_INT",
						ParameterType = System.Data.SqlDbType.Decimal,
						ParameterValue = facNroInt
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@TIPO_PROCESO",
						ParameterType = System.Data.SqlDbType.VarChar,
						ParameterValue = tipoProceso
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@RUTA_ABSOLUTA",
						ParameterType = System.Data.SqlDbType.VarChar,
						ParameterValue = rutaAbsoluta
					},
            }, CustomFunction);
        }

        #endregion

        #region [AdjuntoSinRelacion]

        public List<vEntityAdjuntosSinRelacionRevision> getAdjuntosSinRelacion()
        {
            List<vEntityAdjuntosSinRelacionRevision> res = new List<vEntityAdjuntosSinRelacionRevision>();

            using (SqlConnection con = new SqlConnection(Constants.AppAuditoria))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SPNET_GET_ADJUNTOS_SIN_RELACION_REVISION", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandTimeout = 600;
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    res.Add(new vEntityAdjuntosSinRelacionRevision
                    {
                        Id = rd.GetInt32(rd.GetOrdinal("ID")),
                        FacNroInt = rd.IsDBNull(rd.GetOrdinal("FAC_NROINT")) ? null : new Nullable<decimal>(rd.GetDecimal(rd.GetOrdinal("FAC_NROINT"))),
                        Path = rd.IsDBNull(rd.GetOrdinal("PATH")) ? null : (string)rd.GetString(rd.GetOrdinal("PATH")),
                        RutaAbsoluta = rd.IsDBNull(rd.GetOrdinal("RUTA_ABSOLUTA")) ? null : rd.GetString(rd.GetOrdinal("RUTA_ABSOLUTA"))
                    });
                }
                con.Close();
            }
            return res;
        }

        public bool updateAdjuntosSinRelacion(int id, int status)
        {
            Func<XDocument, bool> CustomFunction = xDoc =>
            {
                bool resultado = false;
                if (xDoc.Descendants("row").Count() > 0)
                {
                    resultado = xDoc.Descendants("row").Attributes("RESULTADO").Any() ? xDoc.Descendants("row").First().Attribute("RESULTADO").Value.ToBoolean() : false;
                }
                return resultado;
            };

            return GetAbstractData<bool>("SPNET_GET_PATH_FILES_DELETE_DISC_UPDATE_STATE", new DataService.ServiceSpParameter[] { 
                new DataService.ServiceSpParameter
					{
						ParameterName = "@ID",
						ParameterType = System.Data.SqlDbType.Int,
						ParameterValue = id
					},
                new DataService.ServiceSpParameter
					{
						ParameterName = "@STATUS",
						ParameterType = System.Data.SqlDbType.Decimal,
						ParameterValue = status
					}
            }, CustomFunction).ObjectValue;
        }



        #endregion
    }
}
