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
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public IEnumerable<Exercise> GetAll() 
        {
            return _context.Exercises.Include(m => m.Machine).ToList();
        }
    }
}
