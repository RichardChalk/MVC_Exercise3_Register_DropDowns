using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Register.ViewModels;

namespace Register.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create()
        {
            // This is where we fill the dropdowns with values
            var userVM = new CreateUserViewModel();
            userVM.Countries = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Sweden", Value = "SE"},
                new SelectListItem(){Text = "Norway", Value = "NO"},
                new SelectListItem(){Text = "Denmark", Value = "DK"},
                new SelectListItem(){Text = "Finland", Value = "FI"},
            };

            userVM.Countries.Insert(0, new SelectListItem
            {
                Text = "Choose a country...",
                Value = ""
            });

            userVM.UserTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Normal", Value = "N"},
                new SelectListItem(){Text = "Premium", Value = "P"},
                new SelectListItem(){Text = "VIP", Value = "VIP"},
            };

            userVM.UserTypes.Insert(0, new SelectListItem
            {
                Text = "Choose a user type...",
                Value = ""
            });

            return View(userVM);
        }

        [HttpPost]
        public IActionResult CreatePost(CreateUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Email = userVM.Email;
                user.Password = userVM.Password;
                user.FirstName = userVM.FirstName;
                user.LastName = userVM.LastName;
                user.CountryLabel = userVM.CountryLabel;
                user.UserTypeLabel = userVM.UserTypeLabel;

                // This is where we can save to the database (if we had one!)
                // _context.SaveChanges();

                return RedirectToAction("RegisterConfirmation");
            }

            return RedirectToAction("Create");
        }

        public IActionResult RegisterConfirmation()
        {
            return View();
        }
    }
}
