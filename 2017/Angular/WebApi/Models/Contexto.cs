using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Contexto: DbContext
    {
        public Contexto() : base("name=BDAlmacen")
        {
        }

        public DbSet<Articulo> Articulos { get; set; }


    }
}
