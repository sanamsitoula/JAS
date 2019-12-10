 


CREATE TABLE items (
item_id integer primary key identity,
item_name national character varying(200),
item_code national character varying(200),

item_description national character varying(max),
photo national character varying(max),
group_id integer not null,
user_id integer not null ,
item_cp national character varying(200),
item_sp national character varying(200),
item_unit national character varying(200),
item_quantity integer default 1,
created_on datetimeoffset

);
