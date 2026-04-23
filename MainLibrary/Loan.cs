using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class Loan
    {
        private double loanAmount;
        private double interestRate;
        private int term;
        private DateTime applicationDate;


        // default constructor
        public Loan()
        {
            loanAmount = 50000;
            interestRate = 0.10;
            term = 3;
            applicationDate = new DateTime(2026, 3, 30);
        }
        // constructor 
        public Loan (double loanAmount, double interestRate)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate;
        }

        public Loan(double loanAmount, double interestRate, int term, DateTime applicationDate)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate;
            this.term = term;
            this.applicationDate = applicationDate;
        }

        // Properties
        public double LoanAmount { get; set; }

        public double InterestRate { get; set; }

        public int Term { get; set; }

        //Read-only property

        public DateTime ApplicationDate { get; }

       
        public double calculateInterest()
        {
            return loanAmount * interestRate; 
        }

        public double calculateTotalPayable()
        {
            return loanAmount + calculateInterest();
        }

        public double calculateMonthlyInstallment()
        {
            double total = loanAmount + (loanAmount *  interestRate);
            return total / term;
        }

        //non-static user defined methods that does not return a value

        public void DisplayLoanDetails()
        {
            Console.WriteLine("loanAmount:" + loanAmount);
            Console.WriteLine("Interest Rate" + interestRate);
            Console.WriteLine("Term" + term);
            Console.WriteLine("Application Date" + applicationDate);

        }

        public void DisplayMonthlyInstallment()
        {
            double monthlyInstallment = calculateMonthlyInstallment();
            Console.WriteLine( "Monthly Installment " + monthlyInstallment);
        }


       // object created *main*
        
        Loan loan1 = new Loan (150000, 0.05); 



    }
}
