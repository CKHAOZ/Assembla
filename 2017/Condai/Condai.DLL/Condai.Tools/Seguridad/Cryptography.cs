using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Condai.Tools.Seguridad
{
    public class Cryptography
    {
        #region [ Propiedades ]

        private static Cryptography obj = new Cryptography();

        #endregion

        #region [ Construcctor ]

        public static Cryptography Instancia
        {
            get { return obj; }
        }

        #endregion

        #region  [ Metodos ]

        public string Encriptar(string valorOrigen)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (byte b in Hash(valorOrigen))
            {
                resultado.Append(b.ToString("X2"));
            }

            return resultado.ToString();
        }

        public string LeerCheckSum(Stream archivo)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] checksum = sha.ComputeHash(archivo);
            return BitConverter.ToString(checksum).Replace("-", String.Empty);
        }

        private byte[] Hash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();

            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        #endregion
    }
}
