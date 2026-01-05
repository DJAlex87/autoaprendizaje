using System;
using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class ClinicalHistoryUseCase
    {
        private readonly IClinicalHistoryRepository _repo;

        public ClinicalHistoryUseCase(IClinicalHistoryRepository repo)
        {
            _repo = repo;
        }

        public (bool Success, string Message) RegistrarAtencion(ClinicalHistoryEntry entry)
        {
            // =========================
            // REGLAS DE NEGOCIO
            // =========================

            // 1. Cuando se receta una ayuda diagnóstica
            //    NO puede haber medicamentos ni procedimientos
            if (entry.AyudasDiagnosticas.Count > 0 &&
               (entry.Medicamentos.Count > 0 || entry.Procedimientos.Count > 0))
            {
                return (false,
                    "Si se registra una ayuda diagnóstica, no pueden registrarse medicamentos ni procedimientos en la misma orden.");
            }

            // 2. Dentro de una misma orden no puede repetirse el mismo ítem
            //    aunque pertenezca a otro tipo (medicamento / procedimiento / ayuda)
            var itemsRepetidos = DetectarItemsDuplicados(entry);
            if (itemsRepetidos.Count > 0)
            {
                string lista = string.Join(", ", itemsRepetidos);
                return (false,
                    $"Hay ítems repetidos dentro de la misma orden (Item: {lista}). Cada ítem debe ser único.");
            }

            // 3. Validaciones básicas mínimas
            if (string.IsNullOrWhiteSpace(entry.PatientCedula))
                return (false, "La cédula del paciente es obligatoria.");

            if (string.IsNullOrWhiteSpace(entry.CedulaMedico))
                return (false, "La cédula del médico es obligatoria.");

            // Si todo está bien, se guarda
            _repo.UpsertEntry(entry);
            return (true, "Atención registrada correctamente.");
        }

        public IReadOnlyList<ClinicalHistoryEntry> ObtenerHistoriaPaciente(string cedulaPaciente)
            => _repo.GetByPatient(cedulaPaciente);

        // -------------------------
        // Helpers de validación
        // -------------------------
        private static List<int> DetectarItemsDuplicados(ClinicalHistoryEntry entry)
        {
            var items = new List<int>();

            items.AddRange(entry.Medicamentos.Select(m => m.Item));
            items.AddRange(entry.Procedimientos.Select(p => p.Item));
            items.AddRange(entry.AyudasDiagnosticas.Select(a => a.Item));

            return items
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
        }
    }
}
