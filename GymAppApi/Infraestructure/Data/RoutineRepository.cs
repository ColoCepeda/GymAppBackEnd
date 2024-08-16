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

        public IEnumerable<Rutine> GetAllRoutines()
        {
            return _context.Set<Rutine>().ToList();
        }

        public Rutine GetRutineById(int id)
        {
            return _context.Set<Rutine>().Find(id);
        }

        public void AddRutine(Rutine rutine)
        {
            _context.Set<Rutine>().Add(rutine);
            _context.SaveChanges();
        }

        public void UpdateRutine(Rutine rutine)
        {
            _context.Set<Rutine>().Update(rutine);
            _context.SaveChanges();
        }

        public void DeleteRutine(int id)
        {
            var rutine = _context.Set<Rutine>().Find(id);
            if (rutine != null)
            {
                _context.Set<Rutine>().Remove(rutine);
                _context.SaveChanges();
            }
        }
    }
}
