using System.ComponentModel.DataAnnotations;

namespace LoanManagementWeb.Models
{
    // ── User ────────────────────────────────────────────────────────────────
    public class User
    {
        public int    UserID   { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role     { get; set; } = "";
    }

    // ── Login View Model ────────────────────────────────────────────────────
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Please select a role.")]
        public string Role { get; set; } = "";
    }

    // ── Customer ────────────────────────────────────────────────────────────
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "National ID / TRN is required.")]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$",
            ErrorMessage = "National ID must be in format: 123-45-6789")]
        [Display(Name = "National ID / TRN")]
        public string NationalID { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{7,15}$",
            ErrorMessage = "Phone must contain 7–15 digits only.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = "";

        [Required(ErrorMessage = "Employment status is required.")]
        [Display(Name = "Employment Status")]
        public string EmploymentStatus { get; set; } = "";

        [Required(ErrorMessage = "Monthly income is required.")]
        [Range(1, 10_000_000, ErrorMessage = "Monthly income must be between $1 and $10,000,000.")]
        [Display(Name = "Monthly Income ($)")]
        public decimal MonthlyIncome { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    // ── Loan ────────────────────────────────────────────────────────────────
    public class Loan
    {
        public int LoanID { get; set; }

        [Required(ErrorMessage = "Please select a customer.")]
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        public string CustomerName { get; set; } = "";

        [Required(ErrorMessage = "Loan amount is required.")]
        [Range(100, 10_000_000, ErrorMessage = "Loan amount must be between $100 and $10,000,000.")]
        [Display(Name = "Loan Amount ($)")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "Interest rate is required.")]
        [Range(0.01, 100.0, ErrorMessage = "Interest rate must be between 0.01% and 100%.")]
        [Display(Name = "Interest Rate (%)")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Loan term is required.")]
        [Range(1, 360, ErrorMessage = "Loan term must be between 1 and 360 months.")]
        [Display(Name = "Loan Term (Months)")]
        public int LoanTermMonths { get; set; }

        [Required(ErrorMessage = "Application date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Application Date")]
        public DateTime ApplicationDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "";

        [Display(Name = "Remaining Balance")]
        public decimal RemainingBalance { get; set; }
    }

    // ── Payment ─────────────────────────────────────────────────────────────
    public class Payment
    {
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Please select a loan.")]
        [Display(Name = "Loan")]
        public int LoanID { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Amount paid is required.")]
        [Range(0.01, 10_000_000, ErrorMessage = "Payment amount must be greater than $0.")]
        [Display(Name = "Amount Paid ($)")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Remaining Balance ($)")]
        public decimal RemainingBalance { get; set; }
    }
}
