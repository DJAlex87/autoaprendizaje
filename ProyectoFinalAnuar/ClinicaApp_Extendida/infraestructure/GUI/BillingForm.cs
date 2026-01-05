using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClinicaApp.Application.UseCases;
using ClinicaApp.Domain.Model;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class BillingForm : Form
    {
        private readonly BillingUseCase _billingUseCase;

        public BillingForm()
        {
            InitializeComponent();

            // Botón de cerrar sesión en la barra superior
            LogoutUiHelper.AttachLogoutButton(this);

            // Use case de facturación vía ServiceLocator
            _billingUseCase = ServiceLocator.CreateBillingUseCase();

            // Inicializar defaults (fecha, año, etc.)
            dtpInvoiceDate.Value = DateTime.Now;
            if (nudYear.Value <= 0)
                nudYear.Value = DateTime.Now.Year;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Regresa al MainForm sin cerrar sesión
            this.Close();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Búsqueda de paciente aún no implementada.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Carga en la grilla dgvDetalles los ítems de una factura existente.
        /// </summary>
        private void CargarDetallesFactura(int invoiceId)
        {
            var (success, message, details) = _billingUseCase.ObtenerDetallesFactura(invoiceId);

            if (!success)
            {
                dgvDetalles.DataSource = null;
                // Si quieres ver mensajes de info, descomenta:
                // if (!string.IsNullOrWhiteSpace(message))
                //     MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Las columnas ya están creadas en el Designer con sus DataPropertyName
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.DataSource = details;
        }

        private void btnVerFacturas_Click(object sender, EventArgs e)
        {
            // Abre el visor de facturas (listado) sin cerrar el BillingForm
            using var frm = new InvoiceListForm();
            frm.ShowDialog(this);

            // Si en el listado se seleccionó alguna factura, la traemos de vuelta
            if (frm.FacturaSeleccionada != null)
            {
                var inv = frm.FacturaSeleccionada;

                // Rellenar encabezado
                txtPatientId.Text = inv.PatientId.ToString();
                txtCedulaMedico.Text = inv.CedulaMedico;
                txtPolicyId.Text = inv.PolicyId?.ToString() ?? string.Empty;
                txtCompanyName.Text = inv.CompanyName ?? string.Empty;
                txtPolicyNumber.Text = inv.PolicyNumber ?? string.Empty;
                dtpPolicyEndDate.Value = inv.PolicyEndDate ?? DateTime.Now;
                txtDaysRemaining.Text = inv.PolicyDaysRemaining?.ToString() ?? string.Empty;
                dtpInvoiceDate.Value = inv.InvoiceDate;
                nudTotalAmount.Value = inv.TotalAmount;
                nudCopay.Value = inv.CopayAmount;
                nudInsurerAmount.Value = inv.InsurerAmount;
                nudYear.Value = inv.Year;

                // Cargar en la grilla los detalles de esa factura
                CargarDetallesFactura(inv.InvoiceId);
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                // ============================
                //  1. Construir InvoiceHeader
                // ============================
                int patientId = 0;
                int.TryParse(txtPatientId.Text.Trim(), out patientId);

                int? policyId = null;
                if (int.TryParse(txtPolicyId.Text.Trim(), out var polAux) && polAux > 0)
                    policyId = polAux;

                int? daysRemaining = null;
                if (int.TryParse(txtDaysRemaining.Text.Trim(), out var daysAux) && daysAux >= 0)
                    daysRemaining = daysAux;

                int year = (int)nudYear.Value;

                decimal total = nudTotalAmount.Value;
                decimal copago = nudCopay.Value;
                decimal aseguradora = nudInsurerAmount.Value;

                var header = new InvoiceHeader
                {
                    PatientId = patientId,
                    CedulaMedico = txtCedulaMedico.Text.Trim(),
                    PolicyId = policyId,
                    CompanyName = string.IsNullOrWhiteSpace(txtCompanyName.Text)
                        ? null
                        : txtCompanyName.Text.Trim(),
                    PolicyNumber = string.IsNullOrWhiteSpace(txtPolicyNumber.Text)
                        ? null
                        : txtPolicyNumber.Text.Trim(),
                    PolicyEndDate = dtpPolicyEndDate.Value.Date,
                    PolicyDaysRemaining = daysRemaining,
                    InvoiceDate = dtpInvoiceDate.Value,
                    TotalAmount = total,
                    CopayAmount = copago,
                    InsurerAmount = aseguradora,
                    Year = year
                };

                // ============================
                //  2. Construir detalles
                // ============================
                var details = new List<InvoiceDetail>();

                if (dgvDetalles != null && dgvDetalles.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalles.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var desc = row.Cells["Description"].Value?.ToString();
                        if (string.IsNullOrWhiteSpace(desc)) continue;

                        int qty = 1;
                        int.TryParse(row.Cells["Quantity"].Value?.ToString(), out qty);

                        decimal unitCost = 0m;
                        decimal.TryParse(row.Cells["UnitCost"].Value?.ToString(), out unitCost);

                        var itemType = row.Cells["ItemType"].Value?.ToString() ?? "Otro";

                        details.Add(new InvoiceDetail
                        {
                            Description = desc.Trim(),
                            Quantity = qty <= 0 ? 1 : qty,
                            UnitCost = unitCost < 0 ? 0 : unitCost,
                            ItemType = itemType
                            // LineTotal se calcula en BillingUseCase si viene en 0
                        });
                    }
                }

                // Si no se capturó ningún detalle en la grilla,
                // creamos uno genérico para que no falle la validación
                if (details.Count == 0 && total > 0)
                {
                    details.Add(new InvoiceDetail
                    {
                        Description = "Servicios facturados",
                        Quantity = 1,
                        UnitCost = total,
                        LineTotal = total,
                        ItemType = "Otro"
                    });
                }

                // ============================
                //  3. Llamar al UseCase
                // ============================
                var result = _billingUseCase.GenerarFactura(header, details);

                MessageBox.Show(
                    result.Message,
                    result.Success ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Success && result.Invoice != null)
                {
                    // Opcional: limpiar montos si quieres preparar para otra factura
                    // (la grilla se actualiza con los detalles guardados en BD)
                    nudTotalAmount.Value = 0;
                    nudCopay.Value = 0;
                    nudInsurerAmount.Value = 0;

                    // Cargar en la grilla los detalles tal como quedaron guardados
                    CargarDetallesFactura(result.Invoice.InvoiceId);
                }
            }
            catch (Exception ex)
            {
                // AHORA sí mostramos TODO el detalle del error
                MessageBox.Show(
                    "Ocurrió un error al generar la factura.\n\n" + ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
