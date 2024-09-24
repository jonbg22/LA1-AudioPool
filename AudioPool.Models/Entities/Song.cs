using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioPool.Models.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public TimeSpan Duration { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
        public int AlbumId { get; set; }
        
        // Navigation properties
        public Album Album {get; set; } = null!;
    }
}