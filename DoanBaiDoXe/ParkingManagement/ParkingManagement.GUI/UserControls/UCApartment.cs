using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCApartment : XtraUserControl
    {
        private readonly ApartmentBLL _apartmentBLL;
        public UCApartment() { InitializeComponent(); _apartmentBLL = new ApartmentBLL(); }
        private void UCApartment_Load(object sender, EventArgs e) { LoadData(); }
        public void LoadData() { try { gridApartment.DataSource = _apartmentBLL.GetAll(); } catch { } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadData(); }
    }
}
