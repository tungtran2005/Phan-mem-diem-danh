using System.Drawing;
using System.Windows.Forms;

namespace Phan_mem_diem_danh.Views
{
    partial class SettingScreen
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblCurrentPassword;
        private Label lblNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkShowPasswords;
        private Label lblMessage;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblCurrentPassword = new Label();
            lblNewPassword = new Label();
            lblConfirmPassword = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            chkShowPasswords = new CheckBox();
            lblMessage = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            panelContainer = new Panel();

            SuspendLayout();

            // panelContainer
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Padding = new Padding(24);
            panelContainer.BackColor = Color.White;
            panelContainer.Controls.Add(lblTitle);
            panelContainer.Controls.Add(lblCurrentPassword);
            panelContainer.Controls.Add(txtCurrentPassword);
            panelContainer.Controls.Add(lblNewPassword);
            panelContainer.Controls.Add(txtNewPassword);
            panelContainer.Controls.Add(lblConfirmPassword);
            panelContainer.Controls.Add(txtConfirmPassword);
            panelContainer.Controls.Add(chkShowPasswords);
            panelContainer.Controls.Add(lblMessage);
            panelContainer.Controls.Add(btnSave);
            panelContainer.Controls.Add(btnCancel);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(24, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(122, 21);
            lblTitle.Text = "Đổi mật khẩu";

            // lblCurrentPassword
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(24, 70);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(112, 15);
            lblCurrentPassword.Text = "Mật khẩu hiện tại:";

            // txtCurrentPassword
            txtCurrentPassword.Location = new Point(24, 90);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(360, 23);
            txtCurrentPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.TabIndex = 0;

            // lblNewPassword
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(24, 126);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(86, 15);
            lblNewPassword.Text = "Mật khẩu mới:";

            // txtNewPassword
            txtNewPassword.Location = new Point(24, 146);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(360, 23);
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TabIndex = 1;

            // lblConfirmPassword
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(24, 182);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(112, 15);
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";

            // txtConfirmPassword
            txtConfirmPassword.Location = new Point(24, 202);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(360, 23);
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TabIndex = 2;

            // chkShowPasswords
            chkShowPasswords.AutoSize = true;
            chkShowPasswords.Location = new Point(24, 236);
            chkShowPasswords.Name = "chkShowPasswords";
            chkShowPasswords.Size = new Size(108, 19);
            chkShowPasswords.Text = "Hiện mật khẩu";
            chkShowPasswords.TabIndex = 3;
            chkShowPasswords.CheckedChanged += chkShowPasswords_CheckedChanged;

            // lblMessage
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(24, 265);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Visible = false;
            lblMessage.MaximumSize = new Size(600, 0);
            lblMessage.AutoEllipsis = true;

            // btnSave
            btnSave.Location = new Point(24, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 32);
            btnSave.Text = "Lưu";
            btnSave.TabIndex = 4;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new Point(150, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 32);
            btnCancel.Text = "Hủy";
            btnCancel.TabIndex = 5;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // SettingScreen (Form)
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 380);
            Controls.Add(panelContainer);
            Name = "SettingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cài đặt";
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            MinimizeBox = false;
            MaximizeBox = false;

            ResumeLayout(false);
        }
    }
}