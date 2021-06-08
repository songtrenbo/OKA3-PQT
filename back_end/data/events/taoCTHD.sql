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
SET [SoTienTK]=SoTienTK-h.[Gia]*@SoLuong

-- UPDATE [dbo].[USERS] u
-- INNER JOIN [dbo].[HOADON] hd AND [dbo].[HANG] h
-- on u.MaUser=hd.MaUser AND h.MaHH=@MaHH AND 
-- SET [SoTienTK]=u.SoTienTK-h.Gia*@SoLuong 

-- UPDATE table1  
-- SET Col 2 = t2.Col2,  
-- Col 3 = t2.Col3  
-- FROM table1 t1  
-- INNER JOIN table2 t2 ON t1.Col1 = t2.col1  
-- WHERE t1.Col1 IN (21,31)

-- UPDATE [dbo].[USERS] 
-- SET [SoTienTK]=u.SoTienTK-h.Gia*@SoLuong 
-- FROM [dbo].[USERS] u 
-- INNER JOIN [dbo].[HOADON] hd AND [dbo].[HANG] h
-- ON u.MaUser=hd.MaUser AND h.MaHH=@MaHH 
-- WHERE u.MaUser=hd.MaUser AND h.MaHH=@MaHH 

-- UPDATE [dbo].[USERS]
-- SET     [SoLuong]=SoLuong-@SoLuong
-- WHERE [MaUser]=@MaUser 