using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Routine> Rutines { get; set; }
        public DbSet<SetExercise> SetExercises { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

    }
}
