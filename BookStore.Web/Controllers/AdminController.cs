using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() {
            return RedirectToAction(nameof(UsersManagement));
        }

        public IActionResult UsersManagement()
        {
            return View(new UsersManagementViewModel());
        }
    }
}
