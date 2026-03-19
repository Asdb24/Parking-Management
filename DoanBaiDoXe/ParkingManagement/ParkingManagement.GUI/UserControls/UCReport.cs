using System;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCReport : XtraUserControl
    {
        private readonly DashboardBLL _dashboardBLL;
        public UCReport() { InitializeComponent(); _dashboardBLL = new DashboardBLL(); }
        private void UCReport_Load(object sender, EventArgs e) { LoadData(); }
        public void LoadData() 
        { 
            try 
            { 
                gridDailyStats.DataSource = _dashboardBLL.GetDailyStats(30); 
                gridVehicleStats.DataSource = _dashboardBLL.GetVehicleTypeStats();
            } 
            catch { } 
        }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadData(); }
    }
}
