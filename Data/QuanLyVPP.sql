CREATE DATABASE QuanLyVPP
GO

USE  QuanLyVPP
GO

CREATE TABLE ChucVu
(
	MaCV NVARCHAR(2) PRIMARY KEY,
	TenChucVu NVARCHAR(50),
)
GO
CREATE TABLE TrangThaiNV
(
	TrangThaiNV INT NOT NULL PRIMARY KEY,
	TenTrangThai NVARCHAR(12),
)
GO

CREATE TABLE NhanVien
(
	MaNV NVARCHAR(5) NOT NULL PRIMARY KEY,
	TenNV NVARCHAR(50) NOT NULL,
	SoDT CHAR(11) NOT NULL,
	DiaChi NVARCHAR(100),
	MaCV NVARCHAR(2),
	TrangThaiNV INT NOT NULL DEFAULT 1,
	FOREIGN KEY (MaCV) REFERENCES dbo.ChucVu(MaCV),
	FOREIGN KEY (TrangThaiNV) REFERENCES dbo.TrangThaiNV(TrangThaiNV),
)
GO

CREATE TABLE TaiKhoan
(
	TenDangNhap NVARCHAR(50) NOT NULL PRIMARY KEY,
	TenHienThi NVARCHAR(50) NOT NULL,
	PassWord NVARCHAR(100) NOT NULL,
	MaNV NVARCHAR(5),
	FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
)
GO

CREATE TABLE DSHangHoa
(
	MaDSHH INT IDENTITY PRIMARY KEY,
	TenDSHH NVARCHAR(50) NOT NULL,
)
GO

CREATE TABLE KhoHH
(
	MaHK NVARCHAR(5) PRIMARY KEY,
	SoLuongHH INT,	
)
GO

CREATE TABLE HangHoa
(
	MaHH NVARCHAR(5) PRIMARY KEY,
	TenHH NVARCHAR(100) NOT NULL,
	DVTinh NVARCHAR(10),
	GiaMua FLOAT NOT NULL,
	DonGia FLOAT NOT NULL,
	MaDSHH INT,
	MaHK NVARCHAR(5),
	FOREIGN KEY (MaDSHH) REFERENCES dbo.DSHangHoa(MaDSHH),
	FOREIGN KEY (MaHK) REFERENCES dbo.KhoHH(MaHK),
)
GO

CREATE TABLE HDKhachHang -- = table trong quan cf
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(10),
	TrangThai NVARCHAR(20) DEFAULT N'Trống',
)
GO

CREATE TABLE HoaDon
(
	MaHD INT IDENTITY PRIMARY KEY,
	NgayNHD DATE NOT NULL DEFAULT GETDATE(),
	NgayXHD DATE,
	TrangThai bit,
	id INT NOT NULL,	
	MaNV NVARCHAR(5),
	GiamGia INT DEFAULT 0,
	TongGia FLOAT,
	FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
	FOREIGN KEY (id) REFERENCES dbo.HDKhachHang(id),
)
GO

CREATE TABLE ChiTietHD
(
	MaHH NVARCHAR(5),
	MaHD INT,
	SoLuong INT DEFAULT 0,
	FOREIGN KEY (MaHH) REFERENCES dbo.HangHoa(MaHH),
	FOREIGN KEY (MaHD) REFERENCES dbo.HoaDon(MaHD),
)
GO

--THÊM THÔNG TIN BẢNG CHUCVU
INSERT INTO ChucVu VALUES (N'QL', N'Quản Lý')
INSERT INTO ChucVu VALUES (N'NV', N'Nhân Viên')

select * from ChucVu
--delete from ChucVu where MaCV = 'QL'

--THÊM THÔNG TIN BẢNG TrangThaiNV
INSERT INTO TrangThaiNV VALUES (1, N'Còn Làm')
INSERT INTO TrangThaiNV VALUES (0, N'Đã Nghỉ Việc')

--THÊM THÔNG TIN BẢNG NHANVIEN
INSERT INTO NhanVien VALUES (N'NV001', N'Nguyễn Văn A', '0123456789', N'Bình Khánh, Long Xuyên',N'QL', 1)
INSERT INTO NhanVien VALUES (N'NV002', N'Nguyễn Thị B', '0864521957', N'Mỹ Bình, Long Xuyên',N'NV', 1)
INSERT INTO NhanVien VALUES (N'NV003', N'Lê Văn C', '0929578536', N'Bình Đức, Long Xuyên',N'NV', 1)
INSERT INTO NhanVien VALUES (N'NV004', N'Điện Máy Xanh', '0929578584', N'Mỹ Bình, Long Xuyên',N'NV', 0)

