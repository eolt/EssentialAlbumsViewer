using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace ArtistsEssentialsWebsite.Models
{
    public class Artist
    {
        public long Id { get; set; }
    
        public string Name { get; set; }

        public string Genre { get; set; }

        public string Image { get; set; }

        public List<Album> EssentialAlbums { get; set; }
    }
}
