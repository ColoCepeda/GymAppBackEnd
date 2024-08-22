using Application.Models.Dtos;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoutineService
    {
        IEnumerable<Routine> GetAllRoutines();
        Routine GetRoutineById(int id);
        public RoutineDto AddRoutine(RoutineCreateRequest routineDto);
        void UpdateRoutine(Routine routine);
        void DeleteRoutine(int id);


    }
}