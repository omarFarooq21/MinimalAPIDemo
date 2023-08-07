CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin
	Select Id, FirstName, LastName
	From dbo.[User]
	where Id = @Id;
end

