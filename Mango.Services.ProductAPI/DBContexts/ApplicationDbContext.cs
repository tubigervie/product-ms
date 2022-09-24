using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //<-- passes these options to the base class
        {

        }
    }
}
