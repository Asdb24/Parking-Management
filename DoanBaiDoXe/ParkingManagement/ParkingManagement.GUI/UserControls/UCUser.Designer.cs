namespace ParkingManagement.GUI.UserControls
{
    partial class UCUser
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUser;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelTop;
        
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        
        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.gridUser = new DevExpress.XtraGrid.GridControl();
            this.gridViewUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).BeginInit();
            this.SuspendLayout();
            
            // panelTop - Dock Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.Add(this.btnRefresh);
            
            // gridUser - Dock Fill
            this.gridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUser.MainView = this.gridViewUser;
            this.gridViewUser.GridControl = this.gridUser;
            this.gridViewUser.OptionsBehavior.Editable = false;
            this.gridViewUser.OptionsView.ShowGroupPanel = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridUser);
            this.Controls.Add(this.panelTop);
            this.Name = "UCUser";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Load += new System.EventHandler(this.UCUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
