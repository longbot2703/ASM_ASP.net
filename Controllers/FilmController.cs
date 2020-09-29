using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFilm.Models;
using WebFilm.Services;

namespace WebFilm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        public FilmController(JsonFileFilmService filmService)
        {
            FilmService = filmService;
        }

        public JsonFileFilmService FilmService { get; }

        [HttpGet]


        public IEnumerable<Film> Get()
        {
            return FilmService.GetFilm();
        }

        [Route("Rate")]
        [HttpGet]

        public ActionResult Get(
            [FromQuery] string FilmId,
            [FromQuery] int Rating)
        {
            FilmService.AddRating(FilmId, Rating);
            return Ok();
        }
    }
}
