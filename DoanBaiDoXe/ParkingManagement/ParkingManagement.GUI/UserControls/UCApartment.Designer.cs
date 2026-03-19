namespace ParkingManagement.GUI.UserControls
{
    partial class UCApartment
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridApartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewApartment;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelTop;
        
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        
        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.gridApartment = new DevExpress.XtraGrid.GridControl();
            this.gridViewApartment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridApartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewApartment)).BeginInit();
            this.SuspendLayout();
            
            // panelTop - Dock Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.Add(this.btnRefresh);
            
            // gridApartment - Dock Fill
            this.gridApartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridApartment.MainView = this.gridViewApartment;
            this.gridViewApartment.GridControl = this.gridApartment;
            this.gridViewApartment.OptionsBehavior.Editable = false;
            this.gridViewApartment.OptionsView.ShowGroupPanel = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridApartment);
            this.Controls.Add(this.panelTop);
            this.Name = "UCApartment";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Load += new System.EventHandler(this.UCApartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridApartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewApartment)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
