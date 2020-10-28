using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AniTrack.Persistence
{
    [Table("Title")]
    public class Title
    {
        [Key]
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string TitleName { get; set; }

        public int Episodes { get; set; }

        public int YearReleased { get; set; }

        public double AverageRating { get; set; }
    }
}