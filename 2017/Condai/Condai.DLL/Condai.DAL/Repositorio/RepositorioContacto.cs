using Condai.DAL.Modelo;
using System.Data.Entity;

namespace Condai.DAL
{
    public class RepositorioContacto<Y> : Repositorio<Y> where Y : class
    {
        //Indica el Contexto del Modelo, se Sobreescribe el contexto en la clase Principal. 
        CondaiContacto Context = new CondaiContacto();

        public override DbContext Contexto
        {
            get
            {
                return Context;
            }
        }
    }
}