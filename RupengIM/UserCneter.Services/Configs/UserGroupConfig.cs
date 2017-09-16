using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCneter.Services.Models;

namespace UserCneter.Services.Configs
{
    public class UserGroupConfig:EntityTypeConfiguration<UserGroupModel>
    {
        public UserGroupConfig()
        {
            this.ToTable("T_UserGroups");
            this.Property(it => it.Name).HasMaxLength(20).IsRequired();
        }
    }
}
