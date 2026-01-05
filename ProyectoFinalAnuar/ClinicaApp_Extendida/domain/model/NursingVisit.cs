using System;

namespace ClinicaApp.Domain.Model
{
    public class NursingVisit
    {
        // PK (mapea a NurseVisit.VisitId)
        public int VisitId { get; set; }

        // Cédula del paciente (NurseVisit.CedulaPaciente)
        public string CedulaPaciente { get; set; } = string.Empty;

        // Cédula de la enfermera (NurseVisit.CedulaEnfermera)
        public string CedulaEnfermera { get; set; } = string.Empty;

        // Fecha y hora de la visita (NurseVisit.FechaHora)
        public DateTime FechaHora { get; set; }

        // Signos vitales
        public string PresionArterial { get; set; } = string.Empty;   // NurseVisit.PresionArterial
        public decimal Temperatura { get; set; }                      // NurseVisit.Temperatura
        public int Pulso { get; set; }                                // NurseVisit.Pulso
        public int Oxigeno { get; set; }                              // NurseVisit.Oxigeno

        // Observaciones de la visita (NurseVisit.Observaciones)
        public string? Observaciones { get; set; }

        // Referencia opcional a orden médica (NurseVisit.OrderNumber / ItemNumber)
        public int? OrderNumber { get; set; }
        public int? ItemNumber { get; set; }
    }
}
