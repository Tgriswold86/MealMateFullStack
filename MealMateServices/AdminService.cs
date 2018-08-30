using Microsoft.AspNet.Identity.EntityFramework;
using MealMate.Data;
using MealMateContracts;
using MealMate.Models.AdminModels;
using Microsoft.Owin;
using System.Collections.Generic;
using System;
using System.Linq;
using MealMate.Contracts;
using MealMateData;

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
            throw new NotImplementedException();
        }

        IEnumerable<MealMateData.ApplicationUser> IAdminService.GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}