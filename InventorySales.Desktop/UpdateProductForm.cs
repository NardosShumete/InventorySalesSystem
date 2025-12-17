using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventorySales.Desktop
{
    public partial class UpdateProductForm : Form
    {
        private readonly ApiService _apiService;
        private readonly int _productId;

        public event EventHandler ProductUpdated;

        public UpdateProductForm(int productId)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _productId = productId;
            LoadCategories();
            LoadProductData();
        }

        private async void LoadCategories()
        {
            try
            {
                var categories = await _apiService.GetAsync<List<CategoryDto>>("products/categories");
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message);
            }
        }

        private async void LoadProductData()
        {
            try
            {
                var product = await _apiService.GetAsync<ProductDto>($"products/{_productId}");
                txtName.Text = product.Name;
                cmbCategory.SelectedValue = product.CategoryId;
                numPrice.Value = product.UnitPrice;
                numStock.Value = product.StockQuantity;
                numReorder.Value = product.ReorderLevel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load product: " + ex.Message);
                this.Close();
            }
        }

        private async void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategoryName = ShowInputBox("New Category", "Enter category name:");
            if (string.IsNullOrWhiteSpace(newCategoryName)) return;

            try
            {
                var newCat = new CreateCategoryDto { Name = newCategoryName, Description = "" };
                await _apiService.PostAsync<CreateCategoryDto, CategoryDto>("products/categories", newCat);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add category: " + ex.Message);
            }
        }

        private string ShowInputBox(string title, string prompt)
        {
            Form promptForm = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(confirmation);
            promptForm.AcceptButton = confirmation;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            var updateProduct = new CreateProductDto
            {
                Name = txtName.Text,
                CategoryId = (int)cmbCategory.SelectedValue,
                UnitPrice = numPrice.Value,
                StockQuantity = (int)numStock.Value,
                ReorderLevel = (int)numReorder.Value,
                Description = "",
                ImageUrl = ""
            };

            try
            {
                await _apiService.PutAsync($"products/{_productId}", updateProduct);
                MessageBox.Show("Product updated successfully!");
                ProductUpdated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
