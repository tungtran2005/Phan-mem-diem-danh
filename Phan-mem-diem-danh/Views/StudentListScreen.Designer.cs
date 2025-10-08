using System.ComponentModel;

namespace Phan_mem_diem_danh.Views;

partial class StudentListScreen
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
        components = new System.ComponentModel.Container();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        groupBox1 = new System.Windows.Forms.GroupBox();
        addStudentButton = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        dgvStudentList = new System.Windows.Forms.DataGridView();
        MSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
        FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
        delete = new System.Windows.Forms.DataGridViewButtonColumn();
        edit = new System.Windows.Forms.DataGridViewButtonColumn();
        Muster = new System.Windows.Forms.DataGridViewComboBoxColumn();
        contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        backButton = new System.Windows.Forms.Button();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStudentList).BeginInit();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(addStudentButton);
        groupBox1.Controls.Add(textBox1);
        groupBox1.Controls.Add(dgvStudentList);
        groupBox1.Location = new System.Drawing.Point(24, 65);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(730, 294);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "ClassName";
        // 
        // addStudentButton
        // 
        addStudentButton.Location = new System.Drawing.Point(273, 258);
        addStudentButton.Name = "addStudentButton";
        addStudentButton.Size = new System.Drawing.Size(121, 23);
        addStudentButton.TabIndex = 2;
        addStudentButton.Text = "Thêm sinh viên";
        addStudentButton.UseVisualStyleBackColor = true;
        addStudentButton.Click += addStudentButton_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(6, 22);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(97, 23);
        textBox1.TabIndex = 1;
        textBox1.Text = "Lịch điểm danh";
        // 
        // dgvStudentList
        // 
        dgvStudentList.BackgroundColor = System.Drawing.SystemColors.Control;
        dgvStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { MSV, FirstName, Lastname, Birth, delete, edit, Muster });
        dgvStudentList.Location = new System.Drawing.Point(6, 66);
        dgvStudentList.Name = "dgvStudentList";
        dgvStudentList.Size = new System.Drawing.Size(644, 186);
        dgvStudentList.TabIndex = 0;
        // 
        // MSV
        // 
        MSV.HeaderText = "Mã sinh viên";
        MSV.Name = "MSV";
        MSV.ReadOnly = true;
        // 
        // FirstName
        // 
        FirstName.HeaderText = "Họ đệm";
        FirstName.Name = "FirstName";
        FirstName.ReadOnly = true;
        // 
        // Lastname
        // 
        Lastname.HeaderText = "Tên";
        Lastname.Name = "Lastname";
        Lastname.ReadOnly = true;
        // 
        // Birth
        // 
        Birth.HeaderText = "Ngày sinh";
        Birth.Name = "Birth";
        Birth.ReadOnly = true;
        // 
        // delete
        // 
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.NullValue = "xoá";
        delete.DefaultCellStyle = dataGridViewCellStyle1;
        delete.HeaderText = "";
        delete.Name = "delete";
        delete.Width = 50;
        // 
        // edit
        // 
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle2.NullValue = "sửa";
        edit.DefaultCellStyle = dataGridViewCellStyle2;
        edit.HeaderText = "";
        edit.Name = "edit";
        edit.Width = 50;
        // 
        // Muster
        // 
        dataGridViewCellStyle3.NullValue = "điểm danh";
        Muster.DefaultCellStyle = dataGridViewCellStyle3;
        Muster.HeaderText = "";
        Muster.Name = "Muster";
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
        // 
        // menuStrip1
        // 
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(1184, 24);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // backButton
        // 
        backButton.Location = new System.Drawing.Point(12, 799);
        backButton.Name = "backButton";
        backButton.Size = new System.Drawing.Size(115, 50);
        backButton.TabIndex = 3;
        backButton.Text = "Quay lại";
        backButton.UseVisualStyleBackColor = true;
        backButton.Click += button1_Click;
        // 
        // StudentListScreen
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1184, 861);
        Controls.Add(backButton);
        Controls.Add(menuStrip1);
        Controls.Add(groupBox1);
        MainMenuStrip = menuStrip1;
        Text = "StudentListScreen";
        Load += StudentListScreen_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStudentList).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button backButton;

    #endregion

    private GroupBox groupBox1;
    private DataGridView dgvStudentList;
    private Button addStudentButton;
    private TextBox textBox1;
    private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    private ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private DataGridViewTextBoxColumn MSV;
    private DataGridViewTextBoxColumn FirstName;
    private DataGridViewTextBoxColumn Lastname;
    private DataGridViewTextBoxColumn Birth;
    private DataGridViewButtonColumn delete;
    private DataGridViewButtonColumn edit;
    private DataGridViewComboBoxColumn Muster;
}