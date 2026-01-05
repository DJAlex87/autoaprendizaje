using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class ProcedureCatalogUseCase
    {
        private readonly IProcedureCatalogRepository _repo;

        public ProcedureCatalogUseCase(IProcedureCatalogRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ProcedureCatalog> GetAll()
            => _repo.GetAll();

        public (bool IsValid, string Error) Save(ProcedureCatalog proc)
        {
            if (string.IsNullOrWhiteSpace(proc.Nombre))
                return (false, "El nombre del procedimiento es obligatorio.");

            if (proc.CostoBase < 0)
                return (false, "El costo no puede ser negativo.");

            if (proc.RequiresSpecialist && (proc.SpecialtyId == null || proc.SpecialtyId == 0))
                return (false, "Debe seleccionar una especialidad cuando el procedimiento requiere especialista.");

            if (proc.ProcedureId == 0)
                _repo.Add(proc);
            else
                _repo.Update(proc);

            return (true, string.Empty);
        }

        public void Delete(int id) => _repo.Delete(id);
    }
}
