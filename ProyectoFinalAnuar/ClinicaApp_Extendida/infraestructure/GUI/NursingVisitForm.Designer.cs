using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class NursingVisitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblCedula;
        private TextBox txtCedulaPaciente;
        private Button btnBuscarPaciente;
        private Label lblNombrePaciente;
        private TextBox txtNombrePaciente;
        private Label lblFechaHora;
        private DateTimePicker dtpFechaHoraVisita;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblNotas;
        private TextBox txtNotas;
        private DataGridView dgvVisitas;
        private Button btnGuardarVisita;
        private Button btnCerrar;
        private GroupBox groupBoxBusqueda;
        private GroupBox groupBoxRegistro;
        private GroupBox groupBoxListado;

        // Nuevos controles para signos vitales
        private Label lblPresionArterial;
        private TextBox txtPresionArterial;
        private Label lblTemperatura;
        private NumericUpDown nudTemperatura;
        private Label lblPulso;
        private NumericUpDown nudPulso;
        private Label lblOxigeno;
        private NumericUpDown nudOxigeno;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedulaPaciente = new System.Windows.Forms.TextBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.txtNombrePaciente = new System.Windows.Forms.TextBox();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.dtpFechaHoraVisita = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.btnGuardarVisita = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBoxBusqueda = new System.Windows.Forms.GroupBox();
            this.groupBoxRegistro = new System.Windows.Forms.GroupBox();
            this.groupBoxListado = new System.Windows.Forms.GroupBox();

            // Nuevos controles
            this.lblPresionArterial = new System.Windows.Forms.Label();
            this.txtPresionArterial = new System.Windows.Forms.TextBox();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.nudTemperatura = new System.Windows.Forms.NumericUpDown();
            this.lblPulso = new System.Windows.Forms.Label();
            this.nudPulso = new System.Windows.Forms.NumericUpDown();
            this.lblOxigeno = new System.Windows.Forms.Label();
            this.nudOxigeno = new System.Windows.Forms.NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.groupBoxBusqueda.SuspendLayout();
            this.groupBoxRegistro.SuspendLayout();
            this.groupBoxListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPulso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOxigeno)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBusqueda
            // 
            this.groupBoxBusqueda.Controls.Add(this.lblCedula);
            this.groupBoxBusqueda.Controls.Add(this.txtCedulaPaciente);
            this.groupBoxBusqueda.Controls.Add(this.btnBuscarPaciente);
            this.groupBoxBusqueda.Controls.Add(this.lblNombrePaciente);
            this.groupBoxBusqueda.Controls.Add(this.txtNombrePaciente);
            this.groupBoxBusqueda.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBusqueda.Name = "groupBoxBusqueda";
            this.groupBoxBusqueda.Size = new System.Drawing.Size(660, 90);
            this.groupBoxBusqueda.TabIndex = 0;
            this.groupBoxBusqueda.TabStop = false;
            this.groupBoxBusqueda.Text = "Paciente";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(16, 28);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(46, 15);
            this.lblCedula.TabIndex = 0;
            this.lblCedula.Text = "Cédula:";
            // 
            // txtCedulaPaciente
            // 
            this.txtCedulaPaciente.Location = new System.Drawing.Point(80, 25);
            this.txtCedulaPaciente.Name = "txtCedulaPaciente";
            this.txtCedulaPaciente.Size = new System.Drawing.Size(180, 23);
            this.txtCedulaPaciente.TabIndex = 1;
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.Location = new System.Drawing.Point(276, 24);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarPaciente.TabIndex = 2;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Location = new System.Drawing.Point(16, 57);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(55, 15);
            this.lblNombrePaciente.TabIndex = 3;
            this.lblNombrePaciente.Text = "Nombre:";
            // 
            // txtNombrePaciente
            // 
            this.txtNombrePaciente.Location = new System.Drawing.Point(80, 54);
            this.txtNombrePaciente.Name = "txtNombrePaciente";
            this.txtNombrePaciente.ReadOnly = true;
            this.txtNombrePaciente.Size = new System.Drawing.Size(560, 23);
            this.txtNombrePaciente.TabIndex = 4;
            this.txtNombrePaciente.TabStop = false;
            // 
            // groupBoxRegistro
            // 
            this.groupBoxRegistro.Controls.Add(this.lblFechaHora);
            this.groupBoxRegistro.Controls.Add(this.dtpFechaHoraVisita);
            this.groupBoxRegistro.Controls.Add(this.lblMotivo);
            this.groupBoxRegistro.Controls.Add(this.txtMotivo);
            this.groupBoxRegistro.Controls.Add(this.lblNotas);
            this.groupBoxRegistro.Controls.Add(this.txtNotas);

            // nuevos controles dentro de groupBoxRegistro
            this.groupBoxRegistro.Controls.Add(this.lblPresionArterial);
            this.groupBoxRegistro.Controls.Add(this.txtPresionArterial);
            this.groupBoxRegistro.Controls.Add(this.lblTemperatura);
            this.groupBoxRegistro.Controls.Add(this.nudTemperatura);
            this.groupBoxRegistro.Controls.Add(this.lblPulso);
            this.groupBoxRegistro.Controls.Add(this.nudPulso);
            this.groupBoxRegistro.Controls.Add(this.lblOxigeno);
            this.groupBoxRegistro.Controls.Add(this.nudOxigeno);

            this.groupBoxRegistro.Location = new System.Drawing.Point(12, 108);
            this.groupBoxRegistro.Name = "groupBoxRegistro";
            this.groupBoxRegistro.Size = new System.Drawing.Size(660, 210);
            this.groupBoxRegistro.TabIndex = 1;
            this.groupBoxRegistro.TabStop = false;
            this.groupBoxRegistro.Text = "Registro de visita";
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Location = new System.Drawing.Point(16, 26);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(73, 15);
            this.lblFechaHora.TabIndex = 0;
            this.lblFechaHora.Text = "Fecha y hora";
            // 
            // dtpFechaHoraVisita
            // 
            this.dtpFechaHoraVisita.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaHoraVisita.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHoraVisita.Location = new System.Drawing.Point(110, 22);
            this.dtpFechaHoraVisita.Name = "dtpFechaHoraVisita";
            this.dtpFechaHoraVisita.Size = new System.Drawing.Size(180, 23);
            this.dtpFechaHoraVisita.TabIndex = 1;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(16, 58);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(48, 15);
            this.lblMotivo.TabIndex = 2;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(110, 55);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(530, 23);
            this.txtMotivo.TabIndex = 3;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(16, 89);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(41, 15);
            this.lblNotas.TabIndex = 4;
            this.lblNotas.Text = "Notas:";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(110, 86);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotas.Size = new System.Drawing.Size(530, 70);
            this.txtNotas.TabIndex = 5;
            // 
            // lblPresionArterial
            // 
            this.lblPresionArterial.AutoSize = true;
            this.lblPresionArterial.Location = new System.Drawing.Point(16, 168);
            this.lblPresionArterial.Name = "lblPresionArterial";
            this.lblPresionArterial.Size = new System.Drawing.Size(76, 15);
            this.lblPresionArterial.TabIndex = 6;
            this.lblPresionArterial.Text = "Presión art.:";
            // 
            // txtPresionArterial
            // 
            this.txtPresionArterial.Location = new System.Drawing.Point(170, 165);
            this.txtPresionArterial.Name = "txtPresionArterial";
            this.txtPresionArterial.Size = new System.Drawing.Size(90, 23);
            this.txtPresionArterial.TabIndex = 7;
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(270, 168);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(83, 15);
            this.lblTemperatura.TabIndex = 8;
            this.lblTemperatura.Text = "Temp. (°C):";
            // 
            // nudTemperatura
            // 
            this.nudTemperatura.DecimalPlaces = 1;
            this.nudTemperatura.Increment = new decimal(new int[] { 1, 0, 0, 65536 }); // 0.1
            this.nudTemperatura.Location = new System.Drawing.Point(359, 165);
            this.nudTemperatura.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            this.nudTemperatura.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
            this.nudTemperatura.Name = "nudTemperatura";
            this.nudTemperatura.Size = new System.Drawing.Size(60, 23);
            this.nudTemperatura.TabIndex = 9;
            this.nudTemperatura.Value = new decimal(new int[] { 36, 0, 0, 0 });
            // 
            // lblPulso
            // 
            this.lblPulso.AutoSize = true;
            this.lblPulso.Location = new System.Drawing.Point(425, 168);
            this.lblPulso.Name = "lblPulso";
            this.lblPulso.Size = new System.Drawing.Size(39, 15);
            this.lblPulso.TabIndex = 10;
            this.lblPulso.Text = "Pulso:";
            // 
            // nudPulso
            // 
            this.nudPulso.Location = new System.Drawing.Point(470, 165);
            this.nudPulso.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.nudPulso.Name = "nudPulso";
            this.nudPulso.Size = new System.Drawing.Size(60, 23);
            this.nudPulso.TabIndex = 11;
            // 
            // lblOxigeno
            // 
            this.lblOxigeno.AutoSize = true;
            this.lblOxigeno.Location = new System.Drawing.Point(536, 168);
            this.lblOxigeno.Name = "lblOxigeno";
            this.lblOxigeno.Size = new System.Drawing.Size(71, 15);
            this.lblOxigeno.TabIndex = 12;
            this.lblOxigeno.Text = "Oxígeno (%):";
            // 
            // nudOxigeno
            // 
            this.nudOxigeno.Location = new System.Drawing.Point(613, 165);
            this.nudOxigeno.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudOxigeno.Name = "nudOxigeno";
            this.nudOxigeno.Size = new System.Drawing.Size(57, 23);
            this.nudOxigeno.TabIndex = 13;
            this.nudOxigeno.Value = new decimal(new int[] { 98, 0, 0, 0 });
            // 
            // groupBoxListado
            // 
            this.groupBoxListado.Controls.Add(this.dgvVisitas);
            this.groupBoxListado.Location = new System.Drawing.Point(12, 324);
            this.groupBoxListado.Name = "groupBoxListado";
            this.groupBoxListado.Size = new System.Drawing.Size(660, 200);
            this.groupBoxListado.TabIndex = 2;
            this.groupBoxListado.TabStop = false;
            this.groupBoxListado.Text = "Historial de visitas";
            // 
            // dgvVisitas
            // 
            this.dgvVisitas.AllowUserToAddRows = false;
            this.dgvVisitas.AllowUserToDeleteRows = false;
            this.dgvVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitas.Location = new System.Drawing.Point(16, 22);
            this.dgvVisitas.MultiSelect = false;
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.ReadOnly = true;
            this.dgvVisitas.RowHeadersVisible = false;
            this.dgvVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisitas.Size = new System.Drawing.Size(624, 164);
            this.dgvVisitas.TabIndex = 0;
            // 
            // btnGuardarVisita
            // 
            this.btnGuardarVisita.Location = new System.Drawing.Point(416, 540);
            this.btnGuardarVisita.Name = "btnGuardarVisita";
            this.btnGuardarVisita.Size = new System.Drawing.Size(120, 30);
            this.btnGuardarVisita.TabIndex = 3;
            this.btnGuardarVisita.Text = "Guardar visita";
            this.btnGuardarVisita.UseVisualStyleBackColor = true;
            this.btnGuardarVisita.Click += new System.EventHandler(this.btnGuardarVisita_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(552, 540);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // NursingVisitForm
            // 
            this.AcceptButton = this.btnBuscarPaciente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 582);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardarVisita);
            this.Controls.Add(this.groupBoxListado);
            this.Controls.Add(this.groupBoxRegistro);
            this.Controls.Add(this.groupBoxBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NursingVisitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Visitas de Enfermería";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.groupBoxBusqueda.ResumeLayout(false);
            this.groupBoxBusqueda.PerformLayout();
            this.groupBoxRegistro.ResumeLayout(false);
            this.groupBoxRegistro.PerformLayout();
            this.groupBoxListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPulso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOxigeno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
