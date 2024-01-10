using Complaints.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Complaints.Api.Data;

// create the context for the mssql server
public class ComplaintsStoreContext : DbContext
{
    public ComplaintsStoreContext(DbContextOptions<ComplaintsStoreContext> options) : base(options) {

    }

    public DbSet<Complaint> Complaints => Set<Complaint>();
    
}