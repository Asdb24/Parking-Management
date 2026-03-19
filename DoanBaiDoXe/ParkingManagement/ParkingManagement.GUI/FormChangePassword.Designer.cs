namespace ParkingManagement.GUI
{
    partial class FormChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblOldPassword;
        private DevExpress.XtraEditors.LabelControl lblNewPassword;
        private DevExpress.XtraEditors.LabelControl lblConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblOldPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblNewPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblConfirmPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            
            this.lblOldPassword.Location = new System.Drawing.Point(20, 20); this.lblOldPassword.Text = "Mật khẩu cũ:";
            this.txtOldPassword.Location = new System.Drawing.Point(20, 45); this.txtOldPassword.Size = new System.Drawing.Size(250, 22);
            this.txtOldPassword.Properties.PasswordChar = '*';
            
            this.lblNewPassword.Location = new System.Drawing.Point(20, 80); this.lblNewPassword.Text = "Mật khẩu mới:";
            this.txtNewPassword.Location = new System.Drawing.Point(20, 105); this.txtNewPassword.Size = new System.Drawing.Size(250, 22);
            this.txtNewPassword.Properties.PasswordChar = '*';
            
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 140); this.lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, 165); this.txtConfirmPassword.Size = new System.Drawing.Size(250, 22);
            this.txtConfirmPassword.Properties.PasswordChar = '*';
            
            this.btnSave.Location = new System.Drawing.Point(20, 210); this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "💾 Lưu"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            this.btnCancel.Location = new System.Drawing.Point(130, 210); this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "❌ Hủy"; this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 260);
            this.Controls.Add(this.lblOldPassword); this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblNewPassword); this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblConfirmPassword); this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnSave); this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.Name = "FormChangePassword"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
