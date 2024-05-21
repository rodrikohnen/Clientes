using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Clientes.Models;
public class FechaNacimientoAttribute : ValidationAttribute
{
    private readonly DateTime _minDate;
    private readonly DateTime _maxDate;

    public FechaNacimientoAttribute()
    {
        _minDate = DateTime.Today.AddYears(-100);
        _maxDate = DateTime.Today;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {

        DateTime parseDate;

        var canParse = DateTime.TryParseExact((string)value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parseDate);

        if (canParse)
        {

            if (parseDate is DateTime date)
            {
                if (date < _minDate || date > _maxDate)
                {
                    return new ValidationResult($"La fecha de Nacimiento tiene que estar en el rango de hoy y hace 100 años");
                }
            }

            return ValidationResult.Success!;
        }
        return new ValidationResult($"La fecha de Nacimiento tiene que ser una fecha valida");

    }
}