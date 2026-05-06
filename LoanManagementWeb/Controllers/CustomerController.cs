using LoanManagementWeb.Data;
using LoanManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementWeb.Controllers
{
    public class CustomerController : Controller
    {
        private IActionResult? AuthCheck()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");
            return null;
        }

        // GET: /Customer
        public IActionResult Index(string? search)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            var list = DataStore.Customers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                list = list.Where(c =>
                    c.FirstName.ToLower().Contains(search)   ||
                    c.LastName.ToLower().Contains(search)    ||
                    c.NationalID.ToLower().Contains(search)  ||
                    c.Email.ToLower().Contains(search));
            }

            ViewBag.Search = search;
            return View(list.ToList());
        }

        // GET: /Customer/Create
        public IActionResult Create()
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            return View(new Customer { CustomerID = DataStore.NextCustomerID });
        }

        // POST: /Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer model)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            // Uniqueness check for NationalID
            if (DataStore.Customers.Any(c => c.NationalID == model.NationalID))
                ModelState.AddModelError("NationalID", "A customer with this National ID already exists.");

            if (!ModelState.IsValid)
            {
                model.CustomerID = DataStore.NextCustomerID;
                return View(model);
            }

            model.CustomerID = DataStore.NextCustomerID;
            DataStore.Customers.Add(model);
            TempData["Success"] = "Customer saved successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Customer/Edit/5
        public IActionResult Edit(int id)
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            var customer = DataStore.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // POST: /Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer model)
        {
            var guard = AuthCheck(); if (guard != null) return guard;

            // Uniqueness check — exclude self
            if (DataStore.Customers.Any(c => c.NationalID == model.NationalID && c.CustomerID != model.CustomerID))
                ModelState.AddModelError("NationalID", "Another customer with this National ID already exists.");

            if (!ModelState.IsValid) return View(model);

            var existing = DataStore.Customers.FirstOrDefault(c => c.CustomerID == model.CustomerID);
            if (existing == null) return NotFound();

            DataStore.Customers.Remove(existing);
            DataStore.Customers.Add(model);
            TempData["Success"] = "Customer updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // POST: /Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var guard = AuthCheck(); if (guard != null) return guard;
            DataStore.Customers.RemoveAll(c => c.CustomerID == id);
            TempData["Success"] = "Customer deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
