SELECT [MaPhieu]
        ,[MaUser]
        ,[SoLuongPhieu]
        ,[NgayNhan]
        ,[NgayHetHan]
        ,[GiamGia]
FROM [dbo].[PHIEUQUATANG] p
INNER JOIN [dbo].[CT_PHIEUQUATANG] ct
ON p.MaCTPhieu=ct.MaCTPhieu
WHERE [MaUser]=@MaUser