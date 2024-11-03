CREATE TABLE [dbo].[REFERRALS]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [referral_id] NCHAR(10) NOT NULL, 
    [search_zip] NCHAR(5) NULL DEFAULT NULL,
    [parent_id] UNIQUEIDENTIFIER NOT NULL, 
    [referral_date] DATETIME2 NOT NULL DEFAULT GETDATE(), 
	[magellan_closed_date] DATE NULL DEFAULT NULL,
    [magellan_contact_status] VARCHAR(50) NOT NULL,
	[magellan_closed_status] VARCHAR(50) NOT NULL,
	[magellan_closed_notes] VARCHAR(1000) NULL,
	[magellan_closed_reason] VARCHAR(1000) NULL, 
    [created_datetime] DATETIME2 NULL DEFAULT NULL
)
