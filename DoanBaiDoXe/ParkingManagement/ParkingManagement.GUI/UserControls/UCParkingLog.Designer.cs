namespace ParkingManagement.GUI.UserControls
{
    partial class UCParkingLog
    {
        private System.ComponentModel.IContainer components = null;
        
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraEditors.LabelControl lblLicensePlateTitle;
        private DevExpress.XtraEditors.TextEdit txtLicensePlate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnCheckIn;
        private DevExpress.XtraEditors.SimpleButton btnCheckOut;
        private DevExpress.XtraEditors.LabelControl lblVehicleInfo;
        private DevExpress.XtraEditors.LabelControl lblInParkingCount;
        private DevExpress.XtraGrid.GridControl gridInParking;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInParking;
        private DevExpress.XtraGrid.GridControl gridHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SplitContainerControl splitGrids;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.splitGrids = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblLicensePlateTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtLicensePlate = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheckIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheckOut = new DevExpress.XtraEditors.SimpleButton();
            this.lblVehicleInfo = new DevExpress.XtraEditors.LabelControl();
            this.lblInParkingCount = new DevExpress.XtraEditors.LabelControl();
            this.gridInParking = new DevExpress.XtraGrid.GridControl();
            this.gridViewInParking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridHistory = new DevExpress.XtraGrid.GridControl();
            this.gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGrids)).BeginInit();
            this.splitGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicensePlate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInParking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInParking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHistory)).BeginInit();
            this.SuspendLayout();
            
            // panelLeft - Dock Left, fixed width
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 500);
            
            // lblLicensePlateTitle
            this.lblLicensePlateTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLicensePlateTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLicensePlateTitle.Text = "🔍 NHẬP BIỂN SỐ XE";
            this.panelLeft.Controls.Add(this.lblLicensePlateTitle);
            
            // txtLicensePlate
            this.txtLicensePlate.Location = new System.Drawing.Point(15, 50);
            this.txtLicensePlate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtLicensePlate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLicensePlate.Size = new System.Drawing.Size(200, 32);
            this.panelLeft.Controls.Add(this.txtLicensePlate);
            
            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(220, 50);
            this.btnSearch.Size = new System.Drawing.Size(60, 32);
            this.btnSearch.Text = "🔍";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.panelLeft.Controls.Add(this.btnSearch);
            
            // btnCheckIn
            this.btnCheckIn.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnCheckIn.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Appearance.Options.UseBackColor = true;
            this.btnCheckIn.Appearance.Options.UseFont = true;
            this.btnCheckIn.Appearance.Options.UseForeColor = true;
            this.btnCheckIn.Location = new System.Drawing.Point(15, 100);
            this.btnCheckIn.Size = new System.Drawing.Size(130, 40);
            this.btnCheckIn.Text = "🟢 CHECK-IN";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            this.panelLeft.Controls.Add(this.btnCheckIn);
            
            // btnCheckOut
            this.btnCheckOut.Appearance.BackColor = System.Drawing.Color.FromArgb(234, 67, 53);
            this.btnCheckOut.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Appearance.Options.UseBackColor = true;
            this.btnCheckOut.Appearance.Options.UseFont = true;
            this.btnCheckOut.Appearance.Options.UseForeColor = true;
            this.btnCheckOut.Location = new System.Drawing.Point(150, 100);
            this.btnCheckOut.Size = new System.Drawing.Size(130, 40);
            this.btnCheckOut.Text = "🔴 CHECK-OUT";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            this.panelLeft.Controls.Add(this.btnCheckOut);
            
            // lblVehicleInfo
            this.lblVehicleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVehicleInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVehicleInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblVehicleInfo.Location = new System.Drawing.Point(15, 160);
            this.lblVehicleInfo.Size = new System.Drawing.Size(265, 300);
            this.lblVehicleInfo.Text = "Nhập biển số và nhấn Tìm để xem thông tin xe";
            this.panelLeft.Controls.Add(this.lblVehicleInfo);
            
            // splitGrids - Dock Fill
            this.splitGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitGrids.Horizontal = false;
            this.splitGrids.Location = new System.Drawing.Point(300, 0);
            this.splitGrids.Name = "splitGrids";
            this.splitGrids.SplitterPosition = 200;
            
            // lblInParkingCount
            this.lblInParkingCount.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInParkingCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInParkingCount.Padding = new System.Windows.Forms.Padding(10);
            this.lblInParkingCount.Text = "🚗 Xe trong bãi: 0";
            
            // btnRefresh
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // gridInParking - Panel1
            this.gridInParking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInParking.MainView = this.gridViewInParking;
            this.gridInParking.Name = "gridInParking";
            this.gridViewInParking.GridControl = this.gridInParking;
            this.gridViewInParking.OptionsBehavior.Editable = false;
            this.gridViewInParking.OptionsView.ShowGroupPanel = false;
            this.splitGrids.Panel1.Controls.Add(this.gridInParking);
            this.splitGrids.Panel1.Controls.Add(this.lblInParkingCount);
            
            // gridHistory - Panel2
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.MainView = this.gridViewHistory;
            this.gridHistory.Name = "gridHistory";
            this.gridViewHistory.GridControl = this.gridHistory;
            this.gridViewHistory.OptionsBehavior.Editable = false;
            this.gridViewHistory.OptionsView.ShowGroupPanel = false;
            this.splitGrids.Panel2.Controls.Add(this.gridHistory);
            
            // UCParkingLog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitGrids);
            this.Controls.Add(this.panelLeft);
            this.Name = "UCParkingLog";
            this.Size = new System.Drawing.Size(1000, 500);
            this.Load += new System.EventHandler(this.UCParkingLog_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitGrids)).EndInit();
            this.splitGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLicensePlate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInParking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInParking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
