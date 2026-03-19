using System.Drawing;

namespace ParkingManagement.GUI
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageView;
        
        // Ribbon Page Groups
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupNavigation;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupSystem;

        // BarButtonItems with Large Icons
        private DevExpress.XtraBars.BarButtonItem btnDashboard;
        private DevExpress.XtraBars.BarButtonItem btnBuilding;
        private DevExpress.XtraBars.BarButtonItem btnApartment;
        private DevExpress.XtraBars.BarButtonItem btnVehicle;
        private DevExpress.XtraBars.BarButtonItem btnParkingSlot;
        private DevExpress.XtraBars.BarButtonItem btnParkingLog;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarButtonItem btnUser;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarButtonItem btnExit;

        // Status Bar
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem barUserInfo;
        private DevExpress.XtraBars.BarStaticItem barDateTime;

        private DevExpress.XtraEditors.PanelControl panelContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            
            // Create Ribbon Control
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            
            // Groups
            this.groupNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            
            // Buttons
            this.btnDashboard = new DevExpress.XtraBars.BarButtonItem();
            this.btnBuilding = new DevExpress.XtraBars.BarButtonItem();
            this.btnApartment = new DevExpress.XtraBars.BarButtonItem();
            this.btnVehicle = new DevExpress.XtraBars.BarButtonItem();
            this.btnParkingSlot = new DevExpress.XtraBars.BarButtonItem();
            this.btnParkingLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            
            // Status bar items
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barUserInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barDateTime = new DevExpress.XtraBars.BarStaticItem();
            
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.SuspendLayout();
            
            // === RIBBON CONTROL ===
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbonControl.ExpandCollapseItem,
                this.btnDashboard, this.btnBuilding, this.btnApartment, this.btnVehicle,
                this.btnParkingSlot, this.btnParkingLog, this.btnReport, this.btnUser,
                this.btnChangePassword, this.btnLogout, this.btnAbout, this.btnExit,
                this.barUserInfo, this.barDateTime
            });
            this.ribbonControl.Location = new Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { this.pageHome, this.pageView });
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Size = new Size(1200, 158);
            
            // === BUTTONS - Navigation (Using DevExpress Image Names) ===
            
            // btnDashboard
            this.btnDashboard.Caption = "Dashboard";
            this.btnDashboard.Id = 1;
            this.btnDashboard.ImageOptions.ImageUri.Uri = "BO_Dashboard";
            this.btnDashboard.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDashboard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDashboard_ItemClick);
            
            // btnBuilding
            this.btnBuilding.Caption = "Tòa Nhà";
            this.btnBuilding.Id = 2;
            this.btnBuilding.ImageOptions.ImageUri.Uri = "BO_Organization";
            this.btnBuilding.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnBuilding.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuilding_ItemClick);
            
            // btnApartment
            this.btnApartment.Caption = "Căn Hộ";
            this.btnApartment.Id = 3;
            this.btnApartment.ImageOptions.ImageUri.Uri = "Home";
            this.btnApartment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnApartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApartment_ItemClick);
            
            // btnVehicle
            this.btnVehicle.Caption = "Phương Tiện";
            this.btnVehicle.Id = 4;
            this.btnVehicle.ImageOptions.ImageUri.Uri = "ProductQuickShippments";
            this.btnVehicle.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnVehicle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVehicle_ItemClick);
            
            // btnParkingSlot
            this.btnParkingSlot.Caption = "Ô Đậu Xe";
            this.btnParkingSlot.Id = 5;
            this.btnParkingSlot.ImageOptions.ImageUri.Uri = "Grid";
            this.btnParkingSlot.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnParkingSlot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParkingSlot_ItemClick);
            
            // btnParkingLog
            this.btnParkingLog.Caption = "Ra/Vào";
            this.btnParkingLog.Id = 6;
            this.btnParkingLog.ImageOptions.ImageUri.Uri = "Action_Refresh";
            this.btnParkingLog.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnParkingLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParkingLog_ItemClick);
            
            // btnReport
            this.btnReport.Caption = "Báo Cáo";
            this.btnReport.Id = 7;
            this.btnReport.ImageOptions.ImageUri.Uri = "BO_Report";
            this.btnReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            
            // btnUser
            this.btnUser.Caption = "Người Dùng";
            this.btnUser.Id = 8;
            this.btnUser.ImageOptions.ImageUri.Uri = "BO_Customer";
            this.btnUser.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUser_ItemClick);
            
            // === BUTTONS - System ===
            
            // btnChangePassword
            this.btnChangePassword.Caption = "Đổi Mật Khẩu";
            this.btnChangePassword.Id = 9;
            this.btnChangePassword.ImageOptions.ImageUri.Uri = "Security_Key";
            this.btnChangePassword.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            
            // btnLogout
            this.btnLogout.Caption = "Đăng Xuất";
            this.btnLogout.Id = 10;
            this.btnLogout.ImageOptions.ImageUri.Uri = "Action_Exit";
            this.btnLogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            
            // btnAbout
            this.btnAbout.Caption = "Giới Thiệu";
            this.btnAbout.Id = 11;
            this.btnAbout.ImageOptions.ImageUri.Uri = "About";
            this.btnAbout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbout_ItemClick);
            
            // btnExit
            this.btnExit.Caption = "Thoát";
            this.btnExit.Id = 12;
            this.btnExit.ImageOptions.ImageUri.Uri = "Close";
            this.btnExit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            
            // === RIBBON PAGE GROUPS ===
            
            // groupNavigation
            this.groupNavigation.ItemLinks.Add(this.btnDashboard);
            this.groupNavigation.ItemLinks.Add(this.btnBuilding);
            this.groupNavigation.ItemLinks.Add(this.btnApartment);
            this.groupNavigation.ItemLinks.Add(this.btnVehicle);
            this.groupNavigation.Name = "groupNavigation";
            this.groupNavigation.Text = "Điều Hướng";
            
            // groupManagement
            this.groupManagement.ItemLinks.Add(this.btnParkingSlot);
            this.groupManagement.ItemLinks.Add(this.btnParkingLog);
            this.groupManagement.ItemLinks.Add(this.btnReport);
            this.groupManagement.ItemLinks.Add(this.btnUser);
            this.groupManagement.Name = "groupManagement";
            this.groupManagement.Text = "Quản Lý";
            
            // groupSystem
            this.groupSystem.ItemLinks.Add(this.btnChangePassword);
            this.groupSystem.ItemLinks.Add(this.btnLogout);
            this.groupSystem.ItemLinks.Add(this.btnAbout);
            this.groupSystem.ItemLinks.Add(this.btnExit);
            this.groupSystem.Name = "groupSystem";
            this.groupSystem.Text = "Hệ Thống";
            
            // === RIBBON PAGES ===
            
            // pageHome
            this.pageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.groupNavigation, this.groupManagement, this.groupSystem
            });
            this.pageHome.Name = "pageHome";
            this.pageHome.Text = "TRANG CHỦ";
            
            // pageView (placeholder for future)
            this.pageView.Name = "pageView";
            this.pageView.Text = "XEM";
            
            // === STATUS BAR ===
            
            this.barUserInfo.Caption = "User";
            this.barUserInfo.Id = 13;
            this.barUserInfo.ImageOptions.ImageUri.Uri = "BOUser";
            
            this.barDateTime.Caption = "DateTime";
            this.barDateTime.Id = 14;
            this.barDateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barDateTime.ImageOptions.ImageUri.Uri = "Today";
            
            this.ribbonStatusBar.ItemLinks.Add(this.barUserInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.barDateTime);
            this.ribbonStatusBar.Location = new Point(0, 708);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new Size(1200, 24);
            
            // === PANEL CONTENT ===
            this.panelContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new Point(0, 158);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(1200, 550);
            
            // === FORM ===
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 730);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.MinimumSize = new Size(1000, 600);
            this.Name = "FormMain";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ BÃI ĐẬU XE Ô TÔ CHUNG CƯ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
