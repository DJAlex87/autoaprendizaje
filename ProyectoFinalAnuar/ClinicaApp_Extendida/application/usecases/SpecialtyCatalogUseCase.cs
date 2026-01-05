using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class SpecialtyCatalogUseCase
    {
        private readonly ISpecialtyCatalogRepository _repo;

        public SpecialtyCatalogUseCase(ISpecialtyCatalogRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<SpecialtyCatalog> GetAll()
            => _repo.GetAll();

        public (bool IsValid, string Error) Save(SpecialtyCatalog spec)
        {
            if (string.IsNullOrWhiteSpace(spec.Nombre))
                return (false, "El nombre de la especialidad es obligatorio.");

            if (spec.SpecialtyId == 0)
                _repo.Add(spec);
            else
                _repo.Update(spec);

            return (true, string.Empty);
        }

        public void Delete(int id) => _repo.Delete(id);
    }
}
