namespace ParkingManagement.GUI.UserControls
{
    partial class UCDashboard
    {
        private System.ComponentModel.IContainer components = null;
        
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelCard1;
        private DevExpress.XtraEditors.PanelControl panelCard2;
        private DevExpress.XtraEditors.PanelControl panelCard3;
        private DevExpress.XtraEditors.PanelControl panelCard4;
        private DevExpress.XtraEditors.PanelControl panelCard5;
        private DevExpress.XtraEditors.PanelControl panelCard6;
        private DevExpress.XtraEditors.LabelControl lblTotalVehiclesTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalVehicles;
        private DevExpress.XtraEditors.LabelControl lblAvailableSlotsTitle;
        private DevExpress.XtraEditors.LabelControl lblAvailableSlots;
        private DevExpress.XtraEditors.LabelControl lblVehiclesInParkingTitle;
        private DevExpress.XtraEditors.LabelControl lblVehiclesInParking;
        private DevExpress.XtraEditors.LabelControl lblTodayRevenueTitle;
        private DevExpress.XtraEditors.LabelControl lblTodayRevenue;
        private DevExpress.XtraEditors.LabelControl lblTodayCheckInsTitle;
        private DevExpress.XtraEditors.LabelControl lblTodayCheckIns;
        private DevExpress.XtraEditors.LabelControl lblTodayCheckOutsTitle;
        private DevExpress.XtraEditors.LabelControl lblTodayCheckOuts;
        private DevExpress.XtraEditors.LabelControl lblIcon1;
        private DevExpress.XtraEditors.LabelControl lblIcon2;
        private DevExpress.XtraEditors.LabelControl lblIcon3;
        private DevExpress.XtraEditors.LabelControl lblIcon4;
        private DevExpress.XtraEditors.LabelControl lblIcon5;
        private DevExpress.XtraEditors.LabelControl lblIcon6;
        private DevExpress.XtraCharts.ChartControl chartVehicleType;
        private DevExpress.XtraGrid.GridControl gridRecentActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecent;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.LabelControl lblChartTitle;
        private DevExpress.XtraEditors.LabelControl lblGridTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartVehicleType = new DevExpress.XtraCharts.ChartControl();
            this.gridRecentActivities = new DevExpress.XtraGrid.GridControl();
            this.gridViewRecent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblChartTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblGridTitle = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVehicleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecentActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecent)).BeginInit();
            this.SuspendLayout();
            
            // === PANEL TOP - Stat Cards ===
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 100);
            this.panelTop.Padding = new System.Windows.Forms.Padding(5);
            
            // Create stat cards with icons
            CreateStatCards();
            
            // btnRefresh - Anchor Right
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(1090, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.Add(this.btnRefresh);
            
            // === SPLIT MAIN - Chart & Grid ===
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 100);
            this.splitMain.Name = "splitMain";
            this.splitMain.Horizontal = true;
            this.splitMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            this.splitMain.SplitterPosition = 400;
            this.splitMain.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            
            // === PANEL 1 - Chart ===
            this.lblChartTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblChartTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(26, 115, 232);
            this.lblChartTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Size = new System.Drawing.Size(400, 30);
            this.lblChartTitle.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblChartTitle.Text = "📊 PHÂN BỐ LOẠI XE";
            
            this.chartVehicleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVehicleType.Name = "chartVehicleType";
            this.chartVehicleType.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartVehicleType.BackColor = System.Drawing.Color.White;
            
            this.splitMain.Panel1.Controls.Add(this.chartVehicleType);
            this.splitMain.Panel1.Controls.Add(this.lblChartTitle);
            
            // === PANEL 2 - Grid ===
            this.lblGridTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblGridTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.lblGridTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridTitle.Size = new System.Drawing.Size(800, 30);
            this.lblGridTitle.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblGridTitle.Text = "🚗 HOẠT ĐỘNG GẦN ĐÂY";
            
            this.gridRecentActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecentActivities.MainView = this.gridViewRecent;
            this.gridRecentActivities.Name = "gridRecentActivities";
            
            this.gridViewRecent.GridControl = this.gridRecentActivities;
            this.gridViewRecent.Name = "gridViewRecent";
            this.gridViewRecent.OptionsBehavior.Editable = false;
            this.gridViewRecent.OptionsView.ShowGroupPanel = false;
            this.gridViewRecent.OptionsView.ColumnAutoWidth = true;
            this.gridViewRecent.OptionsView.RowAutoHeight = true;
            this.gridViewRecent.RowHeight = 30;
            this.gridViewRecent.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gridViewRecent.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            
            this.splitMain.Panel2.Controls.Add(this.gridRecentActivities);
            this.splitMain.Panel2.Controls.Add(this.lblGridTitle);
            
            // === UC DASHBOARD ===
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelTop);
            this.Name = "UCDashboard";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.UCDashboard_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVehicleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecentActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecent)).EndInit();
            this.ResumeLayout(false);
        }

        private void CreateStatCards()
        {
            int cardWidth = 160;
            int cardHeight = 80;
            int margin = 10;
            int x = margin;
            int y = 10;
            
            // Card 1 - Tổng xe (xanh dương)
            panelCard1 = CreateCardWithIcon(x, y, cardWidth, cardHeight, "🚗", "TỔNG XE", 
                ref lblIcon1, ref lblTotalVehiclesTitle, ref lblTotalVehicles, 
                System.Drawing.Color.FromArgb(26, 115, 232));
            panelTop.Controls.Add(panelCard1);
            x += cardWidth + margin;
            
            // Card 2 - Chỗ trống (xanh lá)
            panelCard2 = CreateCardWithIcon(x, y, cardWidth, cardHeight, "🅿️", "CHỖ TRỐNG", 
                ref lblIcon2, ref lblAvailableSlotsTitle, ref lblAvailableSlots, 
                System.Drawing.Color.FromArgb(52, 168, 83));
            panelTop.Controls.Add(panelCard2);
            x += cardWidth + margin;
            
            // Card 3 - Xe trong bãi (cam)
            panelCard3 = CreateCardWithIcon(x, y, cardWidth, cardHeight, "🚦", "XE TRONG BÃI", 
                ref lblIcon3, ref lblVehiclesInParkingTitle, ref lblVehiclesInParking, 
                System.Drawing.Color.FromArgb(255, 152, 0));
            panelTop.Controls.Add(panelCard3);
            x += cardWidth + margin;
            
            // Card 4 - Doanh thu (đỏ)
            panelCard4 = CreateCardWithIcon(x, y, cardWidth, cardHeight, "💰", "DOANH THU", 
                ref lblIcon4, ref lblTodayRevenueTitle, ref lblTodayRevenue, 
                System.Drawing.Color.FromArgb(234, 67, 53));
            panelTop.Controls.Add(panelCard4);
            x += cardWidth + margin;
            
            // Card 5 - Vào hôm nay (cyan)
            panelCard5 = CreateCardWithIcon(x, y, cardWidth, cardHeight, "⬆️", "VÀO HÔM NAY", 
                ref lblIcon5, ref lblTodayCheckInsTitle, ref lblTodayCheckIns, 
                System.Drawing.Color.FromArgb(0, 188, 212));
            panelTop.Controls.Add(panelCard5);
            x += cardWidth + margin;
            
            // Card 6 - Ra hôm nay (tím)
            panelCard6 = CreateCardWithIcon(x, y, cardWidth, cardHeight, "⬇️", "RA HÔM NAY", 
                ref lblIcon6, ref lblTodayCheckOutsTitle, ref lblTodayCheckOuts, 
                System.Drawing.Color.FromArgb(156, 39, 176));
            panelTop.Controls.Add(panelCard6);
        }

        private DevExpress.XtraEditors.PanelControl CreateCardWithIcon(int x, int y, int width, int height, 
            string icon, string title, 
            ref DevExpress.XtraEditors.LabelControl lblIcon,
            ref DevExpress.XtraEditors.LabelControl lblTitle, 
            ref DevExpress.XtraEditors.LabelControl lblValue, System.Drawing.Color color)
        {
            var panel = new DevExpress.XtraEditors.PanelControl();
            panel.Location = new System.Drawing.Point(x, y);
            panel.Size = new System.Drawing.Size(width, height);
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panel.Appearance.BackColor = color;
            panel.Appearance.Options.UseBackColor = true;
            
            // Icon (emoji)
            lblIcon = new DevExpress.XtraEditors.LabelControl();
            lblIcon.Appearance.Font = new System.Drawing.Font("Segoe UI Emoji", 24F);
            lblIcon.Appearance.ForeColor = System.Drawing.Color.White;
            lblIcon.Appearance.Options.UseFont = true;
            lblIcon.Appearance.Options.UseForeColor = true;
            lblIcon.Location = new System.Drawing.Point(8, 15);
            lblIcon.Text = icon;
            panel.Controls.Add(lblIcon);
            
            // Title (nhỏ góc phải trên)
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 200);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new System.Drawing.Point(55, 8);
            lblTitle.Text = title;
            panel.Controls.Add(lblTitle);
            
            // Value (số lớn góc phải dưới)
            lblValue = new DevExpress.XtraEditors.LabelControl();
            lblValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblValue.Appearance.ForeColor = System.Drawing.Color.White;
            lblValue.Appearance.Options.UseFont = true;
            lblValue.Appearance.Options.UseForeColor = true;
            lblValue.Location = new System.Drawing.Point(55, 28);
            lblValue.Text = "0";
            panel.Controls.Add(lblValue);
            
            return panel;
        }
    }
}
