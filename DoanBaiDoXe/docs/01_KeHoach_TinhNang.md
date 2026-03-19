# 🚗 HỆ THỐNG QUẢN LÝ BÃI ĐẬU XE Ô TÔ CHUNG CƯ

## 📋 Tổng Quan Dự Án

### Mục Tiêu
Xây dựng hệ thống quản lý bãi đậu xe ô tô chuyên nghiệp cho chung cư, giúp:
- Quản lý chỗ đậu xe, cư dân và phương tiện
- Theo dõi xe ra/vào tự động
- Tính phí đậu xe linh hoạt
- Báo cáo thống kê trực quan

### Công Nghệ Sử Dụng
| Thành phần | Công nghệ |
|------------|-----------|
| **Ngôn ngữ** | C# .NET Framework 4.8 |
| **IDE** | Visual Studio 2022 |
| **UI Framework** | WinForms + DevExpress |
| **Database** | SQL Server 2019+ |
| **Kiến trúc** | 3-Layer (DAL, BLL, GUI) |
| **ORM** | ADO.NET / Entity Framework |

---

## 🏗️ Kiến Trúc 3 Lớp

```
┌─────────────────────────────────────────────────────┐
│                    GUI LAYER                         │
│  (DevExpress WinForms - Giao diện người dùng)       │
├─────────────────────────────────────────────────────┤
│                    BLL LAYER                         │
│  (Business Logic - Xử lý nghiệp vụ)                 │
├─────────────────────────────────────────────────────┤
│                    DAL LAYER                         │
│  (Data Access - Truy xuất dữ liệu)                  │
├─────────────────────────────────────────────────────┤
│                  SQL SERVER                          │
│  (Database - Cơ sở dữ liệu)                         │
└─────────────────────────────────────────────────────┘
```

### Cấu Trúc Solution
```
ParkingManagement.sln
├── ParkingManagement.GUI        (WinForms + DevExpress)
├── ParkingManagement.BLL        (Business Logic Layer)
├── ParkingManagement.DAL        (Data Access Layer)
├── ParkingManagement.DTO        (Data Transfer Objects)
└── ParkingManagement.Common     (Utilities, Constants, Helpers)
```

---

## 🎯 Tính Năng Chi Tiết

### 1. 🔐 Module Đăng Nhập & Phân Quyền

| Tính năng | Mô tả |
|-----------|-------|
| Đăng nhập | Xác thực username/password |
| Phân quyền | Admin, Nhân viên bảo vệ, Nhân viên thu phí |
| Đổi mật khẩu | Cho phép đổi mật khẩu cá nhân |
| Khóa tài khoản | Khóa sau 5 lần đăng nhập sai |
| Nhật ký đăng nhập | Ghi lại lịch sử đăng nhập |

### 2. 🏠 Quản Lý Căn Hộ & Cư Dân

| Tính năng | Mô tả |
|-----------|-------|
| CRUD Tòa nhà | Thêm/Sửa/Xóa thông tin tòa nhà |
| CRUD Căn hộ | Quản lý căn hộ theo tòa nhà |
| CRUD Cư dân | Thông tin chủ hộ, cư dân |
| Liên kết xe-căn hộ | Đăng ký xe cho căn hộ |
| Tìm kiếm | Tìm theo mã, tên, số điện thoại |

### 3. 🚙 Quản Lý Phương Tiện

| Tính năng | Mô tả |
|-----------|-------|
| Đăng ký xe | Thêm xe mới cho cư dân |
| Loại xe | Ô tô 4 chỗ, 7 chỗ, SUV, Pickup |
| Thông tin xe | Biển số, màu sắc, hãng xe, đời xe |
| Thẻ xe | Cấp thẻ RFID/QR Code |
| Trạng thái | Hoạt động, Tạm ngưng, Hết hạn |
| Ảnh xe | Lưu ảnh xe từ camera |

### 4. 🅿️ Quản Lý Chỗ Đậu Xe

| Tính năng | Mô tả |
|-----------|-------|
| CRUD Khu vực | Tầng hầm B1, B2, B3... |
| CRUD Chỗ đậu | Vị trí, trạng thái (trống/có xe/bảo trì) |
| Phân loại | Chỗ cố định, chỗ tạm |
| Đăng ký chỗ cố định | Gán chỗ đậu cho căn hộ |
| Sơ đồ bãi xe | Hiển thị trực quan bằng sơ đồ |

