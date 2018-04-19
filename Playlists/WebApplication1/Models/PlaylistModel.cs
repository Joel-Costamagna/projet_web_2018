using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models {
    public class PlaylistContext:DbContext {
        public PlaylistContext(DbContextOptions options) : base(options) { }
        public PlaylistContext() { }

        public DbSet<ApplicationUser> Users { set; get; }
        public DbSet<PlaylistModel> Playlists { get; set; }
    }

    public class PlaylistModel {
        [Key]
        public string Id { get; set; }
        [Required]
        public ApplicationUser proprietaire { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        [Required]
        public bool isPublic { get; set; }
        public Musique[] contenu { get; set; }
        public double getDureeTotale() {
            double _duree = 0;
            foreach (var m in contenu) {
                _duree += m.duree;
            }
            return _duree;
        }
    }

    public class Musique {
        [Key]
        public string Id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public double duree { get; set; }
    }

    public class ApplicationUser {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}