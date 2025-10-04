using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Views;

public partial class ClassListScreen : Form
{
    private readonly Configuration _configuration;
    public ClassListScreen(Configuration configuration)
    {
        InitializeComponent();
        _configuration = configuration;

        this.LoadClassList(10);
    }

    public void LoadClassList(int currentAcountId)
    {
        var classList = _configuration.ClassService.GetClassListByAccountId(currentAcountId);
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
        var classList = _configuration.ClassRepository.List();
        ShowClasses(classList);
    }
}