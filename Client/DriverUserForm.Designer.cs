using System.ComponentModel;

namespace Client;

partial class DriverUserForm {
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
		mainPanel = new System.Windows.Forms.Panel();
		menuPanel = new System.Windows.Forms.Panel();
		panel1 = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		onlineCheckBox = new System.Windows.Forms.CheckBox();
		tripPanel = new System.Windows.Forms.Panel();
		userNameText = new System.Windows.Forms.Label();
		foundUserPanel = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		completePanel = new System.Windows.Forms.Panel();
		label5 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		completeDriveButton = new System.Windows.Forms.Button();
		mainPanel.SuspendLayout();
		menuPanel.SuspendLayout();
		panel2.SuspendLayout();
		tripPanel.SuspendLayout();
		foundUserPanel.SuspendLayout();
		completePanel.SuspendLayout();
		SuspendLayout();

		// 
		// mainPanel
		// 
		mainPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
		mainPanel.Controls.Add(tripPanel);
		mainPanel.Controls.Add(menuPanel);
		mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		mainPanel.Location = new System.Drawing.Point(0, 0);
		mainPanel.Name = "mainPanel";
		mainPanel.Size = new System.Drawing.Size(464, 815);
		mainPanel.TabIndex = 0;

		// 
		// menuPanel
		// 
		menuPanel.BackColor = System.Drawing.Color.Transparent;
		menuPanel.Controls.Add(panel1);
		menuPanel.Controls.Add(panel2);
		menuPanel.Location = new System.Drawing.Point(0, 571);
		menuPanel.Name = "menuPanel";
		menuPanel.Size = new System.Drawing.Size(464, 244);
		menuPanel.TabIndex = 1;

		// 
		// panel1
		// 
		panel1.BackColor = System.Drawing.SystemColors.Control;
		panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		panel1.Location = new System.Drawing.Point(0, 124);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(464, 120);
		panel1.TabIndex = 0;

		// 
		// panel2
		// 
		panel2.BackColor = System.Drawing.SystemColors.Control;
		panel2.Controls.Add(label1);
		panel2.Controls.Add(onlineCheckBox);
		panel2.Location = new System.Drawing.Point(12, 21);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(440, 77);
		panel2.TabIndex = 0;

		// 
		// label1
		// 
		label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label1.Location = new System.Drawing.Point(83, 14);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(354, 47);
		label1.TabIndex = 1;
		label1.Text = "Bạn hiện đang online";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// onlineCheckBox
		// 
		onlineCheckBox.Location = new System.Drawing.Point(12, 17);
		onlineCheckBox.Name = "onlineCheckBox";
		onlineCheckBox.Size = new System.Drawing.Size(60, 44);
		onlineCheckBox.TabIndex = 0;
		onlineCheckBox.UseVisualStyleBackColor = true;
		onlineCheckBox.CheckedChanged += onlineCheckBox_CheckedChanged;

		// 
		// tripPanel
		// 
		tripPanel.BackColor = System.Drawing.SystemColors.HighlightText;
		tripPanel.Controls.Add(userNameText);
		tripPanel.Controls.Add(foundUserPanel);
		tripPanel.Controls.Add(completePanel);
		tripPanel.Controls.Add(completeDriveButton);
		tripPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
		tripPanel.Location = new System.Drawing.Point(0, 417);
		tripPanel.Name = "tripPanel";
		tripPanel.Size = new System.Drawing.Size(464, 398);
		tripPanel.TabIndex = 3;

		// 
		// userNameText
		// 
		userNameText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		userNameText.Location = new System.Drawing.Point(176, 152);
		userNameText.Name = "userNameText";
		userNameText.Size = new System.Drawing.Size(276, 57);
		userNameText.TabIndex = 0;
		userNameText.Text = "Lê Văn Liêm";
		userNameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// foundUserPanel
		// 
		foundUserPanel.Controls.Add(label4);
		foundUserPanel.Location = new System.Drawing.Point(3, 6);
		foundUserPanel.Name = "foundUserPanel";
		foundUserPanel.Size = new System.Drawing.Size(458, 131);
		foundUserPanel.TabIndex = 0;

		// 
		// label4
		// 
		label4.Dock = System.Windows.Forms.DockStyle.Top;
		label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label4.Location = new System.Drawing.Point(0, 0);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(458, 57);
		label4.TabIndex = 0;
		label4.Text = "Đã tìm thấy khách hàng!";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// completePanel
		// 
		completePanel.Controls.Add(label5);
		completePanel.Controls.Add(label2);
		completePanel.Location = new System.Drawing.Point(6, 3);
		completePanel.Name = "completePanel";
		completePanel.Size = new System.Drawing.Size(695, 131);
		completePanel.TabIndex = 0;

		// 
		// label5
		// 
		label5.Dock = System.Windows.Forms.DockStyle.Bottom;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label5.Location = new System.Drawing.Point(0, 74);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(695, 57);
		label5.TabIndex = 0;
		label5.Text = "Nhấn nút ở dưới để trở về menu chính!";

		// 
		// label2
		// 
		label2.Dock = System.Windows.Forms.DockStyle.Top;
		label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label2.Location = new System.Drawing.Point(0, 0);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(695, 57);
		label2.TabIndex = 0;
		label2.Text = "Chuyến xe đã hoàn tất!";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// completeDriveButton
		// 
		completeDriveButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
		completeDriveButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		completeDriveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
		completeDriveButton.Location = new System.Drawing.Point(12, 275);
		completeDriveButton.Name = "completeDriveButton";
		completeDriveButton.Size = new System.Drawing.Size(440, 111);
		completeDriveButton.TabIndex = 1;
		completeDriveButton.Text = "Hoàn tất";
		completeDriveButton.UseVisualStyleBackColor = false;
		completeDriveButton.Click += completeDriveButton_Click;

		// 
		// DriverUserForm
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		ClientSize = new System.Drawing.Size(464, 815);
		Controls.Add(mainPanel);
		StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "DriverUserForm";
		mainPanel.ResumeLayout(false);
		menuPanel.ResumeLayout(false);
		panel2.ResumeLayout(false);
		tripPanel.ResumeLayout(false);
		foundUserPanel.ResumeLayout(false);
		completePanel.ResumeLayout(false);
		ResumeLayout(false);
	}

	private System.Windows.Forms.Panel foundUserPanel;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label5;

	private System.Windows.Forms.Label userNameText;
	private System.Windows.Forms.Button completeDriveButton;

	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Panel completePanel;

	private System.Windows.Forms.Panel tripPanel;

	private System.Windows.Forms.Label label1;

	private System.Windows.Forms.CheckBox onlineCheckBox;

	private System.Windows.Forms.Panel panel2;
	private System.Windows.Forms.Panel mainPanel;

	private System.Windows.Forms.Panel panel1;
	private System.Windows.Forms.Panel menuPanel;
	#endregion
}