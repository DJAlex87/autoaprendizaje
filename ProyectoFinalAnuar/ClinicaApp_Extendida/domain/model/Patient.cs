using System;

namespace ClinicaApp.Domain.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Email { get; set; }

        public EmergencyContact? EmergencyContact { get; set; }
        public InsurancePolicy? Policy { get; set; }
    }
}
