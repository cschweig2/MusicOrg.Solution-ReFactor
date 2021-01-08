using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MusicOrg.Models
{
    public class Artist
    {
        public Artist()
        {
            this.Vinyls = new HashSet<ArtistVinyl>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ArtistVinyl> Vinyls { get; set; }

    }
}