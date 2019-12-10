using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IReportServices
    {

        List<GLedgerReportViewModel> ListGledger(SearchViewModel vm);
     
    }
}