using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClinicaApp;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class NursingVisitForm : Form
    {
        private readonly NursingUseCase _useCase;
        private Patient? _currentPatient;
        private readonly int _nurseUserId;

        public NursingVisitForm()
        {
            InitializeComponent();

            _useCase = ServiceLocator.CreateNursingUseCase();

            // CurrentUserId es int (no nullable), así que se asigna directo
            _nurseUserId = SessionManager.CurrentUserId;

            // (Opcional pero sano) validar sesión
            if (_nurseUserId <= 0)
            {
                MessageBox.Show(
                    "No se encontró información del usuario en sesión. " +
                    "Vuelve a iniciar sesión e intenta de nuevo.",
                    "Sesión no válida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            dtpFechaHoraVisita.Value = DateTime.Now;
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            var cedula = txtCedulaPaciente.Text.Trim();

            var result = _useCase.BuscarPacienteYVisitas(cedula);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _currentPatient = null;
                txtNombrePaciente.Clear();
                dgvVisitas.DataSource = null;
                return;
            }

            _currentPatient = result.Patient;
            txtNombrePaciente.Text = $"{_currentPatient!.NombreCompleto}";

            CargarVisitas(result.Visits);
        }

        private void CargarVisitas(IList<NursingVisit> visits)
        {
            dgvVisitas.AutoGenerateColumns = true;
            dgvVisitas.DataSource = visits;

            // Ajuste visual básico para que se vea más amigable
            if (dgvVisitas.Columns.Count > 0)
            {
                // Ocultamos columnas técnicas
                if (dgvVisitas.Columns["VisitId"] != null)
                    dgvVisitas.Columns["VisitId"].Visible = false;
                if (dgvVisitas.Columns["OrderNumber"] != null)
                    dgvVisitas.Columns["OrderNumber"].Visible = false;
                if (dgvVisitas.Columns["ItemNumber"] != null)
                    dgvVisitas.Columns["ItemNumber"].Visible = false;

                // Encabezados amigables
                if (dgvVisitas.Columns["CedulaPaciente"] != null)
                    dgvVisitas.Columns["CedulaPaciente"].HeaderText = "Cédula Paciente";
                if (dgvVisitas.Columns["CedulaEnfermera"] != null)
                    dgvVisitas.Columns["CedulaEnfermera"].HeaderText = "Cédula Enfermera";
                if (dgvVisitas.Columns["FechaHora"] != null)
                    dgvVisitas.Columns["FechaHora"].HeaderText = "Fecha y hora";
                if (dgvVisitas.Columns["PresionArterial"] != null)
                    dgvVisitas.Columns["PresionArterial"].HeaderText = "Presión arterial";
                if (dgvVisitas.Columns["Temperatura"] != null)
                    dgvVisitas.Columns["Temperatura"].HeaderText = "Temperatura (°C)";
                if (dgvVisitas.Columns["Pulso"] != null)
                    dgvVisitas.Columns["Pulso"].HeaderText = "Pulso";
                if (dgvVisitas.Columns["Oxigeno"] != null)
                    dgvVisitas.Columns["Oxigeno"].HeaderText = "Oxígeno (%)";
                if (dgvVisitas.Columns["Observaciones"] != null)
                    dgvVisitas.Columns["Observaciones"].HeaderText = "Observaciones";
            }
        }

        private void btnGuardarVisita_Click(object sender, EventArgs e)
        {
            if (_currentPatient == null)
            {
                MessageBox.Show("Primero debes buscar y seleccionar un paciente.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fechaHora = dtpFechaHoraVisita.Value;
            var motivo = txtMotivo.Text;
            var notas = txtNotas.Text;

            // Campos de signos vitales
            var presion = txtPresionArterial.Text.Trim();
            decimal temperatura = nudTemperatura.Value;
            int pulso = (int)nudPulso.Value;
            int oxigeno = (int)nudOxigeno.Value;

            var result = _useCase.RegistrarVisita(
                _currentPatient.PatientId,
                _nurseUserId,
                fechaHora,
                presion,
                temperatura,
                pulso,
                oxigeno,
                motivo,
                notas);

            MessageBox.Show(result.Message,
                result.Success ? "Éxito" : "Error",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.Success)
            {
                txtMotivo.Clear();
                txtNotas.Clear();
                txtPresionArterial.Clear();

                // 🔴 IMPORTANTE: nada de ceros fuera de rango:
                nudTemperatura.Value = nudTemperatura.Minimum; // 30
                nudPulso.Value = 0;                             // mínimo por defecto
                nudOxigeno.Value = nudOxigeno.Minimum;          // 0

                dtpFechaHoraVisita.Value = DateTime.Now;

                // Recargar visitas
                var refresh = _useCase.BuscarPacienteYVisitas(_currentPatient.Cedula);
                if (refresh.Success)
                    CargarVisitas(refresh.Visits);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
