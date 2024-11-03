CREATE TABLE [dbo].[PARENTS]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [first_name] VARCHAR(50) NOT NULL, 
    [last_name] VARCHAR(50) NOT NULL, 
    [phone] VARCHAR(10) NOT NULL,
    [ok_to_text] BIT NOT NULL DEFAULT 1,
    [email] VARCHAR(50) NOT NULL, 
    [comment] VARCHAR(2000) NULL, 
    [created_datetime] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [last_updated_datetime] DATETIME2 NULL
)
