using System;
using Domain.Enums;
using Domain.Entities;

namespace Application.Models.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string? ImageUrl { get; set; } 
        public Category Category { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public Machine? Machine { get; set; }

        public static ExerciseDto ToDto(Exercise exercise)
        {
            ExerciseDto exerciseDto = new();
            exerciseDto.Id = exercise.Id;
            exerciseDto.Name = exercise.Name;
            exerciseDto.Duration = exercise.Duration;
            exerciseDto.Description = exercise.Description;
            exerciseDto.ImageUrl = exercise.ImageUrl;
            exerciseDto.Category = exercise.Category;
            exerciseDto.Difficulty = exercise.Difficulty;
            exerciseDto.Machine = exercise.Machine;

            return exerciseDto;

        }
    }
}
