INSERT INTO [dbo].[CT_HOADON]
    (
        [SoLuong]
        ,[MaHH]
        ,[MaHD]
    )
VALUES(
    @SoLuong,
    @MaHH,
    @MaHD
)
SELECT SCOPE_IDENTITY() AS MaCTHD

UPDATE [dbo].[HANG]
SET     [SoLuong]=SoLuong-@SoLuong
WHERE [MaHH]=@MaHH   

UPDATE [dbo].[USERS]
SET [SoTienTK]=SoTienTK-h.Gia*@SoLuong
FROM [dbo].[USERS] u
JOIN [dbo].[HANG] h
ON h.MaHH=@MaHH
WHERE [MaUser]=@MaUser   

UPDATE [dbo].[USERS]
SET [DiemThuong]=DiemThuong-h.Gia*@SoLuong
FROM [dbo].[USERS] u
JOIN [dbo].[HANG] h
ON h.MaHH=@MaHH
WHERE [MaUser]=@MaUser