using System.ComponentModel;

namespace Client;

partial class LoginForm {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}

		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		label1 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		registerNormalUserButton = new System.Windows.Forms.Button();
		loginButton = new System.Windows.Forms.Button();
		panel3 = new System.Windows.Forms.Panel();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		passwordTextBox = new System.Windows.Forms.TextBox();
		panel2 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		usernameTextBox = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();

		// 
		// label1
		// 
		label1.Dock = System.Windows.Forms.DockStyle.Top;
		label1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label1.Location = new System.Drawing.Point(0, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(464, 276);
		label1.TabIndex = 0;
		label1.Text = "tađii";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		// 
		// panel1
		// 
		panel1.BackColor = System.Drawing.SystemColors.HighlightText;
		panel1.Controls.Add(registerNormalUserButton);
		panel1.Controls.Add(loginButton);
		panel1.Controls.Add(panel3);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(label2);
		panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		panel1.Location = new System.Drawing.Point(0, 279);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(464, 536);
		panel1.TabIndex = 1;

		// 
		// registerNormalUserButton
		// 
		registerNormalUserButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
		registerNormalUserButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		registerNormalUserButton.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		registerNormalUserButton.ForeColor = System.Drawing.SystemColors.Control;
		registerNormalUserButton.Location = new System.Drawing.Point(22, 351);
		registerNormalUserButton.Name = "registerNormalUserButton";
		registerNormalUserButton.Size = new System.Drawing.Size(430, 64);
		registerNormalUserButton.TabIndex = 0;
		registerNormalUserButton.Text = "Test Đăng ký người dùng";
		registerNormalUserButton.UseVisualStyleBackColor = false;
		registerNormalUserButton.Click += registerNormalUserButton_Click;

		// 
		// loginButton
		// 
		loginButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
		loginButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		loginButton.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		loginButton.ForeColor = System.Drawing.SystemColors.Control;
		loginButton.Location = new System.Drawing.Point(22, 281);
		loginButton.Name = "loginButton";
		loginButton.Size = new System.Drawing.Size(430, 64);
		loginButton.TabIndex = 0;
		loginButton.Text = "Đăng nhập";
		loginButton.UseVisualStyleBackColor = false;
		loginButton.Click += loginButton_Click;

		// 
		// panel3
		// 
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(pictureBox2);
		panel3.Controls.Add(passwordTextBox);
		panel3.Location = new System.Drawing.Point(22, 215);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(430, 51);
		panel3.TabIndex = 2;

		// 
		// pictureBox2
		// 
		pictureBox2.Location = new System.Drawing.Point(11, 10);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(39, 24);
		pictureBox2.TabIndex = 2;
		pictureBox2.TabStop = false;

		// 
		// passwordTextBox
		// 
		passwordTextBox.Location = new System.Drawing.Point(78, 12);
		passwordTextBox.Name = "passwordTextBox";
		passwordTextBox.PasswordChar = '*';
		passwordTextBox.PlaceholderText = "Mật khẩu";
		passwordTextBox.Size = new System.Drawing.Size(288, 23);
		passwordTextBox.TabIndex = 1;
		passwordTextBox.UseSystemPasswordChar = true;

		// 
		// panel2
		// 
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(pictureBox1);
		panel2.Controls.Add(usernameTextBox);
		panel2.Location = new System.Drawing.Point(22, 158);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(430, 51);
		panel2.TabIndex = 2;

		// 
		// pictureBox1
		// 
		pictureBox1.Location = new System.Drawing.Point(11, 10);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(39, 24);
		pictureBox1.TabIndex = 2;
		pictureBox1.TabStop = false;

		// 
		// usernameTextBox
		// 
		usernameTextBox.Location = new System.Drawing.Point(78, 12);
		usernameTextBox.Name = "usernameTextBox";
		usernameTextBox.PlaceholderText = "Số điện thoại";
		usernameTextBox.Size = new System.Drawing.Size(347, 23);
		usernameTextBox.TabIndex = 2;

		// 
		// label2
		// 
		label2.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label2.ForeColor = System.Drawing.SystemColors.ControlText;
		label2.Location = new System.Drawing.Point(12, 40);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(440, 93);
		label2.TabIndex = 0;
		label2.Text = "Chào bạn!";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		// 
		// LoginForm
		// 
		AcceptButton = loginButton;
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.MenuHighlight;
		CancelButton = loginButton;
		ClientSize = new System.Drawing.Size(464, 815);
		Controls.Add(panel1);
		Controls.Add(label1);
		ForeColor = System.Drawing.SystemColors.Control;
		RightToLeft = System.Windows.Forms.RightToLeft.No;
		StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Login";
		panel1.ResumeLayout(false);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}

	private System.Windows.Forms.Button registerNormalUserButton;

	private System.Windows.Forms.Panel panel3;
	private System.Windows.Forms.PictureBox pictureBox2;
	private System.Windows.Forms.TextBox passwordTextBox;
	private System.Windows.Forms.Button loginButton;

	private System.Windows.Forms.PictureBox pictureBox1;

	private System.Windows.Forms.Panel panel2;

	private System.Windows.Forms.TextBox usernameTextBox;

	private System.Windows.Forms.Label label2;

	private System.Windows.Forms.Panel panel1;

	private System.Windows.Forms.Label label1;
	#endregion
}