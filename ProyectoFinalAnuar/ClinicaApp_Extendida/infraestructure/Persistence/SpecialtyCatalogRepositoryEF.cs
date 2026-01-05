using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class SpecialtyCatalogRepositoryEF : ISpecialtyCatalogRepository
    {
        private readonly ClinicDbContext _context;

        public SpecialtyCatalogRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SpecialtyCatalog> GetAll()
            => _context.SpecialtyCatalogs
                       .OrderBy(s => s.Nombre)
                       .ToList();

        public SpecialtyCatalog? GetById(int id)
            => _context.SpecialtyCatalogs.FirstOrDefault(s => s.SpecialtyId == id);

        public void Add(SpecialtyCatalog spec)
        {
            spec.SpecialtyId = 0;
            _context.SpecialtyCatalogs.Add(spec);
            _context.SaveChanges();
        }

        public void Update(SpecialtyCatalog spec)
        {
            _context.SpecialtyCatalogs.Update(spec);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null) return;

            _context.SpecialtyCatalogs.Remove(existing);
            _context.SaveChanges();
        }
    }
}