select * from NhanVien

--THÊM THÔNG TIN BẢNG TAIKHOAN

INSERT INTO TaiKhoan VALUES (N'QuanLy01', N'Quản lý', N'1', N'NV001')
INSERT INTO TaiKhoan VALUES (N'NVABC', N'Nhân viên 1', N'123', N'NV002')
INSERT INTO TaiKhoan VALUES (N'NVDEF', N'Nhân viên 2', N'456', N'NV003')
select * from TaiKhoan

select TenNV, TenChucVu from NhanVien, ChucVu where NhanVien.MaCV=ChucVu.MaCV

-- Stored Procedure đăng nhập
CREATE PROC USP_Login
@TenDangNhap NVARCHAR(50), @PassWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND PassWord = @PassWord
END
GO

-- Vòng lặp lấy danh sách HDKH
DECLARE @i INT=1
WHILE @i<=6
BEGIN
	INSERT INTO HDKhachHang(name) VALUES(N'Hóa Đơn ' + CAST(@i AS NVARCHAR(20)))
	SET @i = @i + 1
END
GO
-- Stored Procedure Lay Danh Sach HDKH
CREATE PROC USP_LayDanhSachHDKH
AS SELECT * FROM HDKhachHang
GO

EXEC USP_LayDanhSachHDKH
UPDATE HDKhachHang SET TrangThai= N'Có người' WHERE id = 1
UPDATE HDKhachHang SET TrangThai= N'Có người' WHERE id =2
UPDATE HDKhachHang SET TrangThai= N'Có người' WHERE id =3
--THÊM THÔNG TIN BẢNG DSHANGHOA
INSERT INTO DSHangHoa VALUES (N'Giấy In')		--id = 1
INSERT INTO DSHangHoa VALUES (N'Bút Bi')		--id = 2
INSERT INTO DSHangHoa VALUES (N'Bút Xóa')		--id = 3
INSERT INTO DSHangHoa VALUES (N'Dao Rọc')		--id = 4
INSERT INTO DSHangHoa VALUES (N'Sổ')			--id = 5
INSERT INTO DSHangHoa VALUES (N'Keo')			--id = 6
INSERT INTO DSHangHoa VALUES (N'Sản Phẩm Khác')	--id = 7

select * from DSHangHoa

--THÊM THÔNG TIN BẢNG KHOHH
--(	MaHK NVARCHAR(5), SoLuongHH INT)
INSERT INTO KhoHH VALUES (N'GA001', 50)
INSERT INTO KhoHH VALUES (N'GA002', 20)
INSERT INTO KhoHH VALUES (N'GA003', 10)
INSERT INTO KhoHH VALUES (N'GA004', 5)
INSERT INTO KhoHH VALUES (N'GA005', 5)
INSERT INTO KhoHH VALUES (N'GA006', 1)
INSERT INTO KhoHH VALUES (N'BA001', 35)
INSERT INTO KhoHH VALUES (N'BA002', 12)
INSERT INTO KhoHH VALUES (N'BA003', 22)
INSERT INTO KhoHH VALUES (N'BA004', 55)
INSERT INTO KhoHH VALUES (N'BA005', 70)
INSERT INTO KhoHH VALUES (N'XA001', 20)
INSERT INTO KhoHH VALUES (N'XA002', 50)

select * from KhoHH

