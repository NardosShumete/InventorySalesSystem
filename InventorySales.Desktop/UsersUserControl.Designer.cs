namespace InventorySales.Desktop
{
    partial class UsersUserControl
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
            gridUsers = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            lblIdFilter = new Label();
            txtIdFilter = new TextBox();
            btnFilterId = new Button();
            lblNameFilter = new Label();
            txtNameFilter = new TextBox();
            btnFilterName = new Button();
            panelActions = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(32, 58, 67);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(328, 48);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "User Management";
            // 
            // gridUsers
            // 
            gridUsers.BackgroundColor = Color.White;
            gridUsers.BorderStyle = BorderStyle.None;
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Dock = DockStyle.Right;
            gridUsers.Location = new Point(415, 48);
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 62;
            gridUsers.Size = new Size(696, 581);
            gridUsers.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(67, 160, 71);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(10, 260);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 50);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "+ Add User";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(10, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 50);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete User";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(32, 58, 67);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(10, 320);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(200, 50);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update User";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // lblIdFilter
            // 
            lblIdFilter.AutoSize = true;
            lblIdFilter.Location = new Point(10, 10);
            lblIdFilter.Name = "lblIdFilter";
            lblIdFilter.Size = new Size(107, 28);
            lblIdFilter.TabIndex = 0;
            lblIdFilter.Text = "Search ID:";
            // 
            // txtIdFilter
            // 
            txtIdFilter.Location = new Point(10, 40);
            txtIdFilter.Name = "txtIdFilter";
            txtIdFilter.Size = new Size(200, 34);
            txtIdFilter.TabIndex = 1;
            // 
            // btnFilterId
            // 
            btnFilterId.BackColor = Color.FromArgb(32, 58, 67);
            btnFilterId.FlatStyle = FlatStyle.Flat;
            btnFilterId.ForeColor = Color.White;
            btnFilterId.Location = new Point(10, 80);
            btnFilterId.Name = "btnFilterId";
            btnFilterId.Size = new Size(200, 40);
            btnFilterId.TabIndex = 2;
            btnFilterId.Text = "Filter ID";
            btnFilterId.UseVisualStyleBackColor = false;
            // 
            // lblNameFilter
            // 
            lblNameFilter.AutoSize = true;
            lblNameFilter.Location = new Point(10, 130);
            lblNameFilter.Name = "lblNameFilter";
            lblNameFilter.Size = new Size(142, 28);
            lblNameFilter.TabIndex = 3;
            lblNameFilter.Text = "Search Name:";
            // 
            // txtNameFilter
            // 
            txtNameFilter.Location = new Point(10, 160);
            txtNameFilter.Name = "txtNameFilter";
            txtNameFilter.Size = new Size(200, 34);
            txtNameFilter.TabIndex = 4;
            // 
            // btnFilterName
            // 
            btnFilterName.BackColor = Color.FromArgb(32, 58, 67);
            btnFilterName.FlatStyle = FlatStyle.Flat;
            btnFilterName.ForeColor = Color.White;
            btnFilterName.Location = new Point(10, 200);
            btnFilterName.Name = "btnFilterName";
            btnFilterName.Size = new Size(200, 40);
            btnFilterName.TabIndex = 5;
            btnFilterName.Text = "Filter Name";
            btnFilterName.UseVisualStyleBackColor = false;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.White;
            panelActions.Controls.Add(lblIdFilter);
            panelActions.Controls.Add(txtIdFilter);
            panelActions.Controls.Add(btnFilterId);
            panelActions.Controls.Add(lblNameFilter);
            panelActions.Controls.Add(txtNameFilter);
            panelActions.Controls.Add(btnFilterName);
            panelActions.Controls.Add(btnAdd);
            panelActions.Controls.Add(btnUpdate);
            panelActions.Controls.Add(btnDelete);
            panelActions.Dock = DockStyle.Left;
            panelActions.Location = new Point(0, 48);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(328, 581);
            panelActions.TabIndex = 4;
            // 
            // UsersUserControl
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 252);
            Controls.Add(panelActions);
            Controls.Add(gridUsers);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Name = "UsersUserControl";
            Size = new Size(1111, 629);
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblIdFilter;
        private System.Windows.Forms.TextBox txtIdFilter;
        private System.Windows.Forms.Button btnFilterId;
        private System.Windows.Forms.Label lblNameFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.Button btnFilterName;
        private System.Windows.Forms.Panel panelActions;
    }
}
