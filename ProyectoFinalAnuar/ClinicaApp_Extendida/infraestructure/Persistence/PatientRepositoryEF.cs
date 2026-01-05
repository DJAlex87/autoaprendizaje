using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class PatientRepositoryEF : IPatientRepository
    {
        private readonly ClinicDbContext _context;

        public PatientRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public void Add(Patient patient)
        {
            patient.PatientId = 0;
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void Delete(int patientId)
        {
            var existing = GetById(patientId);
            if (existing is null) return;
            _context.Patients.Remove(existing);
            _context.SaveChanges();
        }

        public Patient? GetById(int patientId)
            => _context.Patients.FirstOrDefault(p => p.PatientId == patientId);

        public Patient? GetByCedula(string cedula)
            => _context.Patients.FirstOrDefault(p => p.Cedula == cedula);

        public IEnumerable<Patient> GetAll()
            => _context.Patients.ToList();

        public int GetNextId()
        {
            if (!_context.Patients.Any()) return 1;
            return _context.Patients.Max(p => p.PatientId) + 1;
        }
    }
}
