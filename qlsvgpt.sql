USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QLSV_OU')
BEGIN
    ALTER DATABASE QLSV_OU SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSV_OU;
END
GO

CREATE DATABASE QLSV_OU
GO

USE QLSV_OU
GO

SET DATEFORMAT DMY
GO

/* =========================================================
   1. TẠO BẢNG
========================================================= */

-- 1. KHOA
CREATE TABLE Khoa (
    MaKhoa CHAR(4) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
)
GO

-- 2. NIÊN KHÓA
CREATE TABLE NienKhoa (
    MaNienKhoa VARCHAR(10) PRIMARY KEY,
    TenNienKhoa NVARCHAR(50) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    CONSTRAINT CK_NienKhoa_Ngay CHECK (NgayKetThuc > NgayBatDau)
)
GO

-- 3. NGÀNH
CREATE TABLE Nganh (
    MaNganh VARCHAR(10) PRIMARY KEY,
    TenNganh NVARCHAR(100) NOT NULL,
    MaKhoa CHAR(4) NOT NULL,
    CONSTRAINT FK_Nganh_Khoa FOREIGN KEY (MaKhoa)
        REFERENCES Khoa(MaKhoa)
)
GO

-- 4. LỚP
CREATE TABLE Lop (
    MaLop VARCHAR(8) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaNienKhoa VARCHAR(10) NOT NULL,
    MaNganh VARCHAR(10) NOT NULL,
    CONSTRAINT FK_Lop_NienKhoa FOREIGN KEY (MaNienKhoa)
        REFERENCES NienKhoa(MaNienKhoa),
    CONSTRAINT FK_Lop_Nganh FOREIGN KEY (MaNganh)
        REFERENCES Nganh(MaNganh)
)
GO

-- 5. SINH VIÊN
CREATE TABLE SinhVien (
    MaSV CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
   
    MaLop VARCHAR(8) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(255) NOT NULL,
    TrangThaiHocTap NVARCHAR(50) NOT NULL DEFAULT N'Đang học',

    CONSTRAINT CK_SinhVien_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT CK_SinhVien_SDT CHECK (LEN(SDT) BETWEEN 10 AND 11),
    CONSTRAINT FK_SinhVien_Lop FOREIGN KEY (MaLop)
        REFERENCES Lop(MaLop)
)
GO

-- 6. GIẢNG VIÊN
CREATE TABLE GiangVien (
    MaGV VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    HocVi NVARCHAR(30),
    Email VARCHAR(100) UNIQUE,
    SDT VARCHAR(15),
    MaKhoa CHAR(4) NOT NULL,
    CONSTRAINT FK_GiangVien_Khoa FOREIGN KEY (MaKhoa)
        REFERENCES Khoa(MaKhoa)
)
GO

-- 7. MÔN HỌC
CREATE TABLE MonHoc (
    MaMH VARCHAR(8) PRIMARY KEY,
    TenMH NVARCHAR(100) NOT NULL,
    SoTinChi DECIMAL(3,1) NOT NULL,

    CONSTRAINT CK_MonHoc_SoTinChi 
        CHECK (SoTinChi IN (1.5, 2, 3, 4))
)
GO
-- 8. MÔN HỌC TIÊN QUYẾT

CREATE TABLE MonHocTienQuyet (
    MaMH VARCHAR(8) NOT NULL,
    MaMHTQ VARCHAR(8) NOT NULL,
    PRIMARY KEY (MaMH, MaMHTQ),

    CONSTRAINT FK_MHTQ_MonHoc  FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH),
    CONSTRAINT FK_MHTQ_TienQuyet FOREIGN KEY (MaMHTQ) REFERENCES MonHoc(MaMH),
    CONSTRAINT CK_MHTQ_KhacNhau CHECK (MaMH <> MaMHTQ)
)
GO

-- 9. HỌC KỲ
CREATE TABLE HocKy (
    MaHK VARCHAR(10) PRIMARY KEY,
    TenHocKy NVARCHAR(50) NOT NULL,
    NamHoc VARCHAR(20) NOT NULL
)
GO

