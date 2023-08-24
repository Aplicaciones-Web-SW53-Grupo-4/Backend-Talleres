using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomovileUnitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        // GET: api/Vehiculo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vehiculo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vehiculo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Vehiculo/5
        [HttpPut("{Id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return StatusCode(204); 

            }
            catch (Exception ex)
            {
             
                return StatusCode(500, "Se produjo un error interno en el servidor.");
            }
        }
    }
}
