using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; 
        public int Duration { get; set; }
        public Difficulty Difficulty { get; set; }
        public Machine? Machine { get; set; }
    }
}
