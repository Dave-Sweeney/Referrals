CREATE PROCEDURE [dbo].[CHILD_INSERT_SP]
	@referral_id INT,
	@child_first_name VARCHAR(50),
	@child_last_name VARCHAR(50),
	@child_age INT
AS
	BEGIN
	-- Insert new child
	INSERT INTO [dbo].[CHILD] (
		id,
		referral_id,
		first_name,
		last_name,
		age,
		created_datetime)
	VALUES (
		NEWID(),
		@referral_id,
		@child_first_name,
		@child_last_name,
		@child_age,
		GETDATE());
	END
RETURN 0
