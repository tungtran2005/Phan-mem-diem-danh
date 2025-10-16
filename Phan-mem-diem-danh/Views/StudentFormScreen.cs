namespace Phan_mem_diem_danh.Views;

using System;
using System.Drawing;
using System.Windows.Forms;
using Phan_mem_diem_danh.Database.Entities;

public class StudentFormScreen : Form
{
    private readonly Configuration _config;

    // UI
    TextBox txtMSV = null!, txtLast = null!, txtFirst = null!;
    DateTimePicker dtBirth = null!;
    Button btnAdd = null!, btnUpdate = null!, btnDelete = null!, btnClose = null!;

    public StudentFormScreen(Configuration cfg) : this(cfg, null) { }

    /// <param name="msv">MSV để nạp sẵn khi sửa (null = thêm mới)</param>
    public StudentFormScreen(Configuration cfg, string? msv)
    {
        _config = cfg;
        BuildUi();
        if (!string.IsNullOrWhiteSpace(msv)) LoadStudent(msv);
        ApplyAcl();
    }

    // ====== UI ======
    private void BuildUi()
    {
        Text = "Chỉnh sửa thông tin";
        Width = 540; Height = 320;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;

        SuspendLayout();

        var y = 20; int gap = 40;

        var lblMSV = new Label { Text = "MSV:", Left = 20, Top = y, Width = 120 };
        txtMSV = new TextBox { Left = 150, Top = y - 2, Width = 350 }; y += gap;

        var lblLast = new Label { Text = "Họ:", Left = 20, Top = y, Width = 120 };
        txtLast = new TextBox { Left = 150, Top = y - 2, Width = 350 }; y += gap;

        var lblFirst = new Label { Text = "Tên:", Left = 20, Top = y, Width = 120 };
        txtFirst = new TextBox { Left = 150, Top = y - 2, Width = 350 }; y += gap;

        var lblBirth = new Label { Text = "Ngày sinh:", Left = 20, Top = y, Width = 120 };
        dtBirth = new DateTimePicker { Left = 150, Top = y - 4, Width = 160, Format = DateTimePickerFormat.Short };
        y += gap + 6;

        btnClose = new Button { Text = "Đóng", Left = 20, Top = y, Width = 100 };
        btnAdd = new Button { Text = "Thêm sinh viên", Left = 130, Top = y, Width = 120 };
        btnUpdate = new Button { Text = "Cập nhật thông tin", Left = 260, Top = y, Width = 130 };
        btnDelete = new Button { Text = "Xóa sinh viên", Left = 400, Top = y, Width = 120 };

        btnClose.Click += (s, e) => DialogResult = DialogResult.Cancel;
        btnAdd.Click += (s, e) => AddStudent();
        btnUpdate.Click += (s, e) => UpdateStudent();
        btnDelete.Click += (s, e) => DeleteStudent();

        // 👇 Quan trọng: Add cả label + input + nút vào Controls
        Controls.AddRange(new Control[] {
            lblMSV, txtMSV,
            lblLast, txtLast,
            lblFirst, txtFirst,
            lblBirth, dtBirth,
            btnClose, btnAdd, btnUpdate, btnDelete
        });

        ResumeLayout(false);
    }

    // ====== ACL: chỉ GV được thao tác ======
    private void ApplyAcl()
    {
        bool allowed = true;
        try
        {
            // Không phụ thuộc property cụ thể – đọc bằng reflection
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
        catch { /* giữ allowed = true khi test */ }

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
    private void LoadStudent(string msv)
    {
        var a = _config.AccountRepository.FindByMSV(msv);
        if (a == null)
        {
            MessageBox.Show("MSV không tồn tại."); return;
        }
        txtMSV.Text = a.MSV;
        txtLast.Text = a.LastName;
        txtFirst.Text = a.FirstName;
        dtBirth.Value = a.Birth == default ? DateTime.Now : a.Birth;
    }

    // ====== Actions ======
    private void AddStudent()
    {
        var msv = txtMSV.Text.Trim();
        if (string.IsNullOrWhiteSpace(msv) ||
            string.IsNullOrWhiteSpace(txtLast.Text) ||
            string.IsNullOrWhiteSpace(txtFirst.Text))
        { MessageBox.Show("Nhập đầy đủ MSV/Họ/Tên."); return; }

        if (_config.AccountRepository.FindByMSV(msv) != null)
        { MessageBox.Show("MSV đã tồn tại."); return; }

        var a = new Account
        {
            MSV = msv,
            LastName = txtLast.Text.Trim(),
            FirstName = txtFirst.Text.Trim(),
            Birth = dtBirth.Value.Date,
            Password = "123456" // tạm, theo quy ước team
        };

        try
        {
            _config.AccountRepository.Create(a);
            MessageBox.Show("Đã thêm sinh viên.");
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
    }

    private void UpdateStudent()
    {
        var msv = txtMSV.Text.Trim();
        var a = _config.AccountRepository.FindByMSV(msv);
        if (a == null) { MessageBox.Show("Không tìm thấy MSV."); return; }

        a.LastName = txtLast.Text.Trim();
        a.FirstName = txtFirst.Text.Trim();
        a.Birth = dtBirth.Value.Date;

        try
        {
            _config.AccountRepository.Update(a);
            MessageBox.Show("Đã cập nhật.");
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
    }

    private void DeleteStudent()
    {
        var msv = txtMSV.Text.Trim();
        if (string.IsNullOrWhiteSpace(msv)) { MessageBox.Show("Nhập MSV để xóa."); return; }
        if (MessageBox.Show($"Xóa sinh viên MSV {msv}?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        try
        {
            var ok = _config.AccountRepository.DeleteByMSV(msv);
            MessageBox.Show(ok ? "Đã xóa." : "Không tìm thấy MSV.");
            if (ok) DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
    }
}