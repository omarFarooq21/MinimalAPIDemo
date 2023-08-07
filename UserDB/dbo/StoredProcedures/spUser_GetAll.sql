CREATE PROCEDURE [dbo].[spUser_GetAll]

AS
begin
	Select Id, FirstName, LastName
	From dbo.[User]
end

