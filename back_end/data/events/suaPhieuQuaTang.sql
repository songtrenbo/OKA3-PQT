UPDATE [dbo].[CT_PHIEUQUATANG]
SET  [SoLuong]=@SoLuong
        ,[NgayNhan]=@NgayNhan
        ,[NgayHetHan]=@NgayHetHan
        ,[TrangThai]=@TrangThai
        ,[GiamGia]=@GiamGia
        ,[DiemThuongDoi]=@DiemThuongDoi
WHERE [MaCTPhieu]=@MaCTPhieu
 
SELECT  [SoLuong],
        [NgayNhan],
        [NgayHetHan],
        [TrangThai],
        [GiamGia], 
        [DiemThuongDoi]
    FROM [dbo].[CT_PHIEUQUATANG]
    WHERE [MaCTPhieu]=@MaCTPhieu