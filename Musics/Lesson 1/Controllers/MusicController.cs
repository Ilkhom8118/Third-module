using Microsoft.AspNetCore.Mvc;
using MusicCRUD.DataAccess.DataAccess.Entity;
using MusicCRUD.Service.DTOs;
using MusicCRUD.Service.Service;

namespace Lesson_1.Controllers
{
    [Route("api/music")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private IMusicService musicService;

        public MusicController()
        {
            musicService = new MusicService();
        }

        [HttpPost("Add music")]

        public Music AddMusic(MusicDto obj)
        {
            return musicService.AddMusic(obj);
        }


        [HttpGet("Get all music")]

        public List<MusicDto> GetAll()
        {
            return musicService.GetAll();
        }





    }
}
