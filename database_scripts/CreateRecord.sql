USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRecord]
		@Name nvarchar(50),
		@CreateDate datetime,
		@Description nvarchar(1000),
		@CategoryId int,
		@PictureId int
AS
BEGIN
		INSERT INTO dbo.Records (Name, CreateDate, Description, CategoryId, PictureId)
		VALUES (@Name, @CreateDate, @Description, @CategoryId, @PictureId);
END