use eventManger;
if not exists (select * from sysobjects where name='User' )
	CREATE TABLE  dbo.[User] (
    UserID int IDENTITY(1,1) NOT NULL,
    Email varchar(50) NOT NULL,
    FullName varchar(255) NOT NULL,
    Password BINARY(64) NOT NULL,
	CONSTRAINT [PK_User_UserID] PRIMARY KEY CLUSTERED (UserID ASC)
    
)
Go

if exists (select * from sysobjects where name='User')
ALTER TABLE dbo.[User] ADD Salt UNIQUEIDENTIFIER 
GO


create PROCEDURE dbo.spAddUser
    @pEmail varchar(50), 
    @pPassword varchar(50), 
    @pFullName varchar(40) = NULL, 
    @responseMessage varchar(250) OUTPUT ,
	@Status int = 0 OUTPUT

AS
BEGIN
		SET NOCOUNT ON

		
		IF not exists (select Email from dbo.[User] where Email = @pEmail)
			BEGIN
			DECLARE @salt UNIQUEIDENTIFIER=NEWID()
			BEGIN TRY

				INSERT INTO dbo.[User] (Email, Password, Salt, FullName)
				VALUES(@pEmail, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt, @pFullName);
				SET @responseMessage='Success';
				SET @Status = 1;
			END TRY
			BEGIN CATCH
				SET @responseMessage=ERROR_MESSAGE() ;
			END CATCH
			END

		ELSE
			SET @responseMessage='User Already exists'
END
GO


		






create PROCEDURE dbo.spLogin
    @pEmail VARCHAR(50),
    @pPassword VARCHAR(50),
    @responseMessage VARCHAR(250)='' OUTPUT,
	@LoggedUserID INT=NULL OUTPUT,
	@Status int = 0 OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 UserID FROM [dbo].[User] WHERE Email=@pEmail)
    BEGIN
        SET @userID=(SELECT UserID FROM [dbo].[User] WHERE Email=@pEmail AND Password=HASHBYTES('SHA2_512', @pPassword+CAST(Salt AS NVARCHAR(36))))

       IF(@userID IS NULL)
           SET @responseMessage='Incorrect password'
		   
       ELSE 
           SET @responseMessage='User successfully logged in' 
		   SET @LoggedUserID = @userID
		   SET SET @Status = 1;
		   
    END
    ELSE
       SET @responseMessage='Invalid login'
	   

END