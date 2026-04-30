using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class Payment
    {
        public int paymentId {  get; set; }
          public int loanId {  get; set; }
          public DateTime paymentDate {  get; set; }
          public decimal amountPaid {  get; set; }
          public decimal remainingBalance{  get; set; }
    }
}
