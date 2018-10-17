using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiVitechd.Models;

namespace ApiVitechd.Controllers
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class ClientesController : Controller
    {
        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()

        {

            ApiContext context = HttpContext.RequestServices.GetService(typeof(ApiContext)) as ApiContext;

            IEnumerable<Cliente> clientes = context.AllClientes;

            return clientes;

        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Clientes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
