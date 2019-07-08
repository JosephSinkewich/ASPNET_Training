USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[GetEmails]
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Emails
END
GO