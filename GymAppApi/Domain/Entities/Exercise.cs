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
        [Key] //atributo de identificación de todos los registros
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ID numerico
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

    }
}
