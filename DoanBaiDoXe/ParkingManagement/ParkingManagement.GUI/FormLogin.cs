using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;
using ParkingManagement.DTO;

namespace ParkingManagement.GUI
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        private readonly UserBLL _userBLL;

        public FormLogin()
        {
            InitializeComponent();
            _userBLL = new UserBLL();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            
            // Load remember me
            if (Properties.Settings.Default.RememberMe)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                chkRememberMe.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                XtraMessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                var user = _userBLL.Login(username, password);
                if (user != null)
                {
                    // Save remember me
                    if (chkRememberMe.Checked)
                    {
                        Properties.Settings.Default.RememberMe = true;
                        Properties.Settings.Default.Username = username;
                    }
                    else
                    {
                        Properties.Settings.Default.RememberMe = false;
                        Properties.Settings.Default.Username = "";
                    }
                    Properties.Settings.Default.Save();

                    // Store current user
                    CurrentUser.User = user;

                    // Open main form
                    this.Hide();
                    FormMain formMain = new FormMain();
                    formMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }

    /// <summary>
    /// Lưu thông tin user đang đăng nhập
    /// </summary>
    public static class CurrentUser
    {
        public static UserDTO User { get; set; }
        
        public static int UserID => User?.UserID ?? 0;
        public static string Username => User?.Username ?? "";
        public static string FullName => User?.FullName ?? "";
        public static string RoleName => User?.RoleName ?? "";
        public static bool IsAdmin => User?.RoleName == "Admin";
    }
}
