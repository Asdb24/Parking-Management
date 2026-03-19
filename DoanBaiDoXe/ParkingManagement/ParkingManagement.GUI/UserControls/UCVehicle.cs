using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ParkingManagement.BLL;
using ParkingManagement.DTO;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCVehicle : XtraUserControl
    {
        private readonly VehicleBLL _vehicleBLL;

        public UCVehicle()
        {
            InitializeComponent();
            _vehicleBLL = new VehicleBLL();
        }

        private void UCVehicle_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                var list = _vehicleBLL.GetAll();
                gridVehicle.DataSource = list;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormVehicleEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var vehicle = GetSelectedVehicle();
            if (vehicle == null)
            {
                XtraMessageBox.Show("Vui lòng chọn xe cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FormVehicleEdit(vehicle.VehicleID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var vehicle = GetSelectedVehicle();
            if (vehicle == null)
            {
                XtraMessageBox.Show("Vui lòng chọn xe cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show($"Bạn có chắc muốn xóa xe {vehicle.LicensePlate}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _vehicleBLL.Delete(vehicle.VehicleID);
                    LoadData();
                    XtraMessageBox.Show("Xóa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData();
                }
                else
                {
                    var list = _vehicleBLL.Search(keyword);
                    gridVehicle.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadData();
        }

        private VehicleDTO GetSelectedVehicle()
        {
            int[] selectedRows = gridViewVehicle.GetSelectedRows();
            if (selectedRows.Length > 0)
            {
                return gridViewVehicle.GetRow(selectedRows[0]) as VehicleDTO;
            }
            return null;
        }

        private void gridViewVehicle_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
