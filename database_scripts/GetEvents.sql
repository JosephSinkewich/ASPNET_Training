USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[GetEvents]
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Events
END
GO