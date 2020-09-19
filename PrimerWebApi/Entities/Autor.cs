using PrimerWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerWebApi.Entities
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }
        [PrimeraLetraMayuscula]
        [Required]
        [StringLength(10, ErrorMessage = "El campo nombre debe tener un largo {1}")]
        public string Nombre { get; set; }
        [Range(18, 99)]
        public int Edad { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }

        [Url]
        public string Url { get; set; }
        public List<Libro> Libros { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(Nombre))
            {
                var firstLetter = Nombre.ToString()[0].ToString();

                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula", new string[] { nameof(Nombre) });
                }
            }
        }
    }
}
