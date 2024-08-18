using System.Collections.Generic;
using Domain.Entities;

namespace Repositories
{
    public interface IRoutineRepository
    {
        IEnumerable<Routine> GetAllRoutines();
        Routine GetRoutineById(int id);
        void AddRoutine(Routine routine);
        void UpdateRoutine(Routine routine);
        void DeleteRoutine(int id);
    }
}
