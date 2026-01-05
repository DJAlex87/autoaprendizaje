using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class SpecialtyCatalogForm : Form
    {
        private readonly SpecialtyCatalogUseCase _useCase;

        public SpecialtyCatalogForm()
        {
            InitializeComponent();
            LogoutUiHelper.AttachLogoutButton(this);

            ISpecialtyCatalogRepository repo = ServiceLocator.CreateSpecialtyCatalogRepository();
            _useCase = new SpecialtyCatalogUseCase(repo);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvSpecialties.DataSource = _useCase.GetAll()
                .Select(s => new
                {
                    s.SpecialtyId,
                    s.Nombre,
                    s.Description,
                    Activo = s.IsActive
                })
                .ToList();
        }

        private SpecialtyCatalog GetFromForm()
        {
            int.TryParse(txtId.Text.Trim(), out var id);

            return new SpecialtyCatalog
            {
                SpecialtyId = id,
                Nombre = txtNombre.Text.Trim(),
                Description = txtDescripcion.Text.Trim(),
                IsActive = chkActivo.Checked
            };
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            chkActivo.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var spec = GetFromForm();
            var result = _useCase.Save(spec);

            if (!result.IsValid)
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Especialidad guardada correctamente.");
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
                MessageBox.Show("Seleccione una especialidad para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar la especialidad?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            _useCase.Delete(id);
            ClearForm();
            RefreshGrid();
        }

        private void dgvSpecialties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSpecialties.Rows[e.RowIndex];
            txtId.Text = row.Cells["SpecialtyId"].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
            txtDescripcion.Text = row.Cells["Description"].Value?.ToString() ?? "";
            chkActivo.Checked = (bool)(row.Cells["Activo"].Value ?? false);
        }
    }
}
