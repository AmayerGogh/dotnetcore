using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCneter.Services.Models;

namespace UserCneter.Services.Configs
{
    public class AppInfoConfig:EntityTypeConfiguration<AppInfoModel>
    {
        public AppInfoConfig()
        {
            this.ToTable("T_AppInfos");
            this.Property(it => it.Name).HasMaxLength(20).IsRequired();
            this.Property(it => it.AppKey).HasMaxLength(100).IsRequired();
            this.Property(it => it.AppSecret).HasMaxLength(100).IsRequired();
        }
    }
}
