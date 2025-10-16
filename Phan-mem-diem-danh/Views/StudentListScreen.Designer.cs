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
        components = new Container();
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        groupBox1 = new GroupBox();
        addStudentButton = new Button();
        textBox1 = new TextBox();
        dgvStudentList = new DataGridView();
        sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
        contextMenuStrip1 = new ContextMenuStrip(components);
        menuStrip1 = new MenuStrip();
        accountToolStripMenuItem = new ToolStripMenuItem();
        classesToolStripMenuItem = new ToolStripMenuItem();
        Id = new DataGridViewTextBoxColumn();
        MSV = new DataGridViewTextBoxColumn();
        FirstName = new DataGridViewTextBoxColumn();
        Lastname = new DataGridViewTextBoxColumn();
        Birth = new DataGridViewTextBoxColumn();
        delete = new DataGridViewButtonColumn();
        edit = new DataGridViewButtonColumn();
        Muster = new DataGridViewComboBoxColumn();
        groupBox1.SuspendLayout();
        ((ISupportInitialize)dgvStudentList).BeginInit();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(addStudentButton);
        groupBox1.Controls.Add(textBox1);
        groupBox1.Controls.Add(dgvStudentList);
        groupBox1.Location = new Point(24, 65);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(730, 294);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "ClassName";
        // 
        // addStudentButton
        // 
        addStudentButton.Location = new Point(273, 258);
        addStudentButton.Name = "addStudentButton";
        addStudentButton.Size = new Size(121, 23);
        addStudentButton.TabIndex = 2;
        addStudentButton.Text = "Thêm sinh viên";
        addStudentButton.UseVisualStyleBackColor = true;
        addStudentButton.Click += addStudentButton_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(6, 22);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(97, 23);
        textBox1.TabIndex = 1;
        textBox1.Text = "Lịch điểm danh";
        // 
        // dgvStudentList
        // 
        dgvStudentList.AllowUserToAddRows = false;
        dgvStudentList.BackgroundColor = SystemColors.Control;
        dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudentList.Columns.AddRange(new DataGridViewColumn[] { Id, MSV, FirstName, Lastname, Birth, delete, edit, Muster });
        dgvStudentList.Location = new Point(6, 66);
        dgvStudentList.Name = "dgvStudentList";
        dgvStudentList.Size = new Size(637, 186);
        dgvStudentList.TabIndex = 0;
        dgvStudentList.CellContentClick += dgvStudentList_CellContentClick;
        dgvStudentList.EditingControlShowing += dgvStudentList_EditingControlShowing;
        // 
        // sqlCommand1
        // 
        sqlCommand1.CommandTimeout = 30;
        sqlCommand1.EnableOptimizedParameterBinding = false;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(61, 4);
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripMenuItem, classesToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        menuStrip1.ItemClicked += menuStrip1_ItemClicked;
        // 
        // accountToolStripMenuItem
        // 
        accountToolStripMenuItem.Name = "accountToolStripMenuItem";
        accountToolStripMenuItem.Size = new Size(64, 20);
        accountToolStripMenuItem.Text = "Account";
        // 
        // classesToolStripMenuItem
        // 
        classesToolStripMenuItem.Name = "classesToolStripMenuItem";
        classesToolStripMenuItem.Size = new Size(57, 20);
        classesToolStripMenuItem.Text = "Classes";
        // 
        // Id
        // 
        Id.HeaderText = "Id";
        Id.Name = "Id";
        // 
        // MSV
        // 
        MSV.HeaderText = "Mã Sinh Viên";
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
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.NullValue = "xoá";
        delete.DefaultCellStyle = dataGridViewCellStyle1;
        delete.HeaderText = "";
        delete.Name = "delete";
        delete.Width = 50;
        // 
        // edit
        // 
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        // StudentListScreen
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(menuStrip1);
        Controls.Add(groupBox1);
        MainMenuStrip = menuStrip1;
        Name = "StudentListScreen";
        Text = "StudentListScreen";
        Load += StudentListScreen_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((ISupportInitialize)dgvStudentList).EndInit();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox groupBox1;
    private DataGridView dgvStudentList;
    private Button addStudentButton;
    private TextBox textBox1;
    private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    private ContextMenuStrip contextMenuStrip1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem accountToolStripMenuItem;
    private ToolStripMenuItem classesToolStripMenuItem;
    private DataGridViewTextBoxColumn Id;
    private DataGridViewTextBoxColumn MSV;
    private DataGridViewTextBoxColumn FirstName;
    private DataGridViewTextBoxColumn Lastname;
    private DataGridViewTextBoxColumn Birth;
    private DataGridViewButtonColumn delete;
    private DataGridViewButtonColumn edit;
    private DataGridViewComboBoxColumn Muster;
}