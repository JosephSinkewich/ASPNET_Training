USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdatePicture]
		@Id int,
		@Path nvarchar(50)
AS
BEGIN
		UPDATE dbo.Pictures
		SET Path = @Path
		Where dbo.Pictures.Id = @Id
END
GO