namespace ClinicaApp.Domain.Model
{
    public class DiagnosticHelpCatalog
    {
        public int DiagnosticHelpId { get; set; }     // PK
        public string Nombre { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal CostoBase { get; set; }

        public bool RequiresSpecialist { get; set; }

        public int? SpecialtyId { get; set; }
        public SpecialtyCatalog? Specialty { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
