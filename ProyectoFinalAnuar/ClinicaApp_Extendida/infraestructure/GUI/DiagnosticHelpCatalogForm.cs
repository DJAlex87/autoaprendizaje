using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class DiagnosticHelpCatalogForm : Form
    {
        private readonly DiagnosticHelpCatalogUseCase _useCase;
        private readonly SpecialtyCatalogUseCase _specialtyUseCase;
        private List<SpecialtyCatalog> _specialties = new();

        public DiagnosticHelpCatalogForm()
        {
            InitializeComponent();
            LogoutUiHelper.AttachLogoutButton(this);


            var diagRepo = ServiceLocator.CreateDiagnosticHelpCatalogRepository();
            var specRepo = ServiceLocator.CreateSpecialtyCatalogRepository();

            _useCase = new DiagnosticHelpCatalogUseCase(diagRepo);
            _specialtyUseCase = new SpecialtyCatalogUseCase(specRepo);

            LoadSpecialties();
            RefreshGrid();
        }

        private void LoadSpecialties()
        {
            _specialties = _specialtyUseCase.GetAll().Where(s => s.IsActive).ToList();

            cmbSpecialty.DisplayMember = "Nombre";
            cmbSpecialty.ValueMember = "SpecialtyId";
            cmbSpecialty.DataSource = _specialties;
            cmbSpecialty.SelectedIndex = -1;
        }

        private void RefreshGrid()
        {
            dgvDiagnosticHelps.DataSource = _useCase.GetAll()
                .Select(d => new
                {
                    d.DiagnosticHelpId,
                    d.Nombre,
                    d.Description,
                    CostoBase = d.CostoBase,
                    RequiereEspecialista = d.RequiresSpecialist,
                    Especialidad = d.Specialty != null ? d.Specialty.Nombre : "",
                    d.IsActive
                })
                .ToList();
        }

        private DiagnosticHelpCatalog GetFromForm()
        {
            int.TryParse(txtId.Text.Trim(), out var id);
            decimal.TryParse(txtCostoBase.Text.Trim(), out var costo);

            int? specialtyId = null;

            // Corrección segura: evita unboxing de null
            if (cmbSpecialty.SelectedValue is int value)
            {
                specialtyId = value;
            }

            return new DiagnosticHelpCatalog
            {
                DiagnosticHelpId = id,
                Nombre = txtNombre.Text.Trim(),
                Description = txtDescripcion.Text.Trim(),
                CostoBase = costo,
                RequiresSpecialist = chkReqEspecialista.Checked,
                SpecialtyId = specialtyId,
                IsActive = chkActivo.Checked
            };
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCostoBase.Text = "";
            chkReqEspecialista.Checked = false;
            chkActivo.Checked = true;
            cmbSpecialty.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var diag = GetFromForm();
            var result = _useCase.Save(diag);

            if (!result.IsValid)
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Ayuda diagnóstica guardada correctamente.");
            ClearForm();
            RefreshGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var id) || id == 0)
            {
                MessageBox.Show("Seleccione una ayuda diagnóstica para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar la ayuda diagnóstica?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            _useCase.Delete(id);
            ClearForm();
            RefreshGrid();
        }

        private void dgvDiagnosticHelps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDiagnosticHelps.Rows[e.RowIndex];
            txtId.Text = row.Cells["DiagnosticHelpId"].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
            txtDescripcion.Text = row.Cells["Description"].Value?.ToString() ?? "";
            txtCostoBase.Text = row.Cells["CostoBase"].Value?.ToString() ?? "";
            chkReqEspecialista.Checked = (bool)(row.Cells["RequiereEspecialista"].Value ?? false);
            chkActivo.Checked = (bool)(row.Cells["IsActive"].Value ?? false);

            var espNombre = row.Cells["Especialidad"].Value?.ToString();
            if (!string.IsNullOrEmpty(espNombre))
            {
                var esp = _specialties.FirstOrDefault(s => s.Nombre == espNombre);
                if (esp != null)
                    cmbSpecialty.SelectedValue = esp.SpecialtyId;
            }
            else
            {
                cmbSpecialty.SelectedIndex = -1;
            }
        }
    }
}
