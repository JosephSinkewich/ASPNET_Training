USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetRecordsByCategoryId
		@CategoryId int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Records
		WHERE dbo.Records.CategoryId = @CategoryId
END
GO