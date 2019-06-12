using Condai.DAL.Modelo;
using System.Data.Entity;

namespace Condai.DAL
{
    public class RepositorioSeguridad<Y> : Repositorio<Y> where Y : class
    {
        //Indica el Contexto del Modelo, se Sobreescribe el contexto en la clase Principal. 
        CondaiSeguridad Context = new CondaiSeguridad();

        public override DbContext Contexto
        {
            get
            {
                return Context;
            }
        }  
    }
}