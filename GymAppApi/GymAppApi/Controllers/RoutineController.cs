using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineService _routineService;

        public RoutineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        [HttpGet]
        public IActionResult GetAllRoutnes()
        {
            return Ok(_routineService.GetAllRoutines());
        }
        

        [HttpGet("{id}")]
        public IActionResult GetRoutineById(int id)
        {
            return Ok(_routineService.GetRoutineById(id));
        }

        [HttpPost]
        public IActionResult CreateRoutine([FromBody] RoutineCreateRequest routineRequest)
        {
           return Ok(_routineService.AddRoutine(routineRequest));
        }

        //[HttpPut("{id}")]
        //
        //
           //este endpoint hay que hacerlo cuando se haga toda la logica de update en el servicio.
        //

        [HttpDelete("{id}")]
        public IActionResult DeleteRoutine(int id)
        {
            var existingRoutine = _routineService.GetRoutineById(id);

            if (existingRoutine != null) {
                return NoContent(); 
            }
            return NotFound();
        }

    }
}
