
using System.ComponentModel.DataAnnotations;

namespace Complaints.Api.Entities;

public class Complaint
{
    public int Id { get; set; }

    [Required]
    public int CreatedBy { get; set; }

    [Required]
    public DateTime? CreatedDate { get; set; }

    [Required]
    [RegularExpression("^(quality|shipping|billing)$", ErrorMessage = "The field must be one of 'quality', 'shipping' or 'billing'.")]
    public required string ComplaintType { get; set; }
    
    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "This field must have between, 10 and 500 characters.")]
    public required string  Message { get; set; }

    [Required]
    [RegularExpression("^(resolved|pending|dismissed)$", ErrorMessage = "The field must be one of 'resolved', 'pending' or 'dismissed'.")]
    public required string Status  { get; set; }
}