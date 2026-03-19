using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;
using ParkingManagement.DTO;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCBuilding : XtraUserControl
    {
        private readonly BuildingBLL _buildingBLL;

        public UCBuilding()
        {
            InitializeComponent();
            _buildingBLL = new BuildingBLL();
        }

        private void UCBuilding_Load(object sender, EventArgs e) { LoadData(); }

        public void LoadData()
        {
            try { gridBuilding.DataSource = _buildingBLL.GetAll(); }
            catch (Exception ex) { XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnRefresh_Click(object sender, EventArgs e) { LoadData(); }
    }
}
