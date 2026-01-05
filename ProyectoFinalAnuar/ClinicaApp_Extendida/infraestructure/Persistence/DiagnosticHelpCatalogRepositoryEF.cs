using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class DiagnosticHelpCatalogRepositoryEF : IDiagnosticHelpCatalogRepository
    {
        private readonly ClinicDbContext _context;

        public DiagnosticHelpCatalogRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DiagnosticHelpCatalog> GetAll()
            => _context.DiagnosticHelpCatalogs
                       .OrderBy(d => d.Nombre)
                       .ToList();

        public DiagnosticHelpCatalog? GetById(int id)
            => _context.DiagnosticHelpCatalogs.FirstOrDefault(d => d.DiagnosticHelpId == id);

        public void Add(DiagnosticHelpCatalog diag)
        {
            diag.DiagnosticHelpId = 0;
            _context.DiagnosticHelpCatalogs.Add(diag);
            _context.SaveChanges();
        }

        public void Update(DiagnosticHelpCatalog diag)
        {
            _context.DiagnosticHelpCatalogs.Update(diag);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null) return;

            _context.DiagnosticHelpCatalogs.Remove(existing);
            _context.SaveChanges();
        }
    }
}
