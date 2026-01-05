namespace ClinicaApp.Domain.Model
{
    public class ProcedureCatalog
    {
        public int ProcedureId { get; set; }          // PK
        public string Nombre { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal CostoBase { get; set; }

        // Algunos procedimientos requieren especialista
        public bool RequiresSpecialist { get; set; }

        // Tipo de especialidad (FK a SpecialtyCatalog, opcional)
        public int? SpecialtyId { get; set; }
        public SpecialtyCatalog? Specialty { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
