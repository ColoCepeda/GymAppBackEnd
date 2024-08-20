using Application.Interfaces;
using Domain.Entities;
using Repositories;
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
        public RoutineService(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }

        public IEnumerable<Routine> GetAllRoutines()
        {
            return _routineRepository.GetAllRoutines();
        }

        public Routine? GetRoutineById(int id)
        {
            return _routineRepository.GetRoutineById(id);
        }

        public void UpdateRoutine(Routine routine)
        {
            _routineRepository.UpdateRoutine(routine);
        }

        public void DeleteRoutine(int id)
        {
            _routineRepository.DeleteRoutine(id);
        }

        public void AddRoutine(Routine routine)
        {
            _routineRepository.AddRoutine(routine);
        }

    }
}