select * from purchases

select * from transactions
select * from items

alt
insert into items values ('pan','shrink','taps water','a.jpg',1,4,222,2222,'pieces',12,'2018-12-12')
delete from  transactions

insert into purchases(purchase_name,user_id,item_id,quantity,price,purchase_date)
select ('taps purchase',4,1,11,11,'2018-9-9) 

ALTER TABLE transactions
ADD linking_transaction_id integer not null;


BEGIN TRANSACTION
   DECLARE @purchase_id int;
   INSERT INTO purchases (purchase_name,user_id,item_id,quantity,price,purchase_date)VALUES ('aa',4,1,12,122,'2018-11-10');
   SELECT @purchase_id = scope_identity();
   INSERT INTO transactions(transaction_name,gl_id,linking_transaction_id,transaction_date,debit,transactions_type,created_on)
    VALUES ('aaaa',1,@purchase_id,'2018-09-09',5000,'purchases','2018-09-09');
COMMIT

select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,p.price,t.transaction_name,
g.gl_name,g.gl_master_type,t.credit,t.transactions_type,p.purchase_date

 from purchases p
join transactions t on t.linking_transaction_id=p.purchase_id
join gl g on g.gl_id=t.gl_id
join items i on i.item_id=p.item_id

