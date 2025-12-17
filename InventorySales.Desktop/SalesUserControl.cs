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
            btnSearchId.Click += BtnSearchId_Click;
            btnSearchName.Click += BtnSearchName_Click;
            btnSearchQty.Click += BtnSearchQty_Click;
            btnSearchPrice.Click += BtnSearchPrice_Click;
            
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

        private async void BtnSearchId_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text)) return;
            try
            {
                var product = await _apiService.GetAsync<ProductDto>($"products/{txtProductId.Text}");
                if (product != null)
                {
                    txtProductName.Text = product.Name;
                    txtPrice.Text = product.UnitPrice.ToString("F2");
                }
            }
            catch
            {
                MessageBox.Show("Product ID not found.");
            }
        }

        private async void BtnSearchName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text)) return;
            try
            {
                var products = await _apiService.GetAsync<List<ProductListDto>>($"products?search={txtProductName.Text}");
                if (products != null && products.Count > 0)
                {
                    var product = products[0];
                    txtProductId.Text = product.Id.ToString();
                    txtPrice.Text = product.UnitPrice.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Product Name not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching product: " + ex.Message);
            }
        }

        private async void BtnSearchQty_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text)) return;
            try
            {
                var product = await _apiService.GetAsync<ProductDto>($"products/{txtProductId.Text}");
                if (product != null)
                {
                    int requestedQty = (int)txtQuantity.Value;
                    if (requestedQty > product.StockQuantity)
                    {
                        MessageBox.Show($"Not enough stock! Current stock: {product.StockQuantity}");
                    }
                    else
                    {
                        MessageBox.Show($"Stock is sufficient. (Available: {product.StockQuantity})");
                    }
                }
            }
            catch { }
        }

        private async void BtnSearchPrice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text)) return;
            try
            {
                var product = await _apiService.GetAsync<ProductDto>($"products/{txtProductId.Text}");
                if (product != null)
                {
                    txtPrice.Text = product.UnitPrice.ToString("F2");
                }
            }
            catch { }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                MessageBox.Show("Please select a product first (ID or Name search).");
                return;
            }

            try
            {
                int productId = int.Parse(txtProductId.Text);
                int quantity = (int)txtQuantity.Value;
                
                if (quantity <= 0)
                {
                    MessageBox.Show("Quantity must be at least 1.");
                    return;
                }

                // Fetch current stock info to be safe
                var product = await _apiService.GetAsync<ProductDto>($"products/{productId}");
                
                if (product == null)
                {
                    MessageBox.Show("Product not found.");
                    return;
                }

                if (product.StockQuantity < (GetCartQuantity(productId) + quantity))
                {
                    MessageBox.Show($"Not enough stock! Available: {product.StockQuantity}");
                    return;
                }

                // Add to cart logic
                var existing = _cart.FirstOrDefault(c => c.ProductId == product.Id);
                if (existing != null)
                {
                    existing.Quantity += quantity;
                }
                else
                {
                    _cart.Add(new CartItem 
                    { 
                        ProductId = product.Id, 
                        ProductName = product.Name, 
                        UnitPrice = product.UnitPrice, 
                        Quantity = quantity 
                    });
                }

                RefreshCart();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetCartQuantity(int productId)
        {
            return _cart.Where(c => c.ProductId == productId).Sum(c => c.Quantity);
        }

        private void ClearInputs()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtQuantity.Value = 1;
            txtPrice.Text = "";
            txtProductId.Focus();
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
                UserId = Session.UserId,
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
        public int UserId { get; set; }
        public List<SaleDetailDto> Items { get; set; } = new List<SaleDetailDto>();
    }

    public class SaleDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
