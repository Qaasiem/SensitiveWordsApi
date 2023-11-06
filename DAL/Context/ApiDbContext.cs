using Microsoft.EntityFrameworkCore;
using SensitiveWordsApi.Entities;

namespace SensitiveWordsApi.Persistence.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
        }

        public DbSet<SensitiveWord> SensitiveWords{ get; set; }
    }
}
