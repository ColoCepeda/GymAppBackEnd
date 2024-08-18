using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RoutineRepository : IRoutineRepository
    {
        private readonly DbContext _context;

        public RoutineRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Routine> GetAllRoutines()
        {
            return _context.Set<Routine>().Include(r => r.SetExercises).ToList();
        }

        public Routine GetRoutineById(int id)
        {
            return _context.Set<Routine>()
                           .Include(r => r.SetExercises)
                           .FirstOrDefault(r => r.Id == id);
        }

        public void AddRoutine(Routine routine)
        {
            _context.Set<Routine>().Add(routine);
            _context.SaveChanges();
        }

        public void UpdateRoutine(Routine routine)
        {
            _context.Set<Routine>().Update(routine);
            _context.SaveChanges();
        }

        public void DeleteRoutine(int id)
        {
            var routine = _context.Set<Routine>().Find(id);
            if (routine != null)
            {
                _context.Set<Routine>().Remove(routine);
                _context.SaveChanges();
            }
        }
    }
}
