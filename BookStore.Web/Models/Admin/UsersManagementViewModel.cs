public class UsersManagementViewModel : IAdminTabViewModel
{
    public UsersManagementViewModel()
    {
        AdminTabsViewModel = new AdminTabsViewModel(AdminTabs.UsersManagement);
    }

    public AdminTabsViewModel AdminTabsViewModel { get; }
}