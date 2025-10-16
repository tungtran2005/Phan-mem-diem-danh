namespace Phan_mem_diem_danh.Views;

public partial class SettingScreen : Form
{
    private readonly Configuration _configuration;

    public SettingScreen(Configuration configuration)
    {
        _configuration = configuration;
        InitializeComponent();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;

        var oldPwd = txtOldPassword.Text;
        var newPwd = txtNewPassword.Text;
        var confirmPwd = txtConfirmPassword.Text;

        var (success, message) = _configuration.AuthService.ChangePassword(oldPwd, newPwd, confirmPwd);

        if (success)
        {
            lblMessage.ForeColor = Color.ForestGreen;
            lblMessage.Text = "Đổi mật khẩu thành công.";
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
        else
        {
            lblMessage.ForeColor = Color.FromArgb(192, 0, 0);
            lblMessage.Text = message;
        }
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        txtOldPassword.Clear();
        txtNewPassword.Clear();
        txtConfirmPassword.Clear();
        lblMessage.Text = string.Empty;
    }
}