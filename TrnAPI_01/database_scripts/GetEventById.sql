USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetEventById
		@Id int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Events
		WHERE dbo.Events.Id = @Id
END
GO