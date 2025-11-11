using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; } = string.Empty;

        // Relación muchos a muchos con Titles
        public ICollection<TitleTag> TitlesTags { get; set; } = new List<TitleTag>();
    }
}
