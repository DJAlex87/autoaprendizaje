using System;
using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class NursingUseCase
    {
        private readonly INursingVisitRepository _visitRepo;
        private readonly IPatientRepository _patientRepo;
        private readonly IUserRepository _userRepo;

        private const int ROLE_ENFERMERA = 4;

        public NursingUseCase(
            INursingVisitRepository visitRepo,
            IPatientRepository patientRepo,
            IUserRepository userRepo)
        {
            _visitRepo = visitRepo;
            _patientRepo = patientRepo;
            _userRepo = userRepo;
        }

        public (bool Success, string Message, Patient? Patient, IList<NursingVisit> Visits)
            BuscarPacienteYVisitas(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                return (false, "Debes ingresar la cédula del paciente.", null, new List<NursingVisit>());

            var patient = _patientRepo.GetByCedula(cedula);
            if (patient == null)
                return (false, "No se encontró un paciente con esa cédula.", null, new List<NursingVisit>());

            var visits = _visitRepo.GetByPatientCedula(cedula);

            return (true, string.Empty, patient, visits);
        }

        public (bool Success, string Message) RegistrarVisita(
            int patientId,
            int nurseUserId,
            DateTime fechaHora,
            string presionArterial,
            decimal temperatura,
            int pulso,
            int oxigeno,
            string? reason,
            string? notes)
        {
            if (patientId <= 0)
                return (false, "Debes seleccionar un paciente válido.");

            var patient = _patientRepo.GetById(patientId);
            if (patient == null)
                return (false, "No se encontró el paciente en la base de datos.");

            var nurse = _userRepo.GetById(nurseUserId);
            if (nurse == null || nurse.RoleId != ROLE_ENFERMERA)
                return (false, "El usuario actual no tiene rol de enfermería.");

            if (fechaHora == default)
                fechaHora = DateTime.Now;

            if (string.IsNullOrWhiteSpace(presionArterial))
                return (false, "Debes ingresar la presión arterial.");

            if (temperatura <= 0)
                return (false, "Debes ingresar una temperatura mayor a 0.");

            if (pulso <= 0)
                return (false, "Debes ingresar un valor de pulso mayor a 0.");

            if (oxigeno <= 0 || oxigeno > 100)
                return (false, "El oxígeno debe estar entre 1 y 100.");

            // Unificamos reason + notes en Observaciones
            string? observaciones = null;
            var reasonTrimmed = string.IsNullOrWhiteSpace(reason) ? null : reason.Trim();
            var notesTrimmed = string.IsNullOrWhiteSpace(notes) ? null : notes.Trim();

            if (!string.IsNullOrEmpty(reasonTrimmed) && !string.IsNullOrEmpty(notesTrimmed))
                observaciones = $"{reasonTrimmed} - {notesTrimmed}";
            else if (!string.IsNullOrEmpty(reasonTrimmed))
                observaciones = reasonTrimmed;
            else if (!string.IsNullOrEmpty(notesTrimmed))
                observaciones = notesTrimmed;

            var visit = new NursingVisit
            {
                CedulaPaciente = patient.Cedula,
                CedulaEnfermera = nurse.Cedula,
                FechaHora = fechaHora,
                PresionArterial = presionArterial,
                Temperatura = temperatura,
                Pulso = pulso,
                Oxigeno = oxigeno,
                Observaciones = observaciones,
                OrderNumber = null,
                ItemNumber = null
            };

            _visitRepo.Add(visit);
            return (true, "Visita de enfermería registrada correctamente.");
        }
    }
}
