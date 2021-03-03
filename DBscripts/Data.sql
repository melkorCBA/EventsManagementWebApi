USE [eventManger]
GO

INSERT INTO [dbo].[Event]
           ([Title]
           ,[StartDate]
           ,[EndDate]
           ,[Duration]
           ,[Description]
           ,[Place]
           ,[Private]
           ,[PublisherId])
     VALUES 
	 ( N'EventOne', '2021-01-01', '2021-01-03', 2 , N'disscrption of the event 1 is here. It not that important', N'Jupyter', 0 ,1),
	 ( N'EventTwo', '2021-01-03', '2021-01-04', 1 , N'disscrption of the event 2 is here. It not that important', N'Mordor', 0 ,1),
	 ( N'EventThree', '2021-01-04', '2021-01-07', 3 , N'disscrption of the event 3 is here. It not that important', N'Shire', 1 ,1),
	 ( N'EventFour', '2021-01-01', '2021-01-02', 1 , N'disscrption of the event 4 is here. It not that important', N'Gondor', 0 ,1)
           
GO


USE [eventManger]
GO

INSERT INTO [dbo].[Comment]
           ([Text]
           ,[Date]
           ,[AuthorId]
           ,[EventId])
     VALUES 
	 (N'This is a not so big comment1', '2021-01-01', 1, 1),
	 (N'This is a not so big comment2', '2021-01-02', 1, 1),
	 (N'This is a not so big comment3', '2021-01-02', 2, 1),
	 (N'This is a not so big comment3', '2021-01-02', 1, 2),
	 (N'This is a not so big comment3', '2021-01-02', 2, 2),
	 (N'This is a not so big comment3', '2021-01-02', 2, 2),
	 (N'This is a not so big comment3', '2021-01-02', 2, 3),
	 (N'This is a not so big comment3', '2021-01-02', 2, 4)
           
GO

