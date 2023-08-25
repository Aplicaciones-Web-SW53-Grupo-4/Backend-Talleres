using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutomovileUnitApi.Model;

using Microsoft.AspNetCore.Mvc;

namespace AutomovileUnitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // GET: api/Vehiculo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vehiculo/5
        [HttpGet("{id}", Name = "Get")]
        public Vehicle Get(int id)
        {
            Vehicle vehiculo = new Vehicle();
            vehiculo.Id = id;
            vehiculo.Band = "Nissan";
            vehiculo.Model = "Accent";
            vehiculo.Color = "Negro";
            vehiculo.Prize = 70000;
            vehiculo.Rental_Start_Date = "25/08/2023";
            vehiculo.Date_End_Rental = "25/09/2023";
            return vehiculo;
        }

        // POST: api/Vehiculo
        [HttpPost]
        public StatusCodeResult Post([FromBody] Vehicle vehiculo)
        {
            if (vehiculo.Band == "" || vehiculo.Model == "" || vehiculo.Color == "" || vehiculo.Prize == 0|| vehiculo.Rental_Start_Date==""|| vehiculo.Date_End_Rental=="")
                return StatusCode(400);
            return StatusCode(201);
        }
        
        // PUT: api/Vehiculo/5
        [HttpPut("{Id}")]
        public StatusCodeResult Put(int id, [FromBody] string value)
        {
            {
                try
                {
                    return StatusCode(200); // 200 OK o 204 No Content
                }
                catch (Exception ex)
                {
                    return StatusCode(500); // 500 Internal Server Error
                }

            } 
        }
        [HttpDelete("{Id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
