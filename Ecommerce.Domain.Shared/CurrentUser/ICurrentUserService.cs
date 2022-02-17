using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Shared.CurrentUser
{
    public interface ICurrentUserService
    {
        string GetCurrentUserId();
        string GetCurrentUserName();
    }
}
