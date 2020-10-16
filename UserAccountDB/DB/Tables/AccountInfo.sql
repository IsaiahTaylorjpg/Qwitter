CREATE TABLE [dbo].[AccountInfo]
(
    [UserId] INT NOT NULL PRIMARY KEY IDENTITY,
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Street] NVARCHAR(50) NOT NULL, 
    [State] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [ZipCode] INT NOT NULL, 
    [Birthday] NVARCHAR(50) NOT NULL, 
    [Status] NVARCHAR(MAX) NULL
)
