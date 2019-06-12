using System;
using System.Collections.Generic;
using Condai.Entity;
using System.Linq.Expressions;

namespace Condai.DAL
{
    public class DALEvento
    {
        private static DALEvento obj = new DALEvento();

        public static DALEvento Instance
        {
            get { return obj; }
        }

        public Evento LeerEventoPorCodigo(int codigo)
        {
            RepositorioEvento<Evento> contexto = new RepositorioEvento<Evento>();

            Expression<Func<Evento, bool>> linq = (i => i.eveId == codigo);
            
            return contexto.ObtenerObjeto(linq);
        }

        public List<Evento> LeerEventosOrdenadosPorFecha(int top)
        {
            RepositorioEvento<Evento> contexto = new RepositorioEvento<Evento>();

            System.Linq.Expressions.Expression<Func<Evento, DateTime>> selector;

            selector = (x => x.eveFecha);

            return contexto.ObtenerListadoDeObjetosPorFecha(top, selector);
        }

        public bool EliminarEvento(int codigoEvento)
        {
            RepositorioEvento<Evento> contexto = new RepositorioEvento<Evento>();

            Evento evento = new Evento() { eveId = codigoEvento };

            return contexto.EliminarObjeto(evento);
        }

        public int AgregarEvento(Evento eventoNuevo)
        {
            RepositorioEvento<Evento> contexto = new RepositorioEvento<Evento>();

            return contexto.InsertarObjeto(eventoNuevo);
        }
    }
}
