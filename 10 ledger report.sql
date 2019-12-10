select coalesce(sum(t.Debit),0) AS Debit_Amount,coalesce(sum(t.credit),0) As Credit_Amount,g.gl_id,g.gl_name
 from 
transactions t 
join gl g on g.gl_id=t.gl_id
WHERE CAST(t.transaction_date AS DATE) >= '2018-01-01' 
  AND CAST(t.transaction_date AS date) <=  '2018-08-29'

group by g.gl_id, 
 g.gl_name
 order by gl_id 

 select * from transactions
select coalesce(sum(t.Debit),0) AS Debit_Amount,coalesce(sum(t.credit),0) As Credit_Amount,g.gl_id,g.gl_name
 from 
transactions t 
join gl g on g.gl_id=t.gl_id

group by g.gl_id, 
 g.gl_name
 order by gl_id 

create function get_gl_master_type_by_gl_id(@gl_id int)
returns varchar(max)
as 
begin 
Select * from gl where gl_id=@gl_id;
return gl_name
end;





select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,p.price,
t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type,
 p.purchase_date from purchases p join transactions t on
  t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id
    WHERE purchase_date BETWEEN '2018-08-15' AND '2018-08-25'

select * from transactions where gl_id=2

delete from transactions where transaction_date like '%0001%'
 CAST(posted_date AS DATE)

 select * from gl 
 update gl set gl_master_type='Liabilities' where gl_id=2

 insert into transactions values ('office expenses','oe',3,'2018-05-20',null,10000,'journal','2018-8-30',100)

 select p.purchase_id,p.purchase_name,i.item_id,i.item_name,p.quantity,t.credit,t.transaction_name,g.gl_name, g.gl_master_type, t.credit, t.transactions_type, p.purchase_date from purchases p join transactions t on t.linking_transaction_id = p.purchase_id join gl g on g.gl_id = t.gl_id join items i on i.item_id = p.item_id 
  where i.item_id=5 order by transaction_Id DESC
  truncate table purchases
  select * from sales where gl_id =1
  delete from transactions where gl_id=1

 
 select * from transactions


    public int journal_id { get; set; }
        public string journal_name { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }

        public int gl_id { get; set; }

        public string gl_name { get; set; }

        public string transaction_descriptions { get; set; }

        public DateTimeOffset  journal_date { get; set; }

     

	 select * from transactions


	 select u.user_name,t.transaction_name,t.transaction_code,t.transaction_date,t.transactions_type,
	 t.transaction_descriptions,
	 g.gl_name,t.Debit,t.credit,t.gl_id
	  from 
	   transactions t
	  join gl g on g.gl_id=t.gl_id
	  join users u on u.user_id = t.user_id 
	   order by t.transaction_id
	  
	   
	  join transactions t on t.linking_transaction_id = p.purchase_id 
	  join gl g on g.gl_id = t.gl_id
	  join items i on i.item_id = p.item_id 
	  order by transaction_Id DESC