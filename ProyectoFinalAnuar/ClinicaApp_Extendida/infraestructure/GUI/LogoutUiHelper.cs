using System.Drawing;
using System.Windows.Forms;
using ClinicaApp; // SessionManager

namespace ClinicaApp.Infraestructure.GUI
{
    public static class LogoutUiHelper
    {
        /// <summary>
        /// Agrega un botón "Cerrar sesión" en la parte superior derecha
        /// del formulario indicado, y lo conecta con SessionManager.Logout().
        /// </summary>
        public static void AttachLogoutButton(Form form)
        {
            // Evitar agregarlo dos veces
            if (form.Controls.ContainsKey("btnLogoutGlobal"))
                return;

            var btnLogout = new Button
            {
                Name = "btnLogoutGlobal",
                Text = "Cerrar sesión",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Lo agregamos primero, luego calculamos posición
            form.Controls.Add(btnLogout);

            // Función local para reposicionar el botón según el tamaño del form
            void PositionButton()
            {
                // margen de 10 px al borde derecho y 10 px desde arriba
                btnLogout.Location = new Point(
                    form.ClientSize.Width - btnLogout.Width - 10,
                    10
                );

                // Aseguramos que siempre quede por encima de otros controles
                btnLogout.BringToFront();
            }

            // Posicionar en Load y cada vez que se redimensione el formulario
            form.Load += (_, __) => PositionButton();
            form.Resize += (_, __) => PositionButton();

            // Acción de logout
            btnLogout.Click += (_, __) => SessionManager.Logout();
        }
    }
}
