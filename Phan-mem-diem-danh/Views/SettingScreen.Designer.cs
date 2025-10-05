using System.ComponentModel;

namespace Phan_mem_diem_danh.Views
{
    partial class SettingScreen
    {
        private IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblTitle = new System.Windows.Forms.Label();
            lblOldPassword = new System.Windows.Forms.Label();
            lblNewPassword = new System.Windows.Forms.Label();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtOldPassword = new System.Windows.Forms.TextBox();
            txtNewPassword = new System.Windows.Forms.TextBox();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            lblMessage = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(145, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đổi mật khẩu";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Location = new System.Drawing.Point(26, 70);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new System.Drawing.Size(84, 15);
            lblOldPassword.TabIndex = 1;
            lblOldPassword.Text = "Mật khẩu cũ";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new System.Drawing.Point(26, 115);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new System.Drawing.Size(92, 15);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "Mật khẩu mới";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new System.Drawing.Point(26, 160);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(143, 15);
            lblConfirmPassword.TabIndex = 3;
            lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new System.Drawing.Point(200, 66);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new System.Drawing.Size(260, 23);
            txtOldPassword.TabIndex = 4;
            txtOldPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new System.Drawing.Point(200, 111);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new System.Drawing.Size(260, 23);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new System.Drawing.Point(200, 156);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new System.Drawing.Size(260, 23);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(200, 205);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(120, 32);
            btnSave.TabIndex = 7;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(340, 205);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(120, 32);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            lblMessage.Location = new System.Drawing.Point(26, 250);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new System.Drawing.Size(0, 15);
            lblMessage.TabIndex = 9;
            // 
            // SettingScreen
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 290);
            Controls.Add(lblMessage);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtOldPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(lblOldPassword);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingScreen";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cài đặt - Đổi mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}