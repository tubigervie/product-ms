using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //<-- passes these options to the base class
        {

        }

        public DbSet<Product> Products { get; set; } //once this is initially added, run "add-migration AddProductModelToDb" in order to create a migration class as per specified name
                                                     //once added, run "update-database" in order to execute the last migration file ^ which applies changes to the database
    }
}
