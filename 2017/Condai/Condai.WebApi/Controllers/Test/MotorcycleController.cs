using Condai.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Condai.WebApi.Controllers
{
    public class MotorcycleController : ApiController
    {
        List<Motorcycle> listadoMotorcycles = new List<Motorcycle>()
        {
            new Motorcycle { Id = 1, Name = "Z800e", Category = "Naked", Year = 2016, Power = 116, Model = "Kawasaki", Path = @"F:\Imagen\kawasaki-z800.jpg"},
            new Motorcycle { Id = 2, Name = "Diavel 1200", Category = "Naked", Year = 2017, Power = 119, Model = "Ducati", Path = @"F:\Imagen\DucatiDiavel1200.jpg"},
            new Motorcycle { Id = 3, Name = "Dragster 800", Category = "Naked", Year = 2017, Power = 116, Model = "MV Agusta", Path = @"F:\Imagen\Dragster800.jpg"},
            new Motorcycle { Id = 4, Name = "ZX10R", Category="SuperBike", Year = 2017, Power = 175, Model = "Kawasaki", Path = @"F:\Imagen\Zx10r.jpg" }
        };

        // GET: Motorcycle
        public IEnumerable<Motorcycle> GetAllMotorcycles()
        {
            return listadoMotorcycles;
        }

        public IHttpActionResult GetProduct(int id)
        {
            Motorcycle bike = null;

            bike = listadoMotorcycles.Where(h => h.Id == id).FirstOrDefault();

            if (bike != null)
                return Ok(bike);
            else
                return NotFound();
        }
    }
}