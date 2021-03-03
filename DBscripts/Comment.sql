use eventManger;
if not exists (select * from sysobjects where name='Comment' )
	CREATE TABLE  dbo.[Comment] (
    CommentID int NOT NULL Unique IDENTITY(1,1),
    Text varchar(600) NOT NULL,
    Date Date
	
	CONSTRAINT [PK_Comment_CommentID] PRIMARY KEY CLUSTERED (CommentID ASC)
    
)
Go

if exists (select * from sysobjects where name='Comment' )
ALTER TABLE [dbo].Comment add AuthorId int
Go

if exists (select * from sysobjects where name='Comment' )
ALTER TABLE [dbo].Comment add EventId int
Go

if exists (select * from sysobjects where name='Comment' )
ALTER TABLE [dbo].Comment
ADD CONSTRAINT FK_UserComment
FOREIGN KEY (AuthorId) REFERENCES dbo.[User](UserID); 
Go

if exists (select * from sysobjects where name='Comment' )
ALTER TABLE [dbo].Comment
ADD CONSTRAINT FK_EventComment
FOREIGN KEY (EventId) REFERENCES dbo.[Event](EventID); 
Go