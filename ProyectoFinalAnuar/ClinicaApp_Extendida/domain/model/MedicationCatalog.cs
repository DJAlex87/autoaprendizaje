namespace ClinicaApp.Domain.Model
{
    public class MedicationCatalog
    {
        public int MedicationId { get; set; }      // PK (IDENTITY)
        public string Nombre { get; set; } = string.Empty;
        public string? Description { get; set; }   // columna opcional
        public decimal CostoBase { get; set; }     // mapea a CostoBase
        public bool IsActive { get; set; } = true; // BIT en SQL
    }
}
