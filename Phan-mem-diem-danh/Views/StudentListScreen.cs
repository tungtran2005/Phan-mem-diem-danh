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

            dgvStudentList.Rows.Add(student.Id,student.MSV, student.FirstName, student.LastName, student.Birth.ToString("dd/MM/yyyy"));
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
        _configuration.ClassFormScreen.Show();
    }
    //to edit and delete
    private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        //select column
        var column = dgvStudentList.Columns[e.ColumnIndex];

        if (column.Name != "edit" && column.Name != "delete") return;
        //select row
        var row = dgvStudentList.Rows[e.RowIndex];

        //select  by cell
        int studentId = (Int32)row.Cells["Id"].Value;
        string MSV = row.Cells["MSV"].Value.ToString();

        if (column is DataGridViewButtonColumn)
        {
            if (column.Name == "delete")
            {
                DialogResult result= MessageBox.Show(
                    $"xoá sinh viên {MSV} ?",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if(result == DialogResult.Yes)
                {
                    //
                }
            }
            else if (column.Name == "edit")
            {
                MessageBox.Show($"edit : {studentId} ");
            }

        }
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    //for muster
    private void ComboBox_SelectedIndexChanged(object sender,EventArgs e)
    {
        if(sender is ComboBox combobox)
        {
            //select rowindex
            var rowIndex = dgvStudentList.CurrentCell.RowIndex;
            //select row
            var row = dgvStudentList.Rows[rowIndex];
            //select id by cell
            int studentId = (Int32)row.Cells["Id"].Value;

            string itemSelected = combobox.SelectedItem?.ToString();

            MessageBox.Show($"{studentId} + điểm danh : {itemSelected}");
        }
    }
    private void dgvStudentList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if(dgvStudentList.CurrentCell.OwningColumn.Name == "Muster" && e.Control is ComboBox combobox)
            {
                combobox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                combobox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
    }
}