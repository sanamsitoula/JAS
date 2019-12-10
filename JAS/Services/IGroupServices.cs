
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JAS.ViewModels;

namespace JAS.Services
{
    public interface IGroupServices
    {

        List<GroupViewModel> ListGroup();
        bool AddGroup(GroupViewModel model);
       bool EditGroup(GroupViewModel model);
        bool DeleteGroup(int id);
       GroupViewModel GetGroupById(int id);
    }
}