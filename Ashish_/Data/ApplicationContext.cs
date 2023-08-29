using Ashish_.Models.Account;
using Microsoft.EntityFrameworkCore;
using Ashish_.Models;

namespace Ashish_.Data
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ashish_.Models.Vehicle> Vehicles { get; set; } = default!;
    }
}
