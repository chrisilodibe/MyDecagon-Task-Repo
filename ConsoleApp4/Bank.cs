using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Week_2_Task.Model;
using static System.Formats.Asn1.AsnWriter;
//sing System.Security.Cryptography;

namespace Week_2_Task
{
    internal class Bank
    {
        List<Customer> customers;

        public Bank()
        {
            customers = new List<Customer>();

        }



        // helpr methods
        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomerByAccountNumber(string accountNumberToFind)
        {
            return customers.FirstOrDefault(customer => customer.Accounts.Any(account => account.AccountNumber == accountNumberToFind));
        }


        // Operation methods

        public void StartBank()
        {
            Console.WriteLine("WELCOME TO ILODIBE ONYEDIKA BANK OF AFRICA");

            int choice = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter your Choice");

                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Logout");
                string Input = Console.ReadLine();
                while (!int.TryParse(Input, out choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Your Choice should be a whole number be between the option 1 to 3");
                    Console.WriteLine("Enter Your Choice");
                    Input = Console.ReadLine();
                }

                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        Console.WriteLine("Logout");
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (choice != 3);

        }

        public string GenerateAccountNumber(string accountType)
        {
            //string prefix = accountType;
            Random rand = new Random();
            int randomNumber = rand.Next(); // Generate a random 4-digit number
            string accountNumber = string.Empty;
            switch (accountType.ToLower())
            {
                case "savings":
                    accountNumber = "0" + randomNumber.ToString().Substring(0, 9);
                    break;
                case "current":
                    accountNumber = "1" + randomNumber.ToString().Substring(0, 9);
                    break;
                default:
                    Console.WriteLine("select an account type");
                    break;
            }
            return accountNumber;

        }
        public void CreateAccount()
        {
            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine().Trim().ToUpper();
            while (!validations.IsValidFirstName(firstName))
            {
                Console.WriteLine("wrong format, Name cannot be a number or empty");
                Console.WriteLine("Enter your First Name");
                firstName = Console.ReadLine().Trim().ToUpper();
            }
            Console.Clear();

            Console.Write("Enter your Last Name: ");
            string lastName = Console.ReadLine().Trim();
            while (!validations.IsValidlastName(lastName))
            {
                Console.WriteLine("wrong format, Name cannot be a number or empty");
                Console.WriteLine("Enter your Last Name");
                lastName = Console.ReadLine().Trim();
            }
            Console.Clear();

            Console.Write("Enter your Email Address: ");
            string email = Console.ReadLine().ToLower();
            while (!validations.IsValidEmail(email))
            {
                Console.WriteLine("Valid email address.");
                Console.WriteLine("Invalid email address, please follow the standard email format eg. Ik@dove.com");
                Console.WriteLine("Enter your Email Address");
                email = Console.ReadLine();
            }
            Console.Clear();

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            while (!validations.IsPasswordValid(password))
            {
                Console.WriteLine("Password is valid.");
                Console.WriteLine("Password should be minimum 6 characters that include alphanumeric and at least one special characters (@, #, $, %, ^, &, !)");
                Console.WriteLine("Enter Your password");
                password = Console.ReadLine();
            }
            Console.Clear();

            Console.Write("Enter your Phone Number: ");
            string phoneNo = Console.ReadLine();
            while (!validations.IsValidPhone(phoneNo))
            {
                Console.WriteLine("Entry should not be 0 or greater than 11 Digits");
                Console.WriteLine("Enter Your Phone Number");
                phoneNo = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Enter your Account Choice");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Current");
            int choice = int.Parse(Console.ReadLine());
            string accountType = string.Empty;
            switch (choice)
            {
                case 1:
                    accountType = "Savings";
                    break;
                case 2:
                    accountType = "Current";
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
            Console.Clear();

            Console.Write("Enter your initial Deposit: ");
            string Balance = (Console.ReadLine());
            decimal balance;
            while (!decimal.TryParse(Balance, out balance))
            {
                Console.WriteLine("Your initial deposit should be a number and not a word");
                Console.WriteLine("Enter Your Initial Deposit");
                Balance = Console.ReadLine();
            }
            Console.Clear();

            Customer customer = new Customer()
            {
                Name = $"{firstName} {lastName}",
                Email = email,
                Password = password,
                PhoneNumber
                = phoneNo,
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountName = $"{firstName} {lastName}",
                        AccountNumber = GenerateAccountNumber(accountType),
                        AccountType = accountType,
                        Balance = balance,
                        transactions = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                Date = DateTime.Now,
                                Description = $"Initial deposit {balance}",
                                Amount = balance,
                                Balance=balance,
                            }

                        }
                    }
                }
            };

            AddCustomer(customer);


