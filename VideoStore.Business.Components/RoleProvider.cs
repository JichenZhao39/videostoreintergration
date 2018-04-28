﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components
{
    public class RoleProvider : IRoleProvider
    {
        public List<Role> GetRolesForUser(Entities.User pUser)
        {
            return GetRolesForUserName(pUser.Name);
        }



        public List<Role> GetRolesForUserName(string pUserName)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                var lUser = lContainer.Users.Include("Roles").FirstOrDefault((pUser) => pUser.LoginCredential.UserName == pUserName);
                return lUser.Roles.ToList();
            }
        }
    }
}