### 5. 🚦 Quản Lý Ra/Vào

| Tính năng | Mô tả |
|-----------|-------|
| Check-in | Ghi nhận xe vào bãi |
| Check-out | Ghi nhận xe ra bãi |
| Chụp ảnh | Lưu ảnh biển số khi ra/vào |
| Auto nhận dạng | Nhận dạng biển số tự động (tùy chọn) |
| Xe khách | Quản lý xe khách đến thăm |
| Lịch sử | Tra cứu lịch sử ra/vào theo xe, ngày |

### 6. 💰 Quản Lý Phí & Thanh Toán

| Tính năng | Mô tả |
|-----------|-------|
| Loại phí | Phí tháng, phí ngày, phí giờ |
| Bảng giá | Cấu hình giá theo loại xe, thời gian |
| Hóa đơn | Tạo hóa đơn tự động |
| Thanh toán | Tiền mặt, chuyển khoản |
| Nợ phí | Theo dõi cư dân nợ phí |
| Báo cáo thu | Thống kê doanh thu |

### 7. 📊 Báo Cáo & Thống Kê

| Loại báo cáo | Chi tiết |
|--------------|----------|
| Dashboard | Tổng quan số liệu realtime |
| Báo cáo xe | Số lượng xe theo loại, trạng thái |
| Báo cáo ra/vào | Thống kê lượt ra/vào theo ngày/tháng |
| Báo cáo doanh thu | Doanh thu theo ngày/tháng/năm |
| Báo cáo chỗ đậu | Tỷ lệ sử dụng chỗ đậu |
| Xuất Excel/PDF | Xuất báo cáo ra file |

### 8. ⚙️ Cài Đặt Hệ Thống

| Tính năng | Mô tả |
|-----------|-------|
| Thông tin chung cư | Tên, địa chỉ, logo |
| Cấu hình phí | Bảng giá, chính sách |
| Quản lý user | CRUD tài khoản nhân viên |
| Backup/Restore | Sao lưu, phục hồi dữ liệu |
| Nhật ký hệ thống | Audit log các thao tác |

---

## 🎨 Thiết Kế Giao Diện (DevExpress)

### Theme & Màu Sắc
- **Primary Color**: `#1A73E8` (Blue)
- **Secondary Color**: `#34A853` (Green)
- **Accent Color**: `#EA4335` (Red cho cảnh báo)
- **Background**: `#F8F9FA` (Light Gray)
- **Dark Mode**: Hỗ trợ theme tối

### Bố Cục Màn Hình Chính

```
┌───────────────────────────────────────────────────────────────┐
│  🅿️ PARKING MANAGEMENT SYSTEM           [User] [🔔] [⚙️] [✕] │
├────────────┬──────────────────────────────────────────────────┤
│            │                                                  │
│  📊 Dashboard   ┌──────────────────────────────────────────┐  │
│            │    │         MAIN CONTENT AREA                │  │
│  🏠 Căn hộ │    │                                          │  │
│            │    │  - GridControl với DevExpress            │  │
│  🚗 Xe     │    │  - Charts thống kê                       │  │
│            │    │  - Forms nhập liệu                       │  │
│  🅿️ Chỗ đậu│    │  - Ribbon Menu                          │  │
│            │    │                                          │  │
│  🚦 Ra/Vào │    └──────────────────────────────────────────┘  │
│            │                                                  │
│  💰 Thu phí│                                                  │
│            │                                                  │
│  📈 Báo cáo│                                                  │
│            │                                                  │
│  ⚙️ Cài đặt│                                                  │
│            │                                                  │
├────────────┴──────────────────────────────────────────────────┤
│  Status Bar: [Trạng thái kết nối] [User đăng nhập] [Thời gian]│
└───────────────────────────────────────────────────────────────┘
```

### DevExpress Controls Sử Dụng

