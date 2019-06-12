using Condai.DAL.Modelo;
using System.Data.Entity;

namespace Condai.DAL
{
    public class RepositorioBase<Y> : Repositorio<Y> where Y : class
    {
        //Indica el Contexto del Modelo, se Sobreescribe el contexto en la clase Principal. 
        CondaiBase Context = new CondaiBase();

        public override DbContext Contexto
        {
            get
            {
                return Context;
            }
        }  
    }
}