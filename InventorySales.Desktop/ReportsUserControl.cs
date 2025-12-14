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
            
            // Load Today's sales by default
            this.Load += async (s, e) => await LoadSalesInternal(DateTime.Today, null);
        }

        public async void RefreshData()
        {
            await LoadSalesInternal(DateTime.Today, null);
        }

        private async void BtnFilter_Click(object sender, EventArgs e)
        {
            DateTime? date = dtpFilter.Value;
            int? id = null;
            if (int.TryParse(txtIdFilter.Text, out int parsedId))
            {
                id = parsedId;
                date = null; // ID takes precedence? Or filter both? 
                // Requirement: "user can select by id or date". Usually implies ID is specific enough.
            }
            
            await LoadSalesInternal(date, id);
        }

        private async System.Threading.Tasks.Task LoadSalesInternal(DateTime? date, int? id)
        {
            try
            {
                string query = "sales/report?";
                if (id.HasValue) query += $"id={id}";
                else if (date.HasValue) query += $"date={date.Value:yyyy-MM-dd}";

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
                report.AppendLine($"Sale #{sale.Id} | Date: {sale.Date} | Total (Inc. Tax): {sale.TotalAmount:C2} | Tax: {sale.Tax:C2}");
                total += sale.TotalAmount;
            }
            
            report.AppendLine("-------------------------------");
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
