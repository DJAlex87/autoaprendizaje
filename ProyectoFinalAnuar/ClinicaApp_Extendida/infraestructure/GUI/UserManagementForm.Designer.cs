using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class UserManagementForm
    {
        private System.ComponentModel.IContainer components = null!;
        private DataGridView dgvUsers = null!;
        private TextBox txtUserId = null!;
        private TextBox txtCedula = null!;
        private TextBox txtNombre = null!;
        private TextBox txtEmail = null!;
        private TextBox txtTelefono = null!;
        private TextBox txtDireccion = null!;
        private ComboBox cmbRole = null!;
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnGuardar = null!;
        private Button btnNuevo = null!;
        private Button btnEliminar = null!;
        private DateTimePicker dtpFechaNacimiento = null!;
        private Label lblTitulo = null!;
        private GroupBox grpDatos = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.dgvUsers = new DataGridView();
            this.txtUserId = new TextBox();
            this.txtCedula = new TextBox();
            this.txtNombre = new TextBox();
            this.txtEmail = new TextBox();
            this.txtTelefono = new TextBox();
            this.txtDireccion = new TextBox();
            this.cmbRole = new ComboBox();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnGuardar = new Button();
            this.btnNuevo = new Button();
            this.btnEliminar = new Button();
            this.dtpFechaNacimiento = new DateTimePicker();
            this.lblTitulo = new Label();
            this.grpDatos = new GroupBox();

            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text = "Gestión de Usuarios (RRHH)";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);

            // grpDatos
            this.grpDatos.Text = "Datos del usuario";
            this.grpDatos.Location = new System.Drawing.Point(20, 40);
            this.grpDatos.Size = new System.Drawing.Size(620, 150);

            int labelX = 15;
            int inputX = 130;
            int labelX2 = 320;
            int inputX2 = 430;
            int y = 25;
            int dy = 25;

            // Id
            var lblId = new Label { Text = "Id:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtUserId.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtUserId.Width = 60;
            this.txtUserId.ReadOnly = true;

            // Cédula
            y += dy;
            var lblCedula = new Label { Text = "Cédula:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtCedula.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtCedula.Width = 150;

            // Nombre completo
            y += dy;
            var lblNombre = new Label { Text = "Nombre completo:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtNombre.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtNombre.Width = 180;   // ← antes 250

            // Email
            y += dy;
            var lblEmail = new Label { Text = "Email:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtEmail.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtEmail.Width = 180;    // ← antes 250

            // Teléfono
            y += dy;
            var lblTelefono = new Label { Text = "Teléfono:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtTelefono.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtTelefono.Width = 150;

            // Columna derecha: Fecha Nac, Dirección, Rol, Usuario, Contraseña
            int y2 = 25;

            var lblFechaNac = new Label { Text = "Fecha nacimiento:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.dtpFechaNacimiento.Width = 160;
            y2 += dy;

            var lblDireccion = new Label { Text = "Dirección:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtDireccion.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtDireccion.Width = 160;
            y2 += dy;

            var lblRol = new Label { Text = "Rol:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.cmbRole.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.cmbRole.Width = 160;
            y2 += dy;

            var lblUsername = new Label { Text = "Usuario:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtUsername.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtUsername.Width = 160;
            y2 += dy;

            var lblPassword = new Label { Text = "Contraseña:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtPassword.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtPassword.Width = 160;
            this.txtPassword.PasswordChar = '*';

            this.grpDatos.Controls.AddRange(new Control[]
            {
                lblId, this.txtUserId,
                lblCedula, this.txtCedula,
                lblNombre, this.txtNombre,
                lblEmail, this.txtEmail,
                lblTelefono, this.txtTelefono,
                lblFechaNac, this.dtpFechaNacimiento,
                lblDireccion, this.txtDireccion,
                lblRol, this.cmbRole,
                lblUsername, this.txtUsername,
                lblPassword, this.txtPassword
            });

            // Botones
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(660, 60);
            this.btnGuardar.Width = 100;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(660, 100);
            this.btnNuevo.Width = 100;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(660, 140);
            this.btnEliminar.Width = 100;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(20, 210);
            this.dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvUsers.Width = 740;
            this.dgvUsers.Height = 220;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvUsers);

            this.Text = "Gestión de usuarios";
            this.StartPosition = FormStartPosition.CenterParent;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
