using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Articulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
    }
}
