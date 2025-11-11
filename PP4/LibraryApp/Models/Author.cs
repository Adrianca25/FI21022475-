using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;

        // Relación 1 a muchos con Titles
        public ICollection<Title> Titles { get; set; } = new List<Title>();
    }
}
