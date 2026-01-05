using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class PatientManagementForm
    {
        private System.ComponentModel.IContainer components = null!;
        private DataGridView dgvPatients = null!;
        private TextBox txtPatientId = null!;
        private TextBox txtCedula = null!;
        private TextBox txtNombre = null!;
        private DateTimePicker dtpFechaNacimiento = null!;
        private ComboBox cmbGenero = null!;
        private TextBox txtDireccion = null!;
        private TextBox txtTelefono = null!;
        private TextBox txtEmail = null!;
        private Button btnGuardar = null!;
        private Button btnNuevo = null!;
        private Button btnCerrar = null!;
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
            this.dgvPatients = new DataGridView();
            this.txtPatientId = new TextBox();
            this.txtCedula = new TextBox();
            this.txtNombre = new TextBox();
            this.dtpFechaNacimiento = new DateTimePicker();
            this.cmbGenero = new ComboBox();
            this.txtDireccion = new TextBox();
            this.txtTelefono = new TextBox();
            this.txtEmail = new TextBox();
            this.btnGuardar = new Button();
            this.btnNuevo = new Button();
            this.btnCerrar = new Button();
            this.lblTitulo = new Label();
            this.grpDatos = new GroupBox();

            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text = "Gestión de Pacientes (Administrativo)";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);

            // grpDatos
            this.grpDatos.Text = "Datos del paciente";
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
            this.txtPatientId.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtPatientId.Width = 60;
            this.txtPatientId.ReadOnly = true;

            // Cédula
            y += dy;
            var lblCedula = new Label { Text = "Cédula:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtCedula.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtCedula.Width = 150;

            // Nombre completo
            y += dy;
            var lblNombre = new Label { Text = "Nombre completo:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtNombre.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtNombre.Width = 250;

            // Fecha nacimiento
            y += dy;
            var lblFechaNac = new Label { Text = "Fecha nacimiento:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(inputX, y - 3);
            this.dtpFechaNacimiento.Width = 160;

            // Columna derecha: Género, Dirección, Teléfono, Email
            int y2 = 25;

            var lblGenero = new Label { Text = "Género:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.cmbGenero.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.cmbGenero.Width = 140;
            y2 += dy;

            var lblDireccion = new Label { Text = "Dirección:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtDireccion.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtDireccion.Width = 160;
            y2 += dy;

            var lblTelefono = new Label { Text = "Teléfono:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtTelefono.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtTelefono.Width = 160;
            y2 += dy;

            var lblEmail = new Label { Text = "Email:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtEmail.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtEmail.Width = 160;

            this.grpDatos.Controls.AddRange(new Control[]
            {
                lblId, this.txtPatientId,
                lblCedula, this.txtCedula,
                lblNombre, this.txtNombre,
                lblFechaNac, this.dtpFechaNacimiento,
                lblGenero, this.cmbGenero,
                lblDireccion, this.txtDireccion,
                lblTelefono, this.txtTelefono,
                lblEmail, this.txtEmail
            });

            // Botón Guardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(660, 60);
            this.btnGuardar.Width = 100;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Botón Nuevo
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(660, 100);
            this.btnNuevo.Width = 100;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // Botón Cerrar
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new System.Drawing.Point(660, 140);
            this.btnCerrar.Width = 100;
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // dgvPatients
            this.dgvPatients.Location = new System.Drawing.Point(20, 210);
            this.dgvPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvPatients.Width = 740;
            this.dgvPatients.Height = 220;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvPatients_CellDoubleClick);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvPatients);

            this.Text = "Gestión de pacientes";
            this.StartPosition = FormStartPosition.CenterParent;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
