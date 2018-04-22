using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Playlist.Models {
    public class PlaylistContext : DbContext {
        public PlaylistContext(DbContextOptions options) : base(options) { }
        public PlaylistContext() { }

        public DbSet<ApplicationUser> Users { set; get; }

        public DbSet<PlaylistModel> Playlists { get; set; }
    }

    public class PlaylistModel {
        [Key]
        public string Id { get; set; }

        [Required]
        public string proprietaire_name { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string nom { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [Required]
        public bool isPublic { get; set; }

        [MinLength(1)]
        public Musique[] contenu { get; set; }

        [MaxLength(10)]
        public Tags[] tags { get; set; }
    }

    public class Tags {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3), RegularExpression(@"^[a - zA - Z'-]+$")]
        public string valeur;
    }

    public class Musique {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string nom { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [DataType(DataType.Duration)]
        public double duree { get; set; }

        [Required, DataType(DataType.Url)]
        public string URL { get; set; }
    }

    public class ApplicationUser {

        [Key]
        public string Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}