using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Services;
using System.ComponentModel;

namespace Phan_mem_diem_danh.Views;

public partial class ClassListScreen : Form
{
    private readonly Configuration _configuration;

    public ClassListScreen(Configuration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
    }
    private void ClassListScreen_Load(object sender, EventArgs e)
    {

        btnThemLop.Visible = false;
        btnSuaLop.Visible = false;
        btnXoaLop.Visible = false;

        LoadClassList();
        if (true)
        {
            EnableAdminFeatures();
        }
    }

    public void LoadClassList()
    {
        var currentAccountId = LoggedInAccount.GetAccount().Id;
        var classList = _configuration.ClassService.GetClassListByAccountId(currentAccountId);
        ShowClasses(classList);
    }
    public void ShowClasses(List<Class> classes)
    {

        dgvClassList.AutoGenerateColumns = false;

        dgvClassList.Columns["Id"].DataPropertyName = "Id";
        dgvClassList.Columns["ClassName"].DataPropertyName = "Name";
        dgvClassList.Columns["Subject"].DataPropertyName = "Subject";
        dgvClassList.Columns["Department"].DataPropertyName = "Department";
        dgvClassList.Columns["StartDate"].DataPropertyName = "StartDate";
        dgvClassList.Columns["EndDate"].DataPropertyName = "EndDate";

        dgvClassList.DataSource = classes;
        dgvClassList.ClearSelection();
    }

    private void btnViewAll_Click(object sender, EventArgs e)
    {
        var classList = _configuration.ClassService.GetAllClasses();
        ShowClasses(classList);
    }

    private void logoutButton_Click(object sender, EventArgs e)
    {
        LoggedInAccount.ClearAccount();
        Hide();
        _configuration.LoginScreen.Show();
    }
    private void EnableAdminFeatures()
    {
        btnThemLop.Visible = true;
        btnSuaLop.Visible = true;
        btnXoaLop.Visible = true;

        btnSuaLop.Enabled = false;
        btnXoaLop.Enabled = false;
    }

    private void btnThemLop_Click(object sender, EventArgs e)
    {
        var addForm = new ClassFormScreen(_configuration);
        if (addForm.ShowDialog() == DialogResult.OK)
        {
            LoadClassList();
        }
    }

    private void btnSuaLop_Click(object sender, EventArgs e)
    {

    }

    private void btnXoaLop_Click(object sender, EventArgs e)
    {
        if (dgvClassList.SelectedRows.Count == 0) return;
        var selectedRow = dgvClassList.SelectedRows[0];

        int classId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
        string className = selectedRow.Cells["ClassName"].Value?.ToString() ?? "";
        string subject = selectedRow.Cells["Subject"].Value?.ToString() ?? "";
        var confirm = MessageBox.Show($"Bạn có chắc muốn xóa Sửa lớp: {className}, ID: {classId}, Môn: {subject} không?",
                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirm == DialogResult.Yes)
        {
            _configuration.ClassService.DeleteClass(classId);
            LoadClassList();
        }
    }

    private void dgvClassList_SelectionChanged(object sender, EventArgs e)
    {
        bool hasSelection = dgvClassList.SelectedRows.Count > 0;

        btnSuaLop.Enabled = hasSelection;
        btnXoaLop.Enabled = hasSelection;
    }
}