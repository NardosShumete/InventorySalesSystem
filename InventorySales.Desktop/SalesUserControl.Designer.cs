namespace InventorySales.Desktop
{
    partial class SalesUserControl
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
            lblProductId = new Label();
            txtProductId = new TextBox();
            btnSearchId = new Button();
            lblProductName = new Label();
            txtProductName = new TextBox();
            btnSearchName = new Button();
            lblQuantity = new Label();
            txtQuantity = new NumericUpDown();
            btnSearchQty = new Button();
            lblPrice = new Label();
            txtPrice = new TextBox();
            btnSearchPrice = new Button();
            btnAdd = new Button();
            gridCart = new DataGridView();
            lblSubTotal = new Label();
            lblTax = new Label();
            lblTotal = new Label();
            btnCheckout = new Button();
            ((System.ComponentModel.ISupportInitialize)txtQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridCart).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(32, 58, 67);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(183, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sales Point";
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductId.Location = new Point(20, 80);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(118, 28);
            lblProductId.TabIndex = 1;
            lblProductId.Text = "Product ID:";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(140, 77);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(100, 34);
            txtProductId.TabIndex = 2;
            // 
            // btnSearchId
            // 
            btnSearchId.BackColor = Color.FromArgb(32, 58, 67);
            btnSearchId.FlatStyle = FlatStyle.Flat;
            btnSearchId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchId.ForeColor = Color.White;
            btnSearchId.Location = new Point(250, 75);
            btnSearchId.Name = "btnSearchId";
            btnSearchId.Size = new Size(85, 36);
            btnSearchId.TabIndex = 3;
            btnSearchId.Text = "Search";
            btnSearchId.UseVisualStyleBackColor = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductName.Location = new Point(20, 130);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(91, 28);
            lblProductName.TabIndex = 4;
            lblProductName.Text = "Product:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(140, 127);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(100, 34);
            txtProductName.TabIndex = 5;
            // 
            // btnSearchName
            // 
            btnSearchName.BackColor = Color.FromArgb(32, 58, 67);
            btnSearchName.FlatStyle = FlatStyle.Flat;
            btnSearchName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchName.ForeColor = Color.White;
            btnSearchName.Location = new Point(250, 125);
            btnSearchName.Name = "btnSearchName";
            btnSearchName.Size = new Size(85, 36);
            btnSearchName.TabIndex = 6;
            btnSearchName.Text = "Search";
            btnSearchName.UseVisualStyleBackColor = false;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuantity.Location = new Point(20, 180);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 28);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(140, 177);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 34);
            txtQuantity.TabIndex = 8;
            txtQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSearchQty
            // 
            btnSearchQty.BackColor = Color.FromArgb(32, 58, 67);
            btnSearchQty.FlatStyle = FlatStyle.Flat;
            btnSearchQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchQty.ForeColor = Color.White;
            btnSearchQty.Location = new Point(250, 175);
            btnSearchQty.Name = "btnSearchQty";
            btnSearchQty.Size = new Size(85, 36);
            btnSearchQty.TabIndex = 9;
            btnSearchQty.Text = "Check";
            btnSearchQty.UseVisualStyleBackColor = false;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrice.Location = new Point(20, 230);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(64, 28);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(140, 227);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 34);
            txtPrice.TabIndex = 11;
            // 
            // btnSearchPrice
            // 
            btnSearchPrice.BackColor = Color.FromArgb(32, 58, 67);
            btnSearchPrice.FlatStyle = FlatStyle.Flat;
            btnSearchPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchPrice.ForeColor = Color.White;
            btnSearchPrice.Location = new Point(250, 225);
            btnSearchPrice.Name = "btnSearchPrice";
            btnSearchPrice.Size = new Size(85, 36);
            btnSearchPrice.TabIndex = 12;
            btnSearchPrice.Text = "Fetch";
            btnSearchPrice.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(67, 160, 71);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 280);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(315, 45);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "+ Add to Cart";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // gridCart
            // 
            gridCart.BackgroundColor = Color.White;
            gridCart.BorderStyle = BorderStyle.None;
            gridCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCart.Dock = DockStyle.Right;
            gridCart.Location = new Point(380, 0);
            gridCart.Name = "gridCart";
            gridCart.RowHeadersWidth = 62;
            gridCart.Size = new Size(650, 600);
            gridCart.TabIndex = 14;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubTotal.Location = new Point(20, 350);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(158, 28);
            lblSubTotal.TabIndex = 15;
            lblSubTotal.Text = "SubTotal: $0.00";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTax.Location = new Point(20, 380);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(108, 28);
            lblTax.TabIndex = 16;
            lblTax.Text = "Tax: $0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 410);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(169, 38);
            lblTotal.TabIndex = 17;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(67, 160, 71);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(20, 470);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(315, 60);
            btnCheckout.TabIndex = 18;
            btnCheckout.Text = "CHECKOUT";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // SalesUserControl
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 252);
            Controls.Add(btnCheckout);
            Controls.Add(lblTotal);
            Controls.Add(lblTax);
            Controls.Add(lblSubTotal);
            Controls.Add(gridCart);
            Controls.Add(btnAdd);
            Controls.Add(btnSearchPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(btnSearchQty);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(btnSearchName);
            Controls.Add(txtProductName);
            Controls.Add(lblProductName);
            Controls.Add(btnSearchId);
            Controls.Add(txtProductId);
            Controls.Add(lblProductId);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "SalesUserControl";
            Size = new Size(1030, 600);
            ((System.ComponentModel.ISupportInitialize)txtQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Button btnSearchId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.Button btnSearchQty;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnSearchPrice;
    }
}
