using System.Data.Entity;

namespace AniTrack.Persistence
{
    public class AniContext : DbContext
    {
        public AniContext() : base("Server=.;Database=AniTrack_DB;Trusted_Connection=True;")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Title> Titles{ get; set; }


    }
}