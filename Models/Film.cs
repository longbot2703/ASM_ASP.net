using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebFilm.Models
{
    public class Film
    {
        public string Id { get; set; }

        public string Director { get; set; }

        [JsonPropertyName("img")] /*Khi muốn chuyển sang ánh xạ kiểu khác theo project của mình, chỉ về thư mục gốc */
        public string Image { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Film>(this);

    }
}
