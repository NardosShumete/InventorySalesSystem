namespace InventorySales.Desktop
{
    partial class UpdateProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblCat = new Label();
            cmbCategory = new ComboBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblStock = new Label();
            numStock = new NumericUpDown();
            lblReorder = new Label();
            numReorder = new NumericUpDown();
            lblReorderDesc = new Label();
            btnSave = new Button();
            btnAddCategory = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(55, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Update Product";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 58);
            lblName.Name = "lblName";
            lblName.Size = new Size(64, 28);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 95);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 34);
            txtName.TabIndex = 2;
            // 
            // lblCat
            // 
            lblCat.AutoSize = true;
            lblCat.Location = new Point(20, 130);
            lblCat.Name = "lblCat";
            lblCat.Size = new Size(92, 28);
            lblCat.TabIndex = 3;
            lblCat.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(20, 166);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 36);
            cmbCategory.TabIndex = 4;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddCategory.Location = new Point(280, 166);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(40, 36);
            btnAddCategory.TabIndex = 50;
            btnAddCategory.Text = "+";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 205);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 28);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(20, 236);
            numPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(250, 34);
            numPrice.TabIndex = 6;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(20, 273);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(141, 28);
            lblStock.TabIndex = 7;
            lblStock.Text = "Stock Quantity";
            // 
            // numStock
            // 
            numStock.Location = new Point(20, 314);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(250, 34);
            numStock.TabIndex = 8;
            // 
            // lblReorder
            // 
            lblReorder.AutoSize = true;
            lblReorder.Location = new Point(20, 351);
            lblReorder.Name = "lblReorder";
            lblReorder.Size = new Size(130, 28);
            lblReorder.TabIndex = 9;
            lblReorder.Text = "Reorder Level";
            // 
            // numReorder
            // 
            numReorder.Location = new Point(20, 382);
            numReorder.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numReorder.Name = "numReorder";
            numReorder.Size = new Size(250, 34);
            numReorder.TabIndex = 10;
            // 
            // lblReorderDesc
            // 
            lblReorderDesc.AutoSize = true;
            lblReorderDesc.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblReorderDesc.ForeColor = Color.DimGray;
            lblReorderDesc.Location = new Point(20, 319);
            lblReorderDesc.Name = "lblReorderDesc";
            lblReorderDesc.Size = new Size(245, 21);
            lblReorderDesc.TabIndex = 11;
            lblReorderDesc.Text = "* Warns when stock falls below.";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(150, 422);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 48);
            btnSave.TabIndex = 11;
            btnSave.Text = "UPDATE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(20, 422);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 48);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // UpdateProductForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(428, 493);
            Controls.Add(btnCancel);
            Controls.Add(btnAddCategory);
            Controls.Add(btnSave);
            Controls.Add(lblReorderDesc);
            Controls.Add(numReorder);
            Controls.Add(lblReorder);
            Controls.Add(numStock);
            Controls.Add(lblStock);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(cmbCategory);
            Controls.Add(lblCat);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UpdateProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Product";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Label lblReorder;
        private System.Windows.Forms.NumericUpDown numReorder;
        private System.Windows.Forms.Label lblReorderDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnCancel;
    }
}
