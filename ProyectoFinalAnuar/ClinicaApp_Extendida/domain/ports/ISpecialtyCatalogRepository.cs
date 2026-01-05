using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface ISpecialtyCatalogRepository
    {
        IEnumerable<SpecialtyCatalog> GetAll();
        SpecialtyCatalog? GetById(int id);
        void Add(SpecialtyCatalog spec);
        void Update(SpecialtyCatalog spec);
        void Delete(int id);
    }
}
