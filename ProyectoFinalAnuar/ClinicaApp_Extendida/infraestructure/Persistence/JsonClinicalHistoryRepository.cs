using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    /// <summary>
    /// Implementación simple usando un archivo JSON como "base de datos NoSQL".
    /// Estructura: lista de ClinicalHistoryDocument (uno por paciente).
    /// </summary>
    public class JsonClinicalHistoryRepository : IClinicalHistoryRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonClinicalHistoryRepository(string? filePath = null)
        {
            // Por defecto, en la carpeta de la app
            _filePath = filePath ?? Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "clinical_history.json");

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }

        public IReadOnlyList<ClinicalHistoryEntry> GetByPatient(string patientCedula)
        {
            var docs = LoadAllDocuments();
            var doc = docs.FirstOrDefault(d => d.PatientCedula == patientCedula);
            if (doc == null)
                return Array.Empty<ClinicalHistoryEntry>();

            return doc.Atenciones
                      .OrderBy(kv => kv.Key)
                      .Select(kv => kv.Value)
                      .ToList();
        }

        public ClinicalHistoryEntry? GetByPatientAndDate(string patientCedula, DateTime fecha)
        {
            var docs = LoadAllDocuments();
            var doc = docs.FirstOrDefault(d => d.PatientCedula == patientCedula);
            if (doc == null) return null;

            return doc.Atenciones.TryGetValue(fecha, out var entry)
                ? entry
                : null;
        }

        public void UpsertEntry(ClinicalHistoryEntry entry)
        {
            var docs = LoadAllDocuments();

            var doc = docs.FirstOrDefault(d => d.PatientCedula == entry.PatientCedula);
            if (doc == null)
            {
                doc = new ClinicalHistoryDocument
                {
                    PatientCedula = entry.PatientCedula
                };
                docs.Add(doc);
            }

            doc.Atenciones[entry.Fecha] = entry;

            SaveAllDocuments(docs);
        }

        // =========================
        //   Helpers privados
        // =========================
        private List<ClinicalHistoryDocument> LoadAllDocuments()
        {
            if (!File.Exists(_filePath))
                return new List<ClinicalHistoryDocument>();

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<ClinicalHistoryDocument>();

            var docs = JsonSerializer.Deserialize<List<ClinicalHistoryDocument>>(json, _jsonOptions);
            return docs ?? new List<ClinicalHistoryDocument>();
        }

        private void SaveAllDocuments(List<ClinicalHistoryDocument> docs)
        {
            var json = JsonSerializer.Serialize(docs, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }
    }
}
