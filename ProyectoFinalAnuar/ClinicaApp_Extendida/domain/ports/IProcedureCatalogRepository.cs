using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IProcedureCatalogRepository
    {
        IEnumerable<ProcedureCatalog> GetAll();
        ProcedureCatalog? GetById(int id);
        void Add(ProcedureCatalog proc);
        void Update(ProcedureCatalog proc);
        void Delete(int id);
    }
}
