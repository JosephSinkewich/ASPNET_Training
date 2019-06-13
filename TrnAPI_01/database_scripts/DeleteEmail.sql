USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[DeleteEmail]
		@Id int
AS
BEGIN
		DELETE FROM dbo.Emails
		WHERE dbo.Emails.Id = @Id
END
GO