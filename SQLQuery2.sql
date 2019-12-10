BEGIN 
	Go
 
		CREATE DATABASE JAS_1 
 


CREATE TABLE groupes (
group_id integer primary key identity,
group_name national character varying(200),
group_code national character varying(200),
user_id integer not null,
created_on datetimeoffset
);

insert into groupes(group_name,group_code,user_id,created_on) 
select 'taps','tp',1,'2018-01-01'

Select * From dbo.groupes

create table users(
user_id integer identity primary key ,
first_name national character varying(200),
last_name national character varying(300),
email_id national character varying(200),
dateofbirth datetimeoffset ,
password national character varying(300),
isEmailVerified bit not null,
ActivationCode uniqueidentifier not null ,
user_name national character varying(max)
  );

insert into users(first_name,password,user_name,isEmailVerified,ActivationCode)
select 'sanam','55e7SWdxJ1DujGv4M92++vGaEggvWdgwmHQUqG9i+I4=','sanam',0,'00000000-0000-0000-0000-000000000000'
 
 select * from users
  create table roles
  (
  
  role_id integer primary key identity,
  role_name  national character varying(max) ,
  role_code national character varying(max)

  );


  insert into roles(role_name) select 'agent'

  create table UserRoleAssigned
  (
  user_role_assigned_id integer primary key identity ,
  role_id integer not null ,
  user_id integer not null
  
  );

  insert into UserRoleAssigned(role_id,user_id) 
  select 3, 3
