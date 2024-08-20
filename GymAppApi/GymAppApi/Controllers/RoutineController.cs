using Application.Models.Dtos;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace GymAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IExerciseRepository _exerciseRepository;

        public RoutineController(IRoutineRepository routineRepository, IExerciseRepository exerciseRepository)
        {
            _routineRepository = routineRepository;
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoutineDto>> GetAllRoutines()
        {
            var routines = _routineRepository.GetAllRoutines();
            var routineDtos = routines.Select(r => new RoutineDto
            {
                Id = r.Id,
                Name = r.Name,
                Difficulty = r.Difficulty,
                Duration = r.Duration,
                SetExercises = (ICollection<SetExercise>)r.SetExercises.Select(se => new SetExercise
                {
                    Id = se.IdExercise,
                    Set = se.Set,
                })
            }).ToList();

            return Ok(routineDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RoutineDto> GetRoutineById(int id)
        {
            var routine = _routineRepository.GetRoutineById(id);

            if (routine == null)
                return NotFound();

            var routineDto = new RoutineDto
            {
                Id = routine.Id,
                Name = routine.Name,
                Difficulty = routine.Difficulty,
                Duration = routine.Duration,
                SetExercises = (ICollection<SetExercise>)routine.SetExercises.Select(se => new SetExercise
                {
                    Id = se.IdExercise,
                    Set = se.Set,
                }).ToList()
            };

            return Ok(routineDto);
        }

        [HttpPost]
        public ActionResult<RoutineDto> CreateRoutine([FromBody] RoutineSaveRequest routineRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var routine = new Routine
            {
                Name = routineRequest.Name,
                Description = routineRequest.Description,
                SetExercises = routineRequest.ExerciseList.Select(e => new SetExercise
                {
                    IdExercise = e.Id,
                    Set = e.Set
                }).ToList()
            };

            routine.Duration = CalculateTotalDuration(routine.SetExercises);
            routine.Difficulty = CalculateDifficulty(routine.SetExercises);

            _routineRepository.AddRoutine(routine);

            var routineDto = new RoutineDto
            {
                Id = routine.Id,
                Name = routine.Name,
                Difficulty = routine.Difficulty,
                Duration = routine.Duration,
                SetExercises = routine.SetExercises.Select(se => new SetExercise
                {
                    Id = se.IdExercise,
                    Set = se.Set,
                }).ToList()
            };

            return CreatedAtAction(nameof(GetRoutineById), new { id = routineDto.Id }, routineDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRoutine(int id, [FromBody] RoutineSaveRequest routineRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRoutine = _routineRepository.GetRoutineById(id);

            if (existingRoutine == null)
                return NotFound();

            existingRoutine.Name = routineRequest.Name;
            existingRoutine.Description = routineRequest.Description;
            existingRoutine.SetExercises = routineRequest.ExerciseList.Select(e => new SetExercise
            {
                IdExercise = e.Id,
                Set = e.Set
            }).ToList();

            existingRoutine.Duration = CalculateTotalDuration(existingRoutine.SetExercises);
            existingRoutine.Difficulty = CalculateDifficulty(existingRoutine.SetExercises);

            _routineRepository.UpdateRoutine(existingRoutine);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRoutine(int id)
        {
            var existingRoutine = _routineRepository.GetRoutineById(id);

            if (existingRoutine == null)
                return NotFound();

            _routineRepository.DeleteRoutine(id);

            return NoContent();
        }

        private int CalculateTotalDuration(IEnumerable<SetExercise> setExercises)
        {
            int totalDuration = 0;

            foreach (var setExercise in setExercises)
            {
                var exercise = _exerciseRepository.GetExerciseById(setExercise.IdExercise);
                if (exercise != null)
                {
                    totalDuration += exercise.Duration * setExercise.Set;
                }
            }

            return totalDuration;
        }

        private Difficulty CalculateDifficulty(IEnumerable<SetExercise> setExercises)
        {
            double totalDifficulty = 0;
            int totalSets = 0;

            foreach (var setExercise in setExercises)
            {
                var exercise = _exerciseRepository.GetExerciseById(setExercise.IdExercise);
                if (exercise != null)
                {
                    totalDifficulty += exercise.Difficulty * setExercise.Set;
                    totalSets += setExercise.Set;
                }
            }

            double averageDifficulty = totalSets > 0 ? totalDifficulty / totalSets : 0;
            int roundedDifficulty = (int)Math.Round(averageDifficulty);

            if (roundedDifficulty <= 3)
                return Difficulty.Easy;
            else if (roundedDifficulty <= 6)
                return Difficulty.Medium;
            else
                return Difficulty.Hard;
        }

    }
}
