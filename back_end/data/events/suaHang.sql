UPDATE [dbo].[HANG]
SET     [TenHH]=@TenHH,
        [SoLuong]=@SoLuong,
        [Gia]=@Gia,
        [TrangThai]=@TrangThai,
        [MaLoai]=@MaLoai, 
        [MoTa]=@MoTa,
        [Hinh]=@Hinh,
        [MaDT]=@MaDT,
        [MaSize]=@MaSize
WHERE [MaHH]=@MaHH   
   
    
    
SELECT  [TenHH],
        [SoLuong],
        [Gia],
        [TrangThai],
        [MaLoai], 
        [MoTa],
        [Hinh],
        [MaDT],
        [MaSize]
    FROM [dbo].[HANG]
    WHERE [MaHH]=@MaHH