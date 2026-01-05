using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IMedicationCatalogRepository
    {
        IEnumerable<MedicationCatalog> GetAll();
        MedicationCatalog? GetById(int id);
        void Add(MedicationCatalog med);
        void Update(MedicationCatalog med);
        void Delete(int id);
    }
}