-- 10. HỌC PHẦN
CREATE TABLE HocPhan (
    MaHP VARCHAR(50) PRIMARY KEY,
    MaMH VARCHAR(8) NOT NULL,
    MaHK VARCHAR(10) NOT NULL,
    MaGV VARCHAR(10) NOT NULL,
    MaLop VARCHAR(8) NOT NULL,
    SiSoToiDa INT NOT NULL,

    CONSTRAINT FK_HocPhan_MonHoc
        FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH),

    CONSTRAINT FK_HocPhan_HocKy
        FOREIGN KEY (MaHK) REFERENCES HocKy(MaHK),

    CONSTRAINT FK_HocPhan_GiangVien
        FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV),

    CONSTRAINT FK_HocPhan_Lop
        FOREIGN KEY (MaLop) REFERENCES Lop(MaLop),

    CONSTRAINT CK_HocPhan_SiSoToiDa
        CHECK (SiSoToiDa > 0),

    CONSTRAINT UQ_HocPhan_MH_HK_Lop
        UNIQUE (MaMH, MaHK, MaLop)
)
GO
---- tkb
CREATE TABLE ThoiKhoaBieu (
    MaTKB INT IDENTITY(1,1) PRIMARY KEY,
    MaHP VARCHAR(50) NOT NULL,
    Thu INT NOT NULL,
    TietBatDau INT NOT NULL,
    Phong NVARCHAR(20) NOT NULL,

    CONSTRAINT FK_TKB_HocPhan
        FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP),

    CONSTRAINT CK_TKB_Thu
        CHECK (Thu BETWEEN 2 AND 8),

    CONSTRAINT CK_TKB_TietBatDau
        CHECK (TietBatDau IN (1, 7, 13)),

    CONSTRAINT UQ_TKB_HP_Thu_Tiet
        UNIQUE (MaHP, Thu, TietBatDau)
)
GO


-- 12. ĐĂNG KÝ HỌC PHẦN
CREATE TABLE DangKyHocPhan (
    MaDK INT IDENTITY(1,1) PRIMARY KEY,
    MaSV CHAR(10) NOT NULL,
    MaHP VARCHAR(50) NOT NULL,
    NgayDangKy DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    NgayHuy DATETIME2(0) NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đã đăng ký',

    CONSTRAINT FK_DKHP_SinhVien
        FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),

    CONSTRAINT FK_DKHP_HocPhan
        FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP),

    CONSTRAINT CK_DKHP_TrangThai
        CHECK (TrangThai IN (N'Đã đăng ký', N'Đã hủy'))
)
GO

CREATE UNIQUE INDEX UQ_DKHP_DangKy_HieuLuc
ON DangKyHocPhan(MaSV, MaHP)
WHERE TrangThai = N'Đã đăng ký'
GO

---- 13. BẢNG ĐIỂM
CREATE TABLE BangDiem (
    MaSV CHAR(10) NOT NULL,
    MaHP VARCHAR(50) NOT NULL,

    DiemGK DECIMAL(4,2) NULL,
    DiemCK DECIMAL(4,2) NULL,

    PRIMARY KEY (MaSV, MaHP),

    CONSTRAINT FK_BangDiem_SinhVien 
        FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),

    CONSTRAINT FK_BangDiem_HocPhan 
        FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP),

    CONSTRAINT CK_BangDiem_DiemGK 
        CHECK (DiemGK IS NULL OR DiemGK BETWEEN 0 AND 10),

    CONSTRAINT CK_BangDiem_DiemCK 
        CHECK (DiemCK IS NULL OR DiemCK BETWEEN 0 AND 10)
)
GO

---- 14. LỊCH THI
--CREATE TABLE LichThi (
--    MaLichThi VARCHAR(15) PRIMARY KEY,
--    MaHP VARCHAR(15) NOT NULL,
--    NgayThi DATE NOT NULL,
--    GioThi TIME NOT NULL,
--    PhongThi NVARCHAR(50) NOT NULL,
--    CONSTRAINT FK_LichThi_HocPhan FOREIGN KEY (MaHP)
--        REFERENCES HocPhan(MaHP)
--)
--GO

