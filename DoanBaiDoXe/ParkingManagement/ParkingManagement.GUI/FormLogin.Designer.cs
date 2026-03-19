namespace ParkingManagement.GUI
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.CheckEdit chkRememberMe;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.PanelControl panelMain;

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
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblUsername = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.chkRememberMe = new DevExpress.XtraEditors.CheckEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberMe.Properties)).BeginInit();
            this.SuspendLayout();
            
            // panelMain
            this.panelMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblUsername);
            this.panelMain.Controls.Add(this.lblPassword);
            this.panelMain.Controls.Add(this.txtUsername);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Controls.Add(this.chkRememberMe);
            this.panelMain.Controls.Add(this.btnLogin);
            this.panelMain.Controls.Add(this.btnExit);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(400, 350);
            
            // lblTitle
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(26, 115, 232);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 35);
            this.lblTitle.Text = "🅿️ PARKING MANAGEMENT";
            
            // lblUsername
            this.lblUsername.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.Location = new System.Drawing.Point(50, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 21);
            this.lblUsername.Text = "Tên đăng nhập";
            
            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(50, 125);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Size = new System.Drawing.Size(300, 28);
            
            // lblPassword
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(50, 165);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 21);
            this.lblPassword.Text = "Mật khẩu";
            
            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(50, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(300, 28);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            
            // chkRememberMe
            this.chkRememberMe.Location = new System.Drawing.Point(50, 230);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Properties.Caption = "Ghi nhớ đăng nhập";
            this.chkRememberMe.Size = new System.Drawing.Size(150, 20);
            
            // btnLogin
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.Location = new System.Drawing.Point(50, 270);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(140, 40);
            this.btnLogin.Text = "🔓 ĐĂNG NHẬP";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            
            // btnExit
            this.btnExit.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExit.Location = new System.Drawing.Point(210, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.Text = "❌ THOÁT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            
            // FormLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Hệ thống quản lý bãi đậu xe";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberMe.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
