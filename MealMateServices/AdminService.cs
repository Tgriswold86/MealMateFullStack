using Microsoft.AspNet.Identity.EntityFramework;
using MealMateData;
using MealMateContracts;
using MealMate.Models.AdminModels;
using Microsoft.Owin;
using System.Collections.Generic;
using System;
using System.Linq;
using MealMate.Contracts;
using Microsoft.AspNet.Identity;

namespace MealMate.Services
{
    public class AdminService : IAdminService
    {
        private readonly Guid _userId;

        public AdminService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<IdentityRole> GetRolesList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUserList()
        {
            using (var context = new ApplicationDbContext())
            {
                var userList = context.Users.ToList();
                return userList.ToArray();
            }
        }

        public bool IsAdminUser()
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var s = userManager.GetRoles(_userId.ToString());
                    if (s.Count != 0 && s[0].ToString() == "Admin")
                        return true;
                    else
                        return false;
                }

                catch (Exception)
                {
                    throw;
                }

            }
        }

        IEnumerable<MealMateData.ApplicationUser> IAdminService.GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}