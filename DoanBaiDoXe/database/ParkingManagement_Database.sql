


CREATE DATABASE ParkingManagement



USE ParkingManagement;


-- =============================================
-- 1. Bảng Roles - Vai trò người dùng
-- =============================================
CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255),
    CreatedDate DATETIME DEFAULT GETDATE(),
    Status BIT DEFAULT 1
);
GO

-- =============================================
-- 2. Bảng Users - Người dùng hệ thống
-- =============================================
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(256) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Avatar NVARCHAR(255),
    FailedLoginCount INT DEFAULT 0,
    LastLoginDate DATETIME,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status BIT DEFAULT 1 -- 1: Active, 0: Locked
);
GO

-- =============================================
-- 3. Bảng UserRoles - Liên kết User và Role
-- =============================================
CREATE TABLE UserRoles (
    UserRoleID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    RoleID INT NOT NULL,
    AssignedDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    CONSTRAINT UQ_UserRoles UNIQUE (UserID, RoleID)
);
GO

-- =============================================
-- 4. Bảng Buildings - Tòa nhà
-- =============================================
CREATE TABLE Buildings (
    BuildingID INT IDENTITY(1,1) PRIMARY KEY,
    BuildingCode VARCHAR(20) NOT NULL UNIQUE,
    BuildingName NVARCHAR(100) NOT NULL,
    TotalFloors INT DEFAULT 1,
    TotalApartments INT DEFAULT 0,
    Address NVARCHAR(255),
    Description NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status BIT DEFAULT 1
);
GO

-- =============================================
-- 5. Bảng Apartments - Căn hộ
-- =============================================
CREATE TABLE Apartments (
    ApartmentID INT IDENTITY(1,1) PRIMARY KEY,
    BuildingID INT NOT NULL,
    ApartmentCode VARCHAR(20) NOT NULL,
    ApartmentNumber NVARCHAR(20) NOT NULL,
    Floor INT NOT NULL,
    Area DECIMAL(10,2), -- Diện tích (m2)
    Bedrooms INT DEFAULT 1,
    OwnerName NVARCHAR(100),
    Phone VARCHAR(20),
    Email VARCHAR(100),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status BIT DEFAULT 1,
    CONSTRAINT FK_Apartments_Buildings FOREIGN KEY (BuildingID) REFERENCES Buildings(BuildingID),
    CONSTRAINT UQ_Apartment_Code UNIQUE (BuildingID, ApartmentCode)
);
GO

-- =============================================
-- 6. Bảng Residents - Cư dân
-- =============================================
CREATE TABLE Residents (
    ResidentID INT IDENTITY(1,1) PRIMARY KEY,
    ApartmentID INT NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10), -- Nam, Nữ
    DateOfBirth DATE,
    IDCardNumber VARCHAR(20),
    Phone VARCHAR(20),
    Email VARCHAR(100),
    IsOwner BIT DEFAULT 0, -- 1: Chủ hộ, 0: Thành viên
    RelationshipWithOwner NVARCHAR(50), -- Vợ/Chồng, Con, Bố/Mẹ...
    Avatar NVARCHAR(255),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status BIT DEFAULT 1,
    CONSTRAINT FK_Residents_Apartments FOREIGN KEY (ApartmentID) REFERENCES Apartments(ApartmentID)
);
GO

-- =============================================
-- 7. Bảng VehicleTypes - Loại phương tiện
-- =============================================
CREATE TABLE VehicleTypes (
    VehicleTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255),
    Icon NVARCHAR(100),
    SortOrder INT DEFAULT 0,
    Status BIT DEFAULT 1
);
GO

-- =============================================
-- 8. Bảng ParkingZones - Khu vực đậu xe
-- =============================================
CREATE TABLE ParkingZones (
    ZoneID INT IDENTITY(1,1) PRIMARY KEY,
    ZoneCode VARCHAR(20) NOT NULL UNIQUE,
    ZoneName NVARCHAR(100) NOT NULL,
    FloorLevel INT, -- B1, B2, B3 = -1, -2, -3
    TotalSlots INT DEFAULT 0,
    Description NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status BIT DEFAULT 1
);
GO

