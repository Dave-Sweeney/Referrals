CREATE TABLE [dbo].[MagellanStatus]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ReferralId] INT NOT NULL,
	[ContactStatus] VARCHAR(50) NOT NULL,
	[ClosedStatus] VARCHAR(50) NOT NULL,
	[ClosedDate] DATE NULL,
	[ClosedNotes] VARCHAR(1000) NULL,
	[ClosedReason] VARCHAR(1000) NULL,
	[CreatedDateTime] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[LastUpdatedDateTime] DATETIME2 NULL DEFAULT NULL
)
