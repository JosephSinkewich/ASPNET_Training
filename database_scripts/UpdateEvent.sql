USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateEvent]
		@Id int,
		@Name nvarchar(50)
AS
BEGIN
		UPDATE dbo.Events
		SET Name = @Name
		Where dbo.Events.Id = @Id
END
GO