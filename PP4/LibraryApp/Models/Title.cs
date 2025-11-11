using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; } = string.Empty;

        // Relación con el autor
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        // Relación muchos a muchos con Tags
        public ICollection<TitleTag> TitlesTags { get; set; } = new List<TitleTag>();
    }
}
