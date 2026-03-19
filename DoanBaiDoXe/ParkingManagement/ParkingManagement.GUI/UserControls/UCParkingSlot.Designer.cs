namespace ParkingManagement.GUI.UserControls
{
    partial class UCParkingSlot
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridSlot;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSlot;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelTop;
        
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        
        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.gridSlot = new DevExpress.XtraGrid.GridControl();
            this.gridViewSlot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSlot)).BeginInit();
            this.SuspendLayout();
            
            // panelTop - Dock Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.Add(this.btnRefresh);
            
            // gridSlot - Dock Fill
            this.gridSlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSlot.MainView = this.gridViewSlot;
            this.gridViewSlot.GridControl = this.gridSlot;
            this.gridViewSlot.OptionsBehavior.Editable = false;
            this.gridViewSlot.OptionsView.ShowGroupPanel = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSlot);
            this.Controls.Add(this.panelTop);
            this.Name = "UCParkingSlot";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Load += new System.EventHandler(this.UCParkingSlot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSlot)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
