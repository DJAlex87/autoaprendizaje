using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class NursingVisitRepositoryEF : INursingVisitRepository
    {
        private readonly ClinicDbContext _context;

        public NursingVisitRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        // Ahora trabajamos con la cédula del paciente,
        // tal como está en la tabla NurseVisit (CedulaPaciente)
        public IList<NursingVisit> GetByPatientCedula(string cedulaPaciente)
        {
            return _context.NursingVisits
                .Where(v => v.CedulaPaciente == cedulaPaciente)
                .OrderByDescending(v => v.FechaHora)
                .ToList();
        }

        public void Add(NursingVisit visit)
        {
            _context.NursingVisits.Add(visit);
            _context.SaveChanges();
        }
    }
}
