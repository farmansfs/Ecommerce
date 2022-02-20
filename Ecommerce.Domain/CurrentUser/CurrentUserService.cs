using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Shared.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(ClaimsPrincipal user)
        {
            this.user = user;
        }
        public string GetCurrentUserId()
        {
            return user.Claims.FirstOrDefault(x=>x.Type == "sub")?.Value;
        }

        public string GetCurrentUserName()
        {
            return user.Identity.Name;
        }
    }
}
