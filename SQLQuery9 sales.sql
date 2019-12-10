insert into sales(sale_name,user_id,item_id,quantity,price,customer_id,sale_date)
  select 'sales of taps',4,6,10,150,1,'2018-12-05' 

  select s.sale_id,s.sale_name,i.item_id,
  i.item_name,s.quantity,s.price,t.transaction_name,
  g.gl_name,s.customer_id, g.gl_master_type, t.debit, t.transactions_type, 
  s.sale_date from 
  Sales s 
  join transactions t on t.linking_transaction_id = s.sale_id
   join gl g on g.gl_id = t.gl_id 
   join items i on i.item_id = s.item_id

   select * from  Sales
   select * from items
   select * from transactions


   
create proc Insert_into_sales_transactions 
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
	UPDATE items set item_quantity=item_quantity-@quantity,item_sp=@price where item_id=@item_id
COMMIT


GO

select * from sales
truncate table sales 

BEGIN TRANSACTION
   DECLARE @sale_id int;
   INSERT INTO Sales(sale_name,user_id,item_id,quantity,price,sale_date,customer_id)
   VALUES ('sales of taps',4,6,10,150,'2018-01-05',1);
   SELECT @sale_id = scope_identity();
   INSERT INTO transactions(transaction_name,transaction_code,gl_id,transaction_date,debit,transactions_type,created_on,linking_transaction_id)
    VALUES ('trans-01-2018-01-05-sales-of-tapes','fs',2,'2018-01-05',500,'sales','2018-08-27',@sale_id);
COMMIT

