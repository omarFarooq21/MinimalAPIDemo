CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@NewFirstName nvarchar(50),
	@NewLastName nvarchar(50)
AS
begin
	UPDATE dbo.[User]
    SET FirstName = @NewFirstName,
        LastName = @NewLastName
    WHERE Id = @Id;
end

