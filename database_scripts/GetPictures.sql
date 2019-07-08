USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[GetPictures]
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Pictures
END
GO