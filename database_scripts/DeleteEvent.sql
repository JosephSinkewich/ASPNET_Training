USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[DeleteEvent]
		@Id int
AS
BEGIN
		DELETE FROM dbo.Events
		WHERE dbo.Events.Id = @Id
END
GO