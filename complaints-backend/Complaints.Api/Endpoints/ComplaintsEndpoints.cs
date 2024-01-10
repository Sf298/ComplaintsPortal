
using Complaints.Api.Dtos;
using Complaints.Api.Entities;
using Complaints.Api.Repositories;

namespace Complaints.Api.Endpoints;

public static class ComplaintsEndpoints {

    const string GetComplaintEndpointName = "GetComplaint";

    public static RouteGroupBuilder MapComplaintsEndpoints(this IEndpointRouteBuilder routes) {

        var group = routes.MapGroup("/api/complaints")
                          .WithParameterValidation();

        group.MapGet("/", async (IComplaintsRepository repository) => (await repository.GetAllAsync()).Select(complaint => complaint.AsDto()));

        group.MapGet("/{id}", async (IComplaintsRepository repository, int id) => {
            Complaint? compl = await repository.GetAsync(id);
            return compl is not null ? Results.Ok(compl.AsDto()) : Results.NotFound();
        })
        .WithName(GetComplaintEndpointName);

        group.MapPost("/", async (IComplaintsRepository repository, CreateComplaintDto complaintDto) => {
            Complaint complaint = new() {
                CreatedBy = 1, // TODO replace this with the calling user's actual id
                ComplaintType = complaintDto.ComplaintType,
                Message = complaintDto.Message,
                Status = "pending"
            };
            await repository.CreateAsync(complaint);
            return Results.CreatedAtRoute(GetComplaintEndpointName, new { id = complaint.Id }, complaint );
        });

        group.MapPut("/{id}", async (IComplaintsRepository repository, int id, UpdateComplaintDto updatedComplaintDto) => {
            Complaint? existingComplaint = await repository.GetAsync(id);
            if (existingComplaint is null) {
                return Results.NotFound();
            }
            existingComplaint.CreatedBy = updatedComplaintDto.CreatedBy;
            existingComplaint.CreatedDate = updatedComplaintDto.CreatedDate;
            existingComplaint.ComplaintType = updatedComplaintDto.ComplaintType;
            existingComplaint.Message = updatedComplaintDto.Message;
            existingComplaint.Status = updatedComplaintDto.Status;
            await repository.UpdateAsync(existingComplaint);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IComplaintsRepository repository, int id) => {
            await repository.DeleteAsync(id);
            return Results.NoContent();
        });

        return group;
    }
}