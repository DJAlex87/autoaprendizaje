using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class UserRepositoryInMemory : IUserRepository
    {
        public void Add(User user)
        {
            var role = InMemoryDatabase.Roles.FirstOrDefault(r => r.RoleId == user.RoleId);
            user.Role = role;
            InMemoryDatabase.Users.Add(user);
        }

        public void Update(User user)
        {
            var existing = GetById(user.UserId);
            if (existing is null) return;

            existing.Cedula = user.Cedula;
            existing.NombreCompleto = user.NombreCompleto;
            existing.Email = user.Email;
            existing.Telefono = user.Telefono;
            existing.FechaNacimiento = user.FechaNacimiento;
            existing.Direccion = user.Direccion;
            existing.RoleId = user.RoleId;
            existing.Username = user.Username;
            existing.PasswordHash = user.PasswordHash;
            existing.Role = InMemoryDatabase.Roles.FirstOrDefault(r => r.RoleId == user.RoleId);
        }

        public void Delete(int userId)
        {
            var existing = GetById(userId);
            if (existing is null) return;
            InMemoryDatabase.Users.Remove(existing);
        }

        public User? GetById(int userId)
            => InMemoryDatabase.Users.FirstOrDefault(u => u.UserId == userId);

        public User? GetByUsername(string username)
            => InMemoryDatabase.Users.FirstOrDefault(u => u.Username == username);

        public User? GetByCedula(string cedula)
            => InMemoryDatabase.Users.FirstOrDefault(u => u.Cedula == cedula);

        public IEnumerable<User> GetAll()
            => InMemoryDatabase.Users;

        public int GetNextId()
            => InMemoryDatabase.Users.Count == 0 ? 1 : InMemoryDatabase.Users.Max(u => u.UserId) + 1;
    }
}
