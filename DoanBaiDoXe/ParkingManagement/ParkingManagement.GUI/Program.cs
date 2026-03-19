using System;
using System.Windows.Forms;

namespace ParkingManagement.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Set DevExpress skin
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            
            // Check database connection
            if (!ParkingManagement.DAL.DatabaseConnection.Instance.TestConnection())
            {
                MessageBox.Show(
                    "Không thể kết nối đến cơ sở dữ liệu!\n\n" +
                    "Vui lòng kiểm tra:\n" +
                    "1. SQL Server đang chạy\n" +
                    "2. Database ParkingManagement đã được tạo\n" +
                    "3. Connection string trong App.config đúng",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            Application.Run(new FormLogin());
        }
    }
}