-- =============================================
-- 9. Bảng ParkingSlots - Chỗ đậu xe
-- =============================================
CREATE TABLE ParkingSlots (
    SlotID INT IDENTITY(1,1) PRIMARY KEY,
    ZoneID INT NOT NULL,
    SlotCode VARCHAR(20) NOT NULL,
    SlotNumber NVARCHAR(20) NOT NULL,
    SlotType NVARCHAR(20) DEFAULT N'Cố định', -- Cố định, Tạm thời
    RowPosition INT, -- Vị trí hàng
    ColumnPosition INT, -- Vị trí cột
    Width DECIMAL(5,2), -- Chiều rộng (m)
    Length DECIMAL(5,2), -- Chiều dài (m)
    Description NVARCHAR(255),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    SlotStatus NVARCHAR(20) DEFAULT N'Trống', -- Trống, Có xe, Bảo trì, Đã đăng ký
    CONSTRAINT FK_ParkingSlots_Zones FOREIGN KEY (ZoneID) REFERENCES ParkingZones(ZoneID),
    CONSTRAINT UQ_Slot_Code UNIQUE (ZoneID, SlotCode)
);
GO

-- =============================================
-- 10. Bảng Vehicles - Phương tiện
-- =============================================
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    ResidentID INT NOT NULL,
    VehicleTypeID INT NOT NULL,
    SlotID INT, -- Chỗ đậu xe cố định (nếu có)
    LicensePlate VARCHAR(20) NOT NULL UNIQUE,
    Brand NVARCHAR(50), -- Hãng xe
    Model NVARCHAR(50), -- Dòng xe
    Color NVARCHAR(30), -- Màu sắc
    YearOfManufacture INT, -- Năm sản xuất
    CardNumber VARCHAR(50), -- Số thẻ RFID/QR
    VehicleImage NVARCHAR(255), -- Ảnh xe
    LicensePlateImage NVARCHAR(255), -- Ảnh biển số
    RegistrationDate DATE DEFAULT GETDATE(), -- Ngày đăng ký
    ExpiryDate DATE, -- Ngày hết hạn
    Note NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status NVARCHAR(20) DEFAULT N'Hoạt động', -- Hoạt động, Tạm ngưng, Hết hạn
    CONSTRAINT FK_Vehicles_Residents FOREIGN KEY (ResidentID) REFERENCES Residents(ResidentID),
    CONSTRAINT FK_Vehicles_VehicleTypes FOREIGN KEY (VehicleTypeID) REFERENCES VehicleTypes(VehicleTypeID),
    CONSTRAINT FK_Vehicles_Slots FOREIGN KEY (SlotID) REFERENCES ParkingSlots(SlotID)
);
GO

-- =============================================
-- 11. Bảng ParkingFees - Bảng phí đậu xe
-- =============================================
CREATE TABLE ParkingFees (
    FeeID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleTypeID INT NOT NULL,
    FeeName NVARCHAR(100) NOT NULL,
    FeeType NVARCHAR(20) NOT NULL, -- Tháng, Ngày, Giờ
    Amount DECIMAL(18,2) NOT NULL,
    Description NVARCHAR(255),
    EffectiveFrom DATE NOT NULL,
    EffectiveTo DATE,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    Status BIT DEFAULT 1,
    CONSTRAINT FK_ParkingFees_VehicleTypes FOREIGN KEY (VehicleTypeID) REFERENCES VehicleTypes(VehicleTypeID)
);
GO

-- =============================================
-- 12. Bảng ParkingLogs - Lịch sử ra/vào
-- =============================================
CREATE TABLE ParkingLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT NOT NULL,
    SlotID INT,
    CheckInTime DATETIME NOT NULL,
    CheckOutTime DATETIME,
    CheckInImage NVARCHAR(255), -- Ảnh lúc vào
    CheckOutImage NVARCHAR(255), -- Ảnh lúc ra
    CheckInBy INT, -- UserID người check-in
    CheckOutBy INT, -- UserID người check-out
    ParkingType NVARCHAR(20) DEFAULT N'Thường xuyên', -- Thường xuyên, Khách
    Fee DECIMAL(18,2) DEFAULT 0,
    Note NVARCHAR(500),
    LogStatus NVARCHAR(20) DEFAULT N'Đang đậu', -- Đang đậu, Đã ra
    CONSTRAINT FK_ParkingLogs_Vehicles FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    CONSTRAINT FK_ParkingLogs_Slots FOREIGN KEY (SlotID) REFERENCES ParkingSlots(SlotID),
    CONSTRAINT FK_ParkingLogs_CheckInBy FOREIGN KEY (CheckInBy) REFERENCES Users(UserID),
    CONSTRAINT FK_ParkingLogs_CheckOutBy FOREIGN KEY (CheckOutBy) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 13. Bảng Invoices - Hóa đơn
