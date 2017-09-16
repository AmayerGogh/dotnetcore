using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCneter.Services.Models
{
    public class UserGroupModel:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
