using System.ComponentModel;

namespace Client;

partial class NormalUserForm {
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
		usernameLabel = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		panel3 = new System.Windows.Forms.Panel();
		startGoingButton = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		mainPanel = new System.Windows.Forms.Panel();
		gmapPanel = new System.Windows.Forms.Panel();
		backButton = new System.Windows.Forms.Button();
		gmapPanel2nd = new System.Windows.Forms.Panel();
		panel4 = new System.Windows.Forms.Panel();
		label5 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		priceLabel = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		findingPanel = new System.Windows.Forms.Panel();
		findingLabel = new System.Windows.Forms.Label();
		cancelBookingButton = new System.Windows.Forms.Button();
		confirmLocationButton = new System.Windows.Forms.Button();
		foundDriverPanel = new System.Windows.Forms.Panel();
		gmapPanel1st = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel5 = new System.Windows.Forms.Panel();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		label8 = new System.Windows.Forms.Label();
		driverNameText = new System.Windows.Forms.Label();
		foundDriverTextPanel = new System.Windows.Forms.Panel();
		label9 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		completeDriveButton = new System.Windows.Forms.Button();
		completeDriveTextPanel = new System.Windows.Forms.Panel();
		label6 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		chooseLocationPanel = new System.Windows.Forms.Panel();
		chooseLocationButton = new System.Windows.Forms.Button();
		panel7 = new System.Windows.Forms.Panel();
		targetLocationTextBox = new System.Windows.Forms.TextBox();
		panel6 = new System.Windows.Forms.Panel();
		currentLocationTextBox = new System.Windows.Forms.TextBox();
		chooseLocationBackButton = new System.Windows.Forms.Button();
		panel1.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		mainPanel.SuspendLayout();
		gmapPanel.SuspendLayout();
		gmapPanel2nd.SuspendLayout();
		panel4.SuspendLayout();
		findingPanel.SuspendLayout();
		foundDriverPanel.SuspendLayout();
		gmapPanel1st.SuspendLayout();
		panel5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		foundDriverTextPanel.SuspendLayout();
		completeDriveTextPanel.SuspendLayout();
		chooseLocationPanel.SuspendLayout();
		panel7.SuspendLayout();
		panel6.SuspendLayout();
		SuspendLayout();

		// 
		// usernameLabel
		// 
		usernameLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		usernameLabel.Location = new System.Drawing.Point(18, 185);
		usernameLabel.Name = "usernameLabel";
		usernameLabel.Size = new System.Drawing.Size(434, 72);
		usernameLabel.TabIndex = 0;
		usernameLabel.Text = "Xin chào, username!";

		// 
		// panel1
		// 
		panel1.BackColor = System.Drawing.SystemColors.HighlightText;
		panel1.Controls.Add(panel3);
		panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		panel1.Location = new System.Drawing.Point(0, 260);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(464, 555);
		panel1.TabIndex = 1;

		// 
		// panel3
		// 
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(startGoingButton);
		panel3.Controls.Add(pictureBox1);
		panel3.Location = new System.Drawing.Point(12, 22);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(440, 64);
		panel3.TabIndex = 0;

		// 
		// startGoingButton
		// 
		startGoingButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		startGoingButton.ForeColor = System.Drawing.SystemColors.Highlight;
		startGoingButton.Location = new System.Drawing.Point(59, 11);
		startGoingButton.Name = "startGoingButton";
		startGoingButton.Size = new System.Drawing.Size(376, 40);
		startGoingButton.TabIndex = 2;
		startGoingButton.Text = "Hôm nay bạn muốn đi đâu?";
		startGoingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		startGoingButton.UseVisualStyleBackColor = true;
		startGoingButton.Click += startGoingButton_Click;

		// 
		// pictureBox1
		// 
		pictureBox1.Location = new System.Drawing.Point(8, 11);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(45, 40);
		pictureBox1.TabIndex = 1;
		pictureBox1.TabStop = false;

		// 
		// mainPanel
		// 
		mainPanel.Controls.Add(panel1);
		mainPanel.Controls.Add(usernameLabel);
		mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		mainPanel.Location = new System.Drawing.Point(0, 0);
		mainPanel.Name = "mainPanel";
		mainPanel.Size = new System.Drawing.Size(464, 815);
		mainPanel.TabIndex = 2;
		mainPanel.Visible = false;

