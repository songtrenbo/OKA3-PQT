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


UPDATE [dbo].[USERS]
SET     [DiemThuong]=u.DiemThuong-ctpqt.DiemThuongDoi*@SoLuongPhieu
FROM [dbo].[USERS] u
JOIN [dbo].[CT_PHIEUQUATANG] ctpqt
ON ctpqt.MaCTPhieu=@MaCTPhieu
WHERE [MaUser]=@MaUser   

UPDATE [dbo].[CT_PHIEUQUATANG]
SET     [SoLuong]=SoLuong-@SoLuongPhieu
WHERE [MaCTPhieu]=@MaCTPhieu   