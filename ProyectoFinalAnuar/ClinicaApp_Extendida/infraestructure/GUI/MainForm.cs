using System;
using System.Windows.Forms;
using ClinicaApp;                 // Para usar SessionManager
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;

        private const int ROLE_RECURSOS_HUMANOS = 1;
        private const int ROLE_ADMINISTRATIVO = 2;
        private const int ROLE_SOPORTE_INFO = 3;
        private const int ROLE_ENFERMERA = 4;
        private const int ROLE_MEDICO = 5;

        public MainForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            ConfigureWelcomeText();
            ConfigureMenuByRole();
            // 🔴 IMPORTANTE: ya NO llamamos a CreateLogoutButton(), 
            // el botón viene del diseñador.
        }

        private void ConfigureWelcomeText()
        {
            lblBienvenida.Text =
                $"Bienvenido, {_currentUser.NombreCompleto} ({_currentUser.Username}) - Rol: {_currentUser.RoleId}";
        }

        private void HideAllButtons()
        {
            btnGestionUsuarios.Visible = false;
            btnGestionPacientes.Visible = false;
            btnFacturacion.Visible = false;
            btnCatalogoMedicamentos.Visible = false;
            btnCatalogoEspecialidades.Visible = false;
            btnCatalogoProcedimientos.Visible = false;
            btnCatalogoAyudas.Visible = false;
            btnRegistroEnfermeria.Visible = false;
            btnModuloMedico.Visible = false;
        }

        private void ConfigureMenuByRole()
        {
            HideAllButtons();

            switch (_currentUser.RoleId)
            {
                case ROLE_RECURSOS_HUMANOS:
                    btnGestionUsuarios.Visible = true;
                    break;

                case ROLE_ADMINISTRATIVO:
                    btnGestionPacientes.Visible = true;
                    btnFacturacion.Visible = true;
                    break;

                case ROLE_SOPORTE_INFO:
                    btnCatalogoMedicamentos.Visible = true;
                    btnCatalogoEspecialidades.Visible = true;
                    btnCatalogoProcedimientos.Visible = true;
                    btnCatalogoAyudas.Visible = true;
                    break;

                case ROLE_ENFERMERA:
                    btnRegistroEnfermeria.Visible = true;
                    break;

                case ROLE_MEDICO:
                    btnModuloMedico.Visible = true;
                    break;

                default:
                    MessageBox.Show("El rol del usuario no tiene menú configurado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        // ==========================
        //   BOTÓN CERRAR SESIÓN
        // ==========================
        // Este handler se asigna en el Designer:
        // btnLogout.Click += btnLogout_Click;
        private void btnLogout_Click(object? sender, EventArgs e)
        {
            SessionManager.Logout();
        }

        // ======= HANDLERS DE BOTONES =======

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            using var frm = new UserManagementForm();
            frm.ShowDialog(this);
        }

        private void btnGestionPacientes_Click(object sender, EventArgs e)
        {
            using var frm = new PatientManagementForm();
            frm.ShowDialog(this);
        }

        private void btnCatalogoMedicamentos_Click(object sender, EventArgs e)
        {
            using var frm = new MedicationCatalogForm();
            frm.ShowDialog(this);
        }

        private void btnCatalogoEspecialidades_Click(object sender, EventArgs e)
        {
            using var frm = new SpecialtyCatalogForm();
            frm.ShowDialog(this);
        }

        private void btnCatalogoProcedimientos_Click(object sender, EventArgs e)
        {
            using var frm = new ProcedureCatalogForm();
            frm.ShowDialog(this);
        }

        private void btnCatalogoAyudas_Click(object sender, EventArgs e)
        {
            using var frm = new DiagnosticHelpCatalogForm();
            frm.ShowDialog(this);
        }

        private void btnRegistroEnfermeria_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Registro de Visitas de Enfermería.
            using var frm = new NursingVisitForm();
            frm.ShowDialog(this);
        }

        private void btnModuloMedico_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Historia Clínica (NoSQL)
            using var frm = new ClinicalHistoryForm();
            frm.ShowDialog(this);
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            // ANTES: mostraba "Módulo de Facturación en construcción."
            // AHORA: abre el formulario de facturación.
            using var frm = new BillingForm();
            frm.ShowDialog(this);
        }
    }
}
