using System.ComponentModel.DataAnnotations;

namespace BeFitBlazor.Data.Models;

public class ExerciseType
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Nazwa", Description = "Nazwa typu æwiczenia")]
    public string Name { get; set; } = string.Empty;
}