-- =============================================
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceCode VARCHAR(20) NOT NULL UNIQUE,
    ApartmentID INT NOT NULL,
    InvoiceMonth INT NOT NULL, -- Tháng
    InvoiceYear INT NOT NULL, -- Năm
    TotalAmount DECIMAL(18,2) NOT NULL,
    DiscountAmount DECIMAL(18,2) DEFAULT 0,
    FinalAmount DECIMAL(18,2) NOT NULL,
    DueDate DATE NOT NULL,
    PaidDate DATETIME,
    PaymentMethod NVARCHAR(50), -- Tiền mặt, Chuyển khoản
    Note NVARCHAR(500),
    CreatedBy INT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    InvoiceStatus NVARCHAR(20) DEFAULT N'Chưa thanh toán', -- Chưa thanh toán, Đã thanh toán, Quá hạn
    CONSTRAINT FK_Invoices_Apartments FOREIGN KEY (ApartmentID) REFERENCES Apartments(ApartmentID),
    CONSTRAINT FK_Invoices_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 14. Bảng InvoiceDetails - Chi tiết hóa đơn
-- =============================================
CREATE TABLE InvoiceDetails (
    DetailID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    VehicleID INT NOT NULL,
    FeeID INT NOT NULL,
    Quantity INT DEFAULT 1,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    Description NVARCHAR(255),
    CONSTRAINT FK_InvoiceDetails_Invoices FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    CONSTRAINT FK_InvoiceDetails_Vehicles FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    CONSTRAINT FK_InvoiceDetails_Fees FOREIGN KEY (FeeID) REFERENCES ParkingFees(FeeID)
);
GO

