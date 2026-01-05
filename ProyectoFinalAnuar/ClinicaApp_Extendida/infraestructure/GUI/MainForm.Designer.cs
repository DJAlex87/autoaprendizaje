using System.Windows.Forms;

namespace ClinicaApp.Infraestructure.GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null!;

        private Panel panelTop = null!;
        private Label lblBienvenida = null!;
        private Button btnLogout = null!;

        private Button btnGestionUsuarios = null!;
        private Button btnGestionPacientes = null!;
        private Button btnFacturacion = null!;
        private Button btnCatalogoMedicamentos = null!;
        private Button btnCatalogoEspecialidades = null!;
        private Button btnCatalogoProcedimientos = null!;
        private Button btnCatalogoAyudas = null!;
        private Button btnRegistroEnfermeria = null!;
        private Button btnModuloMedico = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.panelTop = new Panel();
            this.lblBienvenida = new Label();
            this.btnLogout = new Button();

            this.btnGestionUsuarios = new Button();
            this.btnGestionPacientes = new Button();
            this.btnFacturacion = new Button();
            this.btnCatalogoMedicamentos = new Button();
            this.btnCatalogoEspecialidades = new Button();
            this.btnCatalogoProcedimientos = new Button();
            this.btnCatalogoAyudas = new Button();
            this.btnRegistroEnfermeria = new Button();
            this.btnModuloMedico = new Button();

            this.SuspendLayout();

            // =========================================
            //  MAIN FORM (definimos primero el tamaño)
            // =========================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clínica - Menú principal";

            // =========================================
            // PANEL SUPERIOR (panelTop)
            // =========================================
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.BackColor = System.Drawing.Color.Gainsboro;
            this.panelTop.Padding = new Padding(10, 10, 10, 10);

            // lblBienvenida (dentro del panel)
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBienvenida.Location = new System.Drawing.Point(10, 15);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(83, 19);
            this.lblBienvenida.Text = "Bienvenido";

            // btnLogout (dentro del panel)
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Text = "Cerrar sesión";
            this.btnLogout.AutoSize = true;
            this.btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLogout.Size = new System.Drawing.Size(100, 27);

            // 👉 lo colocamos pegado a la derecha del panelTop
            this.btnLogout.Location = new System.Drawing.Point(
                this.panelTop.Width - this.btnLogout.Width - 20,
                10
            );

            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += btnLogout_Click;

            // Cuando el formulario cambie de tamaño, recolocamos el botón
            this.panelTop.Resize += (sender, args) =>
            {
                btnLogout.Location = new System.Drawing.Point(
                    panelTop.Width - btnLogout.Width - 20,
                    10
                );
            };

            // Agregar controles al panelTop
            this.panelTop.Controls.Add(this.lblBienvenida);
            this.panelTop.Controls.Add(this.btnLogout);

            // =========================================
            //  BOTONES DEL MENÚ PRINCIPAL
            // =========================================

            int left = 40;
            int top = 80; // Debajo del panelTop
            int width = 350;
            int height = 30;
            int dy = 40;

            // btnGestionUsuarios
            this.btnGestionUsuarios.Location = new System.Drawing.Point(left, top);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(width, height);
            this.btnGestionUsuarios.Text = "Gestión de Usuarios (RRHH)";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            top += dy;

            // btnGestionPacientes
            this.btnGestionPacientes.Location = new System.Drawing.Point(left, top);
            this.btnGestionPacientes.Name = "btnGestionPacientes";
            this.btnGestionPacientes.Size = new System.Drawing.Size(width, height);
            this.btnGestionPacientes.Text = "Gestión de Pacientes (Administrativo)";
            this.btnGestionPacientes.UseVisualStyleBackColor = true;
            this.btnGestionPacientes.Click += btnGestionPacientes_Click;
            top += dy;

            // btnFacturacion
            this.btnFacturacion.Location = new System.Drawing.Point(left, top);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(width, height);
            this.btnFacturacion.Text = "Facturación";
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += btnFacturacion_Click;
            top += dy;

            // btnCatalogoMedicamentos
            this.btnCatalogoMedicamentos.Location = new System.Drawing.Point(left, top);
            this.btnCatalogoMedicamentos.Name = "btnCatalogoMedicamentos";
            this.btnCatalogoMedicamentos.Size = new System.Drawing.Size(width, height);
            this.btnCatalogoMedicamentos.Text = "Catálogo de Medicamentos";
            this.btnCatalogoMedicamentos.UseVisualStyleBackColor = true;
            this.btnCatalogoMedicamentos.Click += btnCatalogoMedicamentos_Click;
            top += dy;

            // btnCatalogoEspecialidades
            this.btnCatalogoEspecialidades.Location = new System.Drawing.Point(left, top);
            this.btnCatalogoEspecialidades.Name = "btnCatalogoEspecialidades";
            this.btnCatalogoEspecialidades.Size = new System.Drawing.Size(width, height);
            this.btnCatalogoEspecialidades.Text = "Catálogo de Especialidades";
            this.btnCatalogoEspecialidades.UseVisualStyleBackColor = true;
            this.btnCatalogoEspecialidades.Click += btnCatalogoEspecialidades_Click;
            top += dy;

            // btnCatalogoProcedimientos
            this.btnCatalogoProcedimientos.Location = new System.Drawing.Point(left, top);
            this.btnCatalogoProcedimientos.Name = "btnCatalogoProcedimientos";
            this.btnCatalogoProcedimientos.Size = new System.Drawing.Size(width, height);
            this.btnCatalogoProcedimientos.Text = "Catálogo de Procedimientos";
            this.btnCatalogoProcedimientos.UseVisualStyleBackColor = true;
            this.btnCatalogoProcedimientos.Click += btnCatalogoProcedimientos_Click;
            top += dy;

            // btnCatalogoAyudas
            this.btnCatalogoAyudas.Location = new System.Drawing.Point(left, top);
            this.btnCatalogoAyudas.Name = "btnCatalogoAyudas";
            this.btnCatalogoAyudas.Size = new System.Drawing.Size(width, height);
            this.btnCatalogoAyudas.Text = "Catálogo de Ayudas Diagnósticas";
            this.btnCatalogoAyudas.UseVisualStyleBackColor = true;
            this.btnCatalogoAyudas.Click += btnCatalogoAyudas_Click;
            top += dy;

            // btnRegistroEnfermeria
            this.btnRegistroEnfermeria.Location = new System.Drawing.Point(left, top);
            this.btnRegistroEnfermeria.Name = "btnRegistroEnfermeria";
            this.btnRegistroEnfermeria.Size = new System.Drawing.Size(width, height);
            this.btnRegistroEnfermeria.Text = "Registro de Visitas (Enfermería)";
            this.btnRegistroEnfermeria.UseVisualStyleBackColor = true;
            this.btnRegistroEnfermeria.Click += btnRegistroEnfermeria_Click;
            top += dy;

            // btnModuloMedico
            this.btnModuloMedico.Location = new System.Drawing.Point(left, top);
            this.btnModuloMedico.Name = "btnModuloMedico";
            this.btnModuloMedico.Size = new System.Drawing.Size(width, height);
            this.btnModuloMedico.Text = "Módulo Médico (Órdenes / Historia)";
            this.btnModuloMedico.UseVisualStyleBackColor = true;
            this.btnModuloMedico.Click += btnModuloMedico_Click;

            // Añadir controles al formulario
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.btnGestionPacientes);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.btnCatalogoMedicamentos);
            this.Controls.Add(this.btnCatalogoEspecialidades);
            this.Controls.Add(this.btnCatalogoProcedimientos);
            this.Controls.Add(this.btnCatalogoAyudas);
            this.Controls.Add(this.btnRegistroEnfermeria);
            this.Controls.Add(this.btnModuloMedico);

            this.ResumeLayout(false);
        }
    }
}
