SELECT [MaCTHD]
      ,cthd.[SoLuong]
      ,[TenHH]
      ,[Gia]
FROM [dbo].[CT_HOADON] cthd
INNER JOIN [dbo].[HANG] h
ON cthd.MaHH=h.MaHH
WHERE [MaHD]=@MaHD
