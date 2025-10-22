using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVC.Models
{
    public class TheModel
    {
        //Chatgpt
        [Required(ErrorMessage = "La frase es obligatoria.")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "La frase debe tener entre 5 y 25 caracteres.")]
        public string Phrase { get; set; }

        
        public Dictionary<char, int> Counts { get; set; } = new();

        
        public string Lower { get; set; }

        
        public string Upper { get; set; }
    }
}

