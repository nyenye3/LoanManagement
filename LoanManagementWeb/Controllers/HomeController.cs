using LoanManagementWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            ViewBag.TotalCustomers  = DataStore.Customers.Count;
            ViewBag.TotalLoans      = DataStore.Loans.Count;
            ViewBag.ActiveLoans     = DataStore.Loans.Count(l => l.Status == "Active");
            ViewBag.TotalPayments   = DataStore.Payments.Count;
            ViewBag.TotalDisbursed  = DataStore.Loans.Sum(l => l.LoanAmount);
            ViewBag.TotalCollected  = DataStore.Payments.Sum(p => p.AmountPaid);

            return View();
        }
    }
}
