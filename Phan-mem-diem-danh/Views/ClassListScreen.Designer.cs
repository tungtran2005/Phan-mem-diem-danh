using System.ComponentModel;

namespace Phan_mem_diem_danh.Views;

partial class ClassListScreen
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
        dgvClassList = new System.Windows.Forms.DataGridView();
        ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
        StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        groupBox1 = new System.Windows.Forms.GroupBox();
        btnViewAll = new System.Windows.Forms.Button();
        logoutButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dgvClassList).BeginInit();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // dgvClassList
        // 
        dgvClassList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
        dgvClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClassList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, ClassName, Subject, Department, StartDate, EndDate });
        dgvClassList.GridColor = System.Drawing.SystemColors.ScrollBar;
        dgvClassList.Location = new System.Drawing.Point(-1, 26);
        dgvClassList.Name = "dgvClassList";
        dgvClassList.ReadOnly = true;
        dgvClassList.RowHeadersWidth = 51;
        dgvClassList.Size = new System.Drawing.Size(799, 246);
        dgvClassList.TabIndex = 1;
        // 
        // ID
        // 
        ID.HeaderText = "Mã lớp";
        ID.MinimumWidth = 6;
        ID.Name = "ID";
        ID.ReadOnly = true;
        ID.Width = 65;
        // 
        // ClassName
        // 
        ClassName.HeaderText = "Tên lớp";
        ClassName.MinimumWidth = 6;
        ClassName.Name = "ClassName";
        ClassName.ReadOnly = true;
        ClassName.Width = 125;
        // 
        // Subject
        // 
        Subject.HeaderText = "môn";
        Subject.MinimumWidth = 6;
        Subject.Name = "Subject";
        Subject.ReadOnly = true;
        Subject.Width = 180;
        // 
        // Department
        // 
        Department.HeaderText = "Khoa";
        Department.MinimumWidth = 6;
        Department.Name = "Department";
        Department.ReadOnly = true;
        Department.Width = 125;
        // 
        // StartDate
        // 
        StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        StartDate.HeaderText = "Ngày bắt đầu";
        StartDate.MinimumWidth = 6;
        StartDate.Name = "StartDate";
        StartDate.ReadOnly = true;
        // 
        // EndDate
        // 
        EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        EndDate.HeaderText = "Ngày kết thúc";
        EndDate.MinimumWidth = 6;
        EndDate.Name = "EndDate";
        EndDate.ReadOnly = true;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(173, 412);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(94, 29);
        button1.TabIndex = 5;
        button1.Text = "Thêm lớp";
        button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(335, 412);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(94, 29);
        button2.TabIndex = 6;
        button2.Text = "Sửa lớp";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(498, 412);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(94, 29);
        button3.TabIndex = 7;
        button3.Text = "Xóa lớp";
        button3.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(dgvClassList);
        groupBox1.Location = new System.Drawing.Point(2, 121);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(797, 271);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "danh sách lớp";
        // 
        // btnViewAll
        // 
        btnViewAll.Location = new System.Drawing.Point(635, 412);
        btnViewAll.Name = "btnViewAll";
        btnViewAll.Size = new System.Drawing.Size(94, 29);
        btnViewAll.TabIndex = 9;
        btnViewAll.Text = "Xem tất cả lớp";
        btnViewAll.UseVisualStyleBackColor = true;
        btnViewAll.Click += btnViewAll_Click;
        // 
        // logoutButton
        // 
        logoutButton.Location = new System.Drawing.Point(1097, 12);
        logoutButton.Name = "logoutButton";
        logoutButton.Size = new System.Drawing.Size(75, 23);
        logoutButton.TabIndex = 10;
        logoutButton.Text = "Đăng xuất";
        logoutButton.UseVisualStyleBackColor = true;
        logoutButton.Click += logoutButton_Click;
        // 
        // ClassListScreen
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1184, 861);
        Controls.Add(logoutButton);
        Controls.Add(btnViewAll);
        Controls.Add(groupBox1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        Text = "ClassListScreen";
        ((System.ComponentModel.ISupportInitialize)dgvClassList).EndInit();
        groupBox1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button logoutButton;

    #endregion
    private DataGridView dgvClassList;
    private Button button1;
    private Button button2;
    private Button button3;
    private System.Windows.Forms.GroupBox groupBox1;
    private DataGridViewTextBoxColumn ID;
    private DataGridViewTextBoxColumn ClassName;
    private DataGridViewTextBoxColumn Subject;
    private DataGridViewTextBoxColumn Department;
    private DataGridViewTextBoxColumn StartDate;
    private DataGridViewTextBoxColumn EndDate;
    private Button btnViewAll;
}