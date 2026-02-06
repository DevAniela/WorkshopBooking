using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WorkshopBooking.Models;

public class Workshop
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Title required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title should be between 3 and 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description required")]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    public string Location { get; set; } = string.Empty;
}