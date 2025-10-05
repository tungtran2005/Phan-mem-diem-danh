using Phan_mem_diem_danh.Exceptions;
using Phan_mem_diem_danh.Services;

namespace Phan_mem_diem_danh.Views;

public partial class LoginScreen : Form
{
    private Configuration _configuration;
    private AuthService _authService;
    
    public LoginScreen(Configuration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
        _authService = configuration.AuthService;

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
            _authService.Login(msv, password);

            Hide();
            _configuration.ClassListScreen.Show();
        }
        catch (AppException ex)
        {
            Console.Error.WriteLine(ex.Message);
            MessageBox.Show(ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.Error.WriteLine(ex.Message);
        } 
    }
}