-- THÊM THÔNG TIN BẢNG HANGHOA
-- (MaHH NVARCHAR(5), TenHH NVARCHAR(100), NgayNhap DATE, DVTinh NVARCHAR(10) GiaMua FLOAT,DonGia FLOAT, MaDSHH INT, MaHK NVARCHAR(5))
INSERT INTO HangHoa VALUES (N'GA001', N'Giấy A5 Excel 70 gsm',  N'ram', 25000, 25600, 1, N'GA001')
INSERT INTO HangHoa VALUES (N'GA002', N'Giấy A4 Excel 70 gsm',  N'ram', 45000,49500, 1, N'GA002')
INSERT INTO HangHoa VALUES (N'GA003', N'Giấy A4 Excel 80 gsm',  N'ram', 50000,58000, 1, N'GA003')
INSERT INTO HangHoa VALUES (N'GA004',  N'Giấy A4 70 Accura',  N'ram', 50000,55000, 1, N'GA004')
INSERT INTO HangHoa VALUES (N'GA005', N'Giấy A4 Double A 70 gsm',  N'ram', 60000, 61100, 1, N'GA005')
INSERT INTO HangHoa VALUES (N'GA006', N'Giấy A4 Double A 80 gsm',  N'ram', 80000, 84000, 1, N'GA006')
INSERT INTO HangHoa VALUES (N'BA001', N'Bút bi Thiên Long 08',  N'cây', 2000,2400, 2, N'BA001')
INSERT INTO HangHoa VALUES (N'BA002', N'Bút bi Thiên Long FO.03',  N'cây', 2000, 2900, 2, N'BA002')
INSERT INTO HangHoa VALUES (N'BA003', N'Bút bi Thiên Long 027',  N'cây', 3000, 3500, 2, N'BA003')
INSERT INTO HangHoa VALUES (N'BA004', N'Bút cắm bàn đôi-Thiên Long',  N'cặp', 10000, 14000, 2, N'BA004')
INSERT INTO HangHoa VALUES (N'BA005', N'Bút nam châm Polar pen (Bạc)',  N'cây', 300000, 331550, 2, N'BA005')
INSERT INTO HangHoa VALUES (N'XA001', N'Bút Xóa nước CP.02',  N'cây', 20000,22300, 3, N'XA001')
INSERT INTO HangHoa VALUES (N'XA002', N'Xóa kéo Plus 105T lớn',  N'cây', 20000,21300, 3, N'XA002')
select * from HangHoa
select TenHH, SoLuongHH from HangHoa, KhoHH where HangHoa.MaHK=KhoHH.MaHK

-- Them TT Bang HoaDon
--MaHD INT IDENTITY, NgayNHD DATE DEFAULT GETDATE,	NgayXHD DATE, TrangThai bit, id INT, MaNV NVARCHAR(5), GiamGia INT
INSERT INTO HoaDon VALUES (GETDATE(), null, 1, 1, N'NV002',0,NULL)				-- Hoa don 1 chua thanh toan
INSERT INTO HoaDon VALUES (GETDATE(), null, 1, 2, N'NV003',0,NULL)		-- Hoa don 2 chua thanh toan
INSERT INTO HoaDon VALUES (GETDATE(), null, 1, 3, N'NV002',0,NULL)				-- Hoa don 3 chua thanh toan
select * from HoaDon

--Them TT Bang ChitietHD
--(MaHH NVARCHAR(5), MaHD INT, SoLuong INT DEFAULT 0)
INSERT INTO ChiTietHD VALUES (N'GA003', 1, 1)		--Hoa don 1
INSERT INTO ChiTietHD VALUES (N'BA002', 1, 5)		--Hoa don 1
INSERT INTO ChiTietHD VALUES (N'BA004', 1, 2)		--Hoa don 1

INSERT INTO ChiTietHD VALUES (N'GA003', 2, 2)		--Hoa don 2
INSERT INTO ChiTietHD VALUES (N'BA004', 2, 2)		--Hoa don 2

INSERT INTO ChiTietHD VALUES (N'BA002', 3, 1)		--Hoa don 3
INSERT INTO ChiTietHD VALUES (N'GA006', 3, 2)		--Hoa don 3

select * from HoaDon where id = 1 and TrangThai = 1

select * from dbo.HoaDon where id = 1 and TrangThai = 1

select HangHoa.TenHH, HangHoa.DVTinh,ChiTietHD.SoLuong, HangHoa.DonGia, HangHoa.DonGia*ChiTietHD.SoLuong as TongDonGia
from HDKhachHang, HoaDon, ChiTietHD, HangHoa
where HDKhachHang.id = 1
select * from DSHangHoa, HangHoa where DSHangHoa.MaDSHH = HangHoa.MaDSHH and DSHangHoa.MaDSHH= 2
--------------------------------
CREATE PROC USP_InsertBill
@id INT
As
BEGIN
	INSERT INTO HoaDon VALUES (GETDATE(),NULL,1,@id,NULL,0,NULL)
