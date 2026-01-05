using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;

namespace ClinicaApp.Application.UseCases
{
    public class AuthUseCase
    {
        private readonly IUserRepository _userRepository;

        public AuthUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthResult Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user is null)
                return new AuthResult { Success = false, Message = "Usuario no encontrado." };

            // Para ejemplo, usamos PasswordHash como texto plano
            if (user.PasswordHash != password)
                return new AuthResult { Success = false, Message = "Contraseña incorrecta." };

            return new AuthResult { Success = true, User = user };
        }
    }
}
