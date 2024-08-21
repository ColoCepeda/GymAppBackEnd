using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _context.Set<Exercise>().ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            return _context.Set<Exercise>().FirstOrDefault(e => e.Id == id);
        }

        public void AddExercise(Exercise exercise)
        {
            _context.Set<Exercise>().Add(exercise);
            _context.SaveChanges();
        }

        public void UpdateExercise(Exercise exercise)
        {
            _context.Set<Exercise>().Update(exercise);
            _context.SaveChanges();
        }

        public void DeleteExercise(int id)
        {
            var exercise = _context.Set<Exercise>().Find(id);
            if (exercise != null)
            {
                _context.Set<Exercise>().Remove(exercise);
                _context.SaveChanges();
            }
        }
    }
}
