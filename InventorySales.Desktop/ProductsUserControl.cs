using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class ProductsUserControl : UserControl
    {
        private readonly ApiService _apiService;
        private string _currentUserRole;
        private List<ProductListDto> _allProducts;

        public ProductsUserControl()
        {
            InitializeComponent();
            _apiService = new ApiService();
            
            // Get current user role from session
            _currentUserRole = Session.Role ?? "User";
            
            // Wire up events
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyPress += TxtSearch_KeyPress;
            
            // Show/hide update and delete buttons based on role
            bool isAdmin = _currentUserRole == "Admin";
            btnUpdate.Visible = isAdmin;
            btnDelete.Visible = isAdmin;
            
            // Load data when control is visible or created
            this.Load += ProductsUserControl_Load;
        }

        private void ProductsUserControl_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddProductForm();
            form.ProductAdded += (s, args) => LoadProducts(); // Refresh on success
            form.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentUserRole != "Admin")
            {
                MessageBox.Show("Only administrators can update products.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedProduct = (ProductListDto)gridProducts.SelectedRows[0].DataBoundItem;
            var form = new UpdateProductForm(selectedProduct.Id);
            form.ProductUpdated += (s, args) => LoadProducts(); // Refresh on success
            form.ShowDialog();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_currentUserRole != "Admin")
            {
                MessageBox.Show("Only administrators can delete products.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProduct = (ProductListDto)gridProducts.SelectedRows[0].DataBoundItem;
            
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete '{selectedProduct.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _apiService.DeleteAsync($"products/{selectedProduct.Id}");
                    MessageBox.Show("Product deleted successfully.");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void ApplyFilters()
        {
            if (_allProducts == null) return;

            var filtered = _allProducts.AsEnumerable();
            string searchText = txtSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                // Check if it's a stock level filter (e.g., "less than 100", "<100", "< 100")
                if (TryParseStockFilter(searchText, out int stockThreshold, out string comparison))
                {
                    filtered = comparison switch
                    {
                        "<" => filtered.Where(p => p.StockQuantity < stockThreshold),
                        ">" => filtered.Where(p => p.StockQuantity > stockThreshold),
                        "<=" => filtered.Where(p => p.StockQuantity <= stockThreshold),
                        ">=" => filtered.Where(p => p.StockQuantity >= stockThreshold),
                        "=" => filtered.Where(p => p.StockQuantity == stockThreshold),
                        _ => filtered
                    };
                }
                else
                {
                    // Search by name, category, ID, or stock quantity
                    searchText = searchText.ToLower();
                    bool isNumeric = int.TryParse(searchText, out int searchNum);

                    filtered = filtered.Where(p =>
                        (p.Name != null && p.Name.ToLower().Contains(searchText)) ||
                        (p.CategoryName != null && p.CategoryName.ToLower().Contains(searchText)) ||
                        p.Id.ToString() == searchText ||
                        (isNumeric && p.StockQuantity == searchNum)
                    );
                }
            }

            gridProducts.DataSource = filtered.ToList();
        }

        private bool TryParseStockFilter(string input, out int threshold, out string comparison)
        {
            threshold = 0;
            comparison = "";
            input = input.Trim().ToLower();

            // Handle "less than X" or "greater than X" format
            if (input.StartsWith("less than ") || input.StartsWith("lessthan"))
            {
                var numPart = input.Replace("less than", "").Replace("lessthan", "").Trim();
                if (int.TryParse(numPart, out threshold))
                {
                    comparison = "<";
                    return true;
                }
            }
            else if (input.StartsWith("greater than ") || input.StartsWith("greaterthan"))
            {
                var numPart = input.Replace("greater than", "").Replace("greaterthan", "").Trim();
                if (int.TryParse(numPart, out threshold))
                {
                    comparison = ">";
                    return true;
                }
            }
            // Handle operator format: <100, >50, <=100, >=50, =100
            else if (input.StartsWith("<="))
            {
                if (int.TryParse(input.Substring(2).Trim(), out threshold))
                {
                    comparison = "<=";
                    return true;
                }
            }
            else if (input.StartsWith(">="))
            {
                if (int.TryParse(input.Substring(2).Trim(), out threshold))
                {
                    comparison = ">=";
                    return true;
                }
            }
            else if (input.StartsWith("<"))
            {
                if (int.TryParse(input.Substring(1).Trim(), out threshold))
                {
                    comparison = "<";
                    return true;
                }
            }
            else if (input.StartsWith(">"))
            {
                if (int.TryParse(input.Substring(1).Trim(), out threshold))
                {
                    comparison = ">";
                    return true;
                }
            }
            else if (input.StartsWith("="))
            {
                if (int.TryParse(input.Substring(1).Trim(), out threshold))
                {
                    comparison = "=";
                    return true;
                }
            }

            return false;
        }

        public async void LoadProducts()
        {
            try
            {
                _allProducts = await _apiService.GetAsync<List<ProductListDto>>("products");
                gridProducts.DataSource = _allProducts;
                
                // Optional: Formatting headers
                if (gridProducts.Columns["Id"] != null) gridProducts.Columns["Id"].HeaderText = "ID";
                if (gridProducts.Columns["CategoryName"] != null) gridProducts.Columns["CategoryName"].HeaderText = "Category";
                if (gridProducts.Columns["UnitPrice"] != null) 
                {
                    gridProducts.Columns["UnitPrice"].HeaderText = "Price";
                    gridProducts.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                }
                if (gridProducts.Columns["StockQuantity"] != null) gridProducts.Columns["StockQuantity"].HeaderText = "Stock";
                if (gridProducts.Columns["ReorderLevel"] != null) gridProducts.Columns["ReorderLevel"].HeaderText = "Reorder Level";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
    }

}
