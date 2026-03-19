using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;

namespace ParkingManagement.GUI
{
    public partial class FormChangePassword : XtraForm
    {
        private readonly UserBLL _userBLL;
        
        public FormChangePassword()
        {
            InitializeComponent();
            _userBLL = new UserBLL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(oldPassword))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6)
            {
                XtraMessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                XtraMessageBox.Show("Xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _userBLL.ChangePassword(CurrentUser.UserID, oldPassword, newPassword);
                XtraMessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
