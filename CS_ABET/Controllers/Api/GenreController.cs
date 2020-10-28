using AniTrack.Controllers.Enterprise;
using AniTrack.Persistence;
using AniTrack.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AniTrack.Controllers.Api
{
    [RoutePrefix("api/Genre")]
    public class GenreController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await new GenreEC().Get());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Ok(await new GenreEC().GetById(id));
        }

        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdate([FromBody] GenreDto genreDto)
        {
            return Ok( await new GenreEC().AddOrUpdate(genreDto));
        }

        [HttpGet]
        [Route("RemoveById/{id}")]
        public async Task<IHttpActionResult> RemoveById(int id)
        {
            return Ok(await new GenreEC().RemoveById(id));
        }

    }
}