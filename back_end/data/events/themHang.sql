INSERT INTO [dbo].[HANG]
    (
        [TenHH]
        ,[Gia]
        ,[TrangThai]
        ,[MaLoai]
        ,[MaDT]
        ,[MaSize]
        ,[MoTa]
        ,[Hinh]
        ,[SoLuong]
    )
VALUES(
    @TenHH,
    @Gia,
    @TrangThai,
    @MaLoai,
    @MaDT,
    @MaSize,
    @MoTa,
    @Hinh,
    @SoLuong
)

SELECT SCOPE_IDENTITY() AS MaHH