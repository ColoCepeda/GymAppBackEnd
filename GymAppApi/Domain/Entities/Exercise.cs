using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Exercise
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public Category Category { get; set; }
        public int Duration { get; set; }
        public Machine? Machine { get; set; }
        public List<Rutine> RutineList { get; set;}

    }
}
