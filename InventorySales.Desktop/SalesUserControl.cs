using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class SalesUserControl : UserControl
    {
        private readonly ApiService _apiService;
        private List<CartItem> _cart;

        public SalesUserControl()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _cart = new List<CartItem>();

            btnAdd.Click += BtnAdd_Click;
            btnCheckout.Click += BtnCheckout_Click;
            
            // Setup Grid with proper data binding
            gridCart.AutoGenerateColumns = false;
            
            // Create and configure columns with data binding
            var colProductId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "ID",
                Name = "ProductId",
                Width = 60
            };
            
            var colProductName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Product",
                Name = "ProductName",
                Width = 200
            };
            
            var colQuantity = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Qty",
                Name = "Quantity",
                Width = 60
            };
            
            var colUnitPrice = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Price",
                Name = "UnitPrice",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };
            
            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                Name = "Total",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };
            
            gridCart.Columns.Add(colProductId);
            gridCart.Columns.Add(colProductName);
            gridCart.Columns.Add(colQuantity);
            gridCart.Columns.Add(colUnitPrice);
            gridCart.Columns.Add(colTotal);
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduct.Text)) return;
            string search = txtProduct.Text;

            try
            {
                // Fetch products by search
                var products = await _apiService.GetAsync<List<ProductListDto>>($"products?search={search}");
                
                if (products == null || products.Count == 0)
                {
                    MessageBox.Show("Product not found");
                    return;
                }

                if (products.Count > 1)
                {
                    MessageBox.Show($"Found {products.Count} products. Please be more specific with the name or ID.");
                    return;
                }

                // Exactly one product found
                var product = products[0];

                if (product.StockQuantity <= 0)
                {
                    MessageBox.Show("Product is out of stock!");
                    return;
                }

                // Add to cart logic
                var existing = _cart.FirstOrDefault(c => c.ProductId == product.Id);
                if (existing != null)
                {
                    if (existing.Quantity + 1 > product.StockQuantity)
                    {
                         MessageBox.Show("Not enough stock.");
                         return;
                    }
                    existing.Quantity++;
                }
                else
                {
                    _cart.Add(new CartItem 
                    { 
                        ProductId = product.Id, 
                        ProductName = product.Name, 
                        UnitPrice = product.UnitPrice, 
                        Quantity = 1 
                    });
                }

                RefreshCart();
                txtProduct.Text = ""; // Reset input
                txtProduct.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RefreshCart()
        {
            gridCart.DataSource = null;
            gridCart.DataSource = _cart;
            
            decimal subTotal = _cart.Sum(c => c.Total);
            decimal tax = subTotal * 0.15m;
            decimal total = subTotal + tax;

            lblSubTotal.Text = $"SubTotal: {subTotal:C2}";
            lblTax.Text = $"Tax (15%): {tax:C2}";
            lblTotal.Text = $"Total: {total:C2}";
        }

        private async void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            var saleDto = new CreateSaleDto
            {
                Items = _cart.Select(c => new SaleDetailDto 
                { 
                    ProductId = c.ProductId, 
                    Quantity = c.Quantity, 
                    UnitPrice = c.UnitPrice 
                }).ToList()
            };

            try
            {
                await _apiService.PostAsync<CreateSaleDto, object>("sales", saleDto);
                MessageBox.Show("Sale Completed!");
                _cart.Clear();
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout Failed: " + ex.Message);
            }
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total => UnitPrice * Quantity;
    }

    public class CreateSaleDto
    {
        public List<SaleDetailDto> Items { get; set; } = new List<SaleDetailDto>();
    }

    public class SaleDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
