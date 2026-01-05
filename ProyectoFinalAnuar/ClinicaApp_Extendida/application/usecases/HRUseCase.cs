using System.Linq;
using System.Collections.Generic;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Application.Adapters.Input.Validators;

namespace ClinicaApp.Application.UseCases
{
    public class HRUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _validator = new();

        public HRUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public (bool IsValid, string Error) CreateUser(User user)
        {
            var validation = _validator.Validate(user);
            if (!validation.IsValid) return validation;

            // cedula y username únicos
            if (_userRepository.GetByCedula(user.Cedula) is not null)
                return (false, "Ya existe un usuario con esa cédula.");

            if (_userRepository.GetByUsername(user.Username) is not null)
                return (false, "Ya existe un usuario con ese nombre de usuario.");

            user.UserId = _userRepository.GetNextId();
            _userRepository.Add(user);
            return (true, string.Empty);
        }

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();

        public (bool IsValid, string Error) UpdateUser(User user)
        {
            var validation = _validator.Validate(user);
            if (!validation.IsValid) return validation;

            var existingByCedula = _userRepository.GetByCedula(user.Cedula);
            if (existingByCedula is not null && existingByCedula.UserId != user.UserId)
                return (false, "Ya existe otro usuario con esa cédula.");

            var existingByUsername = _userRepository.GetByUsername(user.Username);
            if (existingByUsername is not null && existingByUsername.UserId != user.UserId)
                return (false, "Ya existe otro usuario con ese nombre de usuario.");

            _userRepository.Update(user);
            return (true, string.Empty);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }
    }
}
