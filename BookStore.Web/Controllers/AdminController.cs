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

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(nameof(user));
            }

            await _userRepository.Update(user);

            return RedirectToAction(nameof(UsersManagement));
        }
    }
}
