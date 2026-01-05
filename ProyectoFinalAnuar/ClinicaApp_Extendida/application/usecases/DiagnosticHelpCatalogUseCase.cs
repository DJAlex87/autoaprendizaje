using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class DiagnosticHelpCatalogUseCase
    {
        private readonly IDiagnosticHelpCatalogRepository _repo;

        public DiagnosticHelpCatalogUseCase(IDiagnosticHelpCatalogRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<DiagnosticHelpCatalog> GetAll()
            => _repo.GetAll();

        public (bool IsValid, string Error) Save(DiagnosticHelpCatalog diag)
        {
            if (string.IsNullOrWhiteSpace(diag.Nombre))
                return (false, "El nombre de la ayuda diagnóstica es obligatorio.");

            if (diag.CostoBase < 0)
                return (false, "El costo no puede ser negativo.");

            if (diag.RequiresSpecialist && (diag.SpecialtyId == null || diag.SpecialtyId == 0))
                return (false, "Debe seleccionar una especialidad cuando la ayuda requiere especialista.");

            if (diag.DiagnosticHelpId == 0)
                _repo.Add(diag);
            else
                _repo.Update(diag);

            return (true, string.Empty);
        }

        public void Delete(int id) => _repo.Delete(id);
    }
}
