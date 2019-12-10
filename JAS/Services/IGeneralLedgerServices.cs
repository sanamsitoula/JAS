using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IGeneralLedgerServices
    {

        List<GLViewModel> ListGL();
        bool AddGL(GLViewModel model);
        //bool EditGroup(GroupViewModel model);
        //bool DeleteGroup(int id);
        //GroupViewModel GetGroupById(int id);
    }
}