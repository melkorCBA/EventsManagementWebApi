
create view [PublicEvents] as 
select EventID, Title, StartDate, EndDate, Duration, Description, PublisherId, Place, Private, FullName from dbo.[Event]  e left join dbo.[User] u on e.PublisherId = u.UserId where e.Private = 0  ;
Go