            Console.WriteLine(" ACCOUNT CREATED SUCCESSFULLY");
            Console.WriteLine("|--------------------------------------------------------------------|");
            Console.WriteLine("|   Name           | Account Number | Account Type |     Balance     |");
            Console.WriteLine("|------------------|----------------|--------------|-----------------|");
            Console.WriteLine($"| {customer.Name,-8} | {customer.Accounts[0].AccountNumber,-14} | {customer.Accounts[0].AccountType,-12} | {customer.Accounts[0].Balance,14:C2} |");
            Console.WriteLine("----------------------------------------------------------------------");

        }

        public void CreateAccount(Customer customer)
        {
            Console.Write("Enter your Full Name: ");
            string fullName = Console.ReadLine();

            var existingCustomer = GetCustomers().FirstOrDefault(c => c.Accounts.Any(n => n.AccountName == fullName));

            if (existingCustomer != null)
            {
                string newAccountNumber = string.Empty;
                string newAccountType = string.Empty;
                var existingAccounts = customer.Accounts;


                decimal balance = 0;

                if (existingAccounts.Count == 2)
                {

                    Console.WriteLine("You cannot have more than two accounts");
                }
                else
                {
                    var accountType = existingAccounts.First().AccountType;

                    if (accountType.Equals("Savings"))
                    {
                        Console.WriteLine("You already have a Savings Account");
                        Console.WriteLine("You can only add a Current Account");
                        newAccountType = "Current";
                        newAccountNumber = GenerateAccountNumber(newAccountType);
                        Console.WriteLine("Enter your initial Deposit");
                        balance = decimal.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("You already have a Current Account");
                        Console.WriteLine("You can only add a Savings Account");
                        newAccountType = "Savings";
                        newAccountNumber = GenerateAccountNumber(newAccountType);
                        Console.WriteLine("Enter your initial Deposit");
                        string Balance = (Console.ReadLine());
                        while (!decimal.TryParse(Balance, out balance))
                        {
                            Console.WriteLine("Your initial deposit should be a number and not a word");
                            Console.WriteLine("Enter Your Initial Deposit");
                            Balance = Console.ReadLine();
                        }
                    }


                    customer.Accounts.Add(
                        new Account()
                        {
                            AccountName = customer.Name,
                            AccountNumber = newAccountNumber,
                            AccountType = newAccountType,
                            Balance = balance,
                            transactions = new List<Transaction>()
                            {
                            new Transaction()
                            {
                                Date = DateTime.Now,
                                Description = $"Initial deposit {balance}",
                                Amount = balance,
                                Balance=balance,
                            }

                            }
                        }
                        );

                    Console.WriteLine(" ACCOUNT CREATED SUCCESSFULLY");
                    Console.WriteLine("|----------------------------------------------------------------------------|");
                    Console.WriteLine("|         Name     |   Account Number   |   Account Type    |   Balance      |");
                    Console.WriteLine("|------------------|--------------------|-------------------|----------------|");
                    Console.WriteLine($"| {customer.Name,-8} | {newAccountNumber,-18} | {newAccountType,-17} | {balance,14:C2} |");
                    Console.WriteLine("------------------------------------------------------------------------------");

                }


            }




        }

        public void Login()
        {
            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            Console.Clear();

            Customer customer = GetCustomers().FirstOrDefault(c => c.Email == email && c.Password == password);

            if (customer != null)
            {
                int choice = 0;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter your Choice");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Transfer");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Check Balance");
                    Console.WriteLine("5. Print Statment");
                    Console.WriteLine("6. Create Another Account");
                    Console.WriteLine("7. Exit");
                    string Input = Console.ReadLine();
                    while (!int.TryParse(Input, out choice) || choice < 0 || choice > 7)
                    {
                        Console.WriteLine("Your Choice should be a whole number be between the option 1 to 7");
                        Console.WriteLine("Enter Your Choice");
                        Input = Console.ReadLine();
                    }

                    switch (choice)
                    {
                        case 1:
                            Deposit();
                            break;
                        case 2:
                            Transfer();
                            break;
                        case 3:
                            Withdrawal();
                            break;
                        case 4:
                            CheckBalance(customer);
                            break;
                        case 5:
                            PrintStatement(customer);
                            break;
                        case 6:
                            CreateAccount(customer);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                } while (choice != 7);
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            Console.WriteLine();
        }
        public void Deposit()
        {
            Console.WriteLine("Enter your account Number");
            string accountNumber = Console.ReadLine();
            Account customerAccount = GetCustomerByAccountNumber(accountNumber).Accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);

            //Console.WriteLine(customerAccount.Balance);
            Console.WriteLine("Enter amount to deposit");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (amount > 0 && customerAccount != null)
            {
                customerAccount.Balance += amount;
                Console.WriteLine();
                Console.WriteLine($"Deposited : {amount}");
                Console.WriteLine("Deposit Successful");
                //Console.WriteLine(customerAccount.Balance);

                customerAccount.transactions.Add(
                    new Transaction()
                    {
                        Date = DateTime.Now,
                        Description = $"Deposit {amount}",
                        Amount = amount,
                        Balance = customerAccount.Balance
                    }
                    );
            }
            else
            {
                Console.WriteLine("Invalid Deposit Amount.");
            }

        }

        public void Withdrawal()
        {
            Console.WriteLine("Enter your account Number");
            string accountNumber = Console.ReadLine();
            Account customerAccount = GetCustomerByAccountNumber(accountNumber).Accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);

            //Console.WriteLine(customerAccount.Balance);
            Console.WriteLine("Enter amount to withdraw");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (amount > 0 && customerAccount.Balance > amount && customerAccount != null)
            {
                customerAccount.Balance -= amount;
                Console.WriteLine($"Withdraw : {amount}");
                Console.WriteLine("Withdrawal Successful");
                //Console.WriteLine(customerAccount.Balance);

                customerAccount.transactions.Add(
                    new Transaction()
                    {
                        Date = DateTime.Now,
                        Description = $"Withdraw {amount}",
                        Amount = amount,
                        Balance = customerAccount.Balance
                    }
                    );
            }
            else
            {
                Console.WriteLine("Invalid Withdraw Amount.");
            }
        }
        public void Transfer()
        {
            Console.WriteLine("Enter Senders account Number");
            string SenderAccountNumber = Console.ReadLine();
            Account SenderAccount = GetCustomerByAccountNumber(SenderAccountNumber).Accounts.FirstOrDefault(account => account.AccountNumber == SenderAccountNumber);

            Console.WriteLine("Enter Recievers account Number");
            string RecieversAccountNumber = Console.ReadLine();
            Account RecieverAccount = GetCustomerByAccountNumber(RecieversAccountNumber).Accounts.FirstOrDefault(account => account.AccountNumber == RecieversAccountNumber);

            Console.WriteLine("Enter amount to Transfer");
            decimal amount = decimal.Parse(Console.ReadLine());


            if (amount > 0 && SenderAccount.Balance > amount && SenderAccount != null && RecieverAccount != null)
            {
                if (SenderAccountNumber.StartsWith('1') && SenderAccount.Balance < 1000)
                {
                    Console.WriteLine("Insufficient Balance");
                }

                SenderAccount.Balance -= amount;

                //Console.WriteLine(customerAccount.Balance);

                SenderAccount.transactions.Add(
                    new Transaction()
                    {
                        Date = DateTime.Now,
                        Description = $"transfer {amount} to {RecieverAccount.AccountName}({RecieverAccount.AccountNumber})",
                        Amount = amount,
                        Balance = SenderAccount.Balance
                    }
                    );

                RecieverAccount.Balance += amount;
                //Console.WriteLine(customerAccount.Balance);
                RecieverAccount.transactions.Add(
                    new Transaction()
                    {
                        Date = DateTime.Now,
                        Description = $"Received {amount} from {SenderAccount.AccountName} ({SenderAccount.AccountNumber})",
                        Amount = amount,
                        Balance = RecieverAccount.Balance
                    }
                    );
                Console.WriteLine($"Transfer amount : {amount}");
                Console.WriteLine("Transfer Successful");

            }
            else
            {
                Console.WriteLine("Transfer not successful.");
            }


        }


        public void CheckBalance(Customer customer)
        {
            Console.WriteLine("Enter the Account Number");
            string accountNumber = Console.ReadLine();

            var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {

                Console.WriteLine(" ----------------------------------------------------------------------");
                Console.WriteLine(" |    ACCOUNT NAME  | ACCOUNT TYPE | ACCOUNT NUMBER |      BALANCE    |");
                Console.WriteLine(" ----------------------------------------------------------------------");
                Console.WriteLine(" |                  |              |                |                 |  ");
                Console.WriteLine($" | {account.AccountName,-13} | {account.AccountType,-12} | {account.AccountNumber,-14} | {account.Balance,-16}|");
                Console.WriteLine(" |                  |              |                |                 |");
                Console.WriteLine(" ----------------------------------------------------------------------");
            }
            else
                Console.WriteLine("Account Not Fount");

        }

        public void PrintStatement(Customer customer)
        {
            Console.WriteLine($"ACCOUNT STATEMENT");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Account Name  |  Account Number  |  Account Type  |  Balance   |  Description         |  Amount    |   Date           |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");

            foreach (var account in customer.Accounts)
            {
                foreach (var transaction in account.transactions)
                {
                    Console.WriteLine($"| {customer.Name,-13} | {account.AccountNumber,-16} | {account.AccountType,-14} |  {transaction.Balance,-5:C} | {transaction.Description,-12} | {transaction.Amount,-10:C} | {transaction.Date,4:yyyy-MM-dd HH:mm} |");
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            }
        }

    }
}



