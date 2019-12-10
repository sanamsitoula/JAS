using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IItemServices
    {

        List<ItemViewModel> ListItem();
        bool AddItem(ItemViewModel model);
        bool EditItem(ItemViewModel model);
        bool DeleteItem(int id);
        ItemViewModel GetItemById(int id);
    }
}