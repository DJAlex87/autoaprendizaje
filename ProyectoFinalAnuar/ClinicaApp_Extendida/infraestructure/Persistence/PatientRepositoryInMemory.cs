using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class PatientRepositoryInMemory : IPatientRepository
    {
        public void Add(Patient patient)
        {
            InMemoryDatabase.Patients.Add(patient);
        }

        public void Update(Patient patient)
        {
            var existing = GetById(patient.PatientId);
            if (existing is null) return;

            existing.Cedula = patient.Cedula;
            existing.NombreCompleto = patient.NombreCompleto;
            existing.FechaNacimiento = patient.FechaNacimiento;
            existing.Genero = patient.Genero;
            existing.Direccion = patient.Direccion;
            existing.Telefono = patient.Telefono;
            existing.Email = patient.Email;
        }

        public void Delete(int patientId)
        {
            var existing = GetById(patientId);
            if (existing is null) return;
            InMemoryDatabase.Patients.Remove(existing);
        }

        public Patient? GetById(int patientId)
            => InMemoryDatabase.Patients.FirstOrDefault(p => p.PatientId == patientId);

        public Patient? GetByCedula(string cedula)
            => InMemoryDatabase.Patients.FirstOrDefault(p => p.Cedula == cedula);

        public IEnumerable<Patient> GetAll()
            => InMemoryDatabase.Patients;

        public int GetNextId()
            => InMemoryDatabase.Patients.Count == 0 ? 1 : InMemoryDatabase.Patients.Max(p => p.PatientId) + 1;
    }
}
