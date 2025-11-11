using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    // Entidad intermedia para la relación muchos a muchos entre Titles y Tags
    public class TitleTag
    {
        public int TitleId { get; set; }
        public Title? Title { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
