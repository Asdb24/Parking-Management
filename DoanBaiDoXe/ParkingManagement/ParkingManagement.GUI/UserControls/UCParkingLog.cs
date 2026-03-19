using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;
using ParkingManagement.DTO;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCParkingLog : XtraUserControl
    {
        private readonly ParkingLogBLL _logBLL;
        private readonly VehicleBLL _vehicleBLL;

        public UCParkingLog()
        {
            InitializeComponent();
            _logBLL = new ParkingLogBLL();
            _vehicleBLL = new VehicleBLL();
        }

        private void UCParkingLog_Load(object sender, EventArgs e)
        {
            LoadVehiclesInParking();
            LoadRecentLogs();
        }

        private void LoadVehiclesInParking()
        {
            try
            {
                var list = _logBLL.GetVehiclesInParking();
                gridInParking.DataSource = list;
                lblInParkingCount.Text = $"Xe trong bãi: {list.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentLogs()
        {
            try
            {
                var list = _logBLL.GetByDate(DateTime.Today);
                gridHistory.DataSource = list;
            }
            catch { }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string licensePlate = txtLicensePlate.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(licensePlate))
            {
                XtraMessageBox.Show("Vui lòng nhập biển số xe!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicensePlate.Focus();
                return;
            }

            try
            {
                int logId = _logBLL.CheckInByLicensePlate(licensePlate, CurrentUser.UserID);
                if (logId > 0)
                {
                    XtraMessageBox.Show($"Check-in thành công!\nBiển số: {licensePlate}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLicensePlate.Text = "";
                    ClearVehicleInfo();
                    LoadVehiclesInParking();
                    LoadRecentLogs();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var log = GetSelectedLog();
            if (log == null)
            {
                XtraMessageBox.Show("Vui lòng chọn xe cần check-out!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show($"Xác nhận check-out xe {log.LicensePlate}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _logBLL.CheckOut(log.LogID, CurrentUser.UserID);
                    XtraMessageBox.Show($"Check-out thành công!\nBiển số: {log.LicensePlate}\nThời gian đậu: {log.DurationString}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVehiclesInParking();
                    LoadRecentLogs();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string licensePlate = txtLicensePlate.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(licensePlate))
            {
                ClearVehicleInfo();
                return;
            }

            try
            {
                var vehicle = _vehicleBLL.GetByLicensePlate(licensePlate);
                if (vehicle != null)
                {
                    DisplayVehicleInfo(vehicle);
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy xe với biển số này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearVehicleInfo();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayVehicleInfo(VehicleDTO vehicle)
        {
            lblVehicleInfo.Text = $"Biển số: {vehicle.LicensePlate}\n" +
                                  $"Loại xe: {vehicle.VehicleTypeName}\n" +
                                  $"Hãng xe: {vehicle.Brand} {vehicle.Model}\n" +
                                  $"Màu: {vehicle.Color}\n" +
                                  $"Chủ xe: {vehicle.ResidentName}\n" +
                                  $"Căn hộ: {vehicle.ApartmentCode}\n" +
                                  $"Chỗ đậu: {vehicle.SlotCode ?? "Chưa đăng ký"}\n" +
                                  $"Trạng thái: {vehicle.Status}";
        }

        private void ClearVehicleInfo()
        {
            lblVehicleInfo.Text = "Nhập biển số và nhấn Tìm để xem thông tin xe";
        }

        private ParkingLogDTO GetSelectedLog()
        {
            int[] rows = gridViewInParking.GetSelectedRows();
            if (rows.Length > 0)
            {
                return gridViewInParking.GetRow(rows[0]) as ParkingLogDTO;
            }
            return null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadVehiclesInParking();
            LoadRecentLogs();
        }
    }
}
