using LoanManagementWeb.Models;

namespace LoanManagementWeb.Data
{
    public static class DataStore
    {
        public static List<User> Users { get; } = new()
        {
            new User { UserID = 1, Username = "admin",   Password = "admin123",   Role = "Admin"   },
            new User { UserID = 2, Username = "manager", Password = "manager123", Role = "Manager" },
            new User { UserID = 3, Username = "clerk",   Password = "clerk123",   Role = "Clerk"   }
        };

        public static List<Customer> Customers { get; } = new()
        {
            new Customer
            {
                CustomerID = 1, FirstName = "John", LastName = "Smith",
                NationalID = "123-45-6789", PhoneNumber = "8765550101",
                Email = "john.smith@email.com", Address = "10 Main St",
                EmploymentStatus = "Employed", MonthlyIncome = 5000
            },
            new Customer
            {
                CustomerID = 2, FirstName = "Maria", LastName = "Garcia",
                NationalID = "987-65-4321", PhoneNumber = "8765550202",
                Email = "maria.garcia@email.com", Address = "22 Oak Ave",
                EmploymentStatus = "Self-Employed", MonthlyIncome = 7500
            }
        };

        public static List<Loan> Loans { get; } = new()
        {
            new Loan
            {
                LoanID = 1, CustomerID = 1, CustomerName = "John Smith",
                LoanAmount = 10000, InterestRate = 5.5m, LoanTermMonths = 24,
                ApplicationDate = DateTime.Today.AddMonths(-6),
                Status = "Active", RemainingBalance = 7000
            }
        };

        public static List<Payment> Payments { get; } = new()
        {
            new Payment
            {
                PaymentID = 1, LoanID = 1,
                PaymentDate = DateTime.Today.AddMonths(-1),
                AmountPaid = 500, RemainingBalance = 7000
            }
        };

        public static int NextCustomerID => Customers.Count == 0 ? 1 : Customers.Max(c => c.CustomerID) + 1;
        public static int NextLoanID     => Loans.Count     == 0 ? 1 : Loans.Max(l => l.LoanID)         + 1;
        public static int NextPaymentID  => Payments.Count  == 0 ? 1 : Payments.Max(p => p.PaymentID)    + 1;
    }
}
