INSERT INTO [dbo].[CT_PHIEUQUATANG]
    (
        [MaCTPhieu]
        ,[SoLuong]
        ,[NgayNhan]
        ,[NgayHetHan]
        ,[TrangThai]
        ,[GiamGia]
        ,[DiemThuongDoi]
    )
VALUES(
        @MaCTPhieu
        ,@SoLuong
        ,@NgayNhan
        ,@NgayHetHan
        ,@TrangThai
        ,@GiamGia
        ,@DiemThuongDoi
)
SELECT MaCTPhieu
FROM [dbo].[CT_PHIEUQUATANG]
WHERE [MaCTPhieu]=@MaCTPhieu
 