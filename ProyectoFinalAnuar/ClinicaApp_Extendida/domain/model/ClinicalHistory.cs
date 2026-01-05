using System;
using System.Collections.Generic;

namespace ClinicaApp.Domain.Model
{
    // Historial completo de un paciente (documento NoSQL)
    public class ClinicalHistoryDocument
    {
        // Cedula del paciente (clave principal del documento)
        public string PatientCedula { get; set; } = string.Empty;

        // Cada atención, clave = fecha exacta
        public Dictionary<DateTime, ClinicalHistoryEntry> Atenciones { get; set; }
            = new Dictionary<DateTime, ClinicalHistoryEntry>();
    }

    // Registro de una atención específica
    public class ClinicalHistoryEntry
    {
        public DateTime Fecha { get; set; }
        public string PatientCedula { get; set; } = string.Empty;
        public string CedulaMedico { get; set; } = string.Empty;

        public string MotivoConsulta { get; set; } = string.Empty;
        public string Sintomatologia { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;

        // Listas de órdenes
        public List<MedicationOrder> Medicamentos { get; set; } = new();
        public List<ProcedureOrder> Procedimientos { get; set; } = new();
        public List<DiagnosticHelpOrder> AyudasDiagnosticas { get; set; } = new();
    }

    public class MedicationOrder
    {
        public string NumeroOrden { get; set; } = string.Empty;  // máx 6 dígitos
        public int MedicationId { get; set; }
        public string Dosis { get; set; } = string.Empty;
        public string Duracion { get; set; } = string.Empty;
        public int Item { get; set; }
    }

    public class ProcedureOrder
    {
        public string NumeroOrden { get; set; } = string.Empty;
        public int ProcedureId { get; set; }
        public int Cantidad { get; set; }
        public string Frecuencia { get; set; } = string.Empty;
        public bool RequiresSpecialist { get; set; }
        public int? SpecialtyId { get; set; }
        public int Item { get; set; }
    }

    public class DiagnosticHelpOrder
    {
        public string NumeroOrden { get; set; } = string.Empty;
        public int DiagnosticHelpId { get; set; }
        public int Cantidad { get; set; }
        public bool RequiresSpecialist { get; set; }
        public int? SpecialtyId { get; set; }
        public int Item { get; set; }
    }
}
