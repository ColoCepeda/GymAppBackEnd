using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SetExercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Routine")]
        public int IdRoutine { get; set; }
        public Routine Routine { get; set; } // Relación con la entidad Routine

        [ForeignKey("Exercise")]
        public int IdExercise { get; set; }
        public Exercise Exercise { get; set; } // Relación con la entidad Exercise

        public int Series { get; set; } // Número de series

        
    }
}
