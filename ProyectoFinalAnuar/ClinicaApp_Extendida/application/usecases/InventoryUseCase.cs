using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class InventoryUseCase
    {
        private readonly IMedicationCatalogRepository _medRepo;

        public InventoryUseCase(IMedicationCatalogRepository medRepo)
        {
            _medRepo = medRepo;
        }

        public IEnumerable<MedicationCatalog> GetAllMedications()
            => _medRepo.GetAll();

        public (bool IsValid, string Error) SaveMedication(MedicationCatalog med)
        {
            if (string.IsNullOrWhiteSpace(med.Nombre))
                return (false, "El nombre del medicamento es obligatorio.");

            if (med.CostoBase < 0)
                return (false, "El costo no puede ser negativo.");

            if (med.MedicationId == 0)
                _medRepo.Add(med);
            else
                _medRepo.Update(med);

            return (true, string.Empty);
        }

        public void DeleteMedication(int id)
        {
            _medRepo.Delete(id);
        }
    }
}
