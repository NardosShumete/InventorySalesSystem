using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class DashboardForm : Form
    {
        // Views
        private UserControl _currentView;
        private ProductsUserControl _productsView;
        private SalesUserControl _salesView;
        private UsersUserControl _usersView;
        private ReportsUserControl _reportsView;

        public DashboardForm()
        {
            InitializeComponent();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            // Create controls
            _productsView = new ProductsUserControl();
            _salesView = new SalesUserControl();
            _usersView = new UsersUserControl();
            _reportsView = new ReportsUserControl();

            // Prepare them
            _productsView.Dock = DockStyle.Fill;
            _salesView.Dock = DockStyle.Fill;
            _usersView.Dock = DockStyle.Fill;
            _reportsView.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(_productsView);
            contentPanel.Controls.Add(_salesView);
            contentPanel.Controls.Add(_usersView);
            contentPanel.Controls.Add(_reportsView);

            // Wire Events
            btnDashboard.Click += (s, e) => ShowView(null);
            btnProducts.Click += (s, e) => ShowView(_productsView);
            btnSales.Click += (s, e) => ShowView(_salesView);
            btnReports.Click += (s, e) => ShowView(_reportsView);
            btnUsers.Click += (s, e) => ShowView(_usersView);
            btnExit.Click += BtnExit_Click;
            btnLogout.Click += BtnLogout_Click;

            // Start at Dashboard
            ShowView(null);

            // Access Control
            if (!Session.IsAdmin)
            {
                btnUsers.Visible = false;
                btnReports.Visible = false;
                // btnProducts.Visible = false; // User kept products? "normal user shoud limte few functionality".
                // Assuming User can see products/sales/dashboard.
            }
        }

        private void ShowView(UserControl view)
        {
            // Hide all
            _productsView.Visible = false;
            _salesView.Visible = false;
            _usersView.Visible = false;
            _reportsView.Visible = false;

            if (view != null)
            {
                view.Visible = true;
                view.BringToFront();

                if (view is ReportsUserControl reportView)
                {
                    reportView.RefreshData();
                }
            }
            else
            {
                // Refresh Dashboard Data when showing "Overview"
                LoadDashboardData();
            }
        }

        private async void LoadDashboardData()
        {
            var api = new ApiService();
            try
            {
                var data = await api.GetAsync<DashboardDto>("reports/dashboard");
                lblVal1.Text = data.DailySales.ToString("C2");
                lblVal2.Text = $"{data.LowStockCount} Items";
                lblVal3.Text = data.TotalProducts.ToString();
            }
            catch { }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            // Close entire application
            Application.Exit();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Create and show new login form
            var loginForm = new LoginForm();
            loginForm.Show();
            
            // Remove the FormClosed event handler to prevent Application.Exit
            this.FormClosed -= (s, args) => Application.Exit();
            
            // Close dashboard
            this.Close();
        }
    }

}
