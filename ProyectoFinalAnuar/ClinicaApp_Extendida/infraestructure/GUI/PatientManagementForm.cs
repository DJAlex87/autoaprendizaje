using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class PatientManagementForm : Form
    {
        private readonly AdminUseCase _adminUseCase;

        public PatientManagementForm()
        {
            InitializeComponent();
            LogoutUiHelper.AttachLogoutButton(this);
            IPatientRepository repo = ServiceLocator.CreatePatientRepository();
            _adminUseCase = new AdminUseCase(repo);

            cmbGenero.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;

            RefreshGrid();
        }

        private Patient GetPatientFromForm()
        {
            int.TryParse(txtPatientId.Text.Trim(), out var id);

            return new Patient
            {
                PatientId = id,
                Cedula = txtCedula.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Genero = cmbGenero.SelectedItem?.ToString() ?? "",
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }

        private void RefreshGrid()
        {
            dgvPatients.DataSource = _adminUseCase.GetAllPatients()
                .Select(p => new
                {
                    p.PatientId,
                    p.Cedula,
                    p.NombreCompleto,
                    p.Genero,
                    p.Telefono,
                    p.Email
                })
                .ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var patient = GetPatientFromForm();
            if (patient.PatientId == 0)
            {
                var result = _adminUseCase.CreatePatient(patient);
                if (!result.IsValid)
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Paciente creado correctamente.");
            }
            else
            {
                MessageBox.Show("En este ejemplo solo se implementa la creación. (Se podría agregar actualización)");
            }

            ClearForm();
            RefreshGrid();
        }

        private void ClearForm()
        {
            txtPatientId.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPatients.Rows[e.RowIndex];
            txtPatientId.Text = row.Cells["PatientId"].Value?.ToString() ?? "";
            txtCedula.Text = row.Cells["Cedula"].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells["NombreCompleto"].Value?.ToString() ?? "";
            txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cierra solo este formulario y vuelve al menú principal sin cerrar sesión
            this.Close();
        }
    }
}
