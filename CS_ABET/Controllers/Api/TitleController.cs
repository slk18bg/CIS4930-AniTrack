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
    [RoutePrefix("api/Title")]
    public class TitleController : ApiController
    {
        [HttpGet]
        [Route("Get/{genreId}")]
        public async Task<IHttpActionResult> GetById(int genreId)
        {
            return Ok( await new TitleEC().Get(genreId));
        }

        
        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdate([FromBody] TitleDto titleDto)
        {
            return Ok( await new TitleEC().AddOrUpdate(titleDto));
        }


        [HttpGet]
        [Route("Remove/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            return Ok( await new TitleEC().RemoveById(id));
        }
        
    }
}
