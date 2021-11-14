using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Transonline.Data;
using Transonline.Models.Authentication;

namespace Transonline.Services
{
    public class UserRoleProviderMVC : RoleProvider
    {

        private readonly TransonlineDbContext db = new TransonlineDbContext();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {

            //role roles = db.userrolemappings.firstordefault(a => a.registration.username == username).role;
            //var role = roles.name;
            //string[] listroles = new string[1];
            //listroles[0] = role;
            //return listroles;
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}