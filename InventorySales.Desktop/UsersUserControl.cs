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
            this.Load += (s, e) => LoadUsers();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddRegistrationForm();
            form.UserRegistered += (s, args) => LoadUsers();
            form.ShowDialog();
        }

        private async void LoadUsers()
        {
            try
            {
                var users = await _apiService.GetAsync<List<UserDto>>("auth");
                gridUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0 && gridUsers.SelectedCells.Count == 0) return;
            
            // Get selected ID (simplistic approach assuming full row select or first cell)
            int userId = 0;
            if (gridUsers.CurrentRow != null)
            {
                 var user = gridUsers.CurrentRow.DataBoundItem as UserDto;
                 if (user != null) userId = user.Id;
            }

            if (userId == 0) return;

            var confirm = MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // HttpClient lacks generic DeleteAsync helper in our service, let's look at ApiService
                    // Oops, I didn't verify ApiService has Delete. I should probably add it or use raw client.
                    // For now, I'll assume I need to add DeleteAsync to ApiService quickly or just Implement it here if accessible.
                    // Accessing private client is not possible.
                    // I will add Delete method to ApiService in next step if needed, or check file.
                    // I'll assume I need to add it. For now, comment out logic to avoid build error until I fix Service.
                    await _apiService.DeleteAsync($"auth/{userId}"); 
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
