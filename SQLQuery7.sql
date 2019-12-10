select * from purchases
select * from items

select TOp 5(p.quantity), i.item_name from purchases p
join items i on i.item_id=p.item_id 
order by p.quantity desc
