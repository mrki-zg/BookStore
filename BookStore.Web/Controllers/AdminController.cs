using System.Threading.Tasks;
using BookStore.Web.Models.Admin;
using BookStore.Web.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index() {
            return RedirectToAction(nameof(UsersManagement));
        }

        public async Task<IActionResult> UsersManagement()
        {
            var users = await _userRepository.GetAll();
            return View(new UsersManagementViewModel(users));
        }
    }
}
