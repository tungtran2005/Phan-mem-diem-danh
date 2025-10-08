namespace Phan_mem_diem_danh.Views;

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Phan_mem_diem_danh.Database.Entities;

public class ClassFormScreen : Form
{
    private readonly Configuration _config;

    // UI
    TextBox txtName = null!, txtSubject = null!, txtDept = null!;
    DateTimePicker dtStart = null!, dtEnd = null!;
    Button btnAdd = null!, btnUpdate = null!, btnDelete = null!, btnClose = null!;

    public ClassFormScreen(Configuration cfg)
    {
        _config = cfg;
        BuildUi();
        ApplyAcl();
    }

    // ====== UI ======
    private void BuildUi()
    {
        Text = "Chỉnh sửa lớp học";
        Width = 620; Height = 360;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;

        var y = 20; int gap = 40;

        Controls.Add(new Label { Text = "Tên lớp:", Left = 20, Top = y, Width = 160 });
        txtName = new TextBox { Left = 190, Top = y - 2, Width = 390 };
        Controls.Add(txtName); // Thêm TextBox vào Controls
        y += gap;

        Controls.Add(new Label { Text = "Môn học:", Left = 20, Top = y, Width = 160 });
        txtSubject = new TextBox { Left = 190, Top = y - 2, Width = 390 };
        Controls.Add(txtSubject); // Thêm TextBox vào Controls
        y += gap;

        Controls.Add(new Label { Text = "Khoa/Bộ môn:", Left = 20, Top = y, Width = 160 });
        txtDept = new TextBox { Left = 190, Top = y - 2, Width = 390 };
        Controls.Add(txtDept); // Thêm TextBox vào Controls
        y += gap;

        Controls.Add(new Label { Text = "Bắt đầu:", Left = 20, Top = y, Width = 160 });
        dtStart = new DateTimePicker { Left = 190, Top = y - 4, Width = 160, Format = DateTimePickerFormat.Short };
        Controls.Add(dtStart); // Thêm DateTimePicker vào Controls
        y += gap;

        Controls.Add(new Label { Text = "Kết thúc:", Left = 20, Top = y, Width = 160 });
        dtEnd = new DateTimePicker { Left = 190, Top = y - 4, Width = 160, Format = DateTimePickerFormat.Short };
        Controls.Add(dtEnd); // Thêm DateTimePicker vào Controls
        y += gap + 6;

        btnClose = new Button { Text = "Đóng", Left = 20, Top = y, Width = 100 };
        btnAdd = new Button { Text = "Thêm lớp", Left = 190, Top = y, Width = 120 };
        btnUpdate = new Button { Text = "Cập nhật lớp", Left = 320, Top = y, Width = 120 };
        btnDelete = new Button { Text = "Xóa lớp", Left = 450, Top = y, Width = 120 };

        btnClose.Click += (s, e) => DialogResult = DialogResult.Cancel;
        btnAdd.Click += (s, e) => AddClass();
        btnUpdate.Click += (s, e) => UpdateClass();
        btnDelete.Click += (s, e) => DeleteClass();

        Controls.AddRange(new Control[] { btnClose, btnAdd, btnUpdate, btnDelete });
    }

    // ====== ACL: chỉ GV được thao tác ======
    private void ApplyAcl()
    {
        bool allowed = true;
        try
        {
            var auth = _config.AuthService;
            if (auth != null)
            {
                var isTeacherProp = auth.GetType().GetProperty("IsTeacher");
                if (isTeacherProp != null)
                    allowed = isTeacherProp.GetValue(auth) as bool? ?? allowed;
                else
                {
                    var roleProp = auth.GetType().GetProperty("CurrentRole");
                    var role = roleProp?.GetValue(auth) as string;
                    if (!string.IsNullOrWhiteSpace(role))
                        allowed = string.Equals(role, "Teacher", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        catch { /* default true khi test */ }

        btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = allowed;
        if (!allowed)
        {
            Controls.Add(new Label
            {
                Text = "(Chỉ giảng viên mới được thao tác)",
                AutoSize = true,
                Left = 20,
                Top = 4,
                ForeColor = Color.Red
            });
        }
    }

    // ====== Helpers ======
    private string NameText => txtName.Text.Trim();
    private string SubjectText => txtSubject.Text.Trim();

    private Class? FindByNameAndSubject()
    {
        // Không cần thêm method repo – lọc qua List()
        return _config.ClassRepository
                      .List()
                      .FirstOrDefault(c =>
                          string.Equals(c.Name, NameText, StringComparison.OrdinalIgnoreCase) &&
                          string.Equals(c.Subject, SubjectText, StringComparison.OrdinalIgnoreCase));
    }

    // ====== Actions ======
    private void AddClass()
    {
        if (string.IsNullOrWhiteSpace(NameText) || string.IsNullOrWhiteSpace(SubjectText))
        { MessageBox.Show("Nhập Tên lớp và Môn học."); return; }

        if (FindByNameAndSubject() != null)
        { MessageBox.Show("Lớp đã tồn tại (trùng Tên lớp + Môn học)."); return; }

        var c = new Class
        {
            Name = NameText,
            Subject = SubjectText,
            Department = txtDept.Text.Trim(),
            StartDate = dtStart.Value.Date,
            EndDate = dtEnd.Value.Date
        };

        try
        {
            _config.ClassRepository.Create(c);
            MessageBox.Show("Đã thêm lớp.");
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show("Lỗi thêm lớp: " + ex.Message); }
    }

    private void UpdateClass()
    {
        var c = FindByNameAndSubject();
        if (c == null) { MessageBox.Show("Không tìm thấy lớp (theo Tên lớp + Môn học)."); return; }

        c.Department = txtDept.Text.Trim();
        c.StartDate = dtStart.Value.Date;
        c.EndDate = dtEnd.Value.Date;

        try
        {
            _config.ClassRepository.Update(c);
            MessageBox.Show("Đã cập nhật lớp.");
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show("Lỗi cập nhật lớp: " + ex.Message); }
    }

    private void DeleteClass()
    {
        if (string.IsNullOrWhiteSpace(NameText) || string.IsNullOrWhiteSpace(SubjectText))
        { MessageBox.Show("Nhập Tên lớp và Môn học để xóa."); return; }

        if (MessageBox.Show($"Xóa lớp '{NameText}' – '{SubjectText}' ?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        var c = FindByNameAndSubject();
        if (c == null) { MessageBox.Show("Không tìm thấy lớp."); return; }

        try
        {
            var ok = _config.ClassRepository.Delete(c.Id);
            MessageBox.Show(ok ? "Đã xóa lớp." : "Không thể xóa lớp.");
            if (ok) DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show("Lỗi xóa lớp: " + ex.Message); }
    }
}