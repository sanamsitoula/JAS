using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IJournalEntryServices
    {

        List<JournalEntryViewModel> ListJournalEntry(SearchViewModel vm);
        bool AddJournalEntry(List<JournalEntryViewModel> model);
     
    }
}