USE [JAS_1]
GO

/****** Object:  StoredProcedure [dbo].[Insert_into_journal_transactions]    Script Date: 8/31/2018 2:14:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[Insert_into_journal_transactions] 
(  
 

@transaction_name varchar(max),  
@transaction_code varchar(max),
@gl_id integer,  
@transaction_date datetimeoffset,  
@debit integer,
@credit integer, 
@transaction_type varchar(max),
@transaction_description varchar(max),
@user_id integer,@guid varchar(max),
@created_on datetimeoffset   
)  
as  
BEGIN TRANSACTION
   DECLARE @journal_id int;
  
 insert into journal_entries(journal_name,journal_date,journal_guid_code,user_id,gl_id)
 values (@transaction_name,@transaction_date,@guid,@user_id,@gl_id)

 SELECT @journal_id = scope_identity();
   INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,debit,credit,transactions_type,created_on,linking_transaction_id,user_id,transaction_descriptions)
    VALUES (@transaction_name,@transaction_code,@gl_id,@transaction_date,@debit,@credit,@transaction_type,@created_on,@journal_id,@user_id,@transaction_description);
	 
GO

select * from journal_entires


create table journal_entries(
journal_id integer not null identity , 
journal_name national character varying(max),
journal_date datetimeoffset,
journal_guid_code  national character varying(max),
user_id integer ,
gl_id integer

)
