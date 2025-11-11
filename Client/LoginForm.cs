using Client.Auth;
using Client.Net;
using Client.User;

namespace Client;

public partial class LoginForm : Form {
	private readonly AuthController _authController;
	
	public LoginForm() {
		_authController = new AuthController(ApiClientController.Api);
		InitializeComponent();
		
		this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
	}

	private void Form1_FormClosing(object? sender, FormClosingEventArgs e) {
		Logout();
	}

	private async Task Logout() {
		await UserController.Instance.SetOnlineStatusAsync(false);
		UserController.Instance.Reset();
		_authController.Logout();
	}
	private void loginButton_Click(object sender, EventArgs e) {
		Login();
	}

	private async Task Login() {
		string username = usernameTextBox.Text;
		string password = passwordTextBox.Text;
		
		Result<bool> login = await _authController.LoginAsync(username, password);
		if (!login.IsSuccess) {
			MessageBox.Show($"Login failed: {login.Error}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}
		
		new UserController(ApiClientController.Api);
		Result<bool> res = await UserController.Instance.UpdateUserInformationAsync(username);

		Console.WriteLine(UserController.Instance.User.Id);
		Console.WriteLine(UserController.Instance.User.Email);
		Console.WriteLine(UserController.Instance.User.IsOnline);
		Console.WriteLine(UserController.Instance.User.UserType);
		
		this.Hide(); // hide login window
		
		await UserController.Instance.SetOnlineStatusAsync(true);

		Form? main = null;
		
		if (UserController.Instance.User.UserType == EUserType.NormalUser) {
			Program.InstantiateSingletonForNormalUser();
			main = new NormalUserForm();
			main.FormClosed += (s, args) => this.Show(); // close login when main closes
			main.Show();
		}
		else {
			Program.InstantiateSingletonForDriverUser();
			main = new DriverUserForm();
			main.FormClosed += (s, args) => this.Show(); // close login when main closes
			main.Show();
		}
	}
	
	private void registerNormalUserButton_Click(object sender, EventArgs e) {
		Register(false);
	}
	
	private async Task Register(bool isDriver) {
		string username = usernameTextBox.Text;
		string password = passwordTextBox.Text;
		
		Result<bool> login = await _authController.RegisterAsync(username, password);
		if (!login.IsSuccess) {
			MessageBox.Show($"Register failed: {login.Error}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return;
		}

		MessageBox.Show($"User Registered!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}
}