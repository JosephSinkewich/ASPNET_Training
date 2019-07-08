USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateUser]
		@Id int,
		@Name nvarchar(50),
		@Password nvarchar(50),
		@RoleId int,
		@EmailId int
AS
BEGIN
		UPDATE dbo.Users
		SET Name = @Name,
		Password = @Password,
		RoleId = @RoleId,
		EmailId = @EmailId
		Where dbo.Users.Id = @Id
END
GO