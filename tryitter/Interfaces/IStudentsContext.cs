using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IStudentsContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public int SaveChanges();
    }
}
