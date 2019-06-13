USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetEventsByRecordId
		@RecordId int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Events
		WHERE dbo.Events.RecordId = @RecordId
END
GO