using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    [DebuggerDisplay("Entity - {Id}")]
    public class Entity: Entity<Guid>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }

    [DebuggerDisplay("Entity - {Id}")]
    public class Entity<T>
    {
        public T Id { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
