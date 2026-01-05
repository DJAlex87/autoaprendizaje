namespace ClinicaApp.Domain.Model
{
    public class EmergencyContact
    {
        public int EmergencyContactId { get; set; }
        public int PatientId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Relacion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}
