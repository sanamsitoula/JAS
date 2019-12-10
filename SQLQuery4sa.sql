USE [JAS_1]
GO

/****** Object:  StoredProcedure [dbo].[Insert_into_purchases_and_transactions]    Script Date: 8/31/2018 2:32:44 PM ******/
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

GO


insert into journal_entries values( 'aa','2018-05-05','asdfadfsa-asda-ads',4,4)