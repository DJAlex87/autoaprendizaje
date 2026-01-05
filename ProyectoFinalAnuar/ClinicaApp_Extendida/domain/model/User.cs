using System;

namespace ClinicaApp.Domain.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public Role? Role { get; set; }
    }
}
