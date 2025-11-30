using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeFitBlazor.Data.Models;

public class PerformedExercise
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Sesja treningowa", Description = "Sesja, w której wykonano æwiczenie")]
    public int TrainingSessionId { get; set; }
    public TrainingSession? TrainingSession { get; set; }

    [Required]
    [Display(Name = "Typ æwiczenia", Description = "Nazwa rodzaju æwiczenia")]
    public int ExerciseTypeId { get; set; }
    public ExerciseType? ExerciseType { get; set; }

    [Range(0, 1000)]
    [Display(Name = "Obci¹¿enie [kg]", Description = "Zastosowany ciê¿ar w kilogramach")]
    public double Weight { get; set; }

    [Range(1, 100)]
    [Display(Name = "Serie", Description = "Liczba serii")]
    public int Sets { get; set; }

    [Range(1, 1000)]
    [Display(Name = "Powtórzeñ w serii", Description = "Liczba powtórzeñ w jednej serii")]
    public int Reps { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }
}
