using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class InvoiceListForm
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox groupFiltro;
        private Label lblFiltroAnio;
        private NumericUpDown nudFiltroAnio;
        private Button btnBuscar;
        private Button btnVerTodas;

        private GroupBox groupListado;
        private DataGridView dgvFacturas;

        private GroupBox groupDetalle;
        private Label lblPaciente;
        private TextBox txtPaciente;
        private Label lblFechaFactura;
        private TextBox txtFechaFactura;
        private Label lblTotal;
        private TextBox txtTotal;
        private DataGridView dgvDetalles;

        private Button btnCerrar;

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
            this.components = new System.ComponentModel.Container();

            // ========== GRUPO FILTRO ==========
            this.groupFiltro = new GroupBox();
            this.groupFiltro.Text = "Filtro";
            this.groupFiltro.Location = new System.Drawing.Point(12, 12);
            this.groupFiltro.Size = new System.Drawing.Size(660, 60);

            this.lblFiltroAnio = new Label();
            this.lblFiltroAnio.Text = "Año:";
            this.lblFiltroAnio.AutoSize = true;
            this.lblFiltroAnio.Location = new System.Drawing.Point(20, 26);

            this.nudFiltroAnio = new NumericUpDown();
            this.nudFiltroAnio.Location = new System.Drawing.Point(60, 22);
            this.nudFiltroAnio.Width = 80;
            this.nudFiltroAnio.Minimum = 2000;
            this.nudFiltroAnio.Maximum = 2100;

            this.btnBuscar = new Button();
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(160, 20);
            this.btnBuscar.Size = new System.Drawing.Size(80, 25);
            this.btnBuscar.Click += btnBuscar_Click;

            this.btnVerTodas = new Button();
            this.btnVerTodas.Text = "Ver todas";
            this.btnVerTodas.Location = new System.Drawing.Point(250, 20);
            this.btnVerTodas.Size = new System.Drawing.Size(80, 25);
            this.btnVerTodas.Click += btnVerTodas_Click;

            this.groupFiltro.Controls.Add(this.lblFiltroAnio);
            this.groupFiltro.Controls.Add(this.nudFiltroAnio);
            this.groupFiltro.Controls.Add(this.btnBuscar);
            this.groupFiltro.Controls.Add(this.btnVerTodas);

            // ========== GRUPO LISTADO ==========
            this.groupListado = new GroupBox();
            this.groupListado.Text = "Facturas";
            this.groupListado.Location = new System.Drawing.Point(12, 78);
            this.groupListado.Size = new System.Drawing.Size(660, 200);

            this.dgvFacturas = new DataGridView();
            this.dgvFacturas.Location = new System.Drawing.Point(16, 22);
            this.dgvFacturas.Size = new System.Drawing.Size(628, 170);
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturas.CellDoubleClick += dgvFacturas_CellDoubleClick;

            this.groupListado.Controls.Add(this.dgvFacturas);

            // ========== GRUPO DETALLE ==========
            this.groupDetalle = new GroupBox();
            this.groupDetalle.Text = "Detalle de factura seleccionada";
            this.groupDetalle.Location = new System.Drawing.Point(12, 284);
            this.groupDetalle.Size = new System.Drawing.Size(660, 200);

            // Labels/textos cabecera detalle
            this.lblPaciente = new Label();
            this.lblPaciente.Text = "Paciente:";
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(16, 25);

            this.txtPaciente = new TextBox();
            this.txtPaciente.Location = new System.Drawing.Point(80, 22);
            this.txtPaciente.Width = 230;
            this.txtPaciente.ReadOnly = true;

            this.lblFechaFactura = new Label();
            this.lblFechaFactura.Text = "Fecha:";
            this.lblFechaFactura.AutoSize = true;
            this.lblFechaFactura.Location = new System.Drawing.Point(330, 25);

            this.txtFechaFactura = new TextBox();
            this.txtFechaFactura.Location = new System.Drawing.Point(380, 22);
            this.txtFechaFactura.Width = 100;
            this.txtFechaFactura.ReadOnly = true;

            this.lblTotal = new Label();
            this.lblTotal.Text = "Total:";
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(500, 25);

            this.txtTotal = new TextBox();
            this.txtTotal.Location = new System.Drawing.Point(540, 22);
            this.txtTotal.Width = 90;
            this.txtTotal.ReadOnly = true;

            // Grilla detalle
            this.dgvDetalles = new DataGridView();
            this.dgvDetalles.Location = new System.Drawing.Point(16, 55);
            this.dgvDetalles.Size = new System.Drawing.Size(628, 130);
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.groupDetalle.Controls.Add(this.lblPaciente);
            this.groupDetalle.Controls.Add(this.txtPaciente);
            this.groupDetalle.Controls.Add(this.lblFechaFactura);
            this.groupDetalle.Controls.Add(this.txtFechaFactura);
            this.groupDetalle.Controls.Add(this.lblTotal);
            this.groupDetalle.Controls.Add(this.txtTotal);
            this.groupDetalle.Controls.Add(this.dgvDetalles);

            // ========== BOTÓN CERRAR ==========
            this.btnCerrar = new Button();
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new System.Drawing.Point(572, 490);
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.Click += btnCerrar_Click;

            // ========== FORM ==========
            this.ClientSize = new System.Drawing.Size(684, 532);
            this.Controls.Add(this.groupFiltro);
            this.Controls.Add(this.groupListado);
            this.Controls.Add(this.groupDetalle);
            this.Controls.Add(this.btnCerrar);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "Visor de facturas";

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
