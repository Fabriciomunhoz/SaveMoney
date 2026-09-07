using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; protected set; }
        public int CreatedBy { get; protected set; }
        public int ModifiedBy { get; protected set; }

        public void SetModified(int userId)
        {
            ModifiedDate = DateTime.Now;
            ModifiedBy = userId;
        }
    }
}
