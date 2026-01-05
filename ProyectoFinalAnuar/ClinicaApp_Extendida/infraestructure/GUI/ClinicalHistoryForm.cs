using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class ClinicalHistoryForm : Form
    {
        private readonly ClinicalHistoryUseCase _useCase;

        public ClinicalHistoryForm()
        {
            InitializeComponent();
            _useCase = ServiceLocator.CreateClinicalHistoryUseCase();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cedula = txtCedulaPaciente.Text.Trim();
            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Ingresa la cédula del paciente.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var historia = _useCase.ObtenerHistoriaPaciente(cedula);
            dgvHistoria.DataSource = historia
                .Select(h => new
                {
                    h.Fecha,
                    h.CedulaMedico,
                    h.MotivoConsulta,
                    h.Diagnostico,
                    Medicamentos = h.Medicamentos.Count,
                    Procedimientos = h.Procedimientos.Count,
                    Ayudas = h.AyudasDiagnosticas.Count
                })
                .ToList();
        }

        private void btnGuardarAtencion_Click(object sender, EventArgs e)
        {
            var cedulaPaciente = txtCedulaPaciente.Text.Trim();
            var cedulaMedico = txtCedulaMedico.Text.Trim();

            var entry = new ClinicalHistoryEntry
            {
                Fecha = dtpFecha.Value,
                PatientCedula = cedulaPaciente,
                CedulaMedico = cedulaMedico,
                MotivoConsulta = txtMotivo.Text.Trim(),
                Sintomatologia = txtSintomas.Text.Trim(),
                Diagnostico = txtDiagnostico.Text.Trim()
            };

            // Por ahora solo soportamos UNA ayuda diagnóstica o UN medicamento sencillo
            // (después podemos hacer UI más sofisticada con grids y múltiples filas)

            if (chkEsAyudaDiagnostica.Checked)
            {
                // Solo ayuda diagnóstica
                entry.AyudasDiagnosticas.Add(new DiagnosticHelpOrder
                {
                    NumeroOrden = txtNumeroOrden.Text.Trim(),
                    DiagnosticHelpId = (int)numIdAyuda.Value,
                    Cantidad = (int)numCantidad.Value,
                    RequiresSpecialist = chkReqEspecialista.Checked,
                    SpecialtyId = chkReqEspecialista.Checked ? (int?)numIdEspecialidad.Value : null,
                    Item = (int)numItem.Value
                });
            }
            else
            {
                // Solo medicamento (como ejemplo simple)
                entry.Medicamentos.Add(new MedicationOrder
                {
                    NumeroOrden = txtNumeroOrden.Text.Trim(),
                    MedicationId = (int)numIdMedicamento.Value,
                    Dosis = txtDosis.Text.Trim(),
                    Duracion = txtDuracion.Text.Trim(),
                    Item = (int)numItem.Value
                });
            }

            var result = _useCase.RegistrarAtencion(entry);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(result.Message, "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnBuscar_Click(sender, e); // refresca la grilla
        }
    }
}
