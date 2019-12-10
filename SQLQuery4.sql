create table gl(
gl_id integer identity primary key , 
gl_name national character varying(max),
gl_code national character varying(max),
gl_master_type  national character varying(max)
);

select * from gl
insert into gl(gl_name,gl_code,gl_master_type) select 'Sold of item','sold','cash in hand'

create table purchases(
purchase_id integer identity primary key ,
purchase_name national character varying(max),
user_id integer not null,
item_id integer not null,
quantity integer not null,
price integer,
purchase_date datetimeoffset not null
);

update items set group_id=8 where user_id=4

 create table transactions(
 transaction_id integer identity primary key  ,
 transaction_name national character varying(max),
 transaction_code national character varying(max),
 gl_id integer not null ,
 transaction_date datetimeoffset not null,
 Debit DECIMAL(19,4) ,
 credit DECIMAL(19,4),
 transactions_type national character varying(max) not null,
 created_on datetimeoffset not null
 );


 select '10000000000055511.20000000022' decimal(19,4)
