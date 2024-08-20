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
        void AddRoutine(Routine routine);
        void UpdateRoutine(Routine routine);
        void DeleteRoutine(int id);


    }
}