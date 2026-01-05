using System;
using System.Text.RegularExpressions;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Application.Adapters.Input.Validators
{
    public class UserValidator
    {
        public (bool IsValid, string Error) Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.NombreCompleto))
                return (false, "El nombre es obligatorio.");

            if (!Regex.IsMatch(user.Cedula, @"^\d{1,10}$"))
                return (false, "La cédula debe contener entre 1 y 10 dígitos.");

            if (!Regex.IsMatch(user.Telefono, @"^\d{1,10}$"))
                return (false, "El teléfono debe contener entre 1 y 10 dígitos.");

            if (!Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "El correo electrónico no es válido.");

            if ((DateTime.Now.Year - user.FechaNacimiento.Year) > 150)
                return (false, "La edad no puede ser mayor a 150 años.");

            if (user.Direccion.Length > 30)
                return (false, "La dirección no puede superar 30 caracteres.");

            if (!Regex.IsMatch(user.Username, "^[a-zA-Z0-9]{1,15}$"))
                return (false, "El nombre de usuario debe ser alfanumérico y máximo de 15 caracteres.");

            if (!IsValidPassword(user.PasswordHash))
                return (false, "La contraseña debe tener al menos 8 caracteres, una mayúscula, un número y un caracter especial.");

            return (true, string.Empty);
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false;
            if (!Regex.IsMatch(password, "[A-Z]")) return false;
            if (!Regex.IsMatch(password, "[0-9]")) return false;
            if (!Regex.IsMatch(password, "[^a-zA-Z0-9]")) return false;
            return true;
        }
    }
}
