USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateRecordEventRelation]
		@Id int, @RecordId int, @EventId int
AS
BEGIN
		UPDATE dbo.RecordEventRelation
		SET RecordId = @RecordId,
		EventId = @EventId
		WHERE dbo.RecordEventRelation.Id = @Id
END
GO