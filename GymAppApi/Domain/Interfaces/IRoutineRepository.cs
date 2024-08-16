using System.Collections.Generic;
using Domain.Entities;

namespace Repositories
{
    public interface IRoutineRepository
    {
        IEnumerable<Rutine> GetAllRoutines();
        Rutine GetRutineById(int id);
        void AddRutine(Rutine rutine);
        void UpdateRutine(Rutine rutine);
        void DeleteRutine(int id);
    }
}
