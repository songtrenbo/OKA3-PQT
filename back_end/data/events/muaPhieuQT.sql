INSERT INTO [dbo].[PHIEUQUATANG]
    (
        [MaUser]
        ,[MaCTPhieu]
        ,[SoLuongPhieu]
    )
VALUES(
    @MaUser,
    @MaCTPhieu,
    @SoLuongPhieu
)

SELECT SCOPE_IDENTITY() AS MaPhieu

UPDATE [dbo].[USERS]
SET     [DiemThuong]=DiemThuong-ctpqt.DiemThuongDoi*@SoLuongPhieu
INNER JOIN [dbo].[CT_PHIEUQUATANG] ctpqt
ON ctpqt.MaCTPhieu=@MaCTPhieu
WHERE [MaUser]=@MaUser   
