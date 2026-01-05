using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class MedicationCatalogForm
    {
        private System.ComponentModel.IContainer components = null!;
        private DataGridView dgvMedications = null!;
        private TextBox txtId = null!;
        private TextBox txtNombre = null!;
        private TextBox txtDescripcion = null!;
        private TextBox txtCostoBase = null!;
        private CheckBox chkActivo = null!;
        private Button btnGuardar = null!;
        private Button btnNuevo = null!;
        private Button btnEliminar = null!;
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
            this.dgvMedications = new DataGridView();
            this.txtId = new TextBox();
            this.txtNombre = new TextBox();
            this.txtDescripcion = new TextBox();
            this.txtCostoBase = new TextBox();
            this.chkActivo = new CheckBox();
            this.btnGuardar = new Button();
            this.btnNuevo = new Button();
            this.btnEliminar = new Button();
            this.lblTitulo = new Label();
            this.grpDatos = new GroupBox();

            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text = "Catálogo de Medicamentos";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);

            // grpDatos
            this.grpDatos.Text = "Datos del medicamento";
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
            this.txtId.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtId.Width = 60;
            this.txtId.ReadOnly = true;

            // Nombre
            y += dy;
            var lblNombre = new Label { Text = "Nombre:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtNombre.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtNombre.Width = 250;

            // Descripción
            y += dy;
            var lblDescripcion = new Label { Text = "Descripción:", AutoSize = true, Location = new System.Drawing.Point(labelX, y) };
            this.txtDescripcion.Location = new System.Drawing.Point(inputX, y - 3);
            this.txtDescripcion.Width = 250;

            // Costo base
            int y2 = 25;
            var lblCosto = new Label { Text = "Costo base:", AutoSize = true, Location = new System.Drawing.Point(labelX2, y2) };
            this.txtCostoBase.Location = new System.Drawing.Point(inputX2, y2 - 3);
            this.txtCostoBase.Width = 120;
            y2 += dy;

            // Activo
            this.chkActivo.Text = "Activo";
            this.chkActivo.Checked = true;
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(inputX2, y2);

            this.grpDatos.Controls.AddRange(new Control[]
            {
                lblId, this.txtId,
                lblNombre, this.txtNombre,
                lblDescripcion, this.txtDescripcion,
                lblCosto, this.txtCostoBase,
                this.chkActivo
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

            // dgvMedications
            this.dgvMedications.Location = new System.Drawing.Point(20, 210);
            this.dgvMedications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvMedications.Width = 740;
            this.dgvMedications.Height = 220;
            this.dgvMedications.ReadOnly = true;
            this.dgvMedications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedications.MultiSelect = false;
            this.dgvMedications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedications.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvMedications_CellDoubleClick);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvMedications);

            this.Text = "Catálogo de Medicamentos";
            this.StartPosition = FormStartPosition.CenterParent;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
