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
    
    private void button1_Click_1(object sender, EventArgs e)
    {
        try
        {
            string username = usernameField.Text;
            string password = passwordField.Text;
            _authService.Login(username, password);
            
            Hide();
            _configuration.ClassListScreen.Show();
        }
        catch (AppException ex)
        {
            Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
            errorMessage.Text = ex.Message;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
        }
    }

    private void LoginScreen_Load(object? sender, EventArgs e)
    {
        
    }
}