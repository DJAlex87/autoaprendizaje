using System;
using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox groupDatosFactura;
        private TextBox txtPatientId;
        private TextBox txtCedulaMedico;
        private TextBox txtPolicyId;
        private TextBox txtCompanyName;
        private TextBox txtPolicyNumber;
        private DateTimePicker dtpPolicyEndDate;
        private TextBox txtDaysRemaining;
        private DateTimePicker dtpInvoiceDate;
        private NumericUpDown nudTotalAmount;
        private NumericUpDown nudCopay;
        private NumericUpDown nudInsurerAmount;
        private NumericUpDown nudYear;
        private Button btnGenerarFactura;
        private Button btnCerrar;
        private Button btnVerFacturas;   // <--- NUEVO BOTÓN

        private Label lblPatientId;
        private Label lblCedulaMedico;
        private Label lblPolicyId;
        private Label lblCompanyName;
        private Label lblPolicyNumber;
        private Label lblEndDate;
        private Label lblDaysRemaining;
        private Label lblInvoiceDate;
        private Label lblTotalAmount;
        private Label lblCopay;
        private Label lblInsurerAmount;
        private Label lblYear;

        private GroupBox groupDetalles;
        private DataGridView dgvDetalles;

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

            // ============ GROUPBOX DATOS DE FACTURA ============
            this.groupDatosFactura = new GroupBox();
            this.groupDatosFactura.Text = "Datos de factura";
            this.groupDatosFactura.Location = new System.Drawing.Point(12, 12);
            this.groupDatosFactura.Size = new System.Drawing.Size(660, 230);

            // Labels izquierda
            this.lblPatientId = new Label()
            {
                Text = "Paciente (ID):",
                Location = new System.Drawing.Point(20, 30),
                AutoSize = true
            };
            this.lblCedulaMedico = new Label()
            {
                Text = "Cédula Médico:",
                Location = new System.Drawing.Point(20, 65),
                AutoSize = true
            };
            this.lblPolicyId = new Label()
            {
                Text = "Póliza (ID):",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };
            this.lblCompanyName = new Label()
            {
                Text = "Compañía:",
                Location = new System.Drawing.Point(20, 135),
                AutoSize = true
            };
            this.lblPolicyNumber = new Label()
            {
                Text = "Número de póliza:",
                Location = new System.Drawing.Point(20, 170),
                AutoSize = true
            };
            this.lblYear = new Label()
            {
                Text = "Año:",
                Location = new System.Drawing.Point(20, 205),
                AutoSize = true
            };

            // Labels derecha
            this.lblEndDate = new Label()
            {
                Text = "Fecha fin póliza:",
                Location = new System.Drawing.Point(340, 30),
                AutoSize = true
            };
            this.lblDaysRemaining = new Label()
            {
                Text = "Días restantes:",
                Location = new System.Drawing.Point(340, 65),
                AutoSize = true
            };
            this.lblInvoiceDate = new Label()
            {
                Text = "Fecha factura:",
                Location = new System.Drawing.Point(340, 100),
                AutoSize = true
            };
            this.lblTotalAmount = new Label()
            {
                Text = "Total:",
                Location = new System.Drawing.Point(340, 135),
                AutoSize = true
            };
            this.lblCopay = new Label()
            {
                Text = "Copago:",
                Location = new System.Drawing.Point(340, 170),
                AutoSize = true
            };
            this.lblInsurerAmount = new Label()
            {
                Text = "Cubierto EPS:",
                Location = new System.Drawing.Point(340, 205),
                AutoSize = true
            };

            // Controles izquierda
            this.txtPatientId = new TextBox()
            {
                Location = new System.Drawing.Point(140, 27),
                Width = 160
            };
            this.txtCedulaMedico = new TextBox()
            {
                Location = new System.Drawing.Point(140, 62),
                Width = 160
            };
            this.txtPolicyId = new TextBox()
            {
                Location = new System.Drawing.Point(140, 97),
                Width = 160
            };
            this.txtCompanyName = new TextBox()
            {
                Location = new System.Drawing.Point(140, 132),
                Width = 160
            };
            this.txtPolicyNumber = new TextBox()
            {
                Location = new System.Drawing.Point(140, 167),
                Width = 160
            };
            this.nudYear = new NumericUpDown()
            {
                Location = new System.Drawing.Point(140, 202),
                Width = 160,
                Minimum = 2000,
                Maximum = 2100,
                Value = DateTime.Now.Year
            };

            // Controles derecha
            this.dtpPolicyEndDate = new DateTimePicker()
            {
                Location = new System.Drawing.Point(450, 27),
                Width = 180,
                Format = DateTimePickerFormat.Short
            };
            this.txtDaysRemaining = new TextBox()
            {
                Location = new System.Drawing.Point(450, 62),
                Width = 180
            };
            this.dtpInvoiceDate = new DateTimePicker()
            {
                Location = new System.Drawing.Point(450, 97),
                Width = 180,
                Format = DateTimePickerFormat.Short
            };
            this.nudTotalAmount = new NumericUpDown()
            {
                Location = new System.Drawing.Point(450, 132),
                Width = 180,
                DecimalPlaces = 2,
                Maximum = 999999999
            };
            this.nudCopay = new NumericUpDown()
            {
                Location = new System.Drawing.Point(450, 167),
                Width = 180,
                DecimalPlaces = 2,
                Maximum = 999999999
            };
            this.nudInsurerAmount = new NumericUpDown()
            {
                Location = new System.Drawing.Point(450, 202),
                Width = 180,
                DecimalPlaces = 2,
                Maximum = 999999999
            };

            this.groupDatosFactura.Controls.AddRange(new Control[]
            {
                // Izquierda
                lblPatientId, txtPatientId,
                lblCedulaMedico, txtCedulaMedico,
                lblPolicyId, txtPolicyId,
                lblCompanyName, txtCompanyName,
                lblPolicyNumber, txtPolicyNumber,
                lblYear, nudYear,
                // Derecha
                lblEndDate, dtpPolicyEndDate,
                lblDaysRemaining, txtDaysRemaining,
                lblInvoiceDate, dtpInvoiceDate,
                lblTotalAmount, nudTotalAmount,
                lblCopay, nudCopay,
                lblInsurerAmount, nudInsurerAmount
            });

            // ============ DETALLES ============
            this.groupDetalles = new GroupBox();
            this.groupDetalles.Text = "Detalles de factura";
            this.groupDetalles.Location = new System.Drawing.Point(12, 250);
            this.groupDetalles.Size = new System.Drawing.Size(660, 200);

            this.dgvDetalles = new DataGridView();
            this.dgvDetalles.Location = new System.Drawing.Point(20, 25);
            this.dgvDetalles.Size = new System.Drawing.Size(620, 160);
            this.dgvDetalles.AllowUserToAddRows = true;
            this.dgvDetalles.AllowUserToDeleteRows = true;
            this.dgvDetalles.ReadOnly = false;
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.AutoGenerateColumns = false; // importante para el binding

            // Columnas para capturar / mostrar ítems de la factura
            var colDescription = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Descripción",
                DataPropertyName = "Description",
                FillWeight = 35
            };
            var colQuantity = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Cantidad",
                DataPropertyName = "Quantity",
                FillWeight = 15
            };
            var colUnitCost = new DataGridViewTextBoxColumn
            {
                Name = "UnitCost",
                HeaderText = "Costo unitario",
                DataPropertyName = "UnitCost",
                FillWeight = 20
            };
            var colLineTotal = new DataGridViewTextBoxColumn
            {
                Name = "LineTotal",
                HeaderText = "Total línea",
                DataPropertyName = "LineTotal",
                FillWeight = 20
            };
            var colItemType = new DataGridViewTextBoxColumn
            {
                Name = "ItemType",
                HeaderText = "Tipo (Medicamento/Procedimiento/Ayuda)",
                DataPropertyName = "ItemType",
                FillWeight = 25
            };

            this.dgvDetalles.Columns.AddRange(
                colDescription,
                colQuantity,
                colUnitCost,
                colLineTotal,
                colItemType
            );

            this.groupDetalles.Controls.Add(dgvDetalles);

            // ============ BOTONES ============
            this.btnGenerarFactura = new Button();
            this.btnGenerarFactura.Text = "Generar factura";
            this.btnGenerarFactura.Location = new System.Drawing.Point(420, 460);
            this.btnGenerarFactura.Size = new System.Drawing.Size(120, 30);
            this.btnGenerarFactura.Click += btnGenerarFactura_Click;

            this.btnCerrar = new Button();
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new System.Drawing.Point(550, 460);
            this.btnCerrar.Size = new System.Drawing.Size(120, 30);
            this.btnCerrar.Click += btnCerrar_Click;

            this.btnVerFacturas = new Button();
            this.btnVerFacturas.Text = "Ver facturas";
            this.btnVerFacturas.Location = new System.Drawing.Point(290, 460);
            this.btnVerFacturas.Size = new System.Drawing.Size(120, 30);
            this.btnVerFacturas.Click += btnVerFacturas_Click;

            // ============ FORM ============
            this.ClientSize = new System.Drawing.Size(684, 510);
            this.Controls.Add(groupDatosFactura);
            this.Controls.Add(groupDetalles);
            this.Controls.Add(btnVerFacturas);
            this.Controls.Add(btnGenerarFactura);
            this.Controls.Add(btnCerrar);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "Facturación";
        }
    }
}
