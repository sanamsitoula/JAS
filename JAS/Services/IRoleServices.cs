using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAS.Services
{
    public interface IRoleServices
    {
       // UserRole CreateOrUpdate(UserRole model);

        List<RolesViewModel> getAllDetails();
      List<RoleNamesViewModel> getAllRoleList();
     //  RolesViewModel getById(int id);
    }
}