  
using BOOKSTORENEW.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace BOOKSTORENEW.Web.Data
{
    public class ApplicaionDbContext:DbContext
    {
        public ApplicaionDbContext(DbContextOptions<ApplicaionDbContext>options):base(options)

        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
