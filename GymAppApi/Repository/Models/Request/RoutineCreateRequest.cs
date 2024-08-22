using Application.Models.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class RoutineCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<SetExcersiceCreateRequest> ExerciseList { get; set; }


        public static Routine ToEntity(RoutineCreateRequest routineDto)
        {
            Routine routine = new Routine();
            routine.Name = routineDto.Name;
            routine.Description = routineDto.Description;
            routine.SetExercises = routineDto.ExerciseList
                .Select(ex => SetExcersiceCreateRequest.ToEntity(ex))
                .ToList();

            return routine;

        }
    }
}
