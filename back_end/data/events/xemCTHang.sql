SELECT  [MaHH],
        [TenHH],
        [SoLuong],
        [Gia],
        [TrangThai],
        l.[TenLoai], 
        [MoTa],
        [Hinh],
        dt.[SoDT],
        s.[Size]
FROM [dbo].[HANG] h
INNER JOIN [dbo].[SIZE] s
ON h.MaSize=s.MaSize
INNER JOIN [dbo].[LOAI] l
ON h.MaLoai=l.MaLoai
INNER JOIN [dbo].[DIEMTHUONG] dt
ON h.MaDT=dt.MaDT
WHERE [MaHH]=@MaHH
