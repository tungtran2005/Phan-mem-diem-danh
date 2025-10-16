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
        dgvClassList = new DataGridView();
        ID = new DataGridViewTextBoxColumn();
        ClassName = new DataGridViewTextBoxColumn();
        Subject = new DataGridViewTextBoxColumn();
        Department = new DataGridViewTextBoxColumn();
        StartDate = new DataGridViewTextBoxColumn();
        EndDate = new DataGridViewTextBoxColumn();
        btnThemLop = new Button();
        btnSuaLop = new Button();
        btnXoaLop = new Button();
        groupBox1 = new GroupBox();
        btnViewAll = new Button();
        logoutButton = new Button();
        ((ISupportInitialize)dgvClassList).BeginInit();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // dgvClassList
        // 
        dgvClassList.AllowUserToAddRows = false;
        dgvClassList.AllowUserToDeleteRows = false;
        dgvClassList.AllowUserToOrderColumns = true;
        dgvClassList.AllowUserToResizeColumns = false;
        dgvClassList.AllowUserToResizeRows = false;
        dgvClassList.BackgroundColor = SystemColors.InactiveBorder;
        dgvClassList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClassList.Columns.AddRange(new DataGridViewColumn[] { ID, ClassName, Subject, Department, StartDate, EndDate });
        dgvClassList.GridColor = SystemColors.ScrollBar;
        dgvClassList.Location = new Point(5, 35);
        dgvClassList.Margin = new Padding(3, 4, 3, 4);
        dgvClassList.MultiSelect = false;
        dgvClassList.Name = "dgvClassList";
        dgvClassList.ReadOnly = true;
        dgvClassList.RowHeadersVisible = false;
        dgvClassList.RowHeadersWidth = 51;
        dgvClassList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClassList.Size = new Size(1360, 364);
        dgvClassList.TabIndex = 1;
        dgvClassList.SelectionChanged += dgvClassList_SelectionChanged;
        // 
        // ID
        // 
        ID.HeaderText = "Mã lớp";
        ID.MinimumWidth = 6;
        ID.Name = "ID";
        ID.ReadOnly = true;
        ID.Width = 85;
        // 
        // ClassName
        // 
        ClassName.HeaderText = "Tên lớp";
        ClassName.MinimumWidth = 6;
        ClassName.Name = "ClassName";
        ClassName.ReadOnly = true;
        ClassName.Width = 150;
        // 
        // Subject
        // 
        Subject.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        Subject.HeaderText = "môn";
        Subject.MinimumWidth = 6;
        Subject.Name = "Subject";
        Subject.ReadOnly = true;
        // 
        // Department
        // 
        Department.HeaderText = "Khoa";
        Department.MinimumWidth = 6;
        Department.Name = "Department";
        Department.ReadOnly = true;
        Department.Width = 150;
        // 
        // StartDate
        // 
        StartDate.HeaderText = "Ngày bắt đầu";
        StartDate.MinimumWidth = 6;
        StartDate.Name = "StartDate";
        StartDate.ReadOnly = true;
        StartDate.Width = 280;
        // 
        // EndDate
        // 
        EndDate.HeaderText = "Ngày kết thúc";
        EndDate.MinimumWidth = 6;
        EndDate.Name = "EndDate";
        EndDate.ReadOnly = true;
        EndDate.Width = 280;
        // 
        // btnThemLop
        // 
        btnThemLop.Location = new Point(417, 772);
        btnThemLop.Margin = new Padding(3, 4, 3, 4);
        btnThemLop.Name = "btnThemLop";
        btnThemLop.Size = new Size(107, 39);
        btnThemLop.TabIndex = 5;
        btnThemLop.Text = "Thêm lớp";
        btnThemLop.UseVisualStyleBackColor = true;
        btnThemLop.Click += btnThemLop_Click;
        // 
        // btnSuaLop
        // 
        btnSuaLop.Location = new Point(602, 772);
        btnSuaLop.Margin = new Padding(3, 4, 3, 4);
        btnSuaLop.Name = "btnSuaLop";
        btnSuaLop.Size = new Size(107, 39);
        btnSuaLop.TabIndex = 6;
        btnSuaLop.Text = "Sửa lớp";
        btnSuaLop.UseVisualStyleBackColor = true;
        btnSuaLop.Click += btnSuaLop_Click;
        // 
        // btnXoaLop
        // 
        btnXoaLop.Location = new Point(788, 772);
        btnXoaLop.Margin = new Padding(3, 4, 3, 4);
        btnXoaLop.Name = "btnXoaLop";
        btnXoaLop.Size = new Size(107, 39);
        btnXoaLop.TabIndex = 7;
        btnXoaLop.Text = "Xóa lớp";
        btnXoaLop.UseVisualStyleBackColor = true;
        btnXoaLop.Click += btnXoaLop_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(dgvClassList);
        groupBox1.Location = new Point(-9, 291);
        groupBox1.Margin = new Padding(3, 4, 3, 4);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(3, 4, 3, 4);
        groupBox1.Size = new Size(1371, 407);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "danh sách lớp";
        // 
        // btnViewAll
        // 
        btnViewAll.Location = new Point(945, 772);
        btnViewAll.Margin = new Padding(3, 4, 3, 4);
        btnViewAll.Name = "btnViewAll";
        btnViewAll.Size = new Size(107, 39);
        btnViewAll.TabIndex = 9;
        btnViewAll.Text = "Xem tất cả lớp";
        btnViewAll.UseVisualStyleBackColor = true;
        btnViewAll.Click += btnViewAll_Click;
        // 
        // logoutButton
        // 
        logoutButton.Location = new Point(1254, 16);
        logoutButton.Margin = new Padding(3, 4, 3, 4);
        logoutButton.Name = "logoutButton";
        logoutButton.Size = new Size(86, 31);
        logoutButton.TabIndex = 10;
        logoutButton.Text = "Đăng xuất";
        logoutButton.UseVisualStyleBackColor = true;
        logoutButton.Click += logoutButton_Click;
        // 
        // ClassListScreen
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1353, 1055);
        Controls.Add(logoutButton);
        Controls.Add(btnViewAll);
        Controls.Add(groupBox1);
        Controls.Add(btnXoaLop);
        Controls.Add(btnSuaLop);
        Controls.Add(btnThemLop);
        Name = "ClassListScreen";
        Text = "ClassListScreen";
        Load += ClassListScreen_Load;
        ((ISupportInitialize)dgvClassList).EndInit();
        groupBox1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button logoutButton;

    #endregion
    private DataGridView dgvClassList;
    private Button btnThemLop;
    private Button btnSuaLop;
    private Button btnXoaLop;
    private System.Windows.Forms.GroupBox groupBox1;
    private Button btnViewAll;
    private DataGridViewTextBoxColumn ID;
    private DataGridViewTextBoxColumn ClassName;
    private DataGridViewTextBoxColumn Subject;
    private DataGridViewTextBoxColumn Department;
    private DataGridViewTextBoxColumn StartDate;
    private DataGridViewTextBoxColumn EndDate;
}