using System;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class LoginForm : Form
    {
        private readonly AuthUseCase _authUseCase;

        public LoginForm()
        {
            InitializeComponent();
            IUserRepository userRepo = ServiceLocator.CreateUserRepository();
            _authUseCase = new AuthUseCase(userRepo);
        }

        /// <summary>
        /// Limpia los campos del formulario de login y pone el foco en el usuario.
        /// </summary>
        public void ResetForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            // si tienes algún label de error, límpialo aquí también
            // lblError.Text = string.Empty;

            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            var result = _authUseCase.Login(username, password);
            if (!result.Success || result.User is null)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guardamos info básica de sesión (para usarla luego si quieres)
            SessionManager.CurrentUserId = result.User.UserId;
            SessionManager.CurrentUsername = result.User.Username;
            SessionManager.CurrentRoleId = result.User.RoleId;

            // Ocultamos el login y abrimos el menú principal
            Hide();

            var main = new MainForm(result.User);
            // OJO: ya NO hacemos main.FormClosed += (_, __) => Close();
            // porque queremos poder volver al Login con Logout sin cerrar la app.

            main.Show();
        }
    }
}
