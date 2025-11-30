using System.ComponentModel.DataAnnotations;

namespace BeFitBlazor.Data.Models;

public class TrainingSession
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Rozpoczêcie", Description = "Data i godzina rozpoczêcia treningu")]
    public DateTime StartAt { get; set; }

    [Required]
    [Display(Name = "Zakoñczenie", Description = "Data i godzina zakoñczenia treningu")]
    public DateTime EndAt { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }
}
