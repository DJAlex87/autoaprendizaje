using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Application.Adapters.Input.Validators;

namespace ClinicaApp.Application.UseCases
{
    public class AdminUseCase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly PatientValidator _validator = new();

        public AdminUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public (bool IsValid, string Error) CreatePatient(Patient patient)
        {
            var validation = _validator.Validate(patient);
            if (!validation.IsValid) return validation;

            if (_patientRepository.GetByCedula(patient.Cedula) is not null)
                return (false, "Ya existe un paciente con esa cédula.");

            patient.PatientId = _patientRepository.GetNextId();
            _patientRepository.Add(patient);
            return (true, string.Empty);
        }

        public IEnumerable<Patient> GetAllPatients() => _patientRepository.GetAll();
    }
}
