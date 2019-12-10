select * from purchases
select * from transactions

update transactions set transaction_name='17-transaction-name-gl-id-1' where transaction_id=17



 
create procedure Insert_into_purchases_and_transactions
as
BEGIN TRANSACTION
   DECLARE @purchase_id int;
   INSERT INTO purchases (purchase_name,user_id,item_id,quantity,price,purchase_date)VALUES ('aa',4,1,12,122,'2018-11-10');
   SELECT @purchase_id = scope_identity();
   INSERT INTO transactions(transaction_name,gl_id,linking_transaction_id,transaction_date,debit,transactions_type,created_on)
    VALUES ('aaaa',1,@purchase_id,'2018-09-09',5000,'purchases','2018-09-09');
COMMIT

end


create proc Insert_into_purchases_and_transactions  
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
COMMIT

