using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Complaints.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Complaints.Api.Data;

public static class DataExtensions
{
    // automatically apply migration
    public static async Task InitialiseDbAsync(this IServiceProvider serviceProvider) {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ComplaintsStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

    // register database repository
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) {
        var connString = configuration.GetConnectionString("ComplaintsStoreContext");
        services.AddSqlServer<ComplaintsStoreContext>(connString);
        services.AddScoped<IComplaintsRepository, EntityFrameworkComplaintsRepository>();

        return services;
    }
}