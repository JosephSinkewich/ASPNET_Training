USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCategory]
		@Name nvarchar(50)
AS
BEGIN
		INSERT INTO dbo.Categories (Name)
		VALUES (@Name);
END