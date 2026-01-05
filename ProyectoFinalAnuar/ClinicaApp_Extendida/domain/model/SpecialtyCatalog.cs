namespace ClinicaApp.Domain.Model
{
    public class SpecialtyCatalog
    {
        public int SpecialtyId { get; set; }          // PK
        public string Nombre { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
