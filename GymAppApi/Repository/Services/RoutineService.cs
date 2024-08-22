using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IExerciseRepository _exerciseRepository;
        public RoutineService(IRoutineRepository routineRepository, IExerciseRepository exerciseRepository)
        {
            _routineRepository = routineRepository;
            _exerciseRepository = exerciseRepository;
        }

        public IEnumerable<Routine> GetAllRoutines()
        {
            return _routineRepository.GetAll();
        }

        public Routine? GetRoutineById(int id)
        {
            return _routineRepository.Get(id);
        }

        public void UpdateRoutine(Routine routine)
        {
            //Aca se tienen que realizar todas las modificaciones 
            _routineRepository.Update(routine);
        }

        public void DeleteRoutine(int id)
        {
            var routine = _routineRepository.Get(id);
            if (routine != null)
            {
                _routineRepository.Delete(routine);
            }
        }

        public RoutineDto AddRoutine(RoutineCreateRequest routineDto)
        {
            var routine = RoutineCreateRequest.ToEntity(routineDto);
            int totalDifficulty = 0;
            int exerciseCount = 0;
            foreach (var setExercise in routine.SetExercises)
            {
                setExercise.IdRoutine = routine.Id;

                var exercise = _exerciseRepository.Get(setExercise.IdExercise);
                routine.Duration += (exercise.Duration * setExercise.Set);

                totalDifficulty += (int)exercise.Difficulty;
                exerciseCount++;
            }
            if (exerciseCount > 0)
            {
                routine.Difficulty = (Difficulty)(totalDifficulty / exerciseCount);
            }

            _routineRepository.Create(routine);

            return RoutineDto.ToDto(routine);
        }
            
       }

    }
