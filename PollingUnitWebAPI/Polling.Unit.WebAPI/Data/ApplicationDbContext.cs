 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 using Polling.Unit.Repository.DBTableObjects;

namespace Polling.Unit.WebAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
         public virtual DbSet<UserInfo> USER_INFO { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}
 