USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreatePicture]
		@Path nvarchar(50)
AS
BEGIN
		INSERT INTO dbo.Pictures (Path)
		VALUES (@Path);
END