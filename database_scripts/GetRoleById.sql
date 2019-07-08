USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetRoleById
		@Id int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Roles
		WHERE dbo.Roles.Id = @Id
END
GO