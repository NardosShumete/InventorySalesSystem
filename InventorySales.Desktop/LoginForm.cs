using System;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var user = txtUsername.Text;
            var pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try 
            {
                var loginDto = new LoginDto { Username = user, Password = pass };
                var result = await _apiService.PostAsync<LoginDto, UserDto>("auth/login", loginDto);
                
                // Store Session
                Session.UserId = result.Id;
                Session.Username = result.Username;
                Session.Role = result.Role;

                // Show dashboard
                var dashboard = new DashboardForm();
                dashboard.Show();
                
                // Close login form
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed: " + ex.Message);
            }
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
