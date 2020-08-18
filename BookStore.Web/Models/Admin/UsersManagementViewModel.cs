using System.Collections.Generic;

namespace BookStore.Web.Models.Admin
{
    public class UsersManagementViewModel : IAdminTabViewModel
    {
        public UsersManagementViewModel(IList<User> users)
        {
            Users = users;
            AdminTabsViewModel = new AdminTabsViewModel(AdminTabs.UsersManagement);
        }

        public AdminTabsViewModel AdminTabsViewModel { get; }

        public IList<User> Users { get; }
    }
}