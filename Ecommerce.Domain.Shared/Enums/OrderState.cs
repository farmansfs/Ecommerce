using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Shared.Enums
{
    public enum OrderState:byte
    {
        Initial = 0,
        Accepted = 1,
        Prepearing = 2,
        OnDelivery = 3,
        Delivered = 4,
        Rejected = 5
    }
}
