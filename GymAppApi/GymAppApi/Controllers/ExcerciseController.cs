using Application.Models.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace GymAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExerciseDto>> GetAllExercises()
        {
            var exercises = _exerciseRepository.GetAllExercises();
            var exerciseDtos = exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                ImageUrl = e.ImageUrl,
                Category = e.Category.ToString(),
                Duration = e.Duration,
                Difficulty = e.Difficulty,
                Machine = e.Machine
            }).ToList();

            return Ok(exerciseDtos);
        }
    }
}
