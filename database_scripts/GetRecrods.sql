USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[GetRecords]
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Records
END
GO