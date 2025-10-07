using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PP2Web.Models
{
    public class BinaryInputModel
    {
        [Required(ErrorMessage = "El valor a es requerido.")]
        [BinaryStringValidation]
        public string A { get; set; }

        [Required(ErrorMessage = "El valor b es requerido.")]
        [BinaryStringValidation]
        public string B { get; set; }

        // Los resultados (se pueden poblar desde el Controller)
        public BinaryResults Results { get; set; }
    }

    // Atributo de validación personalizado
    public class BinaryStringValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var s = value as string;
            if (string.IsNullOrEmpty(s))
                return new ValidationResult("La cadena no puede estar vacía.");

            // Solo 0 y 1
            if (!Regex.IsMatch(s, @"^[01]+$"))
                return new ValidationResult("La cadena solo puede contener 0 y 1.");

            // longitud <= 8
            if (s.Length > 8)
                return new ValidationResult("La longitud no puede exceder 8 caracteres.");

            // longitud > 0 ya chequeado por IsNullOrEmpty
            // longitud debe ser múltiplo de 2
            if (s.Length % 2 != 0)
                return new ValidationResult("La longitud debe ser múltiplo de 2 (2,4,6,8).");

            return ValidationResult.Success;
        }
    }
}
