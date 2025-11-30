namespace BeFitBlazor.DTOs;

public class PerformedExerciseCreateDto
{
    public int TrainingSessionId { get; set; }
    public int ExerciseTypeId { get; set; }
    public double Weight { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}
