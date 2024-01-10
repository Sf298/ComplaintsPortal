
using System.ComponentModel.DataAnnotations;

namespace Complaints.Api.Dtos;

public record ComplaintDto(
    int Id,
    int CreatedBy,
    DateTime? CreatedDate,
    string? ComplaintType,
    string Message,
    string Status
);

public record CreateComplaintDto(
    [Required]
    [RegularExpression("^(quality|shipping|billing)$", ErrorMessage = "The field must be one of 'quality', 'shipping' or 'billing'.")]
    string ComplaintType,
    
    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "This field must have between, 10 and 500 characters.")]
    string Message
);

public record UpdateComplaintDto(
    [Required]
    int CreatedBy,
    
    [Required]
    DateTime? CreatedDate,
    
    [Required]
    [RegularExpression("^(quality|shipping|billing)$", ErrorMessage = "The field must be one of 'quality', 'shipping' or 'billing'.")]
    string ComplaintType,
    
    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "This field must have between, 10 and 500 characters.")]
    string Message,
    
    [RegularExpression("^(resolved|pending|dismissed)$", ErrorMessage = "The field must be one of 'resolved', 'pending' or 'dismissed'.")]
    string Status
);
