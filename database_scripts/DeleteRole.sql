USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[DeleteRole]
		@Id int
AS
BEGIN
		DELETE FROM dbo.Roles
		WHERE dbo.Roles.Id = @Id
END
GO