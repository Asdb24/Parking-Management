namespace ParkingManagement.GUI.UserControls
{
    partial class UCReport
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridDailyStats;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDailyStats;
        private DevExpress.XtraGrid.GridControl gridVehicleStats;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVehicleStats;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblDaily;
        private DevExpress.XtraEditors.LabelControl lblVehicle;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        
        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridDailyStats = new DevExpress.XtraGrid.GridControl();
            this.gridViewDailyStats = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridVehicleStats = new DevExpress.XtraGrid.GridControl();
            this.gridViewVehicleStats = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblDaily = new DevExpress.XtraEditors.LabelControl();
            this.lblVehicle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDailyStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDailyStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVehicleStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVehicleStats)).BeginInit();
            this.SuspendLayout();
            
            // panelTop - Dock Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.Add(this.btnRefresh);
            
            // splitContainer - Dock Fill
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Horizontal = true;
            this.splitContainer.SplitterPosition = 500;
            
            // Panel1 - Daily Stats
            this.lblDaily.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDaily.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDaily.Padding = new System.Windows.Forms.Padding(10);
            this.lblDaily.Text = "📅 Thống kê theo ngày";
            
            this.gridDailyStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDailyStats.MainView = this.gridViewDailyStats;
            this.gridViewDailyStats.GridControl = this.gridDailyStats;
            this.gridViewDailyStats.OptionsBehavior.Editable = false;
            
            this.splitContainer.Panel1.Controls.Add(this.gridDailyStats);
            this.splitContainer.Panel1.Controls.Add(this.lblDaily);
            
            // Panel2 - Vehicle Stats
            this.lblVehicle.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVehicle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVehicle.Padding = new System.Windows.Forms.Padding(10);
            this.lblVehicle.Text = "🚗 Thống kê theo loại xe";
            
            this.gridVehicleStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVehicleStats.MainView = this.gridViewVehicleStats;
            this.gridViewVehicleStats.GridControl = this.gridVehicleStats;
            this.gridViewVehicleStats.OptionsBehavior.Editable = false;
            
            this.splitContainer.Panel2.Controls.Add(this.gridVehicleStats);
            this.splitContainer.Panel2.Controls.Add(this.lblVehicle);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelTop);
            this.Name = "UCReport";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Load += new System.EventHandler(this.UCReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDailyStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDailyStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVehicleStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVehicleStats)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
