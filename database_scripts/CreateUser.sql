USE [aspnetTrainingDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
		@Name nvarchar(50),
		@Password nvarchar(50),
		@RoleId int,
		@EmailId int
AS
BEGIN
		INSERT INTO dbo.Users (Name, Password, RoleId, EmailId)
		VALUES (@Name, @Password, @RoleId, @EmailId);
END