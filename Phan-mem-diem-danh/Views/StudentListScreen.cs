using Phan_mem_diem_danh.Database.Entities;

namespace Phan_mem_diem_danh.Views;
public partial class StudentListScreen : Form
{
    private readonly Configuration _configuration;
    private int _classId;
    public StudentListScreen(Configuration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
    }
    public void setClassId(int id)
    {
        _classId = id;
    }
    private void loadClassHead(int classId)
    {
        Class? curentClass = _configuration.ClassService.GetClassById(classId);
    }
    
    private void loadStudentList(int classId)
    {
        List<Account> studentList = _configuration.AccountService.GetAccountListByClassId(classId);
        foreach (var student in studentList)
        {
            
            dgvStudentList.Rows.Add(student.MSV, student.FirstName, student.LastName, student.Birth.ToString("dd/MM/yyyy"));
        }

    }

    private void dgvStudentList_load()
    {

        DataGridViewComboBoxColumn btn = (DataGridViewComboBoxColumn)dgvStudentList.Columns["Muster"];
        btn.Items.Clear();
        btn.Items.AddRange("Có mặt", "Vắng mặt", "Muộn", "Xin phép");

    }
    private void StudentListScreen_Load(object sender, EventArgs e)
    {
        setClassId(1);
        dgvStudentList_load();
        loadClassHead(_classId);
        loadStudentList(_classId);
    }

    private void addStudentButton_Click(object sender, EventArgs e)
    {

    }
}