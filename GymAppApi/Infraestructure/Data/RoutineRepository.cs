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
    }
}
