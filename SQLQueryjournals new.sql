

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
@user_id integer,
@guid varchar(max),
@created_on datetimeoffset   
)  
as  
BEGIN TRANSACTION

				DECLARE @journal_id int;
  
			 INSERT INTO journal_entries(journal_name,journal_date,journal_guid_code,user_id)
			 values (@transaction_name,@transaction_date,@guid,@user_id);
			 SELECT @journal_id = scope_identity();
		
				INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,debit,credit,transactions_type,created_on,linking_transaction_id,user_id,transaction_descriptions)
				VALUES (@transaction_name,@transaction_code,@gl_id,@transaction_date,@debit,@credit,@transaction_type,@created_on,@journal_id,@user_id,@transaction_description)
				

COMMIT
GO
select * from purchases
select * from journal_entries

select * from transactions