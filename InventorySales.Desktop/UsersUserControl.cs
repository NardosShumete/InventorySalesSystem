using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class UsersUserControl : UserControl
    {
        private readonly ApiService _apiService;
        
        public UsersUserControl()
        {
            InitializeComponent();
            _apiService = new ApiService();
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnFilterId.Click += (s, e) => LoadUsers(txtIdFilter.Text, null);
            btnFilterName.Click += (s, e) => LoadUsers(null, txtNameFilter.Text);

            this.Load += (s, e) => LoadUsers();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddRegistrationForm();
            form.UserRegistered += (s, args) => LoadUsers();
            form.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (gridUsers.CurrentRow?.DataBoundItem is UserDto user)
            {
                var form = new UpdateUserForm(user);
                form.UserUpdated += (s, args) => LoadUsers();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }
        }

        private async void LoadUsers(string idFilter = null, string nameFilter = null)
        {
            try
            {
                string query = "auth";
                var paramsList = new List<string>();
                if (!string.IsNullOrEmpty(idFilter)) paramsList.Add($"id={idFilter}");
                if (!string.IsNullOrEmpty(nameFilter)) paramsList.Add($"name={nameFilter}");
                
                if (paramsList.Count > 0)
                {
                    query += "?" + string.Join("&", paramsList);
                }

                var users = await _apiService.GetAsync<List<UserDto>>(query);
                gridUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (gridUsers.CurrentRow?.DataBoundItem is UserDto user)
            {
                var confirm = MessageBox.Show($"Delete user '{user.Username}'?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteAsync($"auth/{user.Id}"); 
                        MessageBox.Show("User Deleted.");
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete: " + ex.Message);
                    }
                }
            }
        }
    }
}
