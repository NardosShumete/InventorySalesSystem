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
            lblEmail = new Label();
            txtEmail = new TextBox();
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
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(32, 58, 67);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(256, 45);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Register User";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUser.Location = new Point(20, 80);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(111, 28);
            lblUser.TabIndex = 6;
            lblUser.Text = "Username:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(20, 115);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(300, 34);
            txtUser.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(111, 28);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 195);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 34);
            txtEmail.TabIndex = 9;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPass.Location = new Point(20, 240);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(106, 28);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password:";
            // 
            // txtPass
            // 
            // txtPass
            // 
            txtPass.Location = new Point(20, 275);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(300, 34);
            txtPass.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.Location = new Point(20, 320);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(59, 28);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "Admin", "User", "Manager" });
            cmbRole.Location = new Point(20, 355);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(300, 36);
            cmbRole.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(67, 160, 71);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 420);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(300, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "Create Account";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // AddRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 252);
            ClientSize = new Size(350, 500);
            Controls.Add(btnSave);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtPass);
            Controls.Add(lblPass);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
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
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnSave;
    }
}
