using System.Collections.Generic;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Domain.Ports
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(int userId);
        User? GetById(int userId);
        User? GetByUsername(string username);
        User? GetByCedula(string cedula);
        IEnumerable<User> GetAll();
        int GetNextId();
    }
}
