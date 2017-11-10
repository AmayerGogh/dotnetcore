using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CREATEDATE { get; set; } = DateTime.Now;
        public bool ISDELETED { get; set; } = false;
    }
}
