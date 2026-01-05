using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Infraestructure.GUI;

namespace ClinicaApp
{
    public static class SessionManager
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUsername { get; set; } = string.Empty;
        public static int CurrentRoleId { get; set; }

        /// <summary>
        /// Cierra la sesión actual, vuelve al LoginForm y limpia sus campos.
        /// Se puede llamar desde CUALQUIER formulario.
        /// </summary>
        public static void Logout()
        {
            // Limpiar info de sesión
            CurrentUserId = 0;
            CurrentUsername = string.Empty;
            CurrentRoleId = 0;

            // Buscar el LoginForm ya creado (el que se ocultó al hacer login)
            var login = System.Windows.Forms.Application
                .OpenForms
                .OfType<LoginForm>()
                .FirstOrDefault();

            if (login == null)
            {
                // Si por alguna razón no existe (caso raro), se crea uno nuevo
                login = new LoginForm();
            }

            // Limpiar campos de login y mostrarlo
            login.ResetForm();
            login.Show();

            // Cerrar TODOS los formularios excepto el login
            foreach (Form f in System.Windows.Forms.Application.OpenForms.Cast<Form>().ToList())
            {
                if (f != login)
                {
                    f.Close();
                }
            }
        }
    }
}