-- =============================================
-- 15. Bảng Payments - Thanh toán
-- =============================================
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    PaymentCode VARCHAR(20) NOT NULL UNIQUE,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(18,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL, -- Tiền mặt, Chuyển khoản, Ví điện tử
    TransactionCode VARCHAR(50), -- Mã giao dịch ngân hàng
    ReceivedBy INT, -- UserID người nhận
    Note NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    Status BIT DEFAULT 1,
    CONSTRAINT FK_Payments_Invoices FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    CONSTRAINT FK_Payments_ReceivedBy FOREIGN KEY (ReceivedBy) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 16. Bảng GuestVehicles - Xe khách (vãng lai)
-- =============================================
CREATE TABLE GuestVehicles (
    GuestVehicleID INT IDENTITY(1,1) PRIMARY KEY,
    LicensePlate VARCHAR(20) NOT NULL,
    VehicleTypeID INT NOT NULL,
    DriverName NVARCHAR(100),
    DriverPhone VARCHAR(20),
    VisitingApartmentID INT, -- Căn hộ đến thăm
    Purpose NVARCHAR(255), -- Mục đích
    CheckInTime DATETIME NOT NULL,
    CheckOutTime DATETIME,
    CheckInImage NVARCHAR(255),
    CheckOutImage NVARCHAR(255),
    SlotID INT,
    Fee DECIMAL(18,2) DEFAULT 0,
    IsPaid BIT DEFAULT 0,
    CheckInBy INT,
    CheckOutBy INT,
    Note NVARCHAR(500),
    Status NVARCHAR(20) DEFAULT N'Đang đậu', -- Đang đậu, Đã ra
    CONSTRAINT FK_GuestVehicles_VehicleTypes FOREIGN KEY (VehicleTypeID) REFERENCES VehicleTypes(VehicleTypeID),
    CONSTRAINT FK_GuestVehicles_Apartments FOREIGN KEY (VisitingApartmentID) REFERENCES Apartments(ApartmentID),
    CONSTRAINT FK_GuestVehicles_Slots FOREIGN KEY (SlotID) REFERENCES ParkingSlots(SlotID),
    CONSTRAINT FK_GuestVehicles_CheckInBy FOREIGN KEY (CheckInBy) REFERENCES Users(UserID),
    CONSTRAINT FK_GuestVehicles_CheckOutBy FOREIGN KEY (CheckOutBy) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 17. Bảng AuditLogs - Nhật ký hệ thống
-- =============================================
CREATE TABLE AuditLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    Action NVARCHAR(50) NOT NULL, -- Create, Update, Delete, Login, Logout
    TableName NVARCHAR(50),
    RecordID INT,
    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),
    IPAddress VARCHAR(50),
    MachineName NVARCHAR(100),
    LogDate DATETIME DEFAULT GETDATE(),
    Description NVARCHAR(500),
    CONSTRAINT FK_AuditLogs_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 18. Bảng SystemConfigs - Cấu hình hệ thống
-- =============================================
CREATE TABLE SystemConfigs (
    ConfigID INT IDENTITY(1,1) PRIMARY KEY,
    ConfigKey VARCHAR(50) NOT NULL UNIQUE,
    ConfigValue NVARCHAR(500),
    ConfigType NVARCHAR(50), -- String, Number, Boolean, Date
    Description NVARCHAR(255),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    UpdatedBy INT,
    CONSTRAINT FK_SystemConfigs_Users FOREIGN KEY (UpdatedBy) REFERENCES Users(UserID)
);
GO

-- =============================================
-- 19. Bảng LoginHistory - Lịch sử đăng nhập
-- =============================================
CREATE TABLE LoginHistory (
    HistoryID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    LoginTime DATETIME DEFAULT GETDATE(),
    LogoutTime DATETIME,
    IPAddress VARCHAR(50),
    MachineName NVARCHAR(100),
    LoginStatus NVARCHAR(20), -- Success, Failed
    FailReason NVARCHAR(255),
    CONSTRAINT FK_LoginHistory_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- =============================================
-- TẠO INDEXES
-- =============================================
CREATE INDEX IX_Vehicles_LicensePlate ON Vehicles(LicensePlate);
CREATE INDEX IX_Vehicles_CardNumber ON Vehicles(CardNumber);
CREATE INDEX IX_ParkingLogs_CheckInTime ON ParkingLogs(CheckInTime);
CREATE INDEX IX_ParkingLogs_VehicleID ON ParkingLogs(VehicleID);
CREATE INDEX IX_Invoices_InvoiceCode ON Invoices(InvoiceCode);
CREATE INDEX IX_Invoices_ApartmentID ON Invoices(ApartmentID);
CREATE INDEX IX_Apartments_BuildingID ON Apartments(BuildingID);
CREATE INDEX IX_Residents_ApartmentID ON Residents(ApartmentID);
GO

-- =============================================
-- INSERT DỮ LIỆU MẪU
-- =============================================

-- 1. Thêm vai trò
INSERT INTO Roles (RoleName, Description) VALUES
(N'Admin', N'Quản trị viên hệ thống'),
(N'Manager', N'Quản lý bãi xe'),
(N'Security', N'Nhân viên bảo vệ'),
(N'Cashier', N'Nhân viên thu phí');
GO

-- 2. Thêm user mặc định (password: 123456)
-- Password hash của '123456' bằng SHA256
INSERT INTO Users (Username, PasswordHash, FullName, Email, Phone, Status) VALUES
('admin', 'e10adc3949ba59abbe56e057f20f883e', N'Quản Trị Viên', 'admin@parking.com', '0901234567', 1),
('manager', 'e10adc3949ba59abbe56e057f20f883e', N'Nguyễn Văn Quản Lý', 'manager@parking.com', '0901234568', 1),
('security1', 'e10adc3949ba59abbe56e057f20f883e', N'Trần Văn Bảo Vệ', 'security1@parking.com', '0901234569', 1),
('cashier1', 'e10adc3949ba59abbe56e057f20f883e', N'Lê Thị Thu Phí', 'cashier1@parking.com', '0901234570', 1);
GO

-- 3. Gán vai trò cho user
INSERT INTO UserRoles (UserID, RoleID) VALUES
(1, 1), -- admin - Admin
(2, 2), -- manager - Manager
(3, 3), -- security1 - Security
(4, 4); -- cashier1 - Cashier
GO

-- 4. Thêm loại phương tiện
INSERT INTO VehicleTypes (TypeName, Description, SortOrder) VALUES
(N'Ô tô 4-5 chỗ', N'Xe ô tô từ 4 đến 5 chỗ ngồi', 1),
(N'Ô tô 7 chỗ', N'Xe ô tô 7 chỗ ngồi', 2),
(N'Ô tô SUV', N'Xe SUV, CUV', 3),
(N'Xe bán tải', N'Xe pickup, bán tải', 4),
(N'Xe VAN', N'Xe VAN, xe khách nhỏ', 5);
GO

-- 5. Thêm tòa nhà
INSERT INTO Buildings (BuildingCode, BuildingName, TotalFloors, TotalApartments, Address) VALUES
('A', N'Tòa A - Sunrise', 25, 200, N'Số 123 Đường ABC, Phường XYZ, Quận 1, TP.HCM'),
('B', N'Tòa B - Sunset', 25, 200, N'Số 123 Đường ABC, Phường XYZ, Quận 1, TP.HCM'),
('C', N'Tòa C - Moonlight', 30, 250, N'Số 123 Đường ABC, Phường XYZ, Quận 1, TP.HCM');
GO

-- 6. Thêm căn hộ mẫu
INSERT INTO Apartments (BuildingID, ApartmentCode, ApartmentNumber, Floor, Area, Bedrooms, OwnerName, Phone) VALUES
(1, 'A0101', '0101', 1, 70.5, 2, N'Nguyễn Văn An', '0912345678'),
(1, 'A0102', '0102', 1, 80.0, 3, N'Trần Thị Bình', '0912345679'),
(1, 'A0201', '0201', 2, 70.5, 2, N'Lê Văn Cường', '0912345680'),
(1, 'A0202', '0202', 2, 100.0, 3, N'Phạm Thị Dung', '0912345681'),
(2, 'B0101', '0101', 1, 75.0, 2, N'Hoàng Văn Em', '0912345682'),
(2, 'B0102', '0102', 1, 85.0, 3, N'Vũ Thị Phương', '0912345683'),
(3, 'C0101', '0101', 1, 90.0, 3, N'Đặng Văn Giang', '0912345684'),
(3, 'C0102', '0102', 1, 120.0, 4, N'Bùi Thị Hoa', '0912345685');
GO

-- 7. Thêm cư dân
INSERT INTO Residents (ApartmentID, FullName, Gender, DateOfBirth, IDCardNumber, Phone, IsOwner, RelationshipWithOwner) VALUES
(1, N'Nguyễn Văn An', N'Nam', '1980-05-15', '012345678901', '0912345678', 1, NULL),
(1, N'Nguyễn Thị An Thư', N'Nữ', '1985-08-20', '012345678902', '0912345688', 0, N'Vợ'),
(2, N'Trần Thị Bình', N'Nữ', '1975-03-10', '012345678903', '0912345679', 1, NULL),
(3, N'Lê Văn Cường', N'Nam', '1990-12-25', '012345678904', '0912345680', 1, NULL),
(4, N'Phạm Thị Dung', N'Nữ', '1988-07-08', '012345678905', '0912345681', 1, NULL),
(5, N'Hoàng Văn Em', N'Nam', '1982-01-30', '012345678906', '0912345682', 1, NULL);
GO

-- 8. Thêm khu vực đậu xe
INSERT INTO ParkingZones (ZoneCode, ZoneName, FloorLevel, TotalSlots, Description) VALUES
('B1-A', N'Tầng hầm B1 - Khu A', -1, 50, N'Khu vực A tầng hầm B1'),
('B1-B', N'Tầng hầm B1 - Khu B', -1, 50, N'Khu vực B tầng hầm B1'),
('B2-A', N'Tầng hầm B2 - Khu A', -2, 60, N'Khu vực A tầng hầm B2'),
('B2-B', N'Tầng hầm B2 - Khu B', -2, 60, N'Khu vực B tầng hầm B2'),
('B3', N'Tầng hầm B3', -3, 80, N'Tầng hầm B3 dành cho xe lớn');
GO

-- 9. Thêm chỗ đậu xe mẫu
DECLARE @i INT = 1;
DECLARE @zoneID INT = 1;

-- Zone B1-A: 50 slots
WHILE @i <= 50
BEGIN
    INSERT INTO ParkingSlots (ZoneID, SlotCode, SlotNumber, SlotType, RowPosition, ColumnPosition, Width, Length)
    VALUES (@zoneID, 'B1A' + RIGHT('00' + CAST(@i AS VARCHAR), 3), 'A' + RIGHT('00' + CAST(@i AS VARCHAR), 3), 
            N'Cố định', (@i - 1) / 10 + 1, (@i - 1) % 10 + 1, 2.5, 5.0);
    SET @i = @i + 1;
END

-- Zone B1-B: 50 slots
SET @i = 1;
SET @zoneID = 2;
WHILE @i <= 50
BEGIN
    INSERT INTO ParkingSlots (ZoneID, SlotCode, SlotNumber, SlotType, RowPosition, ColumnPosition, Width, Length)
    VALUES (@zoneID, 'B1B' + RIGHT('00' + CAST(@i AS VARCHAR), 3), 'B' + RIGHT('00' + CAST(@i AS VARCHAR), 3), 
            CASE WHEN @i <= 30 THEN N'Cố định' ELSE N'Tạm thời' END, 
            (@i - 1) / 10 + 1, (@i - 1) % 10 + 1, 2.5, 5.0);
    SET @i = @i + 1;
END
GO

-- 10. Thêm bảng giá phí
INSERT INTO ParkingFees (VehicleTypeID, FeeName, FeeType, Amount, Description, EffectiveFrom) VALUES
(1, N'Phí gửi xe ô tô 4-5 chỗ (tháng)', N'Tháng', 1500000, N'Phí gửi xe ô tô 4-5 chỗ theo tháng', '2024-01-01'),
(1, N'Phí gửi xe ô tô 4-5 chỗ (ngày)', N'Ngày', 100000, N'Phí gửi xe ô tô 4-5 chỗ theo ngày', '2024-01-01'),
(1, N'Phí gửi xe ô tô 4-5 chỗ (giờ)', N'Giờ', 20000, N'Phí gửi xe ô tô 4-5 chỗ theo giờ', '2024-01-01'),
(2, N'Phí gửi xe ô tô 7 chỗ (tháng)', N'Tháng', 1800000, N'Phí gửi xe ô tô 7 chỗ theo tháng', '2024-01-01'),
(2, N'Phí gửi xe ô tô 7 chỗ (ngày)', N'Ngày', 120000, N'Phí gửi xe ô tô 7 chỗ theo ngày', '2024-01-01'),
(2, N'Phí gửi xe ô tô 7 chỗ (giờ)', N'Giờ', 25000, N'Phí gửi xe ô tô 7 chỗ theo giờ', '2024-01-01'),
(3, N'Phí gửi xe SUV (tháng)', N'Tháng', 2000000, N'Phí gửi xe SUV theo tháng', '2024-01-01'),
(3, N'Phí gửi xe SUV (ngày)', N'Ngày', 150000, N'Phí gửi xe SUV theo ngày', '2024-01-01'),
(4, N'Phí gửi xe bán tải (tháng)', N'Tháng', 2200000, N'Phí gửi xe bán tải theo tháng', '2024-01-01'),
(5, N'Phí gửi xe VAN (tháng)', N'Tháng', 2500000, N'Phí gửi xe VAN theo tháng', '2024-01-01');
GO

-- 11. Thêm xe mẫu
INSERT INTO Vehicles (ResidentID, VehicleTypeID, SlotID, LicensePlate, Brand, Model, Color, YearOfManufacture, CardNumber, RegistrationDate, ExpiryDate, Status) VALUES
(1, 1, 1, '51A-12345', N'Toyota', N'Camry', N'Đen', 2022, 'CARD001', '2024-01-01', '2024-12-31', N'Hoạt động'),
(2, 2, 2, '51A-12346', N'Toyota', N'Fortuner', N'Trắng', 2021, 'CARD002', '2024-01-01', '2024-12-31', N'Hoạt động'),
(3, 1, 3, '51A-12347', N'Honda', N'City', N'Đỏ', 2023, 'CARD003', '2024-01-01', '2024-12-31', N'Hoạt động'),
(4, 3, 4, '51A-12348', N'Mazda', N'CX-5', N'Xanh', 2022, 'CARD004', '2024-01-01', '2024-12-31', N'Hoạt động'),
(5, 1, 5, '51A-12349', N'Hyundai', N'Accent', N'Bạc', 2020, 'CARD005', '2024-01-01', '2024-12-31', N'Hoạt động'),
(6, 4, 6, '51A-12350', N'Ford', N'Ranger', N'Xám', 2021, 'CARD006', '2024-01-01', '2024-12-31', N'Hoạt động');
GO

-- Cập nhật trạng thái chỗ đậu đã đăng ký
UPDATE ParkingSlots SET SlotStatus = N'Đã đăng ký' WHERE SlotID IN (1, 2, 3, 4, 5, 6);
GO

-- 12. Thêm lịch sử ra/vào mẫu
INSERT INTO ParkingLogs (VehicleID, SlotID, CheckInTime, CheckOutTime, CheckInBy, ParkingType, LogStatus) VALUES
(1, 1, '2024-12-14 07:30:00', '2024-12-14 17:30:00', 3, N'Thường xuyên', N'Đã ra'),
(2, 2, '2024-12-14 08:00:00', '2024-12-14 18:00:00', 3, N'Thường xuyên', N'Đã ra'),
(3, 3, '2024-12-14 06:45:00', '2024-12-14 16:45:00', 3, N'Thường xuyên', N'Đã ra'),
(1, 1, '2024-12-14 18:00:00', NULL, 3, N'Thường xuyên', N'Đang đậu'),
(4, 4, '2024-12-14 07:00:00', NULL, 3, N'Thường xuyên', N'Đang đậu');
GO

-- 13. Thêm cấu hình hệ thống
INSERT INTO SystemConfigs (ConfigKey, ConfigValue, ConfigType, Description) VALUES
('COMPANY_NAME', N'Chung cư Sunrise City', 'String', N'Tên chung cư'),
('COMPANY_ADDRESS', N'Số 123 Đường ABC, Phường XYZ, Quận 1, TP.HCM', 'String', N'Địa chỉ chung cư'),
('COMPANY_PHONE', '028-1234-5678', 'String', N'Số điện thoại liên hệ'),
('COMPANY_EMAIL', 'info@sunrisecity.com', 'String', N'Email liên hệ'),
('FREE_PARKING_HOURS', '0', 'Number', N'Số giờ đậu xe miễn phí'),
('MAX_FAILED_LOGIN', '5', 'Number', N'Số lần đăng nhập sai tối đa'),
('SESSION_TIMEOUT', '30', 'Number', N'Thời gian timeout phiên (phút)'),
('AUTO_LOCK_ACCOUNT', 'true', 'Boolean', N'Tự động khóa tài khoản sau khi sai quá giới hạn');
GO

-- =============================================
-- TẠO STORED PROCEDURES
-- =============================================

-- SP: Đăng nhập
CREATE PROCEDURE sp_Login
    @Username VARCHAR(50),
    @Password VARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @UserID INT, @Status BIT, @FailedCount INT;
    
    SELECT @UserID = UserID, @Status = Status, @FailedCount = FailedLoginCount
    FROM Users WHERE Username = @Username;
    
    IF @UserID IS NULL
    BEGIN
        SELECT -1 AS Result, N'Tài khoản không tồn tại' AS Message;
        RETURN;
    END
    
    IF @Status = 0
    BEGIN
        SELECT -2 AS Result, N'Tài khoản đã bị khóa' AS Message;
        RETURN;
    END
    
    IF EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID AND PasswordHash = @Password)
    BEGIN
        UPDATE Users SET FailedLoginCount = 0, LastLoginDate = GETDATE() WHERE UserID = @UserID;
        
        SELECT u.UserID, u.Username, u.FullName, u.Email, u.Phone, u.Avatar,
               r.RoleID, r.RoleName
        FROM Users u
        INNER JOIN UserRoles ur ON u.UserID = ur.UserID
        INNER JOIN Roles r ON ur.RoleID = r.RoleID
        WHERE u.UserID = @UserID;
    END
    ELSE
    BEGIN
        UPDATE Users SET FailedLoginCount = FailedLoginCount + 1 WHERE UserID = @UserID;
        
        IF @FailedCount + 1 >= 5
        BEGIN
            UPDATE Users SET Status = 0 WHERE UserID = @UserID;
            SELECT -3 AS Result, N'Sai mật khẩu quá 5 lần, tài khoản đã bị khóa' AS Message;
        END
        ELSE
        BEGIN
            SELECT -4 AS Result, N'Sai mật khẩu. Còn ' + CAST(5 - @FailedCount - 1 AS VARCHAR) + N' lần thử' AS Message;
        END
    END
END
GO

-- SP: Check-in xe
CREATE PROCEDURE sp_CheckIn
    @VehicleID INT,
    @SlotID INT = NULL,
    @CheckInBy INT,
    @CheckInImage NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Kiểm tra xe có đang đậu không
    IF EXISTS (SELECT 1 FROM ParkingLogs WHERE VehicleID = @VehicleID AND LogStatus = N'Đang đậu')
    BEGIN
        SELECT -1 AS Result, N'Xe này hiện đang trong bãi' AS Message;
        RETURN;
    END
    
    -- Nếu không có SlotID, lấy slot đã đăng ký của xe
    IF @SlotID IS NULL
    BEGIN
        SELECT @SlotID = SlotID FROM Vehicles WHERE VehicleID = @VehicleID;
    END
    
    -- Thêm log check-in
    INSERT INTO ParkingLogs (VehicleID, SlotID, CheckInTime, CheckInBy, CheckInImage, LogStatus)
    VALUES (@VehicleID, @SlotID, GETDATE(), @CheckInBy, @CheckInImage, N'Đang đậu');
    
    -- Cập nhật trạng thái slot
    IF @SlotID IS NOT NULL
    BEGIN
        UPDATE ParkingSlots SET SlotStatus = N'Có xe' WHERE SlotID = @SlotID;
    END
    
    SELECT 1 AS Result, N'Check-in thành công' AS Message, SCOPE_IDENTITY() AS LogID;
END
GO

-- SP: Check-out xe
CREATE PROCEDURE sp_CheckOut
    @LogID INT,
    @CheckOutBy INT,
    @CheckOutImage NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @SlotID INT, @CheckInTime DATETIME, @VehicleID INT;
    DECLARE @Hours INT, @Fee DECIMAL(18,2) = 0;
    
    SELECT @SlotID = SlotID, @CheckInTime = CheckInTime, @VehicleID = VehicleID
    FROM ParkingLogs WHERE LogID = @LogID AND LogStatus = N'Đang đậu';
    
    IF @VehicleID IS NULL
    BEGIN
        SELECT -1 AS Result, N'Không tìm thấy thông tin xe đang đậu' AS Message;
        RETURN;
    END
    
    -- Tính phí (nếu là xe vãng lai)
    SET @Hours = DATEDIFF(HOUR, @CheckInTime, GETDATE());
    IF @Hours < 1 SET @Hours = 1;
    
    -- Cập nhật log
    UPDATE ParkingLogs 
    SET CheckOutTime = GETDATE(), 
        CheckOutBy = @CheckOutBy, 
        CheckOutImage = @CheckOutImage,
        Fee = @Fee,
        LogStatus = N'Đã ra'
    WHERE LogID = @LogID;
    
    -- Cập nhật trạng thái slot
    IF @SlotID IS NOT NULL
    BEGIN
        DECLARE @RegisteredVehicle INT;
        SELECT @RegisteredVehicle = VehicleID FROM Vehicles WHERE SlotID = @SlotID;
        
        IF @RegisteredVehicle IS NOT NULL
            UPDATE ParkingSlots SET SlotStatus = N'Đã đăng ký' WHERE SlotID = @SlotID;
        ELSE
            UPDATE ParkingSlots SET SlotStatus = N'Trống' WHERE SlotID = @SlotID;
    END
    
    SELECT 1 AS Result, N'Check-out thành công' AS Message, @Fee AS Fee;
END
GO

-- SP: Thống kê Dashboard
CREATE PROCEDURE sp_GetDashboardStats
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Tổng số xe đã đăng ký
    SELECT COUNT(*) AS TotalVehicles FROM Vehicles WHERE Status = N'Hoạt động';
    
    -- Tổng số chỗ đậu
    SELECT COUNT(*) AS TotalSlots FROM ParkingSlots;
    
    -- Số xe đang trong bãi
    SELECT COUNT(*) AS VehiclesInParking FROM ParkingLogs WHERE LogStatus = N'Đang đậu';
    
    -- Số chỗ trống
    SELECT COUNT(*) AS AvailableSlots FROM ParkingSlots WHERE SlotStatus = N'Trống';
    
    -- Doanh thu hôm nay
    SELECT ISNULL(SUM(FinalAmount), 0) AS TodayRevenue 
    FROM Invoices 
    WHERE InvoiceStatus = N'Đã thanh toán' AND CAST(PaidDate AS DATE) = CAST(GETDATE() AS DATE);
    
    -- Lượt ra/vào hôm nay
    SELECT COUNT(*) AS TodayCheckIns 
    FROM ParkingLogs 
    WHERE CAST(CheckInTime AS DATE) = CAST(GETDATE() AS DATE);
    
    SELECT COUNT(*) AS TodayCheckOuts 
    FROM ParkingLogs 
    WHERE CheckOutTime IS NOT NULL AND CAST(CheckOutTime AS DATE) = CAST(GETDATE() AS DATE);
    
    -- Top 10 hoạt động gần nhất
    SELECT TOP 10 
        pl.LogID, v.LicensePlate, vt.TypeName, v.Brand, v.Color,
        pl.CheckInTime, pl.CheckOutTime, pl.LogStatus,
        a.ApartmentCode, b.BuildingName
    FROM ParkingLogs pl
    INNER JOIN Vehicles v ON pl.VehicleID = v.VehicleID
    INNER JOIN VehicleTypes vt ON v.VehicleTypeID = vt.VehicleTypeID
    INNER JOIN Residents r ON v.ResidentID = r.ResidentID
    INNER JOIN Apartments a ON r.ApartmentID = a.ApartmentID
    INNER JOIN Buildings b ON a.BuildingID = b.BuildingID
    ORDER BY pl.CheckInTime DESC;
END
GO

-- SP: Tìm kiếm xe theo biển số
CREATE PROCEDURE sp_SearchVehicle
    @SearchText VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT v.*, vt.TypeName, r.FullName AS OwnerName, r.Phone,
           a.ApartmentCode, a.ApartmentNumber, b.BuildingName,
           ps.SlotCode, ps.SlotNumber, pz.ZoneName
    FROM Vehicles v
    INNER JOIN VehicleTypes vt ON v.VehicleTypeID = vt.VehicleTypeID
    INNER JOIN Residents r ON v.ResidentID = r.ResidentID
    INNER JOIN Apartments a ON r.ApartmentID = a.ApartmentID
    INNER JOIN Buildings b ON a.BuildingID = b.BuildingID
    LEFT JOIN ParkingSlots ps ON v.SlotID = ps.SlotID
    LEFT JOIN ParkingZones pz ON ps.ZoneID = pz.ZoneID
    WHERE v.LicensePlate LIKE '%' + @SearchText + '%'
       OR v.CardNumber LIKE '%' + @SearchText + '%'
       OR r.FullName LIKE '%' + @SearchText + '%';
END
GO

PRINT N'=== DATABASE CREATED SUCCESSFULLY ===';
GO
