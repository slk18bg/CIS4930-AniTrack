using AniTrack.Persistence;
using AniTrack.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Data.Entity;
using WebGrease.Css.Extensions;



namespace AniTrack.Controllers.Enterprise
{
    public class GenreEC
    {
      
        public async Task<IEnumerable<GenreDto>> Get()
        {
            var results = new List<GenreDto>();
            using (var db = new AniContext())
            {
                try
                {
                    results = await db.Genres.Select(g => new GenreDto { Id = g.Id, Name = g.Name }).ToListAsync();
                }
                catch (Exception e)
                {

                }
            }
            return results;
        }

        public async Task<GenreDto> GetById(int id)
        {
        
            using (var db = new AniContext())
            {
                return await db.Genres.Where(g => g.Id == id)?.Take(1).Select(g => new GenreDto { Id = g.Id, Name = g.Name }).FirstOrDefaultAsync();
            }

        }


        public async Task<GenreDto> AddOrUpdate(GenreDto genreDto)
        {
            var newGenre = new Genre { Id = genreDto.Id, Name = genreDto.Name, LastModified = DateTime.Now };
            using (var db = new AniContext())
            {
                try
                {
                    db.Genres.AddOrUpdate(newGenre);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                }
            }
            return new GenreDto { Id = newGenre.Id, Name = newGenre.Name };
        }

    
        public async Task<GenreDto> RemoveById(int id)
        {
            using (var db = new AniContext())
            {
                var toRemove = db.Genres.FirstOrDefault(s => s.Id == id);
                db.Genres.Remove(toRemove);
                await db.SaveChangesAsync();

                return new GenreDto
                {
                    Id = toRemove.Id,
                    Name = toRemove.Name
                }; ;
            }
        }
    }
}