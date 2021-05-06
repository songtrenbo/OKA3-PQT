INSERT INTO [dbo].[USERS]
    (
        [SoTienTK]
        ,[DiemThuong]
        ,[TenUser]
        ,[Email]
        ,[TaiKhoan]
        ,[MatKhau]
        ,[MaQuyen]
    )
VALUES(
    0,
    0,
    @TenUser,
    @Email,
    @TaiKhoan,
    @MatKhau,
    'KH'
)

SELECT SCOPE_IDENTITY() AS Id