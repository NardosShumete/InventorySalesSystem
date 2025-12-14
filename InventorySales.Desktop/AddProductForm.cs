using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace InventorySales.Desktop
{
    public partial class AddProductForm : Form
    {
        private readonly ApiService _apiService;

        public event EventHandler ProductAdded;

        public AddProductForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadCategories();
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

        private async void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategoryName = ShowInputBox("New Category", "Enter category name:");
            if (string.IsNullOrWhiteSpace(newCategoryName)) return;

            try 
            {
                var newCat = new CategoryDto { Name = newCategoryName };
                await _apiService.PostAsync<CategoryDto, CategoryDto>("products/categories", newCat);
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

            var newProduct = new CreateProductDto
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
                await _apiService.PostAsync<CreateProductDto, ProductDto>("products", newProduct);
                MessageBox.Show("Product added!");
                ProductAdded?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving product: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // DTOs (Quick definition if shared lib not avail, or use existing Dto classes if I had a shared Project)
        // Since we didn't make a shared DTO lib, I define localized DTOs for client here or rely on dynamic.
        // I will use local classes at bottom for simplicity in this file scope.
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateProductDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
    
    public class ProductDto
    {
         public int Id { get; set; }
         // ... other fields if needed for response handling
    }
}
