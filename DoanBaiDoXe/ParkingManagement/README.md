# 📘 HƯỚNG DẪN SỬ DỤNG MÃ NGUỒN
## Hệ Thống Quản Lý Bãi Đậu Xe Ô Tô Chung Cư

---

## 📁 CẤU TRÚC THƯ MỤC

```
ParkingManagement/
├── ParkingManagement.DTO/          # Data Transfer Objects
│   ├── UserDTO.cs
│   ├── RoleDTO.cs
│   ├── BuildingDTO.cs
│   ├── ApartmentDTO.cs
│   ├── ResidentDTO.cs
│   ├── VehicleTypeDTO.cs
│   ├── VehicleDTO.cs
│   ├── ParkingZoneDTO.cs
│   ├── ParkingSlotDTO.cs
│   ├── ParkingLogDTO.cs
│   ├── ParkingFeeDTO.cs
│   ├── InvoiceDTO.cs
│   ├── InvoiceDetailDTO.cs
│   └── DashboardDTO.cs
│
├── ParkingManagement.DAL/          # Data Access Layer
│   ├── DatabaseConnection.cs       # Kết nối database (Singleton)
│   ├── UserDAL.cs
│   ├── BuildingDAL.cs
│   ├── ApartmentDAL.cs
│   ├── VehicleDAL.cs
│   ├── ParkingSlotDAL.cs
│   ├── ParkingLogDAL.cs
│   └── DashboardDAL.cs
│
├── ParkingManagement.BLL/          # Business Logic Layer
│   ├── UserBLL.cs
│   ├── BuildingBLL.cs
│   ├── ApartmentBLL.cs
│   ├── VehicleBLL.cs
│   ├── ParkingSlotBLL.cs
│   ├── ParkingLogBLL.cs
│   └── DashboardBLL.cs
│
└── ParkingManagement.GUI/          # Graphical User Interface
    ├── Program.cs                  # Entry point
    ├── App.config                  # Cấu hình kết nối
    ├── FormLogin.cs                # Màn hình đăng nhập
    ├── FormMain.cs                 # Màn hình chính (Ribbon)
    ├── FormChangePassword.cs       # Đổi mật khẩu
    ├── FormVehicleEdit.cs          # Thêm/Sửa xe
    └── UserControls/
        ├── UCDashboard.cs          # Dashboard thống kê
        ├── UCBuilding.cs           # Quản lý tòa nhà
        ├── UCApartment.cs          # Quản lý căn hộ
        ├── UCVehicle.cs            # Quản lý phương tiện
        ├── UCParkingSlot.cs        # Quản lý chỗ đậu
        ├── UCParkingLog.cs         # Quản lý Ra/Vào
        ├── UCReport.cs             # Báo cáo thống kê
        └── UCUser.cs               # Quản lý người dùng
```

---

## 🛠️ HƯỚNG DẪN THIẾT LẬP

### Bước 1: Tạo Solution trong Visual Studio 2022

1. Mở Visual Studio 2022
2. File → New → Blank Solution
3. Đặt tên: `ParkingManagement`

### Bước 2: Thêm các Project

**Thêm 4 Class Library (.NET Framework 4.8):**

```
1. ParkingManagement.DTO
2. ParkingManagement.DAL
3. ParkingManagement.BLL
```

**Thêm 1 Windows Forms App (.NET Framework 4.8):**
```
4. ParkingManagement.GUI
```

### Bước 3: Thêm References giữa các Project

| Project | References |
|---------|------------|
| **DAL** | DTO, System.Configuration |
| **BLL** | DTO, DAL |
| **GUI** | DTO, BLL, DAL |

### Bước 4: Cài đặt DevExpress

1. Cài DevExpress WinForms từ DevExpress Installer
2. Trong mỗi project GUI, thêm references:
   - DevExpress.Data
   - DevExpress.Utils
   - DevExpress.XtraEditors
   - DevExpress.XtraGrid
   - DevExpress.XtraBars
   - DevExpress.XtraCharts

### Bước 5: Copy Code Files

1. Copy tất cả file `.cs` từ thư mục tương ứng vào Visual Studio
2. Đảm bảo namespace đúng với tên project

### Bước 6: Tạo Database

1. Mở SQL Server Management Studio
2. Chạy file `database/ParkingManagement_Database.sql`
3. Database sẽ được tạo với dữ liệu mẫu

### Bước 7: Cấu hình Connection String

Mở file `App.config` trong project GUI và sửa connection string:

```xml
<connectionStrings>
    <add name="ParkingDB" 
         connectionString="Data Source=TÊN_SERVER;Initial Catalog=ParkingManagement;Integrated Security=True" 
         providerName="System.Data.SqlClient"/>
</connectionStrings>
```

**Ví dụ:**
- Local: `Data Source=.;Initial Catalog=ParkingManagement;Integrated Security=True`
- Named Instance: `Data Source=.\SQLEXPRESS;Initial Catalog=ParkingManagement;Integrated Security=True`
- Với SQL Auth: `Data Source=.;Initial Catalog=ParkingManagement;User ID=sa;Password=123456`

### Bước 8: Build và Chạy

1. Build Solution (Ctrl + Shift + B)
2. Đặt project GUI là Startup Project
3. Chạy (F5)

---

## 👤 THÔNG TIN ĐĂNG NHẬP MẪU

| Username | Password | Vai trò |
|----------|----------|---------|
| admin | 123456 | Admin |
| manager | 123456 | Quản lý |
| security | 123456 | Bảo vệ |
| cashier | 123456 | Thu ngân |

---

## 📝 GHI CHÚ QUAN TRỌNG

### ADO.NET đã được implement sẵn

Code đã bao gồm đầy đủ ADO.NET trong DAL layer:
- `SqlConnection`, `SqlCommand`, `SqlDataReader`
- Stored Procedures: `sp_Login`, `sp_CheckIn`, `sp_CheckOut`
- Parameterized queries để chống SQL Injection

### Những phần cần bổ sung thêm (TODO)

1. **FormVehicleEdit.cs**: Cần load ComboBox cho Resident và VehicleType
2. **Properties/Settings.settings**: Cần tạo file Settings để lưu RememberMe
3. **Thêm các DAL còn thiếu**: ResidentDAL, VehicleTypeDAL, ParkingZoneDAL, ParkingFeeDAL, InvoiceDAL
4. **Thêm chức năng CRUD hoàn chỉnh** cho các UserControl

### Mật khẩu mặc định

Mật khẩu trong database được hash bằng MD5. Password `123456` có hash là:
```
e10adc3949ba59abbe56e057f20f883e
```

---

## 🔧 XỬ LÝ LỖI THƯỜNG GẶP

### Lỗi kết nối database
- Kiểm tra SQL Server đang chạy
- Kiểm tra tên server trong connection string
- Kiểm tra database `ParkingManagement` đã tồn tại

### Lỗi DevExpress không tìm thấy
- Đảm bảo DevExpress đã được cài đặt
- Thêm references đúng version DevExpress

### Lỗi System.Configuration
- Thêm reference `System.Configuration` vào project DAL

---

## 📞 HỖ TRỢ

Nếu có vấn đề, vui lòng kiểm tra:
1. Tất cả references đã được thêm đúng
2. .NET Framework 4.8 đã được cài đặt
3. DevExpress version phù hợp
4. SQL Server đang hoạt động

---

**Chúc bạn thành công! 🎉**
