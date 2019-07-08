USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateEmail]
		@Address nvarchar(50)
AS
BEGIN
		INSERT INTO dbo.Emails (Address)
		VALUES (@Address);
END