namespace InventorySales.Desktop
{
    partial class ReportsUserControl
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
            gridSales = new DataGridView();
            dtpFilter = new DateTimePicker();
            txtIdFilter = new TextBox();
            btnFilter = new Button();
            btnGenerate = new Button();
            lblFilterDate = new Label();
            lblFilterId = new Label();
            ((System.ComponentModel.ISupportInitialize)gridSales).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(266, 45);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Reports & History";
            // 
            // gridSales
            // 
            gridSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSales.BackgroundColor = Color.White;
            gridSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSales.Location = new Point(20, 149);
            gridSales.Name = "gridSales";
            gridSales.RowHeadersWidth = 62;
            gridSales.Size = new Size(700, 300);
            gridSales.TabIndex = 6;
            // 
            // dtpFilter
            // 
            dtpFilter.Format = DateTimePickerFormat.Short;
            dtpFilter.Location = new Point(132, 92);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(120, 34);
            dtpFilter.TabIndex = 4;
            // 
            // txtIdFilter
            // 
            txtIdFilter.Location = new Point(456, 89);
            txtIdFilter.Name = "txtIdFilter";
            txtIdFilter.Size = new Size(100, 34);
            txtIdFilter.TabIndex = 2;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.RosyBrown;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.Location = new Point(571, 75);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(149, 57);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.DarkSlateBlue;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(20, 480);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(374, 50);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate Report File";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // lblFilterDate
            // 
            lblFilterDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFilterDate.Location = new Point(20, 95);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new Size(106, 31);
            lblFilterDate.TabIndex = 5;
            lblFilterDate.Text = "Date:";
            // 
            // lblFilterId
            // 
            lblFilterId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFilterId.Location = new Point(293, 89);
            lblFilterId.Name = "lblFilterId";
            lblFilterId.Size = new Size(157, 34);
            lblFilterId.TabIndex = 3;
            lblFilterId.Text = "Sale ID:";
            // 
            // ReportsUserControl
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnGenerate);
            Controls.Add(btnFilter);
            Controls.Add(txtIdFilter);
            Controls.Add(lblFilterId);
            Controls.Add(dtpFilter);
            Controls.Add(lblFilterDate);
            Controls.Add(gridSales);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "ReportsUserControl";
            Size = new Size(916, 544);
            ((System.ComponentModel.ISupportInitialize)gridSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridSales;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.TextBox txtIdFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.Label lblFilterId;
        private System.Windows.Forms.Button btnGenerate;
    }
}
