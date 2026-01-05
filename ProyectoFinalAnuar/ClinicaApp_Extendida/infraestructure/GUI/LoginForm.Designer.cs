using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null!;
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Label lblUsername = null!;
        private Label lblPassword = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblUsername = new Label();
            this.lblPassword = new Label();

            this.SuspendLayout();

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Text = "Usuario:";
            this.lblUsername.Location = new System.Drawing.Point(20, 20);

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(120, 20);
            this.txtUsername.Width = 180;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Location = new System.Drawing.Point(20, 60);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 60);
            this.txtPassword.Width = 180;
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.Location = new System.Drawing.Point(120, 100);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(340, 150);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Text = "Login - Clínica";
            this.AcceptButton = this.btnLogin;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
