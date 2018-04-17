using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models {
    public class UserContext : DbContext {
        public UserContext(DbContextOptions options) : base(options) { }
        public UserContext() { }

        public DbSet<ApplicationUser> Users { set; get; }
    }

    public class ApplicationUser {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}