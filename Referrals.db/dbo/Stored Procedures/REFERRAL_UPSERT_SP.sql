CREATE PROCEDURE [dbo].[REFERRAL_UPSERT_SP]
	@referral_id int = 0,
	@referral_date datetime2,
	@search_zip nchar(5) NULL,
	@parent_first_name varchar(50),
	@parent_last_name varchar(50),
	@parent_phone varchar(10),
	@parent_ok_to_text bit,
	@parent_email varchar(50),
	@parent_comment varchar(2000) NULL,
	@magellan_closed_date DATE NULL,
	@magellan_contact_status varchar(50),
	@magellan_closed_status varchar(50),
	@magellan_closed_notes varchar(1000) NULL,
	@magellan_closed_reason varchar(1000) NULL
AS
  BEGIN
	
	  DECLARE @parent_id UNIQUEIDENTIFIER
	  DECLARE @child_id UNIQUEIDENTIFIER

	  SET @parent_id = NEWID()
	  SET @child_id = NEWID()

	  -- Insert new parent
	  INSERT INTO [dbo].[PARENTS] (
		id, 
		first_name, 
		last_name, 
		phone, 
		ok_to_text, 
		email, 
		comment, 
		created_datetime)
	  VALUES (
		@parent_id, 
		@parent_first_name, 
		@parent_last_name, 
		@parent_phone, 
		@parent_ok_to_text, 
		@parent_email, 
		@parent_comment, 
		GETDATE());
	  
	    -- Insert new referral
	    INSERT INTO [dbo].[REFERRALS] (
	      id,
		  referral_id,
		  search_zip,
		  parent_id,
		  referral_date,
		  magellan_closed_date,
		  magellan_contact_status,
		  magellan_closed_status,
		  magellan_closed_notes,
		  magellan_closed_reason,
		  created_datetime)
	    VALUES (
	      NEWID(),
		  @referral_id,
		  @search_zip,
		  @parent_id,
		  @referral_date,
		  @magellan_closed_date,
		  @magellan_contact_status,
		  @magellan_closed_status,
		  @magellan_closed_notes,
		  @magellan_closed_reason,
		  GETDATE());
	END