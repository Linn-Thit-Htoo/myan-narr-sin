using Microsoft.EntityFrameworkCore;
using MyanNarrSinApi.Models;

namespace MyanNarrSinApi
{
    public class MyanNarrSinDbContext : DbContext
    {
        public MyanNarrSinDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<UserModel> Users { get; set; }
    }
}
