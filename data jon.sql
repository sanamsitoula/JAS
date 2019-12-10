select g.group_name,i.group_id,i.item_id,i.item_name,i.item_code,i.item_description,i.user_id,
i.item_unit,i.item_sp,i.item_cp,i.item_quantity,i.photo,i.created_on,
u.user_name
 from
 items i join groupes g on g.group_id = i.group_id
 join users u on u.user_id=i.user_id

 select * from items
