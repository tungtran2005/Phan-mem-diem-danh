using System.ComponentModel;

namespace Phan_mem_diem_danh.Views;

partial class LoginScreen
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        usernameField = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        passwordField = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        errorMessage = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        label1.Location = new System.Drawing.Point(420, 202);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(326, 65);
        label1.TabIndex = 0;
        label1.Text = "Đăng nhập";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 13F);
        label2.Location = new System.Drawing.Point(420, 267);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(326, 29);
        label2.TabIndex = 1;
        label2.Text = "Tên đăng nhập";
        // 
        // usernameField
        // 
        usernameField.Location = new System.Drawing.Point(420, 299);
        usernameField.Name = "usernameField";
        usernameField.Size = new System.Drawing.Size(326, 23);
        usernameField.TabIndex = 2;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 13F);
        label3.Location = new System.Drawing.Point(420, 344);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(326, 29);
        label3.TabIndex = 3;
        label3.Text = "Mật khẩu";
        // 
        // passwordField
        // 
        passwordField.Location = new System.Drawing.Point(420, 376);
        passwordField.Name = "passwordField";
        passwordField.Size = new System.Drawing.Size(326, 23);
        passwordField.TabIndex = 4;
        // 
        // button1
        // 
        button1.Font = new System.Drawing.Font("Segoe UI", 13F);
        button1.Location = new System.Drawing.Point(420, 434);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(326, 40);
        button1.TabIndex = 5;
        button1.Text = "Đăng nhập";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // errorMessage
        // 
        errorMessage.Font = new System.Drawing.Font("Segoe UI", 13F);
        errorMessage.ForeColor = System.Drawing.Color.Red;
        errorMessage.Location = new System.Drawing.Point(420, 477);
        errorMessage.Name = "errorMessage";
        errorMessage.Size = new System.Drawing.Size(326, 72);
        errorMessage.TabIndex = 6;
        // 
        // LoginScreen
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1184, 861);
        Controls.Add(errorMessage);
        Controls.Add(button1);
        Controls.Add(passwordField);
        Controls.Add(label3);
        Controls.Add(usernameField);
        Controls.Add(label2);
        Controls.Add(label1);
        Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        Text = "LoginScreen";
        Load += LoginScreen_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label errorMessage;
    private System.Windows.Forms.TextBox passwordField;
    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox usernameField;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}