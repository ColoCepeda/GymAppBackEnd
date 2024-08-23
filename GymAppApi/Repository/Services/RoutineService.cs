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
            var existingRoutine = _routineRepository.Get(routine.Id);
            if (existingRoutine == null)
            {
                throw new Exception("Routine not found.");
            }

            // Validación: Evitar rutinas vacías
            if (routine.SetExercises == null || !routine.SetExercises.Any())
            {
                throw new ArgumentException("La rutina no puede estar vacía. Debe contener al menos un ejercicio.");
            }

            // Validación: Evitar ejercicios duplicados
            var duplicatedExercises = routine.SetExercises
                                             .GroupBy(e => e.IdExercise)
                                             .Where(g => g.Count() > 1)
                                             .Select(g => g.Key)
                                             .ToList();

            if (duplicatedExercises.Any())
            {
                throw new ArgumentException("La rutina contiene ejercicios duplicados. Cada ejercicio debe ser único.");
            }

            existingRoutine.Name = routine.Name;
            existingRoutine.Description = routine.Description;

            existingRoutine.Duration = 0;
            int totalDifficulty = 0;
            int exerciseCount = 0;

            existingRoutine.SetExercises.Clear();

            foreach (var setExerciseDto in routine.SetExercises)
            {
                var exercise = _exerciseRepository.Get(setExerciseDto.IdExercise);
                if (exercise == null)
                {
                    throw new Exception($"Exercise with ID {setExerciseDto.IdExercise} not found.");
                }

                var setExercise = new SetExercise
                {
                    IdRoutine = existingRoutine.Id,
                    IdExercise = setExerciseDto.IdExercise,
                    Set = setExerciseDto.Set
                };

                existingRoutine.SetExercises.Add(setExercise);

                existingRoutine.Duration += (exercise.Duration * setExercise.Set);

                totalDifficulty += (int)exercise.Difficulty;
                exerciseCount++;
            }

            if (exerciseCount > 0)
            {
                existingRoutine.Difficulty = (Difficulty)(totalDifficulty / exerciseCount);
            }

            _routineRepository.Update(existingRoutine);
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

            // Validación: Evitar rutinas vacías
            if (routine.SetExercises == null || !routine.SetExercises.Any())
            {
                throw new ArgumentException("La rutina no puede estar vacía. Debe contener al menos un ejercicio.");
            }

            // Validación: Evitar ejercicios duplicados
            var duplicatedExercises = routine.SetExercises
                                             .GroupBy(e => e.IdExercise)
                                             .Where(g => g.Count() > 1)
                                             .Select(g => g.Key)
                                             .ToList();

            if (duplicatedExercises.Any())
            {
                throw new ArgumentException("La rutina contiene ejercicios duplicados. Cada ejercicio debe ser único.");
            }

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
