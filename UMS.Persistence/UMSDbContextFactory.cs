using Microsoft.EntityFrameworkCore;
namespace UMS.Persistence
{
    public class PcpDbContextFactory 
        : DesignTimeDbContextFactoryBase<UmsContext>
    {
        protected override UmsContext CreateNewInstance(DbContextOptions<UmsContext> options)
        {
            return new UmsContext(options);
        }
    }
}