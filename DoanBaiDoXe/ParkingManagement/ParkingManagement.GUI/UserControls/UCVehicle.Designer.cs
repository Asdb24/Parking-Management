namespace ParkingManagement.GUI.UserControls
{
    partial class UCVehicle
    {
        private System.ComponentModel.IContainer components = null;
        
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraGrid.GridControl gridVehicle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVehicle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.gridVehicle = new DevExpress.XtraGrid.GridControl();
            this.gridViewVehicle = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVehicle)).BeginInit();
            this.SuspendLayout();
            
            // panelTop - Dock Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            // btnAdd
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            // btnEdit
            this.btnEdit.Appearance.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
            this.btnEdit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseForeColor = true;
            this.btnEdit.Location = new System.Drawing.Point(120, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "✏️ Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            
            // btnDelete
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(234, 67, 53);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.Location = new System.Drawing.Point(230, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            
            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(340, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // txtSearch - Anchor Right
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(650, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.NullValuePrompt = "Tìm theo biển số, tên chủ xe...";
            this.txtSearch.Size = new System.Drawing.Size(250, 22);
            
            // btnSearch - Anchor Right
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(910, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.Text = "🔍 Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            
            // gridVehicle - Dock Fill
            this.gridVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVehicle.Location = new System.Drawing.Point(0, 50);
            this.gridVehicle.MainView = this.gridViewVehicle;
            this.gridVehicle.Name = "gridVehicle";
            
            // gridViewVehicle
            this.gridViewVehicle.GridControl = this.gridVehicle;
            this.gridViewVehicle.Name = "gridViewVehicle";
            this.gridViewVehicle.OptionsBehavior.Editable = false;
            this.gridViewVehicle.OptionsView.ShowGroupPanel = false;
            this.gridViewVehicle.OptionsView.ShowAutoFilterRow = true;
            this.gridViewVehicle.DoubleClick += new System.EventHandler(this.gridViewVehicle_DoubleClick);
            
            // UCVehicle
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridVehicle);
            this.Controls.Add(this.panelTop);
            this.Name = "UCVehicle";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Load += new System.EventHandler(this.UCVehicle_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVehicle)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
