using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class ProductsUserControl : UserControl
    {
        private readonly ApiService _apiService;

        public ProductsUserControl()
        {
            InitializeComponent();
            _apiService = new ApiService();
            
            // Wire up events
            btnAdd.Click += BtnAdd_Click;
            
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

        public async void LoadProducts()
        {
            try
            {
                var products = await _apiService.GetAsync<List<ProductListDto>>("products");
                gridProducts.DataSource = products;
                
                // Optional: Formatting headers
                /*
                if (gridProducts.Columns["Id"] != null) gridProducts.Columns["Id"].Width = 50;
                if (gridProducts.Columns["Name"] != null) gridProducts.Columns["Name"].Width = 200;
                */
            }
            catch (Exception ex)
            {
                // In a real app we might log this, but showing message box on Load can be annoying if API is down
                // MessageBox.Show("Error loading products: " + ex.Message);
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
