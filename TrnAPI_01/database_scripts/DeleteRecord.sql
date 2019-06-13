USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[DeleteRecord]
		@Id int
AS
BEGIN
		DELETE FROM dbo.Records
		WHERE dbo.Records.Id = @Id
END
GO