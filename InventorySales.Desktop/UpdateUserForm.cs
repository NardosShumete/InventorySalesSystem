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
            cmbRole.SelectedItem = user.Role;
            
            btnSave.Click += BtnSave_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show("Username cannot be empty");
                return;
            }

            var dto = new RegisterDto
            {
                Username = txtUser.Text,
                Password = txtPass.Text, // Can be empty to skip update
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
