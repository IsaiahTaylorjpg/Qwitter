CREATE TABLE [dbo].[UserStatus]
(
	[StatusId] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Status] NVARCHAR(500) NOT NULL, 
    [UserId] int FOREIGN KEY REFERENCES AccountInfo(UserId) NOT NULL
)
