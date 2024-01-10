using Complaints.Api.Entities;

namespace Complaints.Api.Repositories;

public interface IComplaintsRepository {

    Task<IEnumerable<Complaint>> GetAllAsync();

    Task<Complaint?> GetAsync(int id);

    Task CreateAsync(Complaint complaint);

    Task UpdateAsync(Complaint updatedComplaint);

    Task DeleteAsync(int id);

}
