using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ParkingManagement.BLL;
using ParkingManagement.DTO;

namespace ParkingManagement.GUI
{
    public partial class FormVehicleEdit : XtraForm
    {
        private readonly VehicleBLL _vehicleBLL;
        private int _vehicleId = 0;

        public FormVehicleEdit()
        {
            InitializeComponent();
            _vehicleBLL = new VehicleBLL();
        }

        public FormVehicleEdit(int vehicleId) : this()
        {
            _vehicleId = vehicleId;
        }

        private void FormVehicleEdit_Load(object sender, EventArgs e)
        {
            // TODO: Load ComboBox data (Residents, VehicleTypes)
            
            if (_vehicleId > 0)
            {
                LoadVehicle();
                this.Text = "Sửa thông tin xe";
            }
            else
            {
                this.Text = "Thêm xe mới";
            }
        }

        private void LoadVehicle()
        {
            var vehicle = _vehicleBLL.GetById(_vehicleId);
            if (vehicle != null)
            {
                txtLicensePlate.Text = vehicle.LicensePlate;
                txtBrand.Text = vehicle.Brand;
                txtModel.Text = vehicle.Model;
                txtColor.Text = vehicle.Color;
                txtCardNumber.Text = vehicle.CardNumber;
                txtNote.Text = vehicle.Note;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var vehicle = new VehicleDTO
                {
                    VehicleID = _vehicleId,
                    LicensePlate = txtLicensePlate.Text.Trim().ToUpper(),
                    Brand = txtBrand.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Color = txtColor.Text.Trim(),
                    CardNumber = txtCardNumber.Text.Trim(),
                    Note = txtNote.Text.Trim(),
                    // TODO: Get ResidentID and VehicleTypeID from ComboBoxes
                    ResidentID = 1,
                    VehicleTypeID = 1
                };

                if (_vehicleId > 0)
                {
                    _vehicleBLL.Update(vehicle);
                    XtraMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _vehicleBLL.Insert(vehicle);
                    XtraMessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
