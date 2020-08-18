using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookStore.Web.Validation;

namespace BookStore.Web.Models.Admin
{
    public class User
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ValidUserRole]
        public IList<string> Roles { get; set; }

    }
}
