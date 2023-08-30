using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Task.Model
{
    internal class Account
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }

        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> transactions { get; set; }

        public Account()
        {
            transactions = new List<Transaction>();
        }


    }
}
