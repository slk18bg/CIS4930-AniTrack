using AniTrack.Persistence;
using AniTrack.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;

namespace AniTrack.Controllers.Enterprise
{
    public class TitleEC
    {
     
        // implementations updated to store and pull data from the database rather than pseudo-database class
        public async Task<IEnumerable<TitleDto>> Get(int Id)
        {
            var results = new List<TitleDto>();
            using (var db = new AniContext())
            {
                try
                {
                    results = await db.Titles.Where(t => t.GenreId == Id)
                        .Select(t =>
                    new TitleDto
                    {
                        Id = t.Id,
                        GenreId = t.GenreId,
                        TitleName = t.TitleName,
                        YearReleased = t.YearReleased,
                        Episodes = t.Episodes,
                        AverageRating = t.AverageRating
                    }).ToListAsync();
                }
                catch (Exception e)
                {

                }
            }

            return results;
        }

 
        public async Task<TitleDto> AddOrUpdate(TitleDto titleDto)
        {
            var newTitle = new Title
            {
                Id = titleDto.Id,
                GenreId = titleDto.GenreId,
                TitleName = titleDto.TitleName,
                Episodes = titleDto.Episodes,
                YearReleased = titleDto.YearReleased,
                AverageRating = titleDto.AverageRating
            };

            using (var db = new AniContext())
            {
                try
                {
                    db.Titles.AddOrUpdate(newTitle);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                { }
            }

            return new TitleDto
            {
                Id = newTitle.Id,
                GenreId = newTitle.GenreId,
                TitleName = newTitle.TitleName,
                Episodes = newTitle.Episodes,
                YearReleased = newTitle.YearReleased,
                AverageRating = newTitle.AverageRating
            };
        }


        public async Task<TitleDto> RemoveById(int id)
        {
            using (var db = new AniContext())
            {
                var toRemove = db.Titles.FirstOrDefault(t => t.Id == id);
                db.Titles.Remove(toRemove);
                await db.SaveChangesAsync();

                return new TitleDto
                {
                    Id = toRemove.Id,
                    GenreId = toRemove.GenreId,
                    TitleName = toRemove.TitleName,
                    Episodes = toRemove.Episodes,
                    YearReleased = toRemove.YearReleased,
                    AverageRating = toRemove.AverageRating
                }; ;
            }
        }
    }
}