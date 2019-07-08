USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateRole]
		@Id int,
		@Name nvarchar(50)
AS
BEGIN
		UPDATE dbo.Roles
		SET Name = @Name
		Where dbo.Roles.Id = @Id
END
GO