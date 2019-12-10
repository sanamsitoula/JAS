USE [JAS_1]
GO

/****** Object:  StoredProcedure [dbo].[Insert_into_purchases_and_transactions]    Script Date: 8/30/2018 3:03:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[Insert_into_purchases_and_transactions]  
(  
@purchase_name varchar(max),  
@user_id integer,  
@item_id integer,  
@quantity integer,
@price integer,  
@purchase_date datetimeoffset,  

@transaction_name varchar(max),  
@transaction_code varchar(max),
@gl_id integer,  
@transaction_date datetimeoffset,  
@credit integer,  
@transaction_type varchar(max),
@created_on datetimeoffset   
)  
as  
BEGIN TRANSACTION
   DECLARE @purchase_id int;
   INSERT INTO purchases (purchase_name,user_id,item_id,quantity,price,purchase_date)
   VALUES (@purchase_name,@user_id,@item_id,@quantity,@price,@purchase_date);
   SELECT @purchase_id = scope_identity();
   INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,credit,transactions_type,created_on,linking_transaction_id)
    VALUES (@transaction_name,@transaction_code,@gl_id,@transaction_date,@credit,@transaction_type,@created_on,@purchase_id);

	 INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,debit,transactions_type,created_on,linking_transaction_id)
    VALUES (@transaction_name,@transaction_code,9,@transaction_date,@credit,@transaction_type,@created_on,@purchase_id);

	update items set item_quantity=item_quantity+@quantity,item_cp=@price where item_id=@item_id
COMMIT


create proc [dbo].[Insert_into_sales_transactions] 
(  
@sale_name varchar(max),  
@user_id integer,  
@item_id integer,  
@quantity integer,
@price integer,  
@sale_date datetimeoffset,
@customer_id integer,    

@transaction_name varchar(max),  
@transaction_code varchar(max),
@gl_id integer,  
@transaction_date datetimeoffset,  
@debit integer,  
@transaction_type varchar(max),
@created_on datetimeoffset   
)  
as  
BEGIN TRANSACTION
   DECLARE @sale_id int;
   INSERT INTO Sales(sale_name,user_id,item_id,quantity,price,sale_date,customer_id)
   VALUES (@sale_name,@user_id,@item_id,@quantity,@price,@sale_date,@customer_id);
   SELECT @sale_id = scope_identity();
   INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,debit,transactions_type,created_on,linking_transaction_id)
    VALUES (@transaction_name,@transaction_code,@gl_id,@transaction_date,@debit,@transaction_type,@created_on,@sale_id);
	

	 INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,credit,transactions_type,created_on,linking_transaction_id)
    VALUES (@transaction_name,@transaction_code,11,@transaction_date,@debit,@transaction_type,@created_on,@sale_id);
	
	
	UPDATE items set item_quantity=item_quantity-@quantity,item_sp=@price where item_id=@item_id
COMMIT



GO






  ALTER TABLE transactions
ADD transaction_descriptions national character varying(max);

  ALTER TABLE transactions
ADD user_id integer;

select * from gl
select * from transactions where transactions_type='journalentries'
insert into transactions select '2018-journal entries- khaja kharcha','2018',4,'2018-08-05',0,500,'journalentries','2018-08-15',100,'office expenses staff khaaja',4

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
@created_on datetimeoffset   
)  
as  
BEGIN TRANSACTION
   DECLARE @transaction_id int;
  
 
   INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,debit,transactions_type,created_on,linking_transaction_id,user_id,transaction_descriptions)
    VALUES (@transaction_name,@transaction_code,@gl_id,@transaction_date,@debit,@transaction_type,@created_on,@transaction_id,@user_id,@transaction_description);
	
	  SELECT @transaction_id = scope_identity();
	 INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,credit,transactions_type,created_on,linking_transaction_id,user_id,transaction_descriptions)
    VALUES (@transaction_name,@transaction_code,@gl_id,@transaction_date,@credit,@transaction_type,@created_on,@transaction_id,@user_id,@transaction_description);
		COMMIT



GO


insert into journal_entries values( 'aa','2018-05-05','asdfadfsa-asda-ads',4,4)


