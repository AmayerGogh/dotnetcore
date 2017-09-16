using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserCneter.Services.Models;

namespace UserCneter.Services
{
    public class UserCenterContext:DbContext
    {
        public UserCenterContext():base("name=sqlserver")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserGroupModel> UserGroups { get; set; }
        public DbSet<AppInfoModel> AppInfos { get; set; }
    }
}
