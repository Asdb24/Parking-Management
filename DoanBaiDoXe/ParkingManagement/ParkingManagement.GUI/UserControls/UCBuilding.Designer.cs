namespace ParkingManagement.GUI.UserControls
{
    partial class UCBuilding
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridBuilding;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBuilding;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.gridBuilding = new DevExpress.XtraGrid.GridControl();
            this.gridViewBuilding = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBuilding)).BeginInit();
            this.SuspendLayout();
            
            // panelTop - Dock Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.Add(this.btnRefresh);
            
            // gridBuilding - Dock Fill
            this.gridBuilding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBuilding.MainView = this.gridViewBuilding;
            this.gridBuilding.Name = "gridBuilding";
            
            this.gridViewBuilding.GridControl = this.gridBuilding;
            this.gridViewBuilding.OptionsBehavior.Editable = false;
            this.gridViewBuilding.OptionsView.ShowGroupPanel = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridBuilding);
            this.Controls.Add(this.panelTop);
            this.Name = "UCBuilding";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Load += new System.EventHandler(this.UCBuilding_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBuilding)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
