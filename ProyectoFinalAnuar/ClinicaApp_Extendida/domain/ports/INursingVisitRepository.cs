using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface INursingVisitRepository
    {
        // Obtiene visitas según la cédula del paciente (coincide con NurseVisit.CedulaPaciente)
        IList<NursingVisit> GetByPatientCedula(string cedulaPaciente);

        // Guarda una visita de enfermería
        void Add(NursingVisit visit);
    }
}
