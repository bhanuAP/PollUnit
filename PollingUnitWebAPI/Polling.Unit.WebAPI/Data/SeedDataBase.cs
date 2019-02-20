using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Polling.Unit.Repository.DBTableObjects;

namespace Polling.Unit.WebAPI.Data
{
    public class SeedDataBase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            //var userManager = serviceProvider.GetRequiredService<UserInfo>();
            context.Database.EnsureCreated();

            //if (!context.USER_INFO.Any())
            //{
            //    UserInfo user = new UserInfo
            //    {   
            //        //Email = "a@b.com",
            //        //SecurityStamp = Guid.NewGuid().ToString(),
            //        USER_NAME = "Bhanu"
            //    };
            //    userManager.CreateAsync(user, "password");
            //}
        }
    }
}