---- 15. HỌC PHÍ
--CREATE TABLE HocPhi (
--    MaHocPhi VARCHAR(15) PRIMARY KEY,
--    MaSV CHAR(10) NOT NULL,
--    MaHK VARCHAR(10) NOT NULL,
--    TongTien DECIMAL(12,2) NOT NULL,
--    DaDong DECIMAL(12,2) NOT NULL DEFAULT 0,
--    ConNo AS (TongTien - DaDong),
--    HanDong DATE,
--    TrangThai NVARCHAR(50) NOT NULL,
--    CONSTRAINT FK_HocPhi_SinhVien FOREIGN KEY (MaSV)
--        REFERENCES SinhVien(MaSV),
--    CONSTRAINT FK_HocPhi_HocKy FOREIGN KEY (MaHK)
--        REFERENCES HocKy(MaHK),
--    CONSTRAINT CK_HocPhi_TongTien CHECK (TongTien >= 0),
--    CONSTRAINT CK_HocPhi_DaDong CHECK (DaDong >= 0)
--)
--GO

---- 16. KHIẾU NẠI
--CREATE TABLE KhieuNai (
--    MaKN VARCHAR(15) PRIMARY KEY,
--    MaSV CHAR(10) NOT NULL,
--    NoiDung NVARCHAR(255) NOT NULL,
--    NgayGui DATE NOT NULL DEFAULT GETDATE(),
--    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Tiếp nhận',
--    KetQuaXuLy NVARCHAR(255),
--    CONSTRAINT FK_KhieuNai_SinhVien FOREIGN KEY (MaSV)
--        REFERENCES SinhVien(MaSV)
--)
--GO

-- 17. TÀI KHOẢN
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,
    MaSV CHAR(10) NULL,
    MaGV VARCHAR(10) NULL,
    CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN (N'SinhVien', N'GiangVien', N'Admin')),
    CONSTRAINT FK_TaiKhoan_SinhVien FOREIGN KEY (MaSV)
        REFERENCES SinhVien(MaSV),
    CONSTRAINT FK_TaiKhoan_GiangVien FOREIGN KEY (MaGV)
        REFERENCES GiangVien(MaGV)
)
GO



/* =========================================================
   2. DỮ LIỆU MẪU
========================================================= */

-- KHOA
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
('THTH', N'Công nghệ thông tin'),
('QTQT', N'Quản trị kinh doanh'),
('KTKT', N'Kế toán - Kiểm toán'),
('NNNN',   N'Ngoại ngữ')
GO

-- NIÊN KHÓA
INSERT INTO NienKhoa (MaNienKhoa, TenNienKhoa, NgayBatDau, NgayKetThuc) VALUES
('K21', N'Khóa 2021-2025', '01/09/2021', '31/08/2025'),
('K22', N'Khóa 2022-2026', '01/09/2022', '31/08/2026'),
('K23', N'Khóa 2023-2027', '01/09/2023', '31/08/2027')
GO

-- NGÀNH
INSERT INTO Nganh (MaNganh, TenNganh, MaKhoa) VALUES
('IT', N'Công nghệ thông tin', 'THTH'),
('IM', N'Hệ thống thông tin', 'THTH'),
('BA', N'Quản trị kinh doanh', 'QTQT'),
('AC', N'Kế toán', 'KTKT'),
('EL', N'Ngôn ngữ Anh', 'NNNN')
GO

-- LỚP
INSERT INTO Lop (MaLop, TenLop, MaNienKhoa, MaNganh) VALUES
('DH23IT01', N'Công nghệ thông tin ĐH 2023 - 01', 'K23', 'IT'),
('DH21IT02', N'Công nghệ thông tin ĐH 2021 - 02', 'K21', 'IT'),
('DH23IM01', N'Hệ thống thông tin ĐH 2023 - 01', 'K23', 'IM'),
('DH21BA01', N'Quản trị kinh doanh ĐH 2021 - 01', 'K21', 'BA'),
('DH22AC01', N'Kế toán ĐH 2022 - 01', 'K22', 'AC'),
('DH23EL01', N'Ngôn ngữ Anh ĐH 2021 - 01', 'K23', 'EL')
GO

-- SINH VIÊN
INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh,  MaLop, SDT, Email, DiaChi, TrangThaiHocTap) VALUES
('2351010001', N'Nguyễn Minh Anh', '12/05/2003', N'Nữ', 'DH23IT01', '0909000001', '2351010001anh@ou.edu.vn', N'TP.HCM', N'Đang học'),
('2251010002', N'Trần Quốc Bảo', '20/08/2003', N'Nam', 'DH21IT02', '0909000002', '2251010002bao@ou.edu.vn', N'Cần Thơ', N'Đang học'),
('2354000033', N'Lê Hoài Nam', '03/11/2005', N'Nam', 'DH23IM01', '0909000003', '2351010003nam@ou.edu.vn', N'Hải Phòng', N'Đang học'),
('2254000012', N'Phạm Gia Hân', '15/01/2004', N'Nữ', 'DH23IM01', '0909000004', '2251020001han@ou.edu.vn', N'TP.HCM', N'Đang học'),
('2252010001', N'Võ Đức Huy', '09/01/2004', N'Nam', 'DH21BA01', '0909000005', '2252010001huy@ou.edu.vn', N'An Giang', N'Đang học'),
('2253010001', N'Ngô Thu Trang', '25/06/2004', N'Nữ',  'DH22AC01', '0909000006', '2253010001trang@ou.edu.vn', N'TP.HCM', N'Đang học'),
('2354010001', N'Đặng Khánh Linh', '17/02/2003', N'Nữ', 'DH23EL01', '0909000007', '2354010001linh@ou.edu.vn', N'Tây Ninh', N'Đang học')
GO

-- GIẢNG VIÊN
INSERT INTO GiangVien (MaGV, HoTen, HocVi, Email, SDT, MaKhoa) VALUES
('GV001', N'TS. Nguyễn Văn Phúc', N'Tiến sĩ', 'phucnv@ou.edu.vn', '0911000001', 'THTH'),
('GV002', N'ThS. Trần Thị Hồng', N'Thạc sĩ', 'hongtt@ou.edu.vn', '0911000002', 'THTH'),
('GV003', N'TS. Lê Quốc Dũng', N'Tiến sĩ', 'dunglq@ou.edu.vn', '0911000003', 'QTQT'),
('GV004', N'ThS. Phạm Thu Hà', N'Thạc sĩ', 'hapt@ou.edu.vn', '0911000004', 'KTKT'),
('GV005', N'ThS. Nguyễn Mỹ Lan', N'Thạc sĩ', 'lannm@ou.edu.vn', '0911000005', 'NNNN')
GO

-- MÔN HỌC
INSERT INTO MonHoc (MaMH, TenMH, SoTinChi) VALUES
('ITEC2502', N'Cơ sở dữ liệu', 4),
('ITEC2401', N'Lập trình giao diện', 3),
('ITEC3401', N'Phân tích thiết kế hệ thống', 3),
('ITEC3406', N'Lập trình cơ sở dữ liệu', 3),
('MISY3301', N'Hệ thống thông tin quản lý', 3),
('BADM1301', N'Quản trị học', 3),
('ACCO2301', N'Nguyên lý kế toán', 3)
GO


-- MÔN TIÊN QUYẾT
INSERT INTO MonHocTienQuyet (MaMH, MaMHTQ) VALUES
('ITEC3401', 'ITEC2502'),
('ITEC3406', 'ITEC2401'),
('ITEC3406', 'ITEC2502')
GO

-- HỌC KỲ
INSERT INTO HocKy (MaHK, TenHocKy, NamHoc) VALUES
('241', N'Học kỳ 1', '2024-2025'),
('242', N'Học kỳ 2', '2024-2025'),
('243', N'Học kỳ 3', '2024-2025'),
('251', N'Học kỳ 1', '2025-2026'),
('252', N'Học kỳ 2', '2025-2026'),
('253', N'Học kỳ 3', '2025-2026')
GO

-- HỌC PHẦN
INSERT INTO HocPhan (MaHP, MaMH, MaHK, MaGV, MaLop, SiSoToiDa) VALUES
('DH23IT01-ITEC2502-242', 'ITEC2502', '242', 'GV001', 'DH23IT01', 45),
('DH23IT01-ITEC2401-242', 'ITEC2401', '242', 'GV002', 'DH23IT01', 45),
('DH23IT01-MISY3301-242', 'MISY3301', '242', 'GV003', 'DH23IT01', 50),

('DH21IT02-ITEC2502-242', 'ITEC2502', '242', 'GV001', 'DH21IT02', 45),
('DH21IT02-ITEC2401-242', 'ITEC2401', '242', 'GV002', 'DH21IT02', 45),

('DH23IM01-MISY3301-242', 'MISY3301', '242', 'GV003', 'DH23IM01', 50),

('DH21BA01-BADM1301-242', 'BADM1301', '242', 'GV003', 'DH21BA01', 60),
('DH22AC01-ACCO2301-242', 'ACCO2301', '242', 'GV004', 'DH22AC01', 60);
GO

INSERT INTO ThoiKhoaBieu (MaHP, Thu, TietBatDau, Phong) VALUES
('DH23IT01-ITEC2502-242', 2, 1, N'A101'),
('DH23IT01-ITEC2502-242', 5, 7, N'A203'),

('DH23IT01-ITEC2401-242', 3, 1, N'B201'),
('DH23IT01-MISY3301-242', 4, 7, N'C301'),

('DH21IT02-ITEC2502-242', 2, 1, N'A102'),
('DH21IT02-ITEC2401-242', 3, 7, N'B202'),

('DH23IM01-MISY3301-242', 5, 1, N'C302'),
('DH21BA01-BADM1301-242', 6, 7, N'D101'),
('DH22AC01-ACCO2301-242', 7, 1, N'D202');
GO


INSERT INTO DangKyHocPhan(MaSV,MaHP,NgayDangKy,NgayHuy,TrangThai) VALUES
('2351010001', 'DH23IT01-ITEC2502-242', '2026-05-21 08:00:00', NULL, N'Đã đăng ký'),
('2251010002', 'DH23IT01-ITEC2502-242', '2026-05-21 08:10:00', NULL, N'Đã đăng ký'),
('2351010001', 'DH23IT01-ITEC2502-242', '2026-05-21 08:20:00', '2026-05-21 10:00:00', N'Đã hủy');


INSERT INTO BangDiem (MaSV, MaHP, DiemGK, DiemCK) VALUES
('2351010001', 'DH23IT01-ITEC2502-242', 8.0, 8.5),
('2351010001', 'DH23IT01-ITEC2401-242', 7.0, 8.0),

('2251010002', 'DH21IT02-ITEC2502-242', 6.5, 7.0),
('2251010002', 'DH21IT02-ITEC2401-242', 1.5, 8.0),

('2354000033', 'DH23IM01-MISY3301-242', 7.0, 6.5),
('2254000012', 'DH23IM01-MISY3301-242', 4.0, 5.0),

('2252010001', 'DH21BA01-BADM1301-242', 8.5, 9.0),
('2253010001', 'DH22AC01-ACCO2301-242', 3.5, 4.0)
GO

-- TÀI KHOẢN
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, TrangThai, MaSV, MaGV) VALUES

('2351010001', '123456', N'SinhVien', 1, '2351010001', NULL),
('2251010002', '123456', N'SinhVien', 1, '2251010002', NULL),
('2354000033', '123456', N'SinhVien', 1, '2354000033', NULL),


('gv001', '123456', N'GiangVien', 1, NULL, 'GV001'),
('gv002', '123456', N'GiangVien', 1, NULL, 'GV002'),
('gv003', '123456', N'GiangVien', 1, NULL, 'GV003'),


('admin', 'admin123', N'Admin', 1, NULL, NULL)
GO


-- view môn học
CREATE VIEW vw_MonHoc_ChiTiet
AS
SELECT 
    mh.MaMH,
    mh.TenMH,
    mh.SoTinChi,

    ISNULL(
        STUFF((
            SELECT CHAR(13) + CHAR(10) + tq.TenMH
            FROM MonHocTienQuyet mtq
            JOIN MonHoc tq ON mtq.MaMHTQ = tq.MaMH
            WHERE mtq.MaMH = mh.MaMH
            FOR XML PATH(''), TYPE
        ).value('.', 'NVARCHAR(MAX)'), 1, 2, N''),
        N''
    ) AS MonTienQuyet

FROM MonHoc mh
GO


CREATE VIEW vw_HocPhan_ChiTiet
AS
SELECT
    hp.MaHP,

    hp.MaMH,
    mh.TenMH,

    hp.MaHK,
    hk.TenHocKy,
    hk.NamHoc,

    hp.MaGV,
    gv.HoTen AS TenGV,

    hp.MaLop,
    lop.TenLop,

    hp.SiSoToiDa
FROM HocPhan hp
JOIN MonHoc mh ON hp.MaMH = mh.MaMH
JOIN HocKy hk ON hp.MaHK = hk.MaHK
JOIN GiangVien gv ON hp.MaGV = gv.MaGV
JOIN Lop lop ON hp.MaLop = lop.MaLop
GO

-- view tkb
CREATE VIEW vw_ThoiKhoaBieu_ChiTiet
AS
SELECT
    tkb.MaTKB,
    tkb.MaHP,

    hp.MaMH,
    mh.TenMH,

    hp.MaHK,
    hk.TenHocKy,
    hk.NamHoc,

    hp.MaLop,
    lop.TenLop,

    hp.MaGV,
    gv.HoTen AS TenGV,

    tkb.Thu,
    CASE 
        WHEN tkb.Thu = 8 THEN N'Chủ nhật'
        ELSE N'Thứ ' + CAST(tkb.Thu AS NVARCHAR)
    END AS TenThu,

    tkb.TietBatDau,

    CASE 
        WHEN tkb.TietBatDau = 1 THEN 5
        WHEN tkb.TietBatDau = 7 THEN 5
        WHEN tkb.TietBatDau = 13 THEN 3
    END AS SoTiet,

    CASE 
        WHEN tkb.TietBatDau = 1 THEN N'07:00 - 11:25'
        WHEN tkb.TietBatDau = 7 THEN N'12:45 - 17:10'
        WHEN tkb.TietBatDau = 13 THEN N'17:30 - 20:00'
    END AS GioHoc,

    tkb.Phong
FROM ThoiKhoaBieu tkb
JOIN HocPhan hp ON tkb.MaHP = hp.MaHP
JOIN MonHoc mh ON hp.MaMH = mh.MaMH
JOIN HocKy hk ON hp.MaHK = hk.MaHK
JOIN Lop lop ON hp.MaLop = lop.MaLop
JOIN GiangVien gv ON hp.MaGV = gv.MaGV
GO

-- VIEW CHI TIẾT ĐĂNG KÝ HỌC PHẦN
CREATE VIEW vw_DangKyHocPhan_ChiTiet
AS
SELECT
    dk.MaDK,

    dk.MaSV,
    sv.HoTen AS TenSV,

    dk.MaHP,
    hp.MaMH,
    mh.TenMH,
    mh.SoTinChi,

    hp.MaHK,
    hk.TenHocKy,
    hk.NamHoc,

    hp.MaLop,
    lop.TenLop,

    hp.MaGV,
    gv.HoTen AS TenGV,

    dk.NgayDangKy,
    dk.NgayHuy,
    dk.TrangThai,

    ISNULL(lich.LichHoc, N'Chưa có TKB') AS LichHoc

