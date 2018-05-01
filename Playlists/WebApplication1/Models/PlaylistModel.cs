using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Playlist.Models {
    public class PlaylistContext : DbContext {
        public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options) { }
        public PlaylistContext() { }

        public DbSet<PlaylistModel> Playlists { get; set; }
    }

    public class PlaylistModel {
        [Key]
        public string Id { get; set; }

       
        public string ProprietaireName { get; set; }

        [Required]
        public string Nom { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public List<Musique> Musiques { get; set; }

        [MaxLength(10)]
        public List<Tags> Tags { get; set; }
    }

    public class Tags {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3), RegularExpression(@"^[a - zA - Z'-]+$")]
        public string Valeur;
    }

    public class Musique {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string Nom { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Duration)]
        public double Duree { get; set; }

        [Required, DataType(DataType.Url)]
        public string Url { get; set; }
    }

    public class SearchMusic
    {
        public string Keyword;
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