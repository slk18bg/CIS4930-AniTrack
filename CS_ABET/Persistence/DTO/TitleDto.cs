using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AniTrack.Persistence.DTO
{
    public class TitleDto
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string TitleName { get; set; }

        public int Episodes { get; set; }

        public int YearReleased { get; set; }

        public double AverageRating { get; set; }
    }
}