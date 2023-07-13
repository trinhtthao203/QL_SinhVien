CREATE TABLE Lop (
  MSLop NVARCHAR(8) PRIMARY KEY,
  TenLop NVARCHAR(40),
  KhoaHoc smallint
);

CREATE TABLE SinhVien (
  MSSV NVARCHAR(8) PRIMARY KEY,
  HoLot NVARCHAR(30),
  Ten NVARCHAR(12),
  Phai NVARCHAR(3),
  NgaySinh datetime,
  MSLop NVARCHAR(8),
  MatKhau NVARCHAR(15),
  QuyenSQ NVARCHAR(10),
  FOREIGN KEY (MSLop) REFERENCES Lop(MSLop)
);

CREATE TABLE MonHoc (
  MSMH NVARCHAR(6) PRIMARY KEY,
  TenMH NVARCHAR(50),
  SoTC smallint
);

CREATE TABLE KetQuaHocTap (
	MSSV NVARCHAR(8) NOT NULL FOREIGN KEY REFERENCES SinhVien(MSSV),
	MSMH NVARCHAR(6) NOT NULL FOREIGN KEY REFERENCES MonHoc(MSMH),
	HocKy NVARCHAR(1),
	NienKhoa NVARCHAR(9),
	Nhom NVARCHAR(3),
	Diem decimal(4,2),
	Constraint PK_KetQuaHocTap Primary Key (MSSV, MSMH, HocKy, NienKhoa)
)

INSERT INTO Lop VALUES
('KH09A1', N'Lập trình .Net K36', 36),
('KH09A2', N'Hóa học K36', 36),
('KH09A3', N'Sinh học K36', 36),
('KH09A4', N'Hóa Dược K36', 36),
('KH09A5', N'Toán thống kê K36', 36),
('KH09A6', N'Tin học Ứng dụng K36', 36);

Select * From Lop