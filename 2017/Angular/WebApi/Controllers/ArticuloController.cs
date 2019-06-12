using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ArticuloController : ApiController
    {
        Contexto db = new Contexto();

        public HttpResponseMessage Get()
        {
            var articulos = db.Articulos;
            return Request.CreateResponse<IEnumerable<Articulo>>(HttpStatusCode.OK, articulos);
        }

    }
}
