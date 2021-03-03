--insert dummy data

--add users through sp

use eventManger;

DECLARE @responseMessage NVARCHAR(250)

EXEC dbo.spAddUser
          @pEmail = 'admin@vit.com',
          @pPassword = '123',
          @pFullName = 'admin virtusa',
          
          @responseMessage=@responseMessage OUTPUT

SELECT UserID, Email, Password, Salt, FullName
FROM [dbo].[User]

DECLARE @responseMessage NVARCHAR(250)

EXEC dbo.spAddUser
          @pEmail = 'melkor@cba.com',
          @pPassword = '123',
          @pFullName = 'melkor cba',
          
          @responseMessage=@responseMessage OUTPUT

SELECT UserID, Email, Password, Salt, FullName
FROM [dbo].[User]


--login users through s
DECLARE	@responseMessage nvarchar(250)
Declare @LoggedUserID int

--Correct login and password
EXEC	dbo.spLogin
		@pEmail = N'admin@vit.com',
		@pPassword = N'123',
		@responseMessage = @responseMessage OUTPUT,
		@LoggedUserID = @LoggedUserID OUTPUT

SELECT	@responseMessage as N'@responseMessage', @LoggedUserID as N'LoggedUserID'

