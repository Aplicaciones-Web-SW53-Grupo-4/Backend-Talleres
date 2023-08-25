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
        private List<Vehicle?> vehicleList = new List<Vehicle?>();

        
        [HttpGet()]
        public List<Vehicle?> GetAllVehicles()
        {
            return vehicleList;
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
