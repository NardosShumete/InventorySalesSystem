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
            txtProduct = new TextBox();
            lblProd = new Label();
            btnAdd = new Button();
            gridCart = new DataGridView();
            lblTotal = new Label();
            lblSubTotal = new Label();
            lblTax = new Label();
            btnCheckout = new Button();
            ((System.ComponentModel.ISupportInitialize)gridCart).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(183, 45);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Sales Point";
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(185, 68);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(150, 34);
            txtProduct.TabIndex = 4;
            // 
            // lblProd
            // 
            lblProd.AutoSize = true;
            lblProd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProd.Location = new Point(61, 71);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(118, 28);
            lblProd.TabIndex = 5;
            lblProd.Text = "Product ID:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(355, 65);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(223, 39);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // gridCart
            // 
            gridCart.BackgroundColor = Color.White;
            gridCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCart.Location = new Point(20, 127);
            gridCart.Name = "gridCart";
            gridCart.RowHeadersWidth = 62;
            gridCart.Size = new Size(700, 300);
            gridCart.TabIndex = 2;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubTotal.Location = new Point(550, 435);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(130, 28);
            lblSubTotal.TabIndex = 7;
            lblSubTotal.Text = "SubTotal: $0.00";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTax.Location = new Point(550, 465);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(100, 28);
            lblTax.TabIndex = 8;
            lblTax.Text = "Tax: $0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(550, 495);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(169, 38);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.Green;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(524, 540);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(230, 50);
            btnCheckout.TabIndex = 0;
            btnCheckout.Text = "CHECKOUT";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // SalesUserControl
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnCheckout);
            Controls.Add(lblTotal);
            Controls.Add(lblTax);
            Controls.Add(lblSubTotal);
            Controls.Add(gridCart);
            Controls.Add(btnAdd);
            Controls.Add(txtProduct);
            Controls.Add(lblProd);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "SalesUserControl";
            Size = new Size(801, 620);
            ((System.ComponentModel.ISupportInitialize)gridCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Button btnCheckout;
    }
}
