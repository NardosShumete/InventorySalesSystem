using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class ReportsUserControl : UserControl
    {
        private readonly ApiService _apiService;
        private List<SaleDto> _currentData;

        public ReportsUserControl()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _currentData = new List<SaleDto>();

            btnGenerate.Click += BtnGenerate_Click;
            btnFilter.Click += BtnFilter_Click;
            
            cmbPeriod.SelectedIndex = 0; // Default to Daily

            // Load Today's sales by default
            this.Load += async (s, e) => await LoadSalesInternal(DateTime.Today, DateTime.Today.AddDays(1).AddTicks(-1));
        }

        public async void RefreshData()
        {
            await LoadSalesInternal(DateTime.Today, DateTime.Today.AddDays(1).AddTicks(-1));
        }

        private async void BtnFilter_Click(object sender, EventArgs e)
        {
            DateTime date = dtpFilter.Value.Date;
            DateTime startDate = date;
            DateTime endDate = date.AddDays(1).AddTicks(-1);

            string period = cmbPeriod.SelectedItem?.ToString() ?? "Daily";

            if (period == "Weekly")
            {
                // Start of week (Monday)
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                startDate = date.AddDays(-1 * diff).Date;
                endDate = startDate.AddDays(7).AddTicks(-1);
            }
            else if (period == "Monthly")
            {
                startDate = new DateTime(date.Year, date.Month, 1);
                endDate = startDate.AddMonths(1).AddTicks(-1);
            }
            
            await LoadSalesInternal(startDate, endDate);
        }

        private async System.Threading.Tasks.Task LoadSalesInternal(DateTime startDate, DateTime endDate)
        {
            try
            {
                string query = $"sales/report?startDate={startDate:yyyy-MM-ddTHH:mm:ss}&endDate={endDate:yyyy-MM-ddTHH:mm:ss}";
                
                _currentData = await _apiService.GetAsync<List<SaleDto>>(query);
                gridSales.DataSource = _currentData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales: " + ex.Message);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Count == 0)
            {
                MessageBox.Show("No data to report.");
                return;
            }

            // Build Report Logic
            StringBuilder report = new StringBuilder();
            report.AppendLine("=== SALES REPORT ===");
            report.AppendLine($"Date Generated: {DateTime.Now}");
            
            decimal total = 0;
            foreach (var sale in _currentData)
            {
                string userInfo = sale.UserId.HasValue 
                    ? $" | Sold By: {sale.Username} (ID: {sale.UserId})" 
                    : " | Sold By: Unknown";
                    
                report.AppendLine($"Sale #{sale.Id} | Date: {sale.Date} | Total (Inc. Tax): {sale.TotalAmount:C2} | Tax: {sale.Tax:C2}{userInfo}");
                
                if (sale.Details != null && sale.Details.Count > 0)
                {
                    report.AppendLine("   Products:");
                    foreach (var item in sale.Details)
                    {
                        report.AppendLine($"     - [ID: {item.ProductId}] {item.ProductName} x {item.Quantity} @ {item.UnitPrice:C2} = {item.SubTotal:C2}");
                    }
                }
                report.AppendLine("-------------------------------");
                total += sale.TotalAmount;
            }
            
            report.AppendLine($"TOTAL SALES: {total:C2}");

            // Save File Dialog
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd}.txt";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, report.ToString());
                        MessageBox.Show("Report Saved Successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving user file: " + ex.Message);
                    }
                }
            }
        }
    }
}
