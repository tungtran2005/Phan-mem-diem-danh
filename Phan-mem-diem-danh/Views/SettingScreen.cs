namespace Phan_mem_diem_danh.Views;

public partial class SettingScreen : Form
{
    private readonly Configuration _configuration;

    public SettingScreen(Configuration configuration)
    {
        _configuration = configuration;
        InitializeComponent();
    }

    private void SettingScreen_Load(object sender, EventArgs e)
    {

    }

    private void chkShowPasswords_CheckedChanged(object? sender, EventArgs e)
    {
        bool show = chkShowPasswords.Checked;
        txtCurrentPassword.UseSystemPasswordChar = !show;
        txtNewPassword.UseSystemPasswordChar = !show;
        txtConfirmPassword.UseSystemPasswordChar = !show;
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateForm())
        {
            return;
        }

        // Integration point: call _configuration.AuthService to perform the password change.
        // Example (when implemented): await _configuration.AuthService.ChangePasswordAsync(...);

        ShowMessage("Biểu mẫu hợp lệ. Vui lòng tích hợp dịch vụ đổi mật khẩu.", System.Drawing.Color.DodgerBlue);
    }

    private bool ValidateForm()
    {
        lblMessage.Visible = false;

        // 1) Kiểm tra rỗng
        if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ||
            string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
            string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
        {
            ShowMessage("Vui lòng nhập đầy đủ thông tin.", System.Drawing.Color.Firebrick);
            return false;
        }

        // 2) Xác thực người dùng và mật khẩu cũ
        var auth = _configuration.AuthService;
        if (auth is null || auth.CurrentAccount is null)
        {
            ShowMessage("Không thể xác thực người dùng. Vui lòng đăng nhập lại.", System.Drawing.Color.Firebrick);
            return false;
        }

        if (!auth.VerifyCurrentPassword(txtCurrentPassword.Text))
        {
            ShowMessage("Mật khẩu hiện tại không đúng.", System.Drawing.Color.Firebrick);
            return false;
        }

        // 3) Định dạng mật khẩu mới
        if (!IsValidPasswordFormat(txtNewPassword.Text, out var formatMessage))
        {
            ShowMessage(formatMessage, System.Drawing.Color.Firebrick);
            return false;
        }

        // 4) Xác nhận mật khẩu
        if (txtNewPassword.Text != txtConfirmPassword.Text)
        {
            ShowMessage("Xác nhận mật khẩu không khớp.", System.Drawing.Color.Firebrick);
            return false;
        }

        // 5) Mới không được trùng cũ
        if (txtNewPassword.Text == txtCurrentPassword.Text)
        {
            ShowMessage("Mật khẩu mới phải khác mật khẩu hiện tại.", System.Drawing.Color.Firebrick);
            return false;
        }

        return true;
    }

    // Quy tắc: tối thiểu 8 ký tự, có chữ hoa, chữ thường, số và ký tự đặc biệt
    private static bool IsValidPasswordFormat(string password, out string message)
    {
        if (password.Length < 8)
        {
            message = "Mật khẩu mới phải có ít nhất 8 ký tự.";
            return false;
        }

        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

        if (!hasUpper || !hasLower || !hasDigit || !hasSpecial)
        {
            message = "Mật khẩu mới phải bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt.";
            return false;
        }

        message = string.Empty;
        return true;
    }

    private void ShowMessage(string message, System.Drawing.Color color)
    {
        lblMessage.Text = message;
        lblMessage.ForeColor = color;
        lblMessage.Visible = true;
    }
}