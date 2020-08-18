using System.Collections.Generic;

namespace BookStore.Web.Models.Admin
{
    public class User
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }

    }
}
