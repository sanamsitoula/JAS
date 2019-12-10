using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface ISalesServices
    {

        List<SalesViewModel> ListSale();
        bool AddSale(List<SalesViewModel> model);
        List<ChartSaleViewModel> getChartTopItemSaleList();
        //bool EditGroup(GroupViewModel model);
        //bool DeleteGroup(int id);
        //GroupViewModel GetGroupById(int id);
    }
}