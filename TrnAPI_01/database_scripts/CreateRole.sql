USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRole]
		@Name nvarchar(50)
AS
BEGIN
		INSERT INTO dbo.Records (Name)
		VALUES (@Name);
END