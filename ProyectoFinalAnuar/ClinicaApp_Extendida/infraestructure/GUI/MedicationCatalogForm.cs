using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class MedicationCatalogForm : Form
    {
        private readonly InventoryUseCase _inventoryUseCase;

        public MedicationCatalogForm()
        {
            InitializeComponent();
            LogoutUiHelper.AttachLogoutButton(this);


            IMedicationCatalogRepository repo = ServiceLocator.CreateMedicationCatalogRepository();
            _inventoryUseCase = new InventoryUseCase(repo);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvMedications.DataSource = _inventoryUseCase.GetAllMedications()
                .Select(m => new
                {
                    m.MedicationId,
                    m.Nombre,
                    m.Description,
                    CostoBase = m.CostoBase,
                    Activo = m.IsActive
                })
                .ToList();
        }

        private MedicationCatalog GetFromForm()
        {
            int.TryParse(txtId.Text.Trim(), out var id);
            decimal.TryParse(txtCostoBase.Text.Trim(), out var costo);

            return new MedicationCatalog
            {
                MedicationId = id,
                Nombre = txtNombre.Text.Trim(),
                Description = txtDescripcion.Text.Trim(),
                CostoBase = costo,
                IsActive = chkActivo.Checked
            };
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCostoBase.Text = "";
            chkActivo.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var med = GetFromForm();
            var result = _inventoryUseCase.SaveMedication(med);

            if (!result.IsValid)
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Medicamento guardado correctamente.");
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
                MessageBox.Show("Seleccione un medicamento para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar el medicamento?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            _inventoryUseCase.DeleteMedication(id);
            ClearForm();
            RefreshGrid();
        }

        private void dgvMedications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMedications.Rows[e.RowIndex];
            txtId.Text = row.Cells["MedicationId"].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
            txtDescripcion.Text = row.Cells["Description"].Value?.ToString() ?? "";
            txtCostoBase.Text = row.Cells["CostoBase"].Value?.ToString() ?? "";
            chkActivo.Checked = (bool)(row.Cells["Activo"].Value ?? false);
        }
    }
}
