USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[RemoveEventFromRecord]
		@RecordId int, @EventId int
AS
BEGIN
		DELETE FROM dbo.RecordEventRelations
		WHERE dbo.RecordEventRelations.RecordId = @RecordId
		AND dbo.RecordEventRelations.EventId = @EventId
END
GO