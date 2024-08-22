using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<ExerciseDto>> GetAllExercises()
        {
            return Ok(_exerciseService.GetAllExercises());
        }
    }
}
