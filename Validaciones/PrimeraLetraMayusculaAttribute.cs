using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace PeliculasApi.Validaciones
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()![0].ToString();

            if(primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser Mayúscula");
            }

             return ValidationResult.Success;
        }
    }
}
