using System;
using System.ComponentModel.DataAnnotations;

namespace ArtistsEssentialsWebsite.Models
{
    public class Album
    {
        public long Id { get; set; }
        public long EssentialArtistId { get; set; }

        // Basic Information
        public string Title { get; set; }
        public string Genre { get; set; }
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Album Artwork")]
        public string CoverImage { get; set; }

        //  Commerical Success
        [Range(1, 200)]
        public int? BillboardPeakUS { get; set; }
        public int? WeeksOnChartUS { get; set; }
        public string Certification { get; set; }

        //  Critical Success
        [Range(0, 10)]
        public decimal? PitchforkRating { get; set; }

        [Range(0, 100)]
        public decimal? MetacriticRating { get; set; }

        [Range(0, 5)]
        public decimal? RollingStoneRating { get; set; }

        [Range(0, 5)]
        public decimal? RateYourMusicRating { get; set; }

        //  A bit of both
        [Display(Name = "Grammy Nominations")]
        public int? GrammyNominations { get; set; }
        [Display(Name = "Grammy Wins")]
        public int? GrammyWins { get; set; }
    }
}
