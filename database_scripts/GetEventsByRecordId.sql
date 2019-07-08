USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetEventsByRecordId
		@RecordId int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Events events
		JOIN dbo.RecordEventRelations relations
		ON events.Id = relations.EventId
		WHERE relations.RecordId = @RecordId
END
GO