CREATE PROCEDURE [dbo].[MAGELLAN_STATUS_NOTES_INSERT_SP]
	@referral_id INT,
	@author VARCHAR(100),
	@note VARCHAR(1000),
	@note_date DATE
AS
	INSERT INTO [dbo].[MAGELLAN_NOTE] (
		id,
		referral_id,
		note,
		author,
		note_date,
		created_datetime)
	VALUES (
		NEWID(),
		@referral_id,
		@note,
		@author,
		@note_date,
		GETDATE())
RETURN 0
