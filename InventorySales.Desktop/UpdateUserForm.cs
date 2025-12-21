using System;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class UpdateUserForm : Form
    {
        private readonly ApiService _apiService;
        private readonly UserDto _user;
        public event EventHandler UserUpdated;

        public UpdateUserForm(UserDto user)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _user = user;
            
            txtUser.Text = user.Username;
            txtEmail.Text = user.Email;
            cmbRole.SelectedItem = user.Role;
            
            btnSave.Click += BtnSave_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Username and Email cannot be empty");
                return;
            }

            // Standard email validation regex
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                 MessageBox.Show("Please enter a valid email address (e.g. user@domain.com)");
                 return;
            }

            if (!string.IsNullOrEmpty(txtPass.Text) && txtPass.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");
                return;
            }

            var dto = new RegisterDto
            {
                Username = txtUser.Text,
                Email = txtEmail.Text,
                Password = string.IsNullOrWhiteSpace(txtPass.Text) ? null : txtPass.Text,
                Role = cmbRole.SelectedItem?.ToString() ?? "User"
            };

            try
            {
                await _apiService.PutAsync($"auth/{_user.Id}", dto);
                MessageBox.Show("User Updated Successfully!");
                UserUpdated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message);
            }
        }
    }
}
