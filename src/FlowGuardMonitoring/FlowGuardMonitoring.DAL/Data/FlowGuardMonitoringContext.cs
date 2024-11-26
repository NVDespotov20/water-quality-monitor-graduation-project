using Microsoft.EntityFrameworkCore;

namespace FlowGuardMonitoring.DAL.Data;

public class FlowGuardMonitoringContext : DbContext
{
    public FlowGuardMonitoringContext(DbContextOptions<FlowGuardMonitoringContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}