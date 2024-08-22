using System;
using System.Collections.Generic;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enums;

namespace Application.Models.Dtos
{
    public class RoutineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Difficulty Difficulty { get; set; }
        public int Duration { get; set; }
        public ICollection<SetExerciseDto> SetExercises { get; set; } 

        public static RoutineDto ToDto(Routine routine)
        {
            RoutineDto routineDto = new();
            routineDto.Id = routine.Id;
            routineDto.Name = routine.Name;
            routineDto.Difficulty = routine.Difficulty;
            routineDto.Duration = routine.Duration;
            routineDto.SetExercises = routine.SetExercises
                .Select(ex => SetExerciseDto.ToDto(ex))
                .ToList();

            return routineDto;

        }
    }
}