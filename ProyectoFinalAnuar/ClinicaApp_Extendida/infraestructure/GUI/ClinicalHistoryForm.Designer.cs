using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class ClinicalHistoryForm
    {
        private System.ComponentModel.IContainer components = null!;

        private TextBox txtCedulaPaciente = null!;
        private TextBox txtCedulaMedico = null!;
        private DateTimePicker dtpFecha = null!;
        private TextBox txtMotivo = null!;
        private TextBox txtSintomas = null!;
        private TextBox txtDiagnostico = null!;
        private TextBox txtNumeroOrden = null!;
        private NumericUpDown numIdMedicamento = null!;
        private NumericUpDown numIdAyuda = null!;
        private NumericUpDown numCantidad = null!;
        private NumericUpDown numItem = null!;
        private NumericUpDown numIdEspecialidad = null!;
        private TextBox txtDosis = null!;
        private TextBox txtDuracion = null!;
        private CheckBox chkEsAyudaDiagnostica = null!;
        private CheckBox chkReqEspecialista = null!;
        private Button btnBuscar = null!;
        private Button btnGuardarAtencion = null!;
        private DataGridView dgvHistoria = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            txtCedulaPaciente = new TextBox();
            txtCedulaMedico = new TextBox();
            dtpFecha = new DateTimePicker();
            txtMotivo = new TextBox();
            txtSintomas = new TextBox();
            txtDiagnostico = new TextBox();
            txtNumeroOrden = new TextBox();
            numIdMedicamento = new NumericUpDown();
            numIdAyuda = new NumericUpDown();
            numCantidad = new NumericUpDown();
            numItem = new NumericUpDown();
            numIdEspecialidad = new NumericUpDown();
            txtDosis = new TextBox();
            txtDuracion = new TextBox();
            chkEsAyudaDiagnostica = new CheckBox();
            chkReqEspecialista = new CheckBox();
            btnBuscar = new Button();
            btnGuardarAtencion = new Button();
            dgvHistoria = new DataGridView();

            SuspendLayout();

            // Layout muy básico (luego lo mejoramos si quieres)
            int xLabel = 10, xInput = 140, y = 10, dy = 25;

            void AddLabel(string text, int yy)
            {
                var lbl = new Label
                {
                    Text = text,
                    AutoSize = true,
                    Location = new System.Drawing.Point(xLabel, yy + 3)
                };
                Controls.Add(lbl);
            }

            AddLabel("Cédula paciente:", y);
            txtCedulaPaciente.Location = new System.Drawing.Point(xInput, y);
            txtCedulaPaciente.Width = 120;
            Controls.Add(txtCedulaPaciente);

            btnBuscar.Text = "Buscar historia";
            btnBuscar.Location = new System.Drawing.Point(280, y - 1);
            btnBuscar.Click += btnBuscar_Click;
            Controls.Add(btnBuscar);
            y += dy;

            AddLabel("Cédula médico:", y);
            txtCedulaMedico.Location = new System.Drawing.Point(xInput, y);
            txtCedulaMedico.Width = 120;
            Controls.Add(txtCedulaMedico);
            y += dy;

            AddLabel("Fecha atención:", y);
            dtpFecha.Location = new System.Drawing.Point(xInput, y);
            Controls.Add(dtpFecha);
            y += dy;

            AddLabel("Motivo consulta:", y);
            txtMotivo.Location = new System.Drawing.Point(xInput, y);
            txtMotivo.Width = 300;
            Controls.Add(txtMotivo);
            y += dy;

            AddLabel("Síntomas:", y);
            txtSintomas.Location = new System.Drawing.Point(xInput, y);
            txtSintomas.Width = 300;
            Controls.Add(txtSintomas);
            y += dy;

            AddLabel("Diagnóstico:", y);
            txtDiagnostico.Location = new System.Drawing.Point(xInput, y);
            txtDiagnostico.Width = 300;
            Controls.Add(txtDiagnostico);
            y += dy;

            AddLabel("Nº Orden:", y);
            txtNumeroOrden.Location = new System.Drawing.Point(xInput, y);
            txtNumeroOrden.Width = 80;
            Controls.Add(txtNumeroOrden);
            y += dy;

            chkEsAyudaDiagnostica.Text = "Es ayuda diagnóstica";
            chkEsAyudaDiagnostica.Location = new System.Drawing.Point(xInput, y);
            Controls.Add(chkEsAyudaDiagnostica);
            y += dy;

            AddLabel("Id Medicamento:", y);
            numIdMedicamento.Location = new System.Drawing.Point(xInput, y);
            numIdMedicamento.Maximum = 999999;
            Controls.Add(numIdMedicamento);
            y += dy;

            AddLabel("Dosis:", y);
            txtDosis.Location = new System.Drawing.Point(xInput, y);
            txtDosis.Width = 120;
            Controls.Add(txtDosis);
            y += dy;

            AddLabel("Duración:", y);
            txtDuracion.Location = new System.Drawing.Point(xInput, y);
            txtDuracion.Width = 120;
            Controls.Add(txtDuracion);
            y += dy;

            AddLabel("Id Ayuda:", y);
            numIdAyuda.Location = new System.Drawing.Point(xInput, y);
            numIdAyuda.Maximum = 999999;
            Controls.Add(numIdAyuda);
            y += dy;

            AddLabel("Cantidad:", y);
            numCantidad.Location = new System.Drawing.Point(xInput, y);
            numCantidad.Minimum = 1;
            numCantidad.Maximum = 999;
            numCantidad.Value = 1;
            Controls.Add(numCantidad);
            y += dy;

            AddLabel("Item:", y);
            numItem.Location = new System.Drawing.Point(xInput, y);
            numItem.Minimum = 1;
            numItem.Maximum = 999;
            numItem.Value = 1;
            Controls.Add(numItem);
            y += dy;

            chkReqEspecialista.Text = "Requiere especialista";
            chkReqEspecialista.Location = new System.Drawing.Point(xInput, y);
            Controls.Add(chkReqEspecialista);

            AddLabel("Id Especialidad:", y + dy);
            numIdEspecialidad.Location = new System.Drawing.Point(xInput, y + dy);
            numIdEspecialidad.Maximum = 999999;
            Controls.Add(numIdEspecialidad);
            y += dy * 2;

            btnGuardarAtencion.Text = "Guardar atención";
            btnGuardarAtencion.Location = new System.Drawing.Point(xInput, y);
            btnGuardarAtencion.Click += btnGuardarAtencion_Click;
            Controls.Add(btnGuardarAtencion);
            y += dy + 5;

            dgvHistoria.Location = new System.Drawing.Point(10, y);
            dgvHistoria.Width = 760;
            dgvHistoria.Height = 200;
            dgvHistoria.ReadOnly = true;
            dgvHistoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Controls.Add(dgvHistoria);

            ClientSize = new System.Drawing.Size(800, 550);
            Text = "Historia clínica (Médico)";
            StartPosition = FormStartPosition.CenterParent;

            ResumeLayout(false);
        }
    }
}
