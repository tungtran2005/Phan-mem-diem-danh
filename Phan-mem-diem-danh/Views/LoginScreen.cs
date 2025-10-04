using System.Configuration;
using System.Drawing.Text;
using Phan_mem_diem_danh.Services;

namespace Phan_mem_diem_danh.Views;

public partial class LoginScreen : Form
{
    AuthService authService;
    public LoginScreen(Configuration configuration)
    {
        InitializeComponent();
        authService = configuration.AuthService;

    }

    private void LoginScreen_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string msv = txtMSV.Text.Trim();
            string password = txtPassword.Text.Trim();
            var account = authService.Login(msv, password);

            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 
    }
}