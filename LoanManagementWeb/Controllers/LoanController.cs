using LoanManagementWeb.Data;
using LoanManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanManagementWeb.Controllers
{
    public class LoanController : Controller
    {
        private IActionResult? AuthCheck()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");
            return null;
        }

        private void PopulateCustomerDropdown(int? selectedId = null)
        {
            ViewBag.Customers = new SelectList(
                DataStore.Customers.Select(c => new { c.CustomerID, Name = c.FullName }),
                "CustomerID", "Name", selectedId);
        }

        // GET: /Loan
        public IActionResult Index(string? search, string? statusFilter)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            var list = DataStore.Loans.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                list = list.Where(l =>
                    l.CustomerName.ToLower().Contains(search) ||
                    l.LoanID.ToString().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "All")
                list = list.Where(l => l.Status == statusFilter);

            ViewBag.Search       = search;
            ViewBag.StatusFilter = statusFilter;
            ViewBag.Statuses     = new[] { "All", "Pending", "Active", "Paid", "Defaulted" };
            return View(list.ToList());
        }

        // GET: /Loan/Create
        public IActionResult Create()
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            PopulateCustomerDropdown();
            return View(new Loan { LoanID = DataStore.NextLoanID, ApplicationDate = DateTime.Today });
        }

        // POST: /Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan model)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            if (model.ApplicationDate.Date > DateTime.Today)
                ModelState.AddModelError("ApplicationDate", "Application date cannot be in the future.");

            if (!ModelState.IsValid)
            {
                PopulateCustomerDropdown(model.CustomerID);
                model.LoanID = DataStore.NextLoanID;
                return View(model);
            }

            var customer = DataStore.Customers.FirstOrDefault(c => c.CustomerID == model.CustomerID);
            model.LoanID           = DataStore.NextLoanID;
            model.CustomerName     = customer?.FullName ?? "";
            model.RemainingBalance = model.LoanAmount;

            DataStore.Loans.Add(model);
            TempData["Success"] = "Loan saved successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Loan/Edit/5
        public IActionResult Edit(int id)
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            var loan = DataStore.Loans.FirstOrDefault(l => l.LoanID == id);
            if (loan == null) return NotFound();
            PopulateCustomerDropdown(loan.CustomerID);
            return View(loan);
        }

        // POST: /Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Loan model)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            if (model.ApplicationDate.Date > DateTime.Today)
                ModelState.AddModelError("ApplicationDate", "Application date cannot be in the future.");

            if (!ModelState.IsValid)
            {
                PopulateCustomerDropdown(model.CustomerID);
                return View(model);
            }

            var existing = DataStore.Loans.FirstOrDefault(l => l.LoanID == model.LoanID);
            if (existing == null) return NotFound();

            var customer = DataStore.Customers.FirstOrDefault(c => c.CustomerID == model.CustomerID);
            model.CustomerName     = customer?.FullName ?? "";
            model.RemainingBalance = existing.RemainingBalance;

            DataStore.Loans.Remove(existing);
            DataStore.Loans.Add(model);
            TempData["Success"] = "Loan updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // POST: /Loan/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            DataStore.Loans.RemoveAll(l => l.LoanID == id);
            TempData["Success"] = "Loan deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
