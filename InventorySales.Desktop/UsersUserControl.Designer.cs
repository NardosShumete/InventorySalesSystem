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
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(22, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(294, 45);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "User Management";
            // 
            // gridUsers
            // 
            gridUsers.BackgroundColor = Color.White;
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Location = new Point(22, 70);
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 62;
            gridUsers.Size = new Size(545, 350);
            gridUsers.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(589, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(131, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+ Add User";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(589, 120);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(131, 40);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete User";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // UsersUserControl
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(gridUsers);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Name = "UsersUserControl";
            Size = new Size(833, 520);
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}
