using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebFilm.Models;

namespace WebFilm.Services
{
    public class JsonFileFilmService
    {
        public JsonFileFilmService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "film.json"); }
        }

        public IEnumerable<Film> GetFilm()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Film[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(string filmId, int rating)
        {
            var film = GetFilm();
            if (film.First(x => x.Id == filmId).Ratings == null)
            {
                film.First(x => x.Id == filmId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = film.First(x => x.Id == filmId).Ratings.ToList();
                ratings.Add(rating);
                film.First(x => x.Id == filmId).Ratings = ratings.ToArray();
            }
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Film>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    film
                    );
            }
        }

    }
}
