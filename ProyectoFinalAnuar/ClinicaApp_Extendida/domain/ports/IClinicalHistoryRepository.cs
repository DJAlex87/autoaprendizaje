using System;
using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IClinicalHistoryRepository
    {
        // Obtiene TODAS las atenciones de un paciente
        IReadOnlyList<ClinicalHistoryEntry> GetByPatient(string patientCedula);

        // Obtiene una atención puntual
        ClinicalHistoryEntry? GetByPatientAndDate(string patientCedula, DateTime fecha);

        // Inserta o actualiza una atención (si ya existe esa fecha, se sobreescribe)
        void UpsertEntry(ClinicalHistoryEntry entry);
    }
}
