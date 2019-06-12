using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Condai.Tools.Formato
{
    public class Formato
    {
        #region [ Propiedades ]

        private static Formato obj = new Formato();

        #endregion

        #region [ Construcctor ]

        public static Formato Instancia
        {
            get { return obj; }
        }

        #endregion

        public string Serializar(object dato)
        {
            return JsonConvert.SerializeObject(dato,
                                               Formatting.None,
                                               new IsoDateTimeConverter() {
                                                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss" 
                                               });
        }

        public object Deserializar(string dato)
        {
            return JsonConvert.DeserializeObject<object>(dato);
        }
    }
}
