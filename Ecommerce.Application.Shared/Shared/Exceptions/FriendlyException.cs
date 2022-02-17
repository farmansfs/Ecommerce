using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Exceptions
{
    public class FriendlyException:Exception
    {
        public FriendlyException() : base() { }

        public FriendlyException(string message) : base(message) { }

        public FriendlyException(string message, string details) : base(message)
        {
            Details = details;
        }

        public FriendlyException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public string Details { get; }
    }
}
