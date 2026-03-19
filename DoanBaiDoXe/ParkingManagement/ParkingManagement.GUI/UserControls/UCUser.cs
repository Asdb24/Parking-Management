using System;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCUser : XtraUserControl
    {
        private readonly UserBLL _userBLL;
        public UCUser() { InitializeComponent(); _userBLL = new UserBLL(); }
        private void UCUser_Load(object sender, EventArgs e) { LoadData(); }
        public void LoadData() { try { gridUser.DataSource = _userBLL.GetAll(); } catch { } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadData(); }
    }
}
