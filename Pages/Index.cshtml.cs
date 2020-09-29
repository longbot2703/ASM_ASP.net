using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebFilm.Models;
using WebFilm.Services;

namespace WebFilm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileFilmService filmService)
        {
            _logger = logger;
            FilmService = filmService;
        }

        public JsonFileFilmService FilmService { get; }

        public IEnumerable<Film> Film { get; private set; }  

        public void OnGet()
        {
            Film = FilmService.GetFilm();
        }
    }
}
