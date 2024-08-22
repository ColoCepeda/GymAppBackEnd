using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class RoutineRepository : BaseRepository<Routine>, IRoutineRepository
    {
        private readonly ApplicationDbContext _context;

        public RoutineRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Routine> GetAll()
        {
            return _context.Routines.Include(e => e.SetExercises).ToList();
        }
        public new Routine? Get<Tid>(Tid id)
        {
            return _context.Routines
                           .Include(r => r.SetExercises)  // Incluye la relación aquí
                           .FirstOrDefault(r => r.Id.Equals(id));  // Utiliza FirstOrDefault en lugar de Find
        }
    }
}
