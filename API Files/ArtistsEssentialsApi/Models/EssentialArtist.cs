using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistsEssentialsApi.Models
{
    public class EssentialArtist
    {
        //  Primary key
        public long Id { get; set; }

        //  Basic Information 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        public string Image { get; set; }

        //  Relational Model
        //  Lists albums of band or artist

        public ICollection<EssentialAlbum> EssentialAlbums { get; set; }
    }
}
