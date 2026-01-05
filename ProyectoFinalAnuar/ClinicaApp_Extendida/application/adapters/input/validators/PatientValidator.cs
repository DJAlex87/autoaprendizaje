using System;
using System.Text.RegularExpressions;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Application.Adapters.Input.Validators
{
    public class PatientValidator
    {
        public (bool IsValid, string Error) Validate(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.NombreCompleto))
                return (false, "El nombre completo es obligatorio.");

            if (!Regex.IsMatch(patient.Cedula, @"^\d{1,10}$"))
                return (false, "La cédula debe contener entre 1 y 10 dígitos.");

            if (!Regex.IsMatch(patient.Telefono, @"^\d{10}$"))
                return (false, "El teléfono del paciente debe contener 10 dígitos.");

            if (patient.Email is not null && patient.Email.Length > 0)
            {
                if (!Regex.IsMatch(patient.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    return (false, "El correo electrónico del paciente no es válido.");
            }

            if ((DateTime.Now.Year - patient.FechaNacimiento.Year) > 150)
                return (false, "La edad del paciente no puede ser mayor a 150 años.");

            return (true, string.Empty);
        }
    }
}
