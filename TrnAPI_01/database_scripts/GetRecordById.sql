USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetRecordById
		@Id int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Records
		WHERE dbo.Records.Id = @Id
END
GO