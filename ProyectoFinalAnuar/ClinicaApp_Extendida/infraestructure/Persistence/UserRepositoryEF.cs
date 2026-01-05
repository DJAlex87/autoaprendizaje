using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Infraestructure.Persistence
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly ClinicDbContext _context;

        public UserRepositoryEF(ClinicDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            user.UserId = 0;
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var existing = GetById(userId);
            if (existing is null) return;
            _context.Users.Remove(existing);
            _context.SaveChanges();
        }

        public User? GetById(int userId)
            => _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == userId);

        public User? GetByUsername(string username)
            => _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == username);

        public User? GetByCedula(string cedula)
            => _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Cedula == cedula);

        public IEnumerable<User> GetAll()
            => _context.Users.Include(u => u.Role).ToList();

        public int GetNextId()
        {
            if (!_context.Users.Any()) return 1;
            return _context.Users.Max(u => u.UserId) + 1;
        }
    }
}
