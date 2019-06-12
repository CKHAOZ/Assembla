namespace Condai.Entity
{
    public class Transaccion<TEntity>
    {
        public int IdTransaccion { get; set; }
        public string Mensaje { get; set; }
        public string Error { get; set; }
        public int Resultado { get; set; }
        public string Dll { get; set; }
        public Estado Estado { get; set; }
        public TEntity Dato { get; set; }
    }
}
