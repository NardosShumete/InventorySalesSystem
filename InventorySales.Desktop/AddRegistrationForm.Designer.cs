namespace InventorySales.Desktop
{
    partial class AddRegistrationForm
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
            lblUser = new Label();
            txtUser = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(256, 38);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Register New User";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(20, 58);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(99, 28);
            lblUser.TabIndex = 6;
            lblUser.Text = "Username";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(20, 105);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(240, 34);
            txtUser.TabIndex = 5;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(20, 142);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(93, 28);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(20, 182);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(240, 34);
            txtPass.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 219);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(50, 28);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "Admin", "User", "Manager" });
            cmbRole.Location = new Point(20, 269);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(240, 36);
            cmbRole.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 334);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(256, 58);
            btnSave.TabIndex = 0;
            btnSave.Text = "Register User";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // AddRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(365, 432);
            Controls.Add(btnSave);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtPass);
            Controls.Add(lblPass);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddRegistrationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnSave;
    }
}
