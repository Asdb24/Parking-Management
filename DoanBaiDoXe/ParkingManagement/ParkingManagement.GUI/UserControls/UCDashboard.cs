using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using ParkingManagement.BLL;
using ParkingManagement.DTO;

namespace ParkingManagement.GUI.UserControls
{
    public partial class UCDashboard : XtraUserControl
    {
        private readonly DashboardBLL _dashboardBLL;
        private readonly ParkingLogBLL _logBLL;

        public UCDashboard()
        {
            InitializeComponent();
            _dashboardBLL = new DashboardBLL();
            _logBLL = new ParkingLogBLL();
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        public void LoadDashboard()
        {
            try
            {
                // Load statistics
                var stats = _dashboardBLL.GetDashboardStats();
                
                lblTotalVehicles.Text = stats.TotalVehicles.ToString("N0");
                lblAvailableSlots.Text = stats.AvailableSlots.ToString("N0");
                lblVehiclesInParking.Text = stats.VehiclesInParking.ToString("N0");
                lblTodayRevenue.Text = stats.TodayRevenue.ToString("N0") + " đ";
                lblTodayCheckIns.Text = stats.TodayCheckIns.ToString("N0");
                lblTodayCheckOuts.Text = stats.TodayCheckOuts.ToString("N0");

                // Load vehicle type chart
                LoadVehicleTypeChart();

                // Load recent activities
                LoadRecentActivities();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải Dashboard: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVehicleTypeChart()
        {
            try
            {
                var stats = _dashboardBLL.GetVehicleTypeStats();
                
                chartVehicleType.Series.Clear();
                chartVehicleType.Titles.Clear();
                
                // Create 3D Pie Series
                Series series = new Series("Loại xe", ViewType.Pie3D);
                
                // Custom colors for pie slices
                Color[] colors = new Color[] {
                    Color.FromArgb(26, 115, 232),   // Blue
                    Color.FromArgb(52, 168, 83),    // Green
                    Color.FromArgb(251, 188, 4),    // Yellow
                    Color.FromArgb(234, 67, 53),    // Red
                    Color.FromArgb(156, 39, 176),   // Purple
                    Color.FromArgb(0, 188, 212),    // Cyan
                    Color.FromArgb(255, 152, 0),    // Orange
                };
                
                int colorIndex = 0;
                foreach (var stat in stats)
                {
                    if (stat.Count > 0)
                    {
                        SeriesPoint point = new SeriesPoint(stat.VehicleTypeName, stat.Count);
                        point.Color = colors[colorIndex % colors.Length];
                        series.Points.Add(point);
                        colorIndex++;
                    }
                }
                
                chartVehicleType.Series.Add(series);
                
                // Configure 3D Pie settings
                Pie3DSeriesView view = (Pie3DSeriesView)series.View;
                view.Depth = 30;
                view.ExplodedDistancePercentage = 10;
                
                // Configure labels
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                PieSeriesLabel label = (PieSeriesLabel)series.Label;
                label.TextPattern = "{A}: {VP:P0}";
                label.Position = PieSeriesLabelPosition.TwoColumns;
                
                // Configure legend
                chartVehicleType.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartVehicleType.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                chartVehicleType.Legend.AlignmentVertical = LegendAlignmentVertical.Center;
                chartVehicleType.Legend.Direction = LegendDirection.TopToBottom;
            }
            catch { }
        }

        private void LoadRecentActivities()
        {
            try
            {
                var logs = _logBLL.GetRecentActivities(10);
                gridRecentActivities.DataSource = logs;
                
                // Format columns if needed
                if (gridViewRecent.Columns.Count > 0)
                {
                    // Hide unnecessary columns
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewRecent.Columns)
                    {
                        if (col.FieldName.Contains("ID") && col.FieldName != "LogID")
                        {
                            col.Visible = false;
                        }
                    }
                    
                    // Format important columns
                    if (gridViewRecent.Columns["LicensePlate"] != null)
                    {
                        gridViewRecent.Columns["LicensePlate"].Caption = "Biển số";
                        gridViewRecent.Columns["LicensePlate"].VisibleIndex = 0;
                    }
                    if (gridViewRecent.Columns["VehicleTypeName"] != null)
                    {
                        gridViewRecent.Columns["VehicleTypeName"].Caption = "Loại xe";
                        gridViewRecent.Columns["VehicleTypeName"].VisibleIndex = 1;
                    }
                    if (gridViewRecent.Columns["CheckInTime"] != null)
                    {
                        gridViewRecent.Columns["CheckInTime"].Caption = "Giờ vào";
                        gridViewRecent.Columns["CheckInTime"].VisibleIndex = 2;
                        gridViewRecent.Columns["CheckInTime"].DisplayFormat.FormatString = "dd/MM HH:mm";
                        gridViewRecent.Columns["CheckInTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    }
                    if (gridViewRecent.Columns["CheckOutTime"] != null)
                    {
                        gridViewRecent.Columns["CheckOutTime"].Caption = "Giờ ra";
                        gridViewRecent.Columns["CheckOutTime"].VisibleIndex = 3;
                        gridViewRecent.Columns["CheckOutTime"].DisplayFormat.FormatString = "dd/MM HH:mm";
                        gridViewRecent.Columns["CheckOutTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    }
                    if (gridViewRecent.Columns["Fee"] != null)
                    {
                        gridViewRecent.Columns["Fee"].Caption = "Phí";
                        gridViewRecent.Columns["Fee"].VisibleIndex = 4;
                        gridViewRecent.Columns["Fee"].DisplayFormat.FormatString = "#,##0 đ";
                        gridViewRecent.Columns["Fee"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    }
                }
            }
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }
    }
}
