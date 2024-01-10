
using Complaints.Api.Data;
using Complaints.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Complaints.Api.Repositories;

public class EntityFrameworkComplaintsRepository : IComplaintsRepository
{

    private readonly ComplaintsStoreContext dbContext;

    public EntityFrameworkComplaintsRepository(ComplaintsStoreContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Complaint>> GetAllAsync()
    {
        return await dbContext.Complaints.AsNoTracking().ToListAsync();
    }

    public async Task<Complaint?> GetAsync(int id)
    {
        return await dbContext.Complaints.FindAsync(id);
    }

    public async Task CreateAsync(Complaint complaint)
    {
        complaint.CreatedDate = DateTime.Now;
        await dbContext.Complaints.AddAsync(complaint);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Complaint updatedComplaint)
    {
        dbContext.Complaints.Update(updatedComplaint);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Complaints.Where(complaint => complaint.Id == id).ExecuteDeleteAsync();
    }
}