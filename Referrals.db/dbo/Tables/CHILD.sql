CREATE TABLE [dbo].[CHILD]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY ,
    [referral_id] INT NOT NULL,
    [first_name] VARCHAR(50) NOT NULL, 
    [last_name] VARCHAR(50) NOT NULL, 
    [age] INT NOT NULL, 
    [created_datetime] DATETIME2 NOT NULL DEFAULT GETDATE() , 
    [last_updated_datetime] DATETIME2 NULL DEFAULT NULL
)
