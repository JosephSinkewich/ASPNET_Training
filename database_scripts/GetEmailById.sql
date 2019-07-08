USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetEmailById
		@Id int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Emails
		WHERE dbo.Emails.Id = @Id
END
GO