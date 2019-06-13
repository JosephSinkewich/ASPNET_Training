USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateEvent]
		@Id int,
		@Name nvarchar(50),
		@RecordId int
AS
BEGIN
		UPDATE dbo.Events
		SET Name = @Name, RecordId = @RecordId
		Where dbo.Events.Id = @Id
END
GO