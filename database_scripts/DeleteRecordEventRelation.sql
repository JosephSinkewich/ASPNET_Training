USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[DeleteRecordEventRelation]
		@Id int
AS
BEGIN
		DELETE FROM dbo.RecordEventRelations
		WHERE dbo.RecordEventRelations.Id = @Id
END
GO