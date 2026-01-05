using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class ProcedureCatalogRepositoryEF : IProcedureCatalogRepository
    {
        private readonly ClinicDbContext _context;

        public ProcedureCatalogRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProcedureCatalog> GetAll()
            => _context.ProcedureCatalogs
                       .OrderBy(p => p.Nombre)
                       .ToList();

        public ProcedureCatalog? GetById(int id)
            => _context.ProcedureCatalogs.FirstOrDefault(p => p.ProcedureId == id);

        public void Add(ProcedureCatalog proc)
        {
            proc.ProcedureId = 0;
            _context.ProcedureCatalogs.Add(proc);
            _context.SaveChanges();
        }

        public void Update(ProcedureCatalog proc)
        {
            _context.ProcedureCatalogs.Update(proc);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null) return;

            _context.ProcedureCatalogs.Remove(existing);
            _context.SaveChanges();
        }
    }
}
