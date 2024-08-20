using Domain.Entities;

namespace Repositories
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetAllExercises();
        Exercise GetExerciseById(int id);
        void AddExercise(Exercise exercise);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(int id);
    }
}
