USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateEvent]
		@Name nvarchar(50), @RecordId int
AS
BEGIN
		INSERT INTO dbo.Events (Name, RecordId)
		VALUES (@Name, @RecordId);
END