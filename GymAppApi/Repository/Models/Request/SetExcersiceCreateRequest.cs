using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class SetExcersiceCreateRequest
    {
        public int IdExercise { get; set; }
        public int Set { get; set; }

        public static SetExercise ToEntity(SetExcersiceCreateRequest setExerciseDto)
        {
            SetExercise setExercise = new SetExercise();
            setExercise.IdExercise = setExerciseDto.IdExercise;
            setExercise.Set = setExerciseDto.Set;

            return setExercise;

        }
    }
}
