using System;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCParkingSlot : XtraUserControl
    {
        private readonly ParkingSlotBLL _slotBLL;
        public UCParkingSlot() { InitializeComponent(); _slotBLL = new ParkingSlotBLL(); }
        private void UCParkingSlot_Load(object sender, EventArgs e) { LoadData(); }
        public void LoadData() { try { gridSlot.DataSource = _slotBLL.GetAll(); } catch { } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadData(); }
    }
}
