using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class RoleEntity :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
