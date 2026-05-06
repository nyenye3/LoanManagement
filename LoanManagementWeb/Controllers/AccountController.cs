using LoanManagementWeb.Data;
using LoanManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementWeb.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = DataStore.Users.FirstOrDefault(u =>
                u.Username.Equals(model.Username.Trim(), StringComparison.OrdinalIgnoreCase) &&
                u.Password == model.Password &&
                u.Role     == model.Role);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username, password, or role.");
                return View(model);
            }

            // ── Session tracking ────────────────────────────────────────────
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role",     user.Role);
            HttpContext.Session.SetInt32("UserID",    user.UserID);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