FROM DangKyHocPhan dk
JOIN SinhVien sv ON dk.MaSV = sv.MaSV
JOIN HocPhan hp ON dk.MaHP = hp.MaHP
JOIN MonHoc mh ON hp.MaMH = mh.MaMH
JOIN HocKy hk ON hp.MaHK = hk.MaHK
JOIN Lop lop ON hp.MaLop = lop.MaLop
JOIN GiangVien gv ON hp.MaGV = gv.MaGV

OUTER APPLY (
    SELECT STUFF((
        SELECT CHAR(13) + CHAR(10)
             + CASE 
                   WHEN tkb.Thu = 8 THEN N'Chủ nhật'
                   ELSE N'Thứ ' + CAST(tkb.Thu AS NVARCHAR)
               END
             + N' - Tiết ' + CAST(tkb.TietBatDau AS NVARCHAR)
             + N' - '
             + CASE 
                   WHEN tkb.TietBatDau = 1 THEN N'07:00 - 11:25'
                   WHEN tkb.TietBatDau = 7 THEN N'12:45 - 17:10'
                   WHEN tkb.TietBatDau = 13 THEN N'17:30 - 20:00'
                   ELSE N''
               END
             + N' - Phòng ' + tkb.Phong
        FROM ThoiKhoaBieu tkb
        WHERE tkb.MaHP = hp.MaHP
        ORDER BY tkb.Thu, tkb.TietBatDau
        FOR XML PATH(''), TYPE
    ).value('.', 'NVARCHAR(MAX)'), 1, 2, N'') AS LichHoc
) lich
GO

--view bảng điểm
CREATE VIEW vw_BangDiem_ChiTiet
AS
SELECT
    dk.MaSV,
    sv.HoTen AS TenSV,

    dk.MaHP,
    mh.MaMH,
    mh.TenMH,
    mh.SoTinChi,

    hk.MaHK,
    hk.TenHocKy,
    hk.NamHoc,

    hp.MaLop,
    lop.TenLop,

    bd.DiemGK,
    bd.DiemCK,

    CAST(
        CASE 
            WHEN bd.DiemGK IS NULL OR bd.DiemCK IS NULL THEN NULL
            ELSE ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2)
        END AS DECIMAL(4,2)
    ) AS DiemTK,

    CASE 
        WHEN bd.DiemGK IS NULL OR bd.DiemCK IS NULL THEN NULL
        WHEN bd.DiemGK < 2 OR bd.DiemCK < 2 THEN N'F'
        WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 8.5 THEN N'A'
        WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 7.0 THEN N'B'
        WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 5.5 THEN N'C'
        WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 4.0 THEN N'D'
        ELSE N'F'
    END AS DiemChu,

    CAST(
        CASE 
            WHEN bd.DiemGK IS NULL OR bd.DiemCK IS NULL THEN NULL
            WHEN bd.DiemGK < 2 OR bd.DiemCK < 2 THEN 0
            WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 8.5 THEN 4.0
            WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 7.0 THEN 3.0
            WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 5.5 THEN 2.0
            WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 4.0 THEN 1.0
            ELSE 0
        END AS DECIMAL(3,1)
    ) AS DiemHe4,

    CASE 
        WHEN bd.DiemGK IS NULL OR bd.DiemCK IS NULL THEN N'Chưa nhập'
        WHEN bd.DiemGK < 2 OR bd.DiemCK < 2 THEN N'Không đạt'
        WHEN ROUND(bd.DiemGK * 0.4 + bd.DiemCK * 0.6, 2) >= 4 THEN N'Đạt'
        ELSE N'Không đạt'
    END AS KetQua

FROM DangKyHocPhan dk
JOIN SinhVien sv ON dk.MaSV = sv.MaSV
JOIN HocPhan hp ON dk.MaHP = hp.MaHP
JOIN MonHoc mh ON hp.MaMH = mh.MaMH
JOIN HocKy hk ON hp.MaHK = hk.MaHK
JOIN Lop lop ON hp.MaLop = lop.MaLop
LEFT JOIN BangDiem bd ON dk.MaSV = bd.MaSV AND dk.MaHP = bd.MaHP
WHERE dk.TrangThai = N'Đã đăng ký';
GO
