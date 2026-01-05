using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(int patientId);
        Patient? GetById(int patientId);
        Patient? GetByCedula(string cedula);
        IEnumerable<Patient> GetAll();
        int GetNextId();
    }
}
