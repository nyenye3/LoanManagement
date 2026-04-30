using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class Loan
    {

        /*private decimal loanAmount;
        private decimal interestRate;
        private int term;
        private DateTime applicationDate;*/

        //Properties
        public int loanId { get; set; }
        public int customerId { get; set; }
        public decimal loanAmount { get; set; }
        public decimal interestRate { get; set; }
        public int loanTerm { get; set; }
        public DateTime applicationDate { get; set; }
        public string status { get; set; }



        // default constructor
        public Loan()
        {
            loanAmount = 50000;
            interestRate = 0.01m;
            loanTerm = 3;
            applicationDate = new DateTime(2026, 3, 30);
        }
        // constructors
        public Loan (decimal loanAmount, decimal interestRate)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate;
        }

        public Loan(decimal loanAmount, decimal interestRate, int loanTerm)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate;
            this.loanTerm = loanTerm;
        }


        public Loan(decimal loanAmount, decimal interestRate, int loanTerm, DateTime applicationDate)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate;
            this.loanTerm = loanTerm;
            this.applicationDate = applicationDate;
        }


       

        //Read-only property

        public DateTime ApplicationDate { get; }

       //non-static methods that returns value
        public decimal calculateInterest()
        {
            return loanAmount * interestRate; 
        }

        public decimal calculateTotalPayable()
        {
            return loanAmount + calculateInterest();
        }

        public decimal calculateMonthlyInstallment()
        {
            decimal total = loanAmount + (loanAmount *  interestRate);
            return total / loanTerm;
        }

        //non-static user defined methods that does not return a value

        public void DisplayLoanDetails()
        {
            Console.WriteLine("loanAmount:" + loanAmount);
            Console.WriteLine("Interest Rate" + interestRate);
            Console.WriteLine("Term" + loanTerm);
            Console.WriteLine("Application Date" + applicationDate);

        }

        public void DisplayMonthlyInstallment()
        {
            decimal monthlyInstallment = calculateMonthlyInstallment();
            Console.WriteLine( "Monthly Installment " + monthlyInstallment);
        }


       // object created *main*
        
        //Loan loan1 = new Loan (150000, 0.05m); 

        public static void LoanMessage()
        {
            Console.WriteLine("Welcome to the Loan Managment System");
        }

    }
}
