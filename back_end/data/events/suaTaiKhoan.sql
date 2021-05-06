UPDATE [dbo].[USERS]
SET     [TenUser]=@TenUser,
        [Email]=@Email,
        [TaiKhoan]=@TaiKhoan,
        [MatKhau]=@MatKhau,
        [MaQuyen]=@MaQuyen
WHERE [MaUser]=@MaUser   
   
    
    
    
SELECT [MaUser]
        ,[SoTienTK]
        ,[DiemThuong]
        ,[TenUser]
        ,[Email]
        ,[TaiKhoan]
        ,[MatKhau]
        ,[MaQuyen]
    FROM [dbo].[USERS]
    WHERE [MaUser]=@MaUser