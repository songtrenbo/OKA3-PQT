INSERT INTO [dbo].[HOADON]
    (
        [NgayMua]
        ,[MaUser]
    )
VALUES(
    @NgayMua,
    @MaUser
)
SELECT SCOPE_IDENTITY() AS MaHD
 