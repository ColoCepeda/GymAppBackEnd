using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class SetExerciseDto
    {
        public int IdExercise { get; set; }
        public int Set { get; set; }

        public static SetExerciseDto ToDto(SetExercise setExercise)
        {
            SetExerciseDto dto = new SetExerciseDto();
            dto.IdExercise = setExercise.IdExercise;
            dto.Set = setExercise.Set;

            return dto;
        }
    }
}
