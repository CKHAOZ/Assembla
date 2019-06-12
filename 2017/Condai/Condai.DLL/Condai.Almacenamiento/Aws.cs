using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;
using Condai.Entity;
using Condai.Tools;

namespace Condai.Almacenamiento
{
    public class Aws
    {
        #region [ Propiedades ]

        public static Aws Instancia
        {
            get { return obj; }
        }

        #endregion

        #region [ Atributos ]

        private string DLL = "Condai.Almacenamiento.Aws";

        private static Aws obj = new Aws();

        #endregion

        #region [ Constructor ]

        public Aws()
        {

        }

        #endregion

        #region [ Metodos ]

        public void ObtenerRutaAdjunto()
        {
            string regionAws = "us-west-2";
            string usuarioAws = "CondaiUser";
            string accessKey = "AKIAIB7EDHV2CPLYDT4A";
            string secretKey = "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";

            Amazon.Util.ProfileManager.RegisterProfile(usuarioAws, accessKey, secretKey);

            Amazon.RegionEndpoint region = Amazon.RegionEndpoint.GetBySystemName(regionAws);
            Amazon.Runtime.AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials(usuarioAws);

            Amazon.S3.IAmazonS3 s3Client = new Amazon.S3.AmazonS3Client(credentials, region);

            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest()
            {
                BucketName = "abccondai",
                Key = "Arena.jpg",
                Expires = DateTime.Now.AddSeconds(60)
            };

            var a = s3Client.GetPreSignedURL(request);
        }

        public Transaccion<bool> CargarArchivo(string bucketName, string keyName, Stream data)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(DLL);

            string regionAws = Condai.Tools.Configuracion.RegionAws;
            string usuarioAws = Condai.Tools.Configuracion.UsuarioAws;
            string accessKey = Condai.Tools.Configuracion.AccessKey;
            string secretKey = Condai.Tools.Configuracion.SecretKey;

            Amazon.Util.ProfileManager.RegisterProfile(usuarioAws, accessKey, secretKey);
            Amazon.RegionEndpoint region = Amazon.RegionEndpoint.GetBySystemName(regionAws);
            Amazon.Runtime.AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials(usuarioAws);

            string checkSum = Condai.Tools.Seguridad.Cryptography.Instancia.LeerCheckSum(data);

            using (IAmazonS3 s3Client = new AmazonS3Client(credentials, region))
            {
                string tagCheckSum = "x-amz-meta-checksum";

                var fileInfo = new Amazon.S3.IO.S3FileInfo(s3Client, bucketName, keyName);

                if (fileInfo.Exists)
                {
                    var respGet = s3Client.GetObjectMetadata(bucketName, keyName);

                    if (respGet.Metadata[tagCheckSum] == checkSum)
                    {
                        resultado = ManejoTransaccion<bool>.Instancia.Resultado(Estado.Correcto, resultado, true, "Hay un archivo con la misma ruta en el servidor y tiene el checksum igual.");
                    }
                    else
                    {
                        resultado = ManejoTransaccion<bool>.Instancia.Resultado(Estado.Error, resultado, false, "Hay un archivo con la misma ruta en el servidor, pero tienen checksum diferente.");
                    }
                }
                else
                {
                    var request = new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = keyName,
                        CannedACL = S3CannedACL.Private,
                        InputStream = data
                    };

                    request.Metadata.Add(tagCheckSum, checkSum);

                    s3Client.PutObject(request);
                    
                    var fileInfo2 = new Amazon.S3.IO.S3FileInfo(s3Client, bucketName, keyName);

                    if (fileInfo2.Exists)
                    {
                        resultado = ManejoTransaccion<bool>.Instancia.Resultado(Estado.Correcto, resultado, true, "Cargado");
                    }
                    else
                    {
                        resultado = ManejoTransaccion<bool>.Instancia.Resultado(Estado.Error, resultado, false, "Error cargando el archivo al Aws S3");
                    }
                }
            }

            return resultado;
        }

        #endregion
    }
}


