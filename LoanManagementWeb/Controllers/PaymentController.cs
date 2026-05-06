using LoanManagementWeb.Data;
using LoanManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanManagementWeb.Controllers
{
    public class PaymentController : Controller
    {
        private IActionResult? AuthCheck()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");
            return null;
        }

        private void PopulateLoanDropdown(int? selectedId = null)
        {
            ViewBag.Loans = new SelectList(
                DataStore.Loans
                    .Where(l => l.Status == "Active")
                    .Select(l => new
                    {
                        l.LoanID,
                        Display = $"Loan #{l.LoanID} – {l.CustomerName} (Balance: {l.RemainingBalance:C})"
                    }),
                "LoanID", "Display", selectedId);
        }

        // GET: /Payment
        public IActionResult Index(string? search)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            var list = DataStore.Payments.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                if (int.TryParse(search.Trim(), out int loanId))
                    list = list.Where(p => p.LoanID == loanId);
            }

            ViewBag.Search = search;
            return View(list.OrderByDescending(p => p.PaymentDate).ToList());
        }

        // GET: /Payment/Create
        public IActionResult Create()
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            PopulateLoanDropdown();
            return View(new Payment { PaymentDate = DateTime.Today });
        }

        // POST: /Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Payment model)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            var loan = DataStore.Loans.FirstOrDefault(l => l.LoanID == model.LoanID);

            if (loan == null)
                ModelState.AddModelError("LoanID", "Selected loan not found.");
            else if (model.AmountPaid > loan.RemainingBalance)
                ModelState.AddModelError("AmountPaid", $"Payment cannot exceed remaining balance ({loan.RemainingBalance:C}).");

            if (model.PaymentDate.Date > DateTime.Today)
                ModelState.AddModelError("PaymentDate", "Payment date cannot be in the future.");

            if (!ModelState.IsValid)
            {
                PopulateLoanDropdown(model.LoanID);
                return View(model);
            }

            loan!.RemainingBalance -= model.AmountPaid;
            if (loan.RemainingBalance <= 0) loan.Status = "Paid";

            model.PaymentID        = DataStore.NextPaymentID;
            model.RemainingBalance = loan.RemainingBalance;
            DataStore.Payments.Add(model);

            TempData["Success"] = $"Payment recorded. Remaining balance: {loan.RemainingBalance:C}";
            return RedirectToAction(nameof(Index));
        }
    }
}
