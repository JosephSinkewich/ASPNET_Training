USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateRecord]
		@Id int,
		@Name nvarchar(50),
		@CreateDate datetime,
		@Description nvarchar(1000),
		@CategoryId int,
		@PictureId int
AS
BEGIN
		UPDATE dbo.Records
		SET Name = @Name,
		CreateDate = @CreateDate,
		Description = @Description,
		CategoryId = @CategoryId,
		PictureId = @PictureId
		Where dbo.Records.Id = @Id
END
GO