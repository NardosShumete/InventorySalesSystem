namespace InventorySales.Desktop
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            lblCurrentUser = new Label();
            btnReports = new Button();
            btnUsers = new Button();
            btnSales = new Button();
            btnProducts = new Button();
            btnDashboard = new Button();
            lblBrand = new Label();
            btnExit = new Button();
            btnLogout = new Button();
            contentPanel = new Panel();
            card2 = new Panel();
            lblVal2 = new Label();
            lblTitle2 = new Label();
            strip2 = new Panel();
            card3 = new Panel();
            lblVal3 = new Label();
            lblTitle3 = new Label();
            strip3 = new Panel();
            card1 = new Panel();
            lblVal1 = new Label();
            lblTitle1 = new Label();
            strip1 = new Panel();
            lblHeader = new Label();
            sidebarPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            card1.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(32, 58, 67);
            sidebarPanel.Controls.Add(lblCurrentUser);
            sidebarPanel.Controls.Add(btnReports);
            sidebarPanel.Controls.Add(btnUsers);
            sidebarPanel.Controls.Add(btnSales);
            sidebarPanel.Controls.Add(btnProducts);
            sidebarPanel.Controls.Add(btnDashboard);
            sidebarPanel.Controls.Add(lblBrand);
            sidebarPanel.Controls.Add(btnExit);
            sidebarPanel.Controls.Add(btnLogout);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(250, 600);
            sidebarPanel.TabIndex = 0;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCurrentUser.ForeColor = Color.Gold;
            lblCurrentUser.Location = new Point(20, 90);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(128, 28);
            lblCurrentUser.TabIndex = 8;
            lblCurrentUser.Text = "User: Admin";
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(12, 305);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(220, 45);
            btnReports.TabIndex = 4;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUsers.ForeColor = Color.White;
            btnUsers.Location = new Point(12, 355);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(20, 0, 0, 0);
            btnUsers.Size = new Size(220, 45);
            btnUsers.TabIndex = 5;
            btnUsers.Text = "Registration Mgmt";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnSales
            // 
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSales.ForeColor = Color.White;
            btnSales.Location = new Point(12, 255);
            btnSales.Name = "btnSales";
            btnSales.Padding = new Padding(20, 0, 0, 0);
            btnSales.Size = new Size(220, 45);
            btnSales.TabIndex = 3;
            btnSales.Text = "Sales POS";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.UseVisualStyleBackColor = true;
            // 
            // btnProducts
            // 
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(12, 205);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(20, 0, 0, 0);
            btnProducts.Size = new Size(220, 45);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Products";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(12, 155);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(220, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(20, 30);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(223, 45);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "Inventory HQ";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(0, 510);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(20, 0, 0, 0);
            btnExit.Size = new Size(250, 45);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Lime;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(0, 555);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(250, 45);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(244, 247, 252);
            contentPanel.Controls.Add(card2);
            contentPanel.Controls.Add(card3);
            contentPanel.Controls.Add(card1);
            contentPanel.Controls.Add(lblHeader);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(250, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(30);
            contentPanel.Size = new Size(734, 600);
            contentPanel.TabIndex = 1;
            // 
            // card2
            // 
            card2.BackColor = Color.White;
            card2.Controls.Add(lblVal2);
            card2.Controls.Add(lblTitle2);
            card2.Controls.Add(strip2);
            card2.Location = new Point(260, 100);
            card2.Name = "card2";
            card2.Size = new Size(220, 130);
            card2.TabIndex = 2;
            // 
            // lblVal2
            // 
            lblVal2.AutoSize = true;
            lblVal2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblVal2.Location = new Point(15, 50);
            lblVal2.Name = "lblVal2";
            lblVal2.Size = new Size(144, 48);
            lblVal2.TabIndex = 0;
            lblVal2.Text = "0 Items";
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.ForeColor = Color.Gray;
            lblTitle2.Location = new Point(15, 20);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(100, 28);
            lblTitle2.TabIndex = 1;
            lblTitle2.Text = "Low Stock";
            // 
            // strip2
            // 
            strip2.BackColor = Color.IndianRed;
            strip2.Dock = DockStyle.Top;
            strip2.Location = new Point(0, 0);
            strip2.Name = "strip2";
            strip2.Size = new Size(220, 5);
            strip2.TabIndex = 2;
            // 
            // card3
            // 
            card3.BackColor = Color.White;
            card3.Controls.Add(lblVal3);
            card3.Controls.Add(lblTitle3);
            card3.Controls.Add(strip3);
            card3.Location = new Point(490, 100);
            card3.Name = "card3";
            card3.Size = new Size(220, 130);
            card3.TabIndex = 3;
            // 
            // lblVal3
            // 
            lblVal3.AutoSize = true;
            lblVal3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblVal3.Location = new Point(15, 50);
            lblVal3.Name = "lblVal3";
            lblVal3.Size = new Size(41, 48);
            lblVal3.TabIndex = 0;
            lblVal3.Text = "0";
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.ForeColor = Color.Gray;
            lblTitle3.Location = new Point(15, 20);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(89, 28);
            lblTitle3.TabIndex = 1;
            lblTitle3.Text = "Products";
            // 
            // strip3
            // 
            strip3.BackColor = Color.SkyBlue;
            strip3.Dock = DockStyle.Top;
            strip3.Location = new Point(0, 0);
            strip3.Name = "strip3";
            strip3.Size = new Size(220, 5);
            strip3.TabIndex = 2;
            // 
            // card1
            // 
            card1.BackColor = Color.White;
            card1.Controls.Add(lblVal1);
            card1.Controls.Add(lblTitle1);
            card1.Controls.Add(strip1);
            card1.Location = new Point(30, 100);
            card1.Name = "card1";
            card1.Size = new Size(220, 130);
            card1.TabIndex = 1;
            // 
            // lblVal1
            // 
            lblVal1.AutoSize = true;
            lblVal1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblVal1.Location = new Point(15, 50);
            lblVal1.Name = "lblVal1";
            lblVal1.Size = new Size(187, 48);
            lblVal1.TabIndex = 2;
            lblVal1.Text = "$1,540.00";
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.ForeColor = Color.Gray;
            lblTitle1.Location = new Point(15, 20);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(105, 28);
            lblTitle1.TabIndex = 1;
            lblTitle1.Text = "Daily Sales";
            // 
            // strip1
            // 
            strip1.BackColor = Color.SeaGreen;
            strip1.Dock = DockStyle.Top;
            strip1.Location = new Point(0, 0);
            strip1.Name = "strip1";
            strip1.Size = new Size(220, 5);
            strip1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(33, 33, 33);
            lblHeader.Location = new Point(30, 30);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(419, 54);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Dashboard Overview";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 600);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Font = new Font("Segoe UI", 10F);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            card2.ResumeLayout(false);
            card2.PerformLayout();
            card3.ResumeLayout(false);
            card3.PerformLayout();
            card1.ResumeLayout(false);
            card1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel card1;
        private System.Windows.Forms.Label lblVal1;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Panel strip1;

        private System.Windows.Forms.Panel card2;
        private System.Windows.Forms.Label lblVal2;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Panel strip2;

        private System.Windows.Forms.Panel card3;
        private System.Windows.Forms.Label lblVal3;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Panel strip3;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}
