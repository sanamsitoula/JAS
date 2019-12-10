using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IPurchaseServices
    {

        List<PurchaseViewModel> ListPurchase(SearchViewModel vm);
        bool AddPurchase(List<PurchaseViewModel> model);
        List<ChartPurchaseViewModel> getChartTopItemPurchaseList();
        List<ChartSalePurchaseViewModel> getChartItemSalePurchaseList();
   //     List<PurchaseViewModel> ListPurchaseFromSearch(SearchViewModel sm);
        //bool EditGroup(GroupViewModel model);
        //bool DeleteGroup(int id);
        //GroupViewModel GetGroupById(int id);
    }
}