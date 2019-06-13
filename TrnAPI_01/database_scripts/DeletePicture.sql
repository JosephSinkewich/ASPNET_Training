USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[DeletePictures]
		@Id int
AS
BEGIN
		DELETE FROM dbo.Pictures
		WHERE dbo.Pictures.Id = @Id
END
GO