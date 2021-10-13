using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistsEssentialsApi.Models
{
    public class EssentialAlbum
    {
        //  EF dynamically knows Primary and Foreign key
        //  thus an annotation is not necessary
        public long Id { get; set; }
        public long EssentialArtistId { get; set; }

        // Basic Information
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Album Artwork")]
        public string CoverImage { get; set; }

        //  Commerical Success
        public int? BillboardPeakUS { get; set; }
        public int? WeeksOnChartUS { get; set; }
        public string Certification { get; set; }

        //  Critical Success
        [Range(0, 10)]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal? PitchforkRating { get; set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? MetacriticRating { get; set; }

        [Range(0, 5)]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? RollingStoneRating { get; set; }

        [Range(0, 5)]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? RateYourMusicRating { get; set; }

        //  A bit of both
        public int? GrammyNominations { get; set; }
        public int? GrammyWins { get; set; }

        //  We make the number values optional as not all artists
        //  will be rated or recieve/get nominated for an award
    }
}
