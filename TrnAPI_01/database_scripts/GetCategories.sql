USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[GetCaetories]
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Categories
END
GO