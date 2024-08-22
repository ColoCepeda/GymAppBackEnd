using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IEnumerable<ExerciseDto> GetAllExercises()
        {
            var exercisesDtos = new List<ExerciseDto>();

            foreach (var exercise in _exerciseRepository.Get())
            {
                exercisesDtos.Add(ExerciseDto.ToDto(exercise));
            }
            return exercisesDtos;
        }
    }
}
