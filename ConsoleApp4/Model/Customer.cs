using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Task.Model
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<Account> Accounts { get; set; }


        public Customer()
        {
            Accounts = new List<Account>();
        }

        // public List<Transaction> transactions { get; set; }

        //public Customer(a)
        //{
        //    transactions = new List<Transaction>();
        //}


        //protected readonly string FirstName, LastName, Age, Email, Password, PhonNumber;
        //protected int Amount = 0;
        //public string FName
        //{    
        //    get { return FirstName; }
        //}
        //public string LName
        //{
        //    get { return LastName; }
        //}
        //public string EM
        //{
        //    get { return Email; }
        //}
        //public string Pass
        //{
        //    get { return Password; }
        //}
        //public string Phone
        //{
        //    get { return PhonNumber; }
        //}
        //public int Am
        //{
        //    set { Amount = value; }
        //    get { return Amount; }
        //}
    }
    //public void Display()
    //{
    //    Console.WriteLine($"Customer Details: {FirstName} {LastName}");
    //}

}
