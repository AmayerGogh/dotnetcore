using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCneter.Services.Models;

namespace UserCneter.Services.Configs
{
    public class UserConfig: EntityTypeConfiguration<UserModel>
    {
        public UserConfig()
        {
            this.ToTable("T_Users");
            this.Property(it => it.PhoneNum).HasMaxLength(20).IsRequired();
            this.Property(it => it.NickName).HasMaxLength(20).IsRequired();
            this.Property(it => it.PasswordHash).HasMaxLength(30).IsRequired();
            this.Property(it => it.PasswordSalt).HasMaxLength(10).IsRequired();
            this.HasMany(it => it.UserGroups).WithMany(it => it.Users).Map(it => it.MapLeftKey("UserId").MapRightKey("UserGroupId").ToTable("T_GroupUserRelationships"));
        }
    }
}
