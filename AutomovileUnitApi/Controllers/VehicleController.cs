using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private static List<Vehicle> _vehicles = new List<Vehicle>()
        {
            new Vehicle()
            {
                Id = 1, Band = "Nissan", Model = "Accent", Color = "Negro", Prize = 75000, Rental_Start_Date = "25/08/2023",
                Date_End_Rental = "12/09/2023"
            },
            new Vehicle()
            {
                Id = 2, Band = "Toyota", Model = "Corolla", Color = "Blanco", Prize = 80000,
                Rental_Start_Date = "25/07/2023", Date_End_Rental = "15/09/2023"
            },
            new Vehicle()
            {
                Id = 3, Band = "Volkswagen", Model = "Gol", Color = "Amarillo", Prize = 90000,
                Rental_Start_Date = "25/05/2023", Date_End_Rental = "29/09/2023"
            },
            new Vehicle()
            {
                Id = 4, Band = "BMW", Model = "i4", Color = "Azul", Prize = 70200, Rental_Start_Date = "23/08/2023",
                Date_End_Rental = "21/09/2023"
            },
            new Vehicle()
            {
                Id = 5, Band = "Jeep", Model = "Avenger", Color = "Verde", Prize = 74200, Rental_Start_Date = "18/08/2023",
                Date_End_Rental = "27/09/2023"
            }
        };

        private List<Vehicle?> vehicleList = new List<Vehicle?>();

        
        [HttpGet()]
        public List<Vehicle?> GetAllVehicles()
        {
            return vehicleList;
        }
        /*
        [HttpGet("{id}", Name = "GetVehicle")]
        public ActionResult<Vehicle> GetForDataBase(int id)
        {
            Vehicle vehicle = vehicles.Find(s => s.Id == id);
            if (vehicle == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 Not Found
            }
            return vehicle;
        }
        */
        
        [HttpGet("another/{id}", Name = "GetAnother")]
        public ActionResult<Vehicle> GetAnother(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound(); // Retorna una respuesta HTTP 404 Not Found si el vehículo no se encuentra
            }

            return Ok(vehicle); // Retorna una respuesta HTTP 200 OK con los datos del vehículo
        }
        
       
        [HttpGet("{id}", Name = "Get")]
        public Vehicle Get(int id)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Id = id;
            vehicle.Band = "Nissan";
            vehicle.Model = "Accent";
            vehicle.Color = "Negro";
            vehicle.Prize = 70000;
            vehicle.Rental_Start_Date = "25/08/2023";
            vehicle.Date_End_Rental = "25/09/2023";
            return vehicle;
        }

        [HttpPost]
        public StatusCodeResult Post([FromBody] Vehicle? vehicle)
        {
            if (vehicle.Band == "" || vehicle.Model == "" || vehicle.Color == "" || vehicle.Prize == 0|| vehicle.Rental_Start_Date==""|| vehicle.Date_End_Rental=="")
                return StatusCode(400);
            vehicleList.Add(vehicle);
            return StatusCode(201);
        }
        
        [HttpPut("{Id}")]
        public StatusCodeResult Put(int id, [FromBody] Vehicle? vehicle)
        {
            {
                if (vehicle == null || id != vehicle.Id)
                    return StatusCode(400);
                try
                {
                    return StatusCode(200); 
                }
                catch (Exception ex)
                {
                    return StatusCode(500); 
                }
            } 
        }
        [HttpDelete("{Id}")]
        public StatusCodeResult Delete(int id)
        {
            Vehicle? vehicle = vehicleList.FirstOrDefault(vehicleAux => vehicleAux != null && vehicleAux.Id == id);
            if (vehicle == null)
                return StatusCode(404);
            try
            {
                vehicleList.Remove(vehicle);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
