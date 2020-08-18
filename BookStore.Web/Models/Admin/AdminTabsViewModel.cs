public class AdminTabsViewModel
{
    public AdminTabsViewModel(AdminTabs adminTab)
    {
        ActiveAdminTab = adminTab;
    }

    public AdminTabs ActiveAdminTab { get; }
}