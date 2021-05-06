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
    )
VALUES(
    @TenHH,
    @Gia,
    @TrangThai,
    @MaLoai,
    @MaDT,
    @MaSize,
    @MoTa,
    @Hinh
)

SELECT SCOPE_IDENTITY() AS MaHH