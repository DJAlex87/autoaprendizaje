using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class MedicationCatalogRepositoryEF : IMedicationCatalogRepository
    {
        private readonly ClinicDbContext _context;

        public MedicationCatalogRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MedicationCatalog> GetAll()
            => _context.MedicationCatalogs
                       .OrderBy(m => m.Nombre)
                       .ToList();

        public MedicationCatalog? GetById(int id)
            => _context.MedicationCatalogs.FirstOrDefault(m => m.MedicationId == id);

        public void Add(MedicationCatalog med)
        {
            med.MedicationId = 0; // deja que SQL asigne el IDENTITY
            _context.MedicationCatalogs.Add(med);
            _context.SaveChanges();
        }

        public void Update(MedicationCatalog med)
        {
            _context.MedicationCatalogs.Update(med);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null) return;

            _context.MedicationCatalogs.Remove(existing);
            _context.SaveChanges();
        }
    }
}