END
GO
--------------------------------
--CREATE PROC USP_InsertBillInfo
--@MaHH NVARCHAR(5), @MaHD int, @SoLuong int
--AS
--BEGIN
--	INSERT INTO ChiTietHD VALUES (@MaHH, @MaHD, @SoLuong)
--END
--GO
--------------------------------
CREATE PROC USP_InsertBillInfo
@MaHH NVARCHAR(5), @MaHD int, @SoLuong int
AS
BEGIN
	DECLARE @CTHDDaTonTai INT
	DECLARE @SLNew INT = 1
	SELECT @CTHDDaTonTai = MaHD, @SLNew = SoLuong FROM ChiTietHD WHERE MaHD = @MAHD AND MaHH = @MaHH
	IF(@CTHDDaTonTai >0)
	BEGIN
		DECLARE @NewSL INT = @SLNew + @SoLuong
		IF(@NewSL >0)
		BEGIN
			UPDATE ChiTietHD SET SoLuong = @SLNew + @SoLuong WHERE MaHH = @MaHH
			UPDATE KhoHH  SET SoLuongHH = SoLuongHH - @SoLuong from HangHoa, KhoHH WHERE KhoHH.MaHK = HangHoa.MaHK and Hanghoa.MaHK = @MaHH
		END
		ELSE
			DELETE ChiTietHD WHERE MaHD = @MAHD AND MaHH = @MaHH
			UPDATE KhoHH  SET SoLuongHH = SoLuongHH - @SoLuong from HangHoa, KhoHH WHERE KhoHH.MaHK = HangHoa.MaHK and Hanghoa.MaHK = @MaHH
	END
	ELSE
	BEGIN
		INSERT INTO ChiTietHD VALUES (@MaHH, @MaHD, @SoLuong)
		UPDATE KhoHH  SET SoLuongHH = SoLuongHH - @SoLuong from HangHoa, KhoHH WHERE KhoHH.MaHK = HangHoa.MaHK and Hanghoa.MaHK = @MaHH
	END	
END
GO


CREATE TRIGGER UTG_UpdateBillInfo
ON ChiTietHD FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @MaHD INT
	
	SELECT @MaHD = MaHD FROM Inserted
	
	DECLARE @id INT
	
	SELECT @id = id FROM dbo.HoaDon WHERE MaHD = @MaHD AND TrangThai = 1
	
	UPDATE dbo.HDKhachHang SET TrangThai = N'Có người' WHERE id=@id
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @MaHD INT
	
	SELECT @MaHD = MaHD FROM Inserted	
	
	DECLARE @id INT
	
	SELECT @id = id FROM dbo.HoaDon WHERE MaHD = @MaHD
	
	DECLARE @SoLuong int = 0
	
	SELECT @SoLuong = COUNT(*) FROM dbo.ChiTietHD, dbo.HoaDon WHERE ChiTietHD.MaHD = HoaDon.MaHD and id = @id AND TrangThai = 1
	
	IF (@SoLuong = 0)
		UPDATE dbo.HDKhachHang SET TrangThai = N'Trống' WHERE id=@id
END
GO
select * from ChiTietHD

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.ChiTietHD FOR DELETE
AS
BEGIN
	DECLARE @MaHD_CT INT
	DECLARE @MaHH_CT NVARCHAR
	SELECT @MaHD_CT = MaHD, @MaHH_CT = deleted.MaHH FROM deleted	
	
	DECLARE @id INT 
	SELECT @id = id FROM HoaDon WHERE MaHD = @MaHD_CT
	DECLARE @SoLuong INT = 0
	SELECT @SoLuong = count(*) FROM ChiTietHD, HoaDon WHERE ChiTietHD.MaHD = HoaDon.MaHD and HoaDon.TrangThai = 1 and ChiTietHD.MaHD = @MaHD_CT
	IF(@SoLuong =0)
		update HDKhachHang set TrangThai = N'Trống' where id = @MaHD_CT
END
GO

CREATE PROC USP_GetListBillByDate
@NgayNHD DATE, @NgayXHD DATE
AS
BEGIN
	select HoaDon.MaHD as [Số HD], HDKhachHang.name as[Hóa Đơn], HoaDon.NgayNHD as[Ngày Nhập HD], HoaDon.NgayXHD as[Ngày Xuất HD], NhanVien.TenNV as[Nhân Viên], HoaDon.GiamGia as[Giảm Giá], HoaDon.TongGia as[Tổng tiền]
	from HoaDon, HDKhachHang, NhanVien
	where HoaDon.TrangThai = 0 and HoaDon.id = HDKhachHang.id and HoaDon.NgayNHD >= @NgayNHD and HoaDon.NgayXHD <= @NgayXHD and HoaDon.MaNV = NhanVien.MaNV
END
GO

select ChucVu.MaCV, TaiKhoan.TenDangNhap, TaiKhoan.TenHienThi, NhanVien.DiaChi, TaiKhoan.PassWord 
from ChucVu, TaiKhoan, NhanVien 
where TenDangNhap = N'Quanly01' and TaiKhoan.MaNV = NhanVien.MaNV and NhanVien.MaCV = ChucVu.MaCV

CREATE PROC USP_UpdatePssAccount
@TenDangNhap NVARCHAR(50), @TenHienThi NVARCHAR(50), @PassWord NVARCHAR(100), @NewPassWord NVARCHAR(100)
AS
BEGIN
	DECLARE @IsRightPass INT = 0
	SELECT @IsRightPass = COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND PassWord = @PassWord
	IF(@IsRightPass =1)
	BEGIN
		IF(@NewPassWord!=NULL or @NewPassWord!='')
			UPDATE TaiKhoan SET PassWord = @NewPassWord WHERE TenDangNhap = @TenDangNhap
	END
