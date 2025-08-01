
SELECT [AspNetUsers].[UserName] , [Schools].Name
FROM [AspNetUsers] ,[Schools]
WHERE [AspNetUsers].[IdSchool] = [Schools].[id]