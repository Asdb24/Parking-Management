namespace ParkingManagement.GUI
{
    partial class FormVehicleEdit
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblLicensePlate;
        private DevExpress.XtraEditors.TextEdit txtLicensePlate;
        private DevExpress.XtraEditors.LabelControl lblBrand;
        private DevExpress.XtraEditors.TextEdit txtBrand;
        private DevExpress.XtraEditors.LabelControl lblModel;
        private DevExpress.XtraEditors.TextEdit txtModel;
        private DevExpress.XtraEditors.LabelControl lblColor;
        private DevExpress.XtraEditors.TextEdit txtColor;
        private DevExpress.XtraEditors.LabelControl lblCardNumber;
        private DevExpress.XtraEditors.TextEdit txtCardNumber;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblLicensePlate = new DevExpress.XtraEditors.LabelControl();
            this.txtLicensePlate = new DevExpress.XtraEditors.TextEdit();
            this.lblBrand = new DevExpress.XtraEditors.LabelControl();
            this.txtBrand = new DevExpress.XtraEditors.TextEdit();
            this.lblModel = new DevExpress.XtraEditors.LabelControl();
            this.txtModel = new DevExpress.XtraEditors.TextEdit();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.txtColor = new DevExpress.XtraEditors.TextEdit();
            this.lblCardNumber = new DevExpress.XtraEditors.LabelControl();
            this.txtCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicensePlate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            
            int y = 20, h = 50;
            this.lblLicensePlate.Location = new System.Drawing.Point(20, y); this.lblLicensePlate.Text = "Biển số xe: *";
            this.txtLicensePlate.Location = new System.Drawing.Point(120, y); this.txtLicensePlate.Size = new System.Drawing.Size(200, 22);
            this.txtLicensePlate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            
            y += h;
            this.lblBrand.Location = new System.Drawing.Point(20, y); this.lblBrand.Text = "Hãng xe:";
            this.txtBrand.Location = new System.Drawing.Point(120, y); this.txtBrand.Size = new System.Drawing.Size(200, 22);
            
            y += h;
            this.lblModel.Location = new System.Drawing.Point(20, y); this.lblModel.Text = "Model:";
            this.txtModel.Location = new System.Drawing.Point(120, y); this.txtModel.Size = new System.Drawing.Size(200, 22);
            
            y += h;
            this.lblColor.Location = new System.Drawing.Point(20, y); this.lblColor.Text = "Màu xe:";
            this.txtColor.Location = new System.Drawing.Point(120, y); this.txtColor.Size = new System.Drawing.Size(200, 22);
            
            y += h;
            this.lblCardNumber.Location = new System.Drawing.Point(20, y); this.lblCardNumber.Text = "Số thẻ:";
            this.txtCardNumber.Location = new System.Drawing.Point(120, y); this.txtCardNumber.Size = new System.Drawing.Size(200, 22);
            
            y += h;
            this.lblNote.Location = new System.Drawing.Point(20, y); this.lblNote.Text = "Ghi chú:";
            this.txtNote.Location = new System.Drawing.Point(120, y); this.txtNote.Size = new System.Drawing.Size(200, 60);
            
            y += 80;
            this.btnSave.Location = new System.Drawing.Point(120, y); this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.Text = "💾 Lưu"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            this.btnCancel.Location = new System.Drawing.Point(220, y); this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.Text = "❌ Hủy"; this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, y + 50);
            this.Controls.Add(this.lblLicensePlate); this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.lblBrand); this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.lblModel); this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblColor); this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblCardNumber); this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.lblNote); this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnSave); this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.Name = "FormVehicleEdit"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin xe";
            this.Load += new System.EventHandler(this.FormVehicleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLicensePlate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