		// 
		// gmapPanel
		// 
		gmapPanel.Controls.Add(backButton);
		gmapPanel.Controls.Add(foundDriverPanel);
		gmapPanel.Controls.Add(gmapPanel2nd);
		gmapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		gmapPanel.Location = new System.Drawing.Point(0, 0);
		gmapPanel.Name = "gmapPanel";
		gmapPanel.Size = new System.Drawing.Size(464, 815);
		gmapPanel.TabIndex = 3;

		// 
		// backButton
		// 
		backButton.BackColor = System.Drawing.Color.Red;
		backButton.Location = new System.Drawing.Point(15, 14);
		backButton.Name = "backButton";
		backButton.Size = new System.Drawing.Size(66, 61);
		backButton.TabIndex = 6;
		backButton.Text = "Quay về";
		backButton.UseVisualStyleBackColor = false;
		backButton.Click += backButton_Click;

		// 
		// gmapPanel2nd
		// 
		gmapPanel2nd.BackColor = System.Drawing.SystemColors.HighlightText;
		gmapPanel2nd.Controls.Add(panel4);
		gmapPanel2nd.Location = new System.Drawing.Point(0, 370);
		gmapPanel2nd.Margin = new System.Windows.Forms.Padding(30);
		gmapPanel2nd.Name = "gmapPanel2nd";
		gmapPanel2nd.Padding = new System.Windows.Forms.Padding(30);
		gmapPanel2nd.Size = new System.Drawing.Size(464, 445);
		gmapPanel2nd.TabIndex = 5;

		// 
		// panel4
		// 
		panel4.BackColor = System.Drawing.SystemColors.Control;
		panel4.Controls.Add(label5);
		panel4.Controls.Add(label4);
		panel4.Controls.Add(priceLabel);
		panel4.Controls.Add(label2);
		panel4.Controls.Add(findingPanel);
		panel4.Controls.Add(confirmLocationButton);
		panel4.Dock = System.Windows.Forms.DockStyle.Fill;
		panel4.Location = new System.Drawing.Point(30, 30);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(404, 385);
		panel4.TabIndex = 0;

		// 
		// label5
		// 
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label5.ForeColor = System.Drawing.SystemColors.ControlText;
		label5.Location = new System.Drawing.Point(18, 180);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(386, 89);
		label5.TabIndex = 1;
		label5.Text = "Hiện tại tađii chỉ hỗ trợ thanh toán bằng phương thức tiền mặt";

		// 
		// label4
		// 
		label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label4.ForeColor = System.Drawing.SystemColors.ControlText;
		label4.Location = new System.Drawing.Point(19, 96);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(385, 101);
		label4.TabIndex = 1;
		label4.Text = "Vui lòng xác nhận để bắt đầu tìm tài xế";

		// 
		// priceLabel
		// 
		priceLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		priceLabel.ForeColor = System.Drawing.SystemColors.ControlText;
		priceLabel.Location = new System.Drawing.Point(223, 15);
		priceLabel.Name = "priceLabel";
		priceLabel.Size = new System.Drawing.Size(181, 76);
		priceLabel.TabIndex = 0;
		priceLabel.Text = "32.000 VND";
		priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// label2
		// 
		label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label2.ForeColor = System.Drawing.SystemColors.ControlText;
		label2.Location = new System.Drawing.Point(18, 15);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(199, 76);
		label2.TabIndex = 0;
		label2.Text = "Giá dự kiến:";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// findingPanel
		// 
		findingPanel.Controls.Add(findingLabel);
		findingPanel.Controls.Add(cancelBookingButton);
		findingPanel.Location = new System.Drawing.Point(3, 272);
		findingPanel.Name = "findingPanel";
		findingPanel.Size = new System.Drawing.Size(398, 113);
		findingPanel.TabIndex = 4;

		// 
		// findingLabel
		// 
		findingLabel.Dock = System.Windows.Forms.DockStyle.Top;
		findingLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		findingLabel.ForeColor = System.Drawing.SystemColors.ControlText;
		findingLabel.Location = new System.Drawing.Point(0, 0);
		findingLabel.Name = "findingLabel";
		findingLabel.Size = new System.Drawing.Size(398, 47);
		findingLabel.TabIndex = 3;
		findingLabel.Text = "Đang tìm tài xế";
		findingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		// 
		// cancelBookingButton
		// 
		cancelBookingButton.BackColor = System.Drawing.Color.Tomato;
		cancelBookingButton.Dock = System.Windows.Forms.DockStyle.Bottom;
		cancelBookingButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		cancelBookingButton.ForeColor = System.Drawing.SystemColors.Control;
		cancelBookingButton.Location = new System.Drawing.Point(0, 50);
		cancelBookingButton.Name = "cancelBookingButton";
		cancelBookingButton.Size = new System.Drawing.Size(398, 63);
		cancelBookingButton.TabIndex = 5;
		cancelBookingButton.Text = "Hủy tìm tài xế";
		cancelBookingButton.UseVisualStyleBackColor = false;
		cancelBookingButton.Click += cancelBookingButton_Click;

		// 
		// confirmLocationButton
		// 
		confirmLocationButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
		confirmLocationButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		confirmLocationButton.ForeColor = System.Drawing.SystemColors.Control;
		confirmLocationButton.Location = new System.Drawing.Point(3, 295);
		confirmLocationButton.Name = "confirmLocationButton";
		confirmLocationButton.Size = new System.Drawing.Size(398, 84);
		confirmLocationButton.TabIndex = 2;
		confirmLocationButton.Text = "Xác nhận";
		confirmLocationButton.UseVisualStyleBackColor = false;
		confirmLocationButton.Click += confirmLocationButton_Click;

		// 
		// foundDriverPanel
		// 
		foundDriverPanel.BackColor = System.Drawing.SystemColors.HighlightText;
		foundDriverPanel.Controls.Add(gmapPanel1st);
		foundDriverPanel.Controls.Add(panel5);
		foundDriverPanel.Location = new System.Drawing.Point(0, 370);
		foundDriverPanel.Margin = new System.Windows.Forms.Padding(30);
		foundDriverPanel.Name = "foundDriverPanel";
		foundDriverPanel.Padding = new System.Windows.Forms.Padding(30);
		foundDriverPanel.Size = new System.Drawing.Size(464, 445);
		foundDriverPanel.TabIndex = 6;

		// 
		// gmapPanel1st
		// 
		gmapPanel1st.BackColor = System.Drawing.SystemColors.HighlightText;
		gmapPanel1st.Controls.Add(label1);
		gmapPanel1st.Location = new System.Drawing.Point(0, 501);
		gmapPanel1st.Name = "gmapPanel1st";
		gmapPanel1st.Size = new System.Drawing.Size(706, 154);
		gmapPanel1st.TabIndex = 4;

		// 
		// label1
		// 
		label1.Dock = System.Windows.Forms.DockStyle.Fill;
		label1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		label1.Location = new System.Drawing.Point(0, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(706, 154);
		label1.TabIndex = 0;
		label1.Text = "Hãy chọn điểm đến";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		// 
		// panel5
		// 
		panel5.BackColor = System.Drawing.SystemColors.Control;
		panel5.Controls.Add(pictureBox2);
		panel5.Controls.Add(label8);
		panel5.Controls.Add(driverNameText);
		panel5.Controls.Add(foundDriverTextPanel);
		panel5.Controls.Add(completeDriveButton);
		panel5.Controls.Add(completeDriveTextPanel);
		panel5.Dock = System.Windows.Forms.DockStyle.Fill;
		panel5.Location = new System.Drawing.Point(30, 30);
		panel5.Margin = new System.Windows.Forms.Padding(30);
		panel5.Name = "panel5";
		panel5.Padding = new System.Windows.Forms.Padding(30);
		panel5.Size = new System.Drawing.Size(404, 385);
		panel5.TabIndex = 0;

		// 
		// pictureBox2
		// 
		pictureBox2.Location = new System.Drawing.Point(21, 166);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(115, 115);
		pictureBox2.TabIndex = 4;
		pictureBox2.TabStop = false;

		// 
		// label8
		// 
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label8.ForeColor = System.Drawing.SystemColors.ControlText;
		label8.Location = new System.Drawing.Point(156, 227);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(248, 54);
		label8.TabIndex = 1;
		label8.Text = "36H1-6969";

		// 
		// driverNameText
		// 
		driverNameText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		driverNameText.ForeColor = System.Drawing.SystemColors.ControlText;
		driverNameText.Location = new System.Drawing.Point(156, 171);
		driverNameText.Name = "driverNameText";
		driverNameText.Size = new System.Drawing.Size(248, 54);
		driverNameText.TabIndex = 1;
		driverNameText.Text = "Lê Văn Liêm";
		driverNameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// foundDriverTextPanel
		// 
		foundDriverTextPanel.Controls.Add(label9);
		foundDriverTextPanel.Controls.Add(label7);
		foundDriverTextPanel.Location = new System.Drawing.Point(3, 3);
		foundDriverTextPanel.Name = "foundDriverTextPanel";
		foundDriverTextPanel.Size = new System.Drawing.Size(401, 149);
		foundDriverTextPanel.TabIndex = 5;

		// 
		// label9
		// 
		label9.Dock = System.Windows.Forms.DockStyle.Top;
		label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label9.ForeColor = System.Drawing.SystemColors.ControlText;
		label9.Location = new System.Drawing.Point(0, 0);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(401, 62);
		label9.TabIndex = 0;
		label9.Text = "Đã tìm thấy tài xế!";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// label7
		// 
		label7.Dock = System.Windows.Forms.DockStyle.Bottom;
		label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label7.ForeColor = System.Drawing.SystemColors.ControlText;
		label7.Location = new System.Drawing.Point(0, 76);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(401, 73);
		label7.TabIndex = 1;
		label7.Text = "Tài xế đang đến địa điểm của bạn";

		// 
		// completeDriveButton
		// 
		completeDriveButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
		completeDriveButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		completeDriveButton.Location = new System.Drawing.Point(3, 322);
		completeDriveButton.Name = "completeDriveButton";
		completeDriveButton.Size = new System.Drawing.Size(398, 57);
		completeDriveButton.TabIndex = 7;
		completeDriveButton.Text = "Hoàn tất";
		completeDriveButton.UseVisualStyleBackColor = false;
		completeDriveButton.Click += completeDriveButton_Click;

		// 
		// completeDriveTextPanel
		// 
		completeDriveTextPanel.Controls.Add(label6);
		completeDriveTextPanel.Controls.Add(label10);
		completeDriveTextPanel.Location = new System.Drawing.Point(2, 3);
		completeDriveTextPanel.Name = "completeDriveTextPanel";
		completeDriveTextPanel.Size = new System.Drawing.Size(402, 149);
		completeDriveTextPanel.TabIndex = 6;

		// 
		// label6
		// 
		label6.Dock = System.Windows.Forms.DockStyle.Top;
		label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label6.ForeColor = System.Drawing.SystemColors.ControlText;
		label6.Location = new System.Drawing.Point(0, 0);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(402, 62);
		label6.TabIndex = 0;
		label6.Text = "Chuyến xe đã hoàn tất!";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		// 
		// label10
		// 
		label10.Dock = System.Windows.Forms.DockStyle.Bottom;
		label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		label10.ForeColor = System.Drawing.SystemColors.ControlText;
		label10.Location = new System.Drawing.Point(0, 76);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(402, 73);
		label10.TabIndex = 1;
		label10.Text = "Nhấn nút ở dưới để trở về menu chính!";

		// 
		// chooseLocationPanel
		// 
		chooseLocationPanel.BackColor = System.Drawing.SystemColors.HighlightText;
		chooseLocationPanel.Controls.Add(chooseLocationButton);
		chooseLocationPanel.Controls.Add(panel7);
		chooseLocationPanel.Controls.Add(panel6);
		chooseLocationPanel.Controls.Add(chooseLocationBackButton);
		chooseLocationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		chooseLocationPanel.Location = new System.Drawing.Point(0, 0);
		chooseLocationPanel.Name = "chooseLocationPanel";
		chooseLocationPanel.Size = new System.Drawing.Size(464, 815);
		chooseLocationPanel.TabIndex = 4;

		// 
		// chooseLocationButton
		// 
		chooseLocationButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
		chooseLocationButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		chooseLocationButton.Location = new System.Drawing.Point(12, 722);
		chooseLocationButton.Name = "chooseLocationButton";
		chooseLocationButton.Size = new System.Drawing.Size(436, 81);
		chooseLocationButton.TabIndex = 3;
		chooseLocationButton.Text = "Tiếp theo";
		chooseLocationButton.UseVisualStyleBackColor = false;
		chooseLocationButton.Click += chooseLocationButton_Click;

		// 
		// panel7
		// 
		panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel7.Controls.Add(targetLocationTextBox);
		panel7.Location = new System.Drawing.Point(24, 196);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(428, 58);
		panel7.TabIndex = 2;

		// 
		// targetLocationTextBox
		// 
		targetLocationTextBox.Location = new System.Drawing.Point(64, 16);
		targetLocationTextBox.Name = "targetLocationTextBox";
		targetLocationTextBox.PlaceholderText = "Nhập điểm đến";
		targetLocationTextBox.Size = new System.Drawing.Size(359, 23);
		targetLocationTextBox.TabIndex = 0;
		targetLocationTextBox.TextChanged += targetLocationTextBox_TextChanged;

		// 
		// panel6
		// 
		panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel6.Controls.Add(currentLocationTextBox);
		panel6.Location = new System.Drawing.Point(24, 124);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(428, 58);
		panel6.TabIndex = 2;

		// 
		// currentLocationTextBox
		// 
		currentLocationTextBox.Location = new System.Drawing.Point(64, 16);
		currentLocationTextBox.Name = "currentLocationTextBox";
		currentLocationTextBox.PlaceholderText = "<Địa điểm hiện tại>";
		currentLocationTextBox.Size = new System.Drawing.Size(359, 23);
		currentLocationTextBox.TabIndex = 0;
		currentLocationTextBox.TextChanged += currentLocationTextBox_TextChanged;

		// 
		// chooseLocationBackButton
		// 
		chooseLocationBackButton.BackColor = System.Drawing.Color.Red;
		chooseLocationBackButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
		chooseLocationBackButton.Location = new System.Drawing.Point(24, 18);
		chooseLocationBackButton.Name = "chooseLocationBackButton";
		chooseLocationBackButton.Size = new System.Drawing.Size(78, 76);
		chooseLocationBackButton.TabIndex = 1;
		chooseLocationBackButton.Text = "Back";
		chooseLocationBackButton.UseVisualStyleBackColor = false;
		chooseLocationBackButton.Click += chooseLocationBackButton_Click;

		// 
		// NormalUserForm
		// 
		AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.MenuHighlight;
		ClientSize = new System.Drawing.Size(464, 815);
		Controls.Add(gmapPanel);
		Controls.Add(chooseLocationPanel);
		Controls.Add(mainPanel);
		ForeColor = System.Drawing.SystemColors.Control;
		StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Normal User";
		Load += NormalUserForm_Load;
		panel1.ResumeLayout(false);
		panel3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		mainPanel.ResumeLayout(false);
		gmapPanel.ResumeLayout(false);
		gmapPanel2nd.ResumeLayout(false);
		panel4.ResumeLayout(false);
		findingPanel.ResumeLayout(false);
		foundDriverPanel.ResumeLayout(false);
		gmapPanel1st.ResumeLayout(false);
		panel5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		foundDriverTextPanel.ResumeLayout(false);
		completeDriveTextPanel.ResumeLayout(false);
		chooseLocationPanel.ResumeLayout(false);
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		ResumeLayout(false);
	}

	private System.Windows.Forms.Button chooseLocationButton;

	private System.Windows.Forms.TextBox currentLocationTextBox;
	private System.Windows.Forms.Panel panel7;
	private System.Windows.Forms.TextBox targetLocationTextBox;

	private System.Windows.Forms.Button chooseLocationBackButton;

	private System.Windows.Forms.Panel panel6;

	private System.Windows.Forms.Panel chooseLocationPanel;

	private System.Windows.Forms.Button backButton;

	private System.Windows.Forms.Panel foundDriverTextPanel;
	private System.Windows.Forms.Panel completeDriveTextPanel;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.Label label10;
	private System.Windows.Forms.Button completeDriveButton;

	private System.Windows.Forms.Panel findingPanel;

	private System.Windows.Forms.Label label8;

	private System.Windows.Forms.PictureBox pictureBox2;

	private System.Windows.Forms.Panel foundDriverPanel;
	private System.Windows.Forms.Panel panel5;
	private System.Windows.Forms.Button cancelBookingButton;
	private System.Windows.Forms.Label driverNameText;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Label label9;

	private System.Windows.Forms.Label findingLabel;

	private System.Windows.Forms.Panel gmapPanel1st;

	private System.Windows.Forms.Button confirmLocationButton;

	private System.Windows.Forms.Label label5;

	private System.Windows.Forms.Label priceLabel;
	private System.Windows.Forms.Label label4;

	private System.Windows.Forms.Label label2;

	private System.Windows.Forms.Panel panel4;

	private System.Windows.Forms.Label label1;

	private System.Windows.Forms.Panel gmapPanel2nd;

	private System.Windows.Forms.Panel gmapPanel;

	private System.Windows.Forms.PictureBox pictureBox1;
	private System.Windows.Forms.Button startGoingButton;

	private System.Windows.Forms.Panel panel3;

	private System.Windows.Forms.Panel mainPanel;

	private System.Windows.Forms.Panel panel1;

	private System.Windows.Forms.Label usernameLabel;
	#endregion
}