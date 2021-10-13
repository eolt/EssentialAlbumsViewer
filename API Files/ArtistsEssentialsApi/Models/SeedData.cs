using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArtistsEssentialsApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new EssentialsContext(
                serviceProvider.GetRequiredService<DbContextOptions<EssentialsContext>>()))
            {
                context.Database.Migrate();

                if (context.EssentialArtists.Any())
                {
                    return;
                }
                
                //  Used when testing "essentialArtists" api
                context.EssentialArtists.AddRange(
                    new EssentialArtist
                    {
                        Name = "Prince",
                        Genre = "Pop"
                    },
                    new EssentialArtist
                    {
                        Name = "Bjork",
                        Genre = "Pop"
                    },
                    new EssentialArtist
                    {
                        Name = "Kanye West",
                        Genre = "Hip Hop"
                    }
                    ) ;

                /*
                //  Used when testing "essentialAlbums" api. 
                //  These lines of code cannot run during or before "essential artists" api as the artist id won't exist. 
                 context.EssentialAlbums.AddRange(
                     new EssentialAlbum
                     {
                         EssentialArtistId = 1,
                         Title = "Purple Rain",
                         Genre = "Pop",
                         ReleaseYear = 1984,
                         CreatedBy = "Prince And The Revolution",
                         CoverImage = "https://is4-ssl.mzstatic.com/image/thumb/Music125/v4/1d/5f/63/1d5f63e5-03d9-b02b-0ff6-764793106578/source/600x600bb.jpg",
                         BillboardPeakUS = 1,
                         WeeksOnChartUS = 153,
                         Certification = "13x Multi-Platinum",
                         PitchforkRating = 10,
                         MetacriticRating = 100,
                         RollingStoneRating = 4,
                         RateYourMusicRating = (decimal?)4.08,
                         GrammyNominations = 2,
                         GrammyWins = 2
                     },
                     new EssentialAlbum
                     {
                         EssentialArtistId = 2,
                         Title = "Post",
                         Genre = "Art Pop",
                         ReleaseYear = 1995,
                         CreatedBy = "Bjork",
                         CoverImage = "https://is2-ssl.mzstatic.com/image/thumb/Music/v4/02/b4/60/02b460b4-2383-f263-815f-7b7951726433/source/600x600bb.jpg",
                         BillboardPeakUS = 32,
                         WeeksOnChartUS = 20,
                         Certification = "Platinum",
                         PitchforkRating = 10,
                         MetacriticRating = null,
                         RollingStoneRating = 4,
                         RateYourMusicRating = (decimal?)3.91,
                         GrammyNominations = 2,
                         GrammyWins = 0
                     },
                     new EssentialAlbum
                     {
                         EssentialArtistId = 3,
                         Title = "My Beautiful Dark Twisted Fantasy",
                         Genre = "Hip Hop",
                         ReleaseYear = 2010,
                         CreatedBy = "Kanye West",
                         CoverImage = "https://is4-ssl.mzstatic.com/image/thumb/Music124/v4/eb/25/91/eb259150-c049-18b5-bccf-373da842b63a/source/600x600bb.jpg",
                         BillboardPeakUS = 1,
                         WeeksOnChartUS = 151,
                         Certification = "3x Multi-Platinum",
                         PitchforkRating = 10,
                         MetacriticRating = 94,
                         RollingStoneRating = 5,
                         RateYourMusicRating = (decimal?)4.07,
                         GrammyNominations = 2,
                         GrammyWins = 3
                     }
                     );
                */
                context.SaveChanges();
            }
        }
    }
}
