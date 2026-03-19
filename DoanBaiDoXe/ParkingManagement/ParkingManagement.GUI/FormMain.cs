using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;
using ParkingManagement.GUI.UserControls;

namespace ParkingManagement.GUI
{
    public partial class FormMain : RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Set window state
            this.WindowState = FormWindowState.Maximized;
            
            // Update status bar
            UpdateStatusBar();
            
            // Load Dashboard by default
            ShowDashboard();
        }

        private void UpdateStatusBar()
        {
            barUserInfo.Caption = $"👤 {CurrentUser.FullName} ({CurrentUser.RoleName})";
            barDateTime.Caption = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            
            // Timer để cập nhật thời gian
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => barDateTime.Caption = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer.Start();
        }

        private void ShowUserControl(XtraUserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void ShowDashboard()
        {
            ShowUserControl(new UCDashboard());
        }

        #region Navigation Events
        
        private void btnDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCDashboard());
        }

        private void btnBuilding_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCBuilding());
        }

        private void btnApartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCApartment());
        }

        private void btnVehicle_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCVehicle());
        }

        private void btnParkingSlot_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCParkingSlot());
        }

        private void btnParkingLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCParkingLog());
        }

        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCReport());
        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowUserControl(new UCUser());
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new FormChangePassword())
            {
                form.ShowDialog(this);
            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentUser.User = null;
                this.Hide();
                using (var login = new FormLogin())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        UpdateStatusBar();
                        ShowDashboard();
                        this.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void btnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show(
                "HỆ THỐNG QUẢN LÝ BÃI ĐẬU XE Ô TÔ CHUNG CƯ\n\n" +
                "Phiên bản: 1.0.0\n" +
                "Công nghệ: C# .NET Framework 4.8, DevExpress, SQL Server\n\n" +
                "© 2024 - Đồ án môn học",
                "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