| Control | Mục đích |
|---------|----------|
| `RibbonControl` | Menu ribbon hiện đại |
| `AccordionControl` | Navigation sidebar |
| `GridControl` | Hiển thị danh sách dữ liệu |
| `ChartControl` | Biểu đồ thống kê |
| `DockManager` | Quản lý panel linh hoạt |
| `XtraForm` + `FluentDesignForm` | Form hiện đại |
| `TileControl` | Dashboard tiles |
| `DateEdit`, `LookUpEdit` | Input controls |
| `XtraReport` | In báo cáo |

### Các Màn Hình Chính

#### 1. Màn Hình Đăng Nhập
- Logo chung cư
- Form đăng nhập đẹp với animation
- Remember me, Quên mật khẩu
- Hiệu ứng loading

#### 2. Dashboard
- **Tile thống kê**: Tổng xe, Chỗ trống, Xe trong bãi, Doanh thu hôm nay
- **Biểu đồ tròn**: Phân bố loại xe
- **Biểu đồ đường**: Xu hướng ra/vào theo giờ
- **Biểu đồ cột**: Doanh thu 7 ngày gần nhất
- **Bảng hoạt động gần đây**: 10 xe ra/vào gần nhất

#### 3. Quản Lý Xe
- Grid hiển thị danh sách xe
- Toolbar: Thêm, Sửa, Xóa, Tìm kiếm, Xuất Excel
- Form popup thêm/sửa xe
- Ảnh xe, ảnh biển số

#### 4. Màn Hình Ra/Vào
- Camera live view (nếu có)
- Ô nhập biển số lớn
- Nút Check-in / Check-out
- Thông tin xe hiện tại
- Lịch sử gần đây

#### 5. Sơ Đồ Bãi Xe
- Visual layout các chỗ đậu
- Màu sắc phân biệt: Xanh=Trống, Đỏ=Có xe, Vàng=Bảo trì
- Click để xem thông tin chi tiết
- Zoom in/out

---

## 🗄️ Thiết Kế Database

### Entity Relationship Diagram (ERD)

```
┌─────────────┐      ┌─────────────┐      ┌─────────────┐
│   USERS     │      │  BUILDINGS  │      │ PARKING_ZONE│
├─────────────┤      ├─────────────┤      ├─────────────┤
│ UserID (PK) │      │BuildingID(PK│      │ ZoneID (PK) │
│ Username    │      │ BuildingName│      │ ZoneName    │
│ Password    │      │ TotalFloors │      │ Description │
│ FullName    │      │ Address     │      │ TotalSlots  │
│ Role        │      │ Status      │      │ Status      │
│ Status      │      └─────────────┘      └─────────────┘
│ CreatedDate │             │                    │
└─────────────┘             │                    │
                            ▼                    ▼
                   ┌─────────────┐      ┌─────────────┐
                   │ APARTMENTS  │      │PARKING_SLOTS│
                   ├─────────────┤      ├─────────────┤
                   │ApartmentID  │      │ SlotID (PK) │
                   │BuildingID(FK│◄─────│ ZoneID (FK) │
                   │ ApartmentNo │      │ SlotNumber  │
                   │ Floor       │      │ SlotType    │
                   │ Area        │      │ Status      │
                   │ OwnerName   │      │ ApartmentID │
                   │ Phone       │      └─────────────┘
                   └─────────────┘             │
                          │                    │
                          ▼                    │
                   ┌─────────────┐             │
                   │  RESIDENTS  │             │
                   ├─────────────┤             │
                   │ResidentID(PK│             │
                   │ApartmentID  │             │
                   │ FullName    │             │
                   │ Phone       │             │
                   │ IDCard      │             │
                   │ IsOwner     │             │
                   └─────────────┘             │
                          │                    │
                          ▼                    │
                   ┌─────────────┐             │
                   │  VEHICLES   │◄────────────┘
                   ├─────────────┤
                   │VehicleID(PK)│
                   │ResidentID(FK│
                   │SlotID (FK)  │
                   │LicensePlate │
                   │ VehicleType │
                   │ Brand       │
                   │ Color       │
                   │ CardNumber  │
                   │ Status      │
                   │ StartDate   │
                   │ EndDate     │
                   └─────────────┘
                          │
                          ▼
    ┌─────────────┐      ┌─────────────┐      ┌─────────────┐
    │PARKING_FEES │      │PARKING_LOGS │      │  INVOICES   │
    ├─────────────┤      ├─────────────┤      ├─────────────┤
    │ FeeID (PK)  │      │ LogID (PK)  │      │InvoiceID(PK)│
    │ FeeName     │      │VehicleID(FK)│      │VehicleID(FK)│
    │ VehicleType │      │ CheckInTime │      │ Month       │
    │ FeeType     │      │CheckOutTime │      │ Amount      │
    │ Amount      │      │ SlotID      │      │ DueDate     │
    │ Description │      │CheckInImage │      │ PaidDate    │
    │ Status      │      │CheckOutImage│      │ Status      │
    └─────────────┘      │ Status      │      │ CreatedBy   │
                         │ CreatedBy   │      └─────────────┘
                         └─────────────┘
```

