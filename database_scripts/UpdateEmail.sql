USE [aspnetTrainingDB]
GO
CREATE PROCEDURE [dbo].[UpdateEmail]
		@Id int,
		@Address nvarchar(50)
AS
BEGIN
		UPDATE dbo.Emails
		SET Address = @Address
		Where dbo.Emails.Id = @Id
END
GO