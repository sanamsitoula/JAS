BEGIN 
	Go
 
		CREATE DATABASE JAS_1 
 


CREATE TABLE groupes (
group_id integer primary key identity,
group_name national character varying(200),
group_code national character varying(200),
user_id integer not null,
created_on national character varying(200)
);

insert into groupes(group_name,group_code,user_id,created_on) 
select 'Basin','BS',1,'2018-01-01'



