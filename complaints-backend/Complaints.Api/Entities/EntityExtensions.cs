
using Complaints.Api.Dtos;

namespace Complaints.Api.Entities;

public static class EntityExtensions
{
    public static ComplaintDto AsDto(this Complaint complaint) {
        return new ComplaintDto(
            complaint.Id,
            complaint.CreatedBy,
            complaint.CreatedDate,
            complaint.ComplaintType,
            complaint.Message,
            complaint.Status
        );
    }
}