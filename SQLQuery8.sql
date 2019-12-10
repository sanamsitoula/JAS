create table Sales(
sale_id integer identity primary key ,
sale_name national character varying(max),
user_id integer ,
item_id integer,
quantity integer,
price integer, 
customer_id integer,sale_date datetimeoffset);


select * from purchases