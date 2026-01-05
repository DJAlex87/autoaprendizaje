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
    public partial class ProcedureCatalogForm : Form
    {
        private readonly ProcedureCatalogUseCase _useCase;
        private readonly SpecialtyCatalogUseCase _specialtyUseCase;
        private List<SpecialtyCatalog> _specialties = new();

        public ProcedureCatalogForm()
        {
            InitializeComponent();
            LogoutUiHelper.AttachLogoutButton(this);

            var procRepo = ServiceLocator.CreateProcedureCatalogRepository();
            var specRepo = ServiceLocator.CreateSpecialtyCatalogRepository();

            _useCase = new ProcedureCatalogUseCase(procRepo);
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
            dgvProcedures.DataSource = _useCase.GetAll()
                .Select(p => new
                {
                    p.ProcedureId,
                    p.Nombre,
                    p.Description,
                    CostoBase = p.CostoBase,
                    RequiereEspecialista = p.RequiresSpecialist,
                    Especialidad = p.Specialty != null ? p.Specialty.Nombre : "",
                    p.IsActive
                })
                .ToList();
        }

        private ProcedureCatalog GetFromForm()
        {
            int.TryParse(txtId.Text.Trim(), out var id);
            decimal.TryParse(txtCostoBase.Text.Trim(), out var costo);

            int? specialtyId = null;
            // Solo asigna si SelectedValue NO es null y es un int
            if (cmbSpecialty.SelectedValue is int value)
            {
                specialtyId = value;
            }

            return new ProcedureCatalog
            {
                ProcedureId = id,
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
            var proc = GetFromForm();
            var result = _useCase.Save(proc);

            if (!result.IsValid)
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Procedimiento guardado correctamente.");
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
                MessageBox.Show("Seleccione un procedimiento para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar el procedimiento?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            _useCase.Delete(id);
            ClearForm();
            RefreshGrid();
        }

        private void dgvProcedures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProcedures.Rows[e.RowIndex];
            txtId.Text = row.Cells["ProcedureId"].Value?.ToString() ?? "";
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
