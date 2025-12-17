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
            btnFilter = new Button();
            btnGenerate = new Button();
            lblFilterDate = new Label();
            lblPeriod = new Label();
            cmbPeriod = new ComboBox();
            panelFilterCard = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridSales).BeginInit();
            panelFilterCard.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(32, 58, 67);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(323, 48);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Reports & Analytics";
            // 
            // gridSales
            // 
            gridSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSales.BackgroundColor = Color.White;
            gridSales.BorderStyle = BorderStyle.None;
            gridSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSales.Dock = DockStyle.Bottom;
            gridSales.Location = new Point(0, 316);
            gridSales.Name = "gridSales";
            gridSales.RowHeadersWidth = 62;
            gridSales.Size = new Size(916, 365);
            gridSales.TabIndex = 6;
            // 
            // dtpFilter
            // 
            dtpFilter.Format = DateTimePickerFormat.Short;
            dtpFilter.Location = new Point(100, 23);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(150, 34);
            dtpFilter.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(32, 58, 67);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(680, 15);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(170, 50);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Search Data";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(67, 160, 71);
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(20, 236);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(300, 55);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Export Report (.txt)";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // lblFilterDate
            // 
            lblFilterDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFilterDate.Location = new Point(20, 26);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new Size(74, 31);
            lblFilterDate.TabIndex = 5;
            lblFilterDate.Text = "Date:";
            // 
            // lblPeriod
            // 
            lblPeriod.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPeriod.Location = new Point(280, 26);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(100, 31);
            lblPeriod.TabIndex = 8;
            lblPeriod.Text = "Period:";
            // 
            // cmbPeriod
            // 
            cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriod.FormattingEnabled = true;
            cmbPeriod.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly" });
            cmbPeriod.Location = new Point(380, 23);
            cmbPeriod.Name = "cmbPeriod";
            cmbPeriod.Size = new Size(150, 36);
            cmbPeriod.TabIndex = 9;
            // 
            // panelFilterCard
            // 
            panelFilterCard.BackColor = Color.White;
            panelFilterCard.Controls.Add(lblFilterDate);
            panelFilterCard.Controls.Add(dtpFilter);
            panelFilterCard.Controls.Add(lblPeriod);
            panelFilterCard.Controls.Add(cmbPeriod);
            panelFilterCard.Controls.Add(btnFilter);
            panelFilterCard.Location = new Point(20, 85);
            panelFilterCard.Name = "panelFilterCard";
            panelFilterCard.Size = new Size(870, 80);
            panelFilterCard.TabIndex = 10;
            // 
            // ReportsUserControl
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 252);
            Controls.Add(panelFilterCard);
            Controls.Add(btnGenerate);
            Controls.Add(gridSales);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "ReportsUserControl";
            Size = new Size(916, 681);
            ((System.ComponentModel.ISupportInitialize)gridSales).EndInit();
            panelFilterCard.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridSales;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panelFilterCard;
    }
}