### Danh Sách Bảng

| STT | Tên bảng | Mô tả |
|-----|----------|-------|
| 1 | `Users` | Người dùng hệ thống |
| 2 | `Roles` | Vai trò phân quyền |
| 3 | `UserRoles` | Liên kết user-role |
| 4 | `Buildings` | Tòa nhà |
| 5 | `Apartments` | Căn hộ |
| 6 | `Residents` | Cư dân |
| 7 | `VehicleTypes` | Loại phương tiện |
| 8 | `Vehicles` | Phương tiện |
| 9 | `ParkingZones` | Khu vực đậu xe |
| 10 | `ParkingSlots` | Chỗ đậu xe |
| 11 | `ParkingFees` | Bảng giá phí |
| 12 | `ParkingLogs` | Lịch sử ra/vào |
| 13 | `Invoices` | Hóa đơn |
| 14 | `InvoiceDetails` | Chi tiết hóa đơn |
| 15 | `Payments` | Thanh toán |
| 16 | `AuditLogs` | Nhật ký hệ thống |
| 17 | `SystemConfigs` | Cấu hình hệ thống |

---

## 📅 Kế Hoạch Thực Hiện

### Phase 1: Setup & Database (2-3 ngày)
- [ ] Tạo solution với 5 projects
- [ ] Tạo database SQL Server
- [ ] Tạo các bảng và quan hệ
- [ ] Insert dữ liệu mẫu
- [ ] Tạo DTO classes

### Phase 2: DAL & BLL Layer (3-4 ngày)
- [ ] Viết DAL cho tất cả bảng
- [ ] Viết BLL xử lý nghiệp vụ
- [ ] Unit test cơ bản

### Phase 3: GUI Layer - Core (5-7 ngày)
- [ ] Form đăng nhập
- [ ] Main form với navigation
- [ ] Dashboard
- [ ] CRUD Căn hộ & Cư dân
- [ ] CRUD Phương tiện
- [ ] CRUD Chỗ đậu xe

### Phase 4: GUI Layer - Advanced (5-7 ngày)
- [ ] Màn hình Ra/Vào
- [ ] Quản lý phí & hóa đơn
- [ ] Báo cáo & thống kê
- [ ] Xuất Excel/PDF
- [ ] Settings

### Phase 5: Testing & Polish (2-3 ngày)
- [ ] Test toàn bộ chức năng
- [ ] Fix bugs
- [ ] Tối ưu performance
- [ ] Deploy

---

## ⚠️ Lưu Ý Quan Trọng

> [!IMPORTANT]
> - Sử dụng Stored Procedures cho các truy vấn phức tạp
> - Mã hóa mật khẩu bằng SHA256 hoặc BCrypt
> - Validate dữ liệu ở cả BLL và GUI
> - Xử lý exception đầy đủ
> - Logging các lỗi và hoạt động quan trọng

> [!TIP]
> - Sử dụng DevExpress Skin/Theme cho giao diện đẹp
> - Áp dụng async/await cho các tác vụ nặng
> - Cache dữ liệu thường dùng (lookup tables)
> - Sử dụng MDI hoặc Tab control để quản lý forms

---

## 📞 Liên Hệ & Hỗ Trợ

**Dự án**: Hệ Thống Quản Lý Bãi Đậu Xe Ô Tô Chung Cư  
**Phiên bản**: 1.0.0  
**Ngày tạo**: 14/12/2024

---

*Tài liệu này sẽ được cập nhật trong quá trình phát triển.*
