using MealMateData;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
namespace MealMate.Contracts
{
    public interface IAdminService
    {
        bool IsAdminUser();
        IEnumerable<ApplicationUser> GetUserList();
        IEnumerable<IdentityRole> GetRolesList();
    }
}