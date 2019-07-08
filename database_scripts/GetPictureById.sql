USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].GetPictureById
		@Id int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM dbo.Pictures
		WHERE dbo.Pictures.Id = @Id
END
GO