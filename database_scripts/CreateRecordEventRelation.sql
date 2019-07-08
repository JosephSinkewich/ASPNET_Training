USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRecordEventRelation]
		@RecordId int, @EventId int
AS
BEGIN
		INSERT INTO dbo.RecordEventRelations (RecordId, EventId)
		VALUES (@RecordId, @EventId);
END