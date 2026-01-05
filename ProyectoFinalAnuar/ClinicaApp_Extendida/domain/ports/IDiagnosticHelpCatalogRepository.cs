using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IDiagnosticHelpCatalogRepository
    {
        IEnumerable<DiagnosticHelpCatalog> GetAll();
        DiagnosticHelpCatalog? GetById(int id);
        void Add(DiagnosticHelpCatalog diag);
        void Update(DiagnosticHelpCatalog diag);
        void Delete(int id);
    }
}
