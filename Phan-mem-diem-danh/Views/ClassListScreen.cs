using Phan_mem_diem_danh.Database.Entities;
using Phan_mem_diem_danh.Services;

namespace Phan_mem_diem_danh.Views;

public partial class ClassListScreen : Form
{
    private readonly Configuration _configuration;
    
    public ClassListScreen(Configuration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
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
        dgvClassList.DataSource = classes;
        dgvClassList.Columns["Id"].DataPropertyName = "Id";
        dgvClassList.Columns["ClassName"].DataPropertyName = "Name";
        dgvClassList.Columns["Subject"].DataPropertyName = "Subject";
        dgvClassList.Columns["Department"].DataPropertyName = "Department";
        dgvClassList.Columns["StartDate"].DataPropertyName = "StartDate";
        dgvClassList.Columns["EndDate"].DataPropertyName = "EndDate";
    }

    private void btnViewAll_Click(object sender, EventArgs e)
    {
        var classList = _configuration.ClassService.GetAllClasses();
        ShowClasses(classList);
    }
}