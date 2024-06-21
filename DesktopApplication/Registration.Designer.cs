namespace DesktopApplication
{
    partial class Registration
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblUserRePassword;
        private System.Windows.Forms.Label lblUserAddress;
        private System.Windows.Forms.Label lblUserContact;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserRePassword;
        private System.Windows.Forms.TextBox txtUserAddress;
        private System.Windows.Forms.TextBox txtUserContact;
        private System.Windows.Forms.Button btnUserRegister;
        private System.Windows.Forms.Label lblPartnerCompanyName;
        private System.Windows.Forms.Label lblPartnerEmail;
        private System.Windows.Forms.Label lblPartnerPassword;
        private System.Windows.Forms.Label lblPartnerRePassword;
        private System.Windows.Forms.Label lblPartnerAddress;
        private System.Windows.Forms.Label lblPartnerContact;
        private System.Windows.Forms.TextBox txtPartnerCompanyName;
        private System.Windows.Forms.TextBox txtPartnerEmail;
        private System.Windows.Forms.TextBox txtPartnerPassword;
        private System.Windows.Forms.TextBox txtPartnerRePassword;
        private System.Windows.Forms.TextBox txtPartnerAddress;
        private System.Windows.Forms.TextBox txtPartnerContact;
        private System.Windows.Forms.Button btnPartnerRegister;
        private System.Windows.Forms.Button btnSwitchToUser;
        private System.Windows.Forms.Button btnSwitchToPartner;
        private System.Windows.Forms.Label lblFormHeading;
        private System.Windows.Forms.Panel userFormPanel;
        private System.Windows.Forms.Panel partnerFormPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFormHeading = new System.Windows.Forms.Label();
            this.btnSwitchToUser = new System.Windows.Forms.Button();
            this.btnSwitchToPartner = new System.Windows.Forms.Button();
            this.userFormPanel = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserEmail = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.lblUserRePassword = new System.Windows.Forms.Label();
            this.txtUserRePassword = new System.Windows.Forms.TextBox();
            this.lblUserAddress = new System.Windows.Forms.Label();
            this.txtUserAddress = new System.Windows.Forms.TextBox();
            this.lblUserContact = new System.Windows.Forms.Label();
            this.txtUserContact = new System.Windows.Forms.TextBox();
            this.btnUserRegister = new System.Windows.Forms.Button();
            this.partnerFormPanel = new System.Windows.Forms.Panel();
            this.lblPartnerCompanyName = new System.Windows.Forms.Label();
            this.txtPartnerCompanyName = new System.Windows.Forms.TextBox();
            this.lblPartnerEmail = new System.Windows.Forms.Label();
            this.txtPartnerEmail = new System.Windows.Forms.TextBox();
            this.lblPartnerPassword = new System.Windows.Forms.Label();
            this.txtPartnerPassword = new System.Windows.Forms.TextBox();
            this.lblPartnerRePassword = new System.Windows.Forms.Label();
            this.txtPartnerRePassword = new System.Windows.Forms.TextBox();
            this.lblPartnerAddress = new System.Windows.Forms.Label();
            this.txtPartnerAddress = new System.Windows.Forms.TextBox();
            this.lblPartnerContact = new System.Windows.Forms.Label();
            this.txtPartnerContact = new System.Windows.Forms.TextBox();
            this.btnPartnerRegister = new System.Windows.Forms.Button();
            this.userFormPanel.SuspendLayout();
            this.partnerFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormHeading
            // 
            this.lblFormHeading.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblFormHeading.Location = new System.Drawing.Point(294, 20);
            this.lblFormHeading.Name = "lblFormHeading";
            this.lblFormHeading.Size = new System.Drawing.Size(300, 40);
            this.lblFormHeading.TabIndex = 0;
            this.lblFormHeading.Text = "USER REGISTRATION";
            this.lblFormHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSwitchToUser
            // 
            this.btnSwitchToUser.Location = new System.Drawing.Point(244, 80);
            this.btnSwitchToUser.Name = "btnSwitchToUser";
            this.btnSwitchToUser.Size = new System.Drawing.Size(150, 40);
            this.btnSwitchToUser.TabIndex = 1;
            this.btnSwitchToUser.Text = "Register as User";
            this.btnSwitchToUser.Click += new System.EventHandler(this.BtnSwitchToUser_Click);
            // 
            // btnSwitchToPartner
            // 
            this.btnSwitchToPartner.Location = new System.Drawing.Point(494, 80);
            this.btnSwitchToPartner.Name = "btnSwitchToPartner";
            this.btnSwitchToPartner.Size = new System.Drawing.Size(150, 40);
            this.btnSwitchToPartner.TabIndex = 2;
            this.btnSwitchToPartner.Text = "Register as Partner";
            this.btnSwitchToPartner.Click += new System.EventHandler(this.BtnSwitchToPartner_Click);
            // 
            // userFormPanel
            // 
            this.userFormPanel.Controls.Add(this.lblUserName);
            this.userFormPanel.Controls.Add(this.txtUserName);
            this.userFormPanel.Controls.Add(this.lblUserEmail);
            this.userFormPanel.Controls.Add(this.txtUserEmail);
            this.userFormPanel.Controls.Add(this.lblUserPassword);
            this.userFormPanel.Controls.Add(this.txtUserPassword);
            this.userFormPanel.Controls.Add(this.lblUserRePassword);
            this.userFormPanel.Controls.Add(this.txtUserRePassword);
            this.userFormPanel.Controls.Add(this.lblUserAddress);
            this.userFormPanel.Controls.Add(this.txtUserAddress);
            this.userFormPanel.Controls.Add(this.lblUserContact);
            this.userFormPanel.Controls.Add(this.txtUserContact);
            this.userFormPanel.Controls.Add(this.btnUserRegister);
            this.userFormPanel.Location = new System.Drawing.Point(144, 130);
            this.userFormPanel.Name = "userFormPanel";
            this.userFormPanel.Size = new System.Drawing.Size(613, 400);
            this.userFormPanel.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(20, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(100, 30);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(150, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(400, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblUserEmail
            // 
            this.lblUserEmail.Location = new System.Drawing.Point(20, 70);
            this.lblUserEmail.Name = "lblUserEmail";
            this.lblUserEmail.Size = new System.Drawing.Size(100, 30);
            this.lblUserEmail.TabIndex = 2;
            this.lblUserEmail.Text = "Email address:";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(150, 70);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(400, 20);
            this.txtUserEmail.TabIndex = 3;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.Location = new System.Drawing.Point(20, 120);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(100, 30);
            this.lblUserPassword.TabIndex = 4;
            this.lblUserPassword.Text = "Password:";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(150, 120);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(400, 20);
            this.txtUserPassword.TabIndex = 5;
            // 
            // lblUserRePassword
            // 
            this.lblUserRePassword.Location = new System.Drawing.Point(20, 170);
            this.lblUserRePassword.Name = "lblUserRePassword";
            this.lblUserRePassword.Size = new System.Drawing.Size(130, 30);
            this.lblUserRePassword.TabIndex = 6;
            this.lblUserRePassword.Text = "Re-enter Password:";
            // 
            // txtUserRePassword
            // 
            this.txtUserRePassword.Location = new System.Drawing.Point(150, 170);
            this.txtUserRePassword.Name = "txtUserRePassword";
            this.txtUserRePassword.PasswordChar = '*';
            this.txtUserRePassword.Size = new System.Drawing.Size(400, 20);
            this.txtUserRePassword.TabIndex = 7;
            // 
            // lblUserAddress
            // 
            this.lblUserAddress.Location = new System.Drawing.Point(20, 220);
            this.lblUserAddress.Name = "lblUserAddress";
            this.lblUserAddress.Size = new System.Drawing.Size(100, 30);
            this.lblUserAddress.TabIndex = 8;
            this.lblUserAddress.Text = "Address:";
            // 
            // txtUserAddress
            // 
            this.txtUserAddress.Location = new System.Drawing.Point(150, 220);
            this.txtUserAddress.Name = "txtUserAddress";
            this.txtUserAddress.Size = new System.Drawing.Size(400, 20);
            this.txtUserAddress.TabIndex = 9;
            // 
            // lblUserContact
            // 
            this.lblUserContact.Location = new System.Drawing.Point(20, 270);
            this.lblUserContact.Name = "lblUserContact";
            this.lblUserContact.Size = new System.Drawing.Size(100, 30);
            this.lblUserContact.TabIndex = 10;
            this.lblUserContact.Text = "Contact No:";
            // 
            // txtUserContact
            // 
            this.txtUserContact.Location = new System.Drawing.Point(150, 270);
            this.txtUserContact.Name = "txtUserContact";
            this.txtUserContact.Size = new System.Drawing.Size(400, 20);
            this.txtUserContact.TabIndex = 11;
            // 
            // btnUserRegister
            // 
            this.btnUserRegister.Location = new System.Drawing.Point(250, 320);
            this.btnUserRegister.Name = "btnUserRegister";
            this.btnUserRegister.Size = new System.Drawing.Size(100, 40);
            this.btnUserRegister.TabIndex = 12;
            this.btnUserRegister.Text = "Register";
            this.btnUserRegister.Click += new System.EventHandler(this.BtnUserRegister_Click);
            // 
            // partnerFormPanel
            // 
            this.partnerFormPanel.Controls.Add(this.lblPartnerCompanyName);
            this.partnerFormPanel.Controls.Add(this.txtPartnerCompanyName);
            this.partnerFormPanel.Controls.Add(this.lblPartnerEmail);
            this.partnerFormPanel.Controls.Add(this.txtPartnerEmail);
            this.partnerFormPanel.Controls.Add(this.lblPartnerPassword);
            this.partnerFormPanel.Controls.Add(this.txtPartnerPassword);
            this.partnerFormPanel.Controls.Add(this.lblPartnerRePassword);
            this.partnerFormPanel.Controls.Add(this.txtPartnerRePassword);
            this.partnerFormPanel.Controls.Add(this.lblPartnerAddress);
            this.partnerFormPanel.Controls.Add(this.txtPartnerAddress);
            this.partnerFormPanel.Controls.Add(this.lblPartnerContact);
            this.partnerFormPanel.Controls.Add(this.txtPartnerContact);
            this.partnerFormPanel.Controls.Add(this.btnPartnerRegister);
            this.partnerFormPanel.Location = new System.Drawing.Point(144, 130);
            this.partnerFormPanel.Name = "partnerFormPanel";
            this.partnerFormPanel.Size = new System.Drawing.Size(613, 400);
            this.partnerFormPanel.TabIndex = 4;
            this.partnerFormPanel.Visible = false;
            // 
            // lblPartnerCompanyName
            // 
            this.lblPartnerCompanyName.Location = new System.Drawing.Point(20, 20);
            this.lblPartnerCompanyName.Name = "lblPartnerCompanyName";
            this.lblPartnerCompanyName.Size = new System.Drawing.Size(130, 30);
            this.lblPartnerCompanyName.TabIndex = 0;
            this.lblPartnerCompanyName.Text = "Company Name:";
            // 
            // txtPartnerCompanyName
            // 
            this.txtPartnerCompanyName.Location = new System.Drawing.Point(150, 20);
            this.txtPartnerCompanyName.Name = "txtPartnerCompanyName";
            this.txtPartnerCompanyName.Size = new System.Drawing.Size(400, 20);
            this.txtPartnerCompanyName.TabIndex = 1;
            // 
            // lblPartnerEmail
            // 
            this.lblPartnerEmail.Location = new System.Drawing.Point(20, 70);
            this.lblPartnerEmail.Name = "lblPartnerEmail";
            this.lblPartnerEmail.Size = new System.Drawing.Size(100, 30);
            this.lblPartnerEmail.TabIndex = 2;
            this.lblPartnerEmail.Text = "Email address:";
            // 
            // txtPartnerEmail
            // 
            this.txtPartnerEmail.Location = new System.Drawing.Point(150, 70);
            this.txtPartnerEmail.Name = "txtPartnerEmail";
            this.txtPartnerEmail.Size = new System.Drawing.Size(400, 20);
            this.txtPartnerEmail.TabIndex = 3;
            // 
            // lblPartnerPassword
            // 
            this.lblPartnerPassword.Location = new System.Drawing.Point(20, 120);
            this.lblPartnerPassword.Name = "lblPartnerPassword";
            this.lblPartnerPassword.Size = new System.Drawing.Size(100, 30);
            this.lblPartnerPassword.TabIndex = 4;
            this.lblPartnerPassword.Text = "Password:";
            // 
            // txtPartnerPassword
            // 
            this.txtPartnerPassword.Location = new System.Drawing.Point(150, 120);
            this.txtPartnerPassword.Name = "txtPartnerPassword";
            this.txtPartnerPassword.PasswordChar = '*';
            this.txtPartnerPassword.Size = new System.Drawing.Size(400, 20);
            this.txtPartnerPassword.TabIndex = 5;
            // 
            // lblPartnerRePassword
            // 
            this.lblPartnerRePassword.Location = new System.Drawing.Point(20, 170);
            this.lblPartnerRePassword.Name = "lblPartnerRePassword";
            this.lblPartnerRePassword.Size = new System.Drawing.Size(130, 30);
            this.lblPartnerRePassword.TabIndex = 6;
            this.lblPartnerRePassword.Text = "Re-enter Password:";
            // 
            // txtPartnerRePassword
            // 
            this.txtPartnerRePassword.Location = new System.Drawing.Point(150, 170);
            this.txtPartnerRePassword.Name = "txtPartnerRePassword";
            this.txtPartnerRePassword.PasswordChar = '*';
            this.txtPartnerRePassword.Size = new System.Drawing.Size(400, 20);
            this.txtPartnerRePassword.TabIndex = 7;
            // 
            // lblPartnerAddress
            // 
            this.lblPartnerAddress.Location = new System.Drawing.Point(20, 220);
            this.lblPartnerAddress.Name = "lblPartnerAddress";
            this.lblPartnerAddress.Size = new System.Drawing.Size(100, 30);
            this.lblPartnerAddress.TabIndex = 8;
            this.lblPartnerAddress.Text = "Address:";
            // 
            // txtPartnerAddress
            // 
            this.txtPartnerAddress.Location = new System.Drawing.Point(150, 220);
            this.txtPartnerAddress.Name = "txtPartnerAddress";
            this.txtPartnerAddress.Size = new System.Drawing.Size(400, 20);
            this.txtPartnerAddress.TabIndex = 9;
            // 
            // lblPartnerContact
            // 
            this.lblPartnerContact.Location = new System.Drawing.Point(20, 270);
            this.lblPartnerContact.Name = "lblPartnerContact";
            this.lblPartnerContact.Size = new System.Drawing.Size(100, 30);
            this.lblPartnerContact.TabIndex = 10;
            this.lblPartnerContact.Text = "Contact No:";
            // 
            // txtPartnerContact
            // 
            this.txtPartnerContact.Location = new System.Drawing.Point(150, 270);
            this.txtPartnerContact.Name = "txtPartnerContact";
            this.txtPartnerContact.Size = new System.Drawing.Size(400, 20);
            this.txtPartnerContact.TabIndex = 11;
            // 
            // btnPartnerRegister
            // 
            this.btnPartnerRegister.Location = new System.Drawing.Point(250, 320);
            this.btnPartnerRegister.Name = "btnPartnerRegister";
            this.btnPartnerRegister.Size = new System.Drawing.Size(100, 40);
            this.btnPartnerRegister.TabIndex = 12;
            this.btnPartnerRegister.Text = "Register";
            this.btnPartnerRegister.Click += new System.EventHandler(this.BtnPartnerRegister_Click);
            // 
            // Registration
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblFormHeading);
            this.Controls.Add(this.btnSwitchToUser);
            this.Controls.Add(this.btnSwitchToPartner);
            this.Controls.Add(this.userFormPanel);
            this.Controls.Add(this.partnerFormPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.userFormPanel.ResumeLayout(false);
            this.userFormPanel.PerformLayout();
            this.partnerFormPanel.ResumeLayout(false);
            this.partnerFormPanel.PerformLayout();
            this.ResumeLayout(false);

        }


    }
}
