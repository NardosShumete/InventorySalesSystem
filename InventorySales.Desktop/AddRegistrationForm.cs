using System;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class AddRegistrationForm : Form
    {
        private readonly ApiService _apiService;
        public event EventHandler UserRegistered;

        public AddRegistrationForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            cmbRole.SelectedIndex = 1; // Default to User
            btnSave.Click += BtnSave_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill username, email and password");
                return;
            }

            // Standard email validation regex
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                 MessageBox.Show("Please enter a valid email address (e.g. user@domain.com)");
                 return;
            }

            if (txtPass.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");
                return;
            }

            var dto = new RegisterDto
            {
                Username = txtUser.Text,
                Email = txtEmail.Text,
                Password = txtPass.Text,
                Role = cmbRole.SelectedItem.ToString()
            };

            try
            {
                await _apiService.PostAsync<RegisterDto, object>("auth/register", dto);
                MessageBox.Show("User Registered Successfully!");
                UserRegistered?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Failed: " + ex.Message);
            }
        }
    }
}