END
GO
select ChucVu.MaCV, ChucVu.TenChucVu, TaiKhoan.TenDangNhap, TaiKhoan.TenHienThi, TaiKhoan.PassWord, NhanVien.SoDT 
from ChucVu, TaiKhoan, NhanVien 
where TenDangNhap = N'QuanLy01' and TaiKhoan.MaNV = NhanVien.MaNV and NhanVien.MaCV = ChucVu.MaCV
select * from TaiKhoan

CREATE PROC USP_UpdateAccount
@TenDangNhap NVARCHAR(50), @TenHienThi NVARCHAR(50), @PassWord NVARCHAR(100), @DiaChi NVARCHAR(100), @SoDT CHAR(11)
AS
BEGIN
	DECLARE @IsRightPass INT = 0
	SELECT @IsRightPass = COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND PassWord = @PassWord
	IF(@IsRightPass =1)
	BEGIN
		IF(@DiaChi!=NULL or @DiaChi!='')
			UPDATE NhanVien SET DiaChi = @DiaChi FROM NhanVien, TaiKhoan WHERE NhanVien.MaNV = TaiKhoan.MaNV AND TenDangNhap = @TenDangNhap
		IF(@TenHienThi!=NULL or @TenHienThi!='')
			UPDATE TaiKhoan SET TenHienThi = @TenHienThi WHERE TenDangNhap = @TenDangNhap
		IF(@SoDT!=NULL or @SoDT!='')
			UPDATE NhanVien SET SoDT = @SoDT FROM TaiKhoan, NhanVien WHERE NhanVien.MaNV = TaiKhoan.MaNV AND TenDangNhap = @TenDangNhap
	END
END
GO
			UPDATE NhanVien SET DiaChi = N'Long Xuyen,11111' FROM NhanVien, TaiKhoan WHERE NhanVien.MaNV = TaiKhoan.MaNV AND TenDangNhap = N'Quanly01'

select * from HangHoa
select * from KhoHH
select * from HoaDon
select * from DSHangHoa
select MaHH as[Mã HH], TenHH as[Tên HH], DVTinh as[ĐV Tính], DonGia as[Đơn Giá], MaDSHH as[Mã DS], MaHK as[Mã Kho] from HangHoa

select * from NhanVien
select * from TaiKhoan
select NhanVien.MaNV as[Mã NV],  TenChucVu as[Tên Chức Vụ], TenHienThi as[Tên Hiển Thị], TenNV as[Tên NV], SoDT as[Số DT], DiaChi as[Địa Chỉ], ChucVu.TenChucVu
from NhanVien, TaiKhoan, ChucVu 
where NhanVien.MaNV = TaiKhoan.MaNV and ChucVu.MaCV = NhanVien.MaCV
update KhoHH set SoLuongHH = 5 where MaHK = N'GA007'
update HangHoa set TenHH = N'Giấy A5 Excel 70 gsm', DVTinh = N'ram', DonGia = 30000, MaDSHH = 1 where MaHH=N'GA007'
select * from TaiKhoan, NhanVien where TaiKhoan.MaNV =NhanVien.MaNV and TenDangNhap != N'NV004'
select TenDangNhap from TaiKhoan, NhanVien where TaiKhoan.MaNV = NhanVien.MaNV and TenDangNhap != N'NV004'
select TenDangNhap from TaiKhoan where TaiKhoan.TenDangNhap = N'NVABC' and TaiKhoan.MaNV = N'NV004'
select TenDangNhap from TaiKhoan, NhanVien where TaiKhoan.MaNV = NhanVien.MaNV and TaiKhoan.MaNV = N'NV004'
delete from NhanVien where MaNV = N'NV005'
delete from TaiKhoan where TenDangNhap = N'NV100'
update KhoHH set SoLuongHH = 4 where MaHK = N'BA001'
select * from KhoHH

select NhanVien.MaNV as[Mã NV],  ChucVu.MaCV as[Chức Vụ], TenNV as[Tên NV], SoDT as[Số DT], TrangThaiNV.TenTrangThai as[Trạng Thái], DiaChi as[Địa Chỉ] 
from NhanVien, ChucVu, TrangThaiNV 
where ChucVu.MaCV = NhanVien.MaCV and NhanVien.TrangThaiNV = 0 and NhanVien.TrangThaiNV = TrangThaiNV.TrangThaiNV