use eventManger;
if not exists (select * from sysobjects where name='Event' )
	CREATE TABLE  dbo.[Event] (
    EventID int IDENTITY(1,1) NOT NULL,
    Title varchar(200) NOT NULL,
    StartDate Date NOT NULL,
	EndDate Date NOT NULL,
	Duration float ,
	Description Varchar(400),
	Place varchar(200),
	Private bit,
   
	CONSTRAINT [PK_Event_EventID] PRIMARY KEY CLUSTERED (EventID ASC)
    
)
Go

if exists (select * from sysobjects where name='Event' )
ALTER TABLE [dbo].Event add PublisherId int
Go

if exists (select * from sysobjects where name='Event' )
ALTER TABLE [dbo].Event
ADD CONSTRAINT FK_UserEvents
FOREIGN KEY (PublisherId) REFERENCES dbo.[User](UserID); 
Go

create PROCEDURE dbo.[spGetAllEvents]
	@userID int = null
AS 
begin
	select EventID, Title, StartDate, EndDate, Duration, Description, PublisherId, Place, Private, FullName from dbo.[Event]  e left join dbo.[User] u on e.PublisherId = u.UserId where e.PublisherId = @userID  ;
end
Go