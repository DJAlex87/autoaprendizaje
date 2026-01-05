using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaApp.Domain.Model;
using ClinicaApp.Domain.Ports;
using ClinicaApp.Infraestructure.Config;
using ClinicaApp.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Infraestructure.GUI
{
    public partial class UserManagementForm : Form
    {
        private readonly IUserRepository _userRepository;

        public UserManagementForm()
        {
            InitializeComponent();
            LogoutUiHelper.AttachLogoutButton(this);

            // Botón global de "Cerrar sesión" arriba a la derecha
            LogoutUiHelper.AttachLogoutButton(this);

            // Repositorio apuntando a SQL Server (EF)
            _userRepository = ServiceLocator.CreateUserRepository();

            LoadRoles();
            LoadUsers();
        }

        // ======================
        //   CARGA DE ROLES
        // ======================
        private void LoadRoles()
        {
            try
            {
                var options = new DbContextOptionsBuilder<ClinicDbContext>()
                    .UseSqlServer(Config.Config.ConnectionString)
                    .Options;

                using var ctx = new ClinicDbContext(options);

                var roles = ctx.Roles
                               .OrderBy(r => r.RoleId)
                               .ToList();

                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "Name";   // propiedad Name de la entidad Role
                cmbRole.ValueMember = "RoleId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando roles: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        //   CARGA DE USUARIOS
        // ======================
        private void LoadUsers()
        {
            try
            {
                var users = _userRepository.GetAll().ToList();

                dgvUsers.AutoGenerateColumns = true;  // que genere columnas solo
                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        //       BOTONES
        // ======================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(txtUserId.Text, out int userId);
                bool isNew = userId == 0;

                User? user;
                if (isNew)
                {
                    user = new User();
                }
                else
                {
                    user = _userRepository.GetById(userId);
                    if (user == null)
                    {
                        MessageBox.Show("Usuario no encontrado.");
                        return;
                    }
                }

                user.Cedula = txtCedula.Text.Trim();
                user.NombreCompleto = txtNombre.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.Telefono = txtTelefono.Text.Trim();
                user.Direccion = txtDireccion.Text.Trim();
                user.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                user.Username = txtUsername.Text.Trim();
                user.PasswordHash = txtPassword.Text;  // para demo
                
                // Antes de asignar el RoleId, valida que haya un rol seleccionado
                var roleValue = cmbRole.SelectedValue;
                if (roleValue is null)
                {
                    MessageBox.Show("Debes seleccionar un rol para el usuario.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                user.RoleId = (int)roleValue;

                if (isNew)
                    _userRepository.Add(user);
                else
                    _userRepository.Update(user);

                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUserId.Text, out int userId) || userId == 0)
            {
                MessageBox.Show("Selecciona un usuario para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Seguro que deseas eliminar este usuario?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                _userRepository.Delete(userId);
                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        //   GRID → FORM
        // ======================

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvUsers.Rows[e.RowIndex].DataBoundItem is not User user)
                return;

            FillForm(user);
        }

        private void FillForm(User user)
        {
            txtUserId.Text = user.UserId.ToString();
            txtCedula.Text = user.Cedula;
            txtNombre.Text = user.NombreCompleto;
            txtEmail.Text = user.Email;
            txtTelefono.Text = user.Telefono;
            txtDireccion.Text = user.Direccion;
            dtpFechaNacimiento.Value = user.FechaNacimiento;
            txtUsername.Text = user.Username;
            txtPassword.Text = user.PasswordHash;
            cmbRole.SelectedValue = user.RoleId;
        }

        private void ClearForm()
        {
            txtUserId.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            dtpFechaNacimiento.Value = DateTime.Today;
        }
    }
}
