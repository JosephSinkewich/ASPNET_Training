USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetUserById
		@Id int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Users
		WHERE dbo.Users.Id = @Id
END
GO