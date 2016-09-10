using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SimpleAtm;
using System.Threading.Tasks;

namespace SimpleAtm
{
    class SimplerATM
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, What is your name? ");
            string username = Console.ReadLine();
            SimplerATM usermen = new SimplerATM();
            usermen.userMenu();

          

        }



        public void collectUserInput()
        {
            string x = Console.ReadLine();
            int userMenuChoice;


            if (int.TryParse(x, out userMenuChoice) && userMenuChoice >= 1 && userMenuChoice <= 4)

            {
                int selection = userMenuChoice;
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Checking Balance");
                        calculateCurrentBalance();
                        break;
                    case 2:
                        HandleDeposits D = new HandleDeposits();
                        D.deposit();
                        break;
                    case 3:
                        Console.WriteLine("Handling Withdrawal");
                        break;
                    case 4:
                        Console.WriteLine("Quiting the application\n Thank you");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Not sure what you want, select again");
                        userMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("You Entered {0}", x);
                Console.WriteLine("Kindly choose from (1,2,3 or 4)");
            }
        }

        //public void deposit()
        //{
        //    double userTotalDepositAmount = 0;
        //    int depositFrequency = 0;

        //    //for (int count = 1; count < MAXDEPOSITFREQPERDAY;) //check frequency of deposit, should not be greater than 4 
        //    while (depositFrequency < MAXDEPOSITFREQPERDAY)
        //    {
        //        Console.WriteLine("How Much would you want to deposit ? ");
        //        string userdepositAmount = Console.ReadLine();
        //        double depositValue;
        //        if (double.TryParse(userdepositAmount, out depositValue) && depositValue <= MAXDEPOSITPERTRANSACTION)
        //        {
        //            double currentTotalDeposit = userTotalDepositAmount + depositValue;
        //            if (currentTotalDeposit <= MAXDEPOSITVALUEPERDAY)
        //            //                    userDepositAmount = depositValue;
        //            {
        //                Console.WriteLine("you deposited {0} ", depositValue);
        //            }
        //            else
        //            {
        //                Console.WriteLine("You have exceeded the maximum deposits value per day");
        //            }
        //        }

        //        else

        //        {
        //            Console.WriteLine("Sorry, You exceeded the maximum allowed deposit per Transaction\n");
        //        }
        //        depositFrequency = (depositFrequency + 1);
        //        break;
        //    }

        //    userMenu();
        //    //return userDepositAmount;
        //}


        public void userMenu()
        {
            Console.WriteLine("Welcome x : What would you like to do ? \n 1. Check Balance \n 2. Deposit \n 3. Withdraw \n 4. Quit");
            collectUserInput();
        }

        public double calculateCurrentBalance()
        {
            double TotalDeposits = 0;
            double totalWithdrawals = 0;
            double currentBalance = TotalDeposits - totalWithdrawals;
            return currentBalance;


        }
    }
}


public class HandleDeposits
{
    public const int MAXDEPOSITVALUEPERDAY = 150000;
    public const int MAXDEPOSITPERTRANSACTION = 40000;
    public const int MAXDEPOSITFREQPERDAY = 4;
    
    public void deposit()
    {
        SimplerATM SA = new SimplerATM();

        double userTotalDepositAmount;
        int depositFrequency = 0;

        //for (int count = 1; count < MAXDEPOSITFREQPERDAY;) //check frequency of deposit, should not be greater than 4 
        while (depositFrequency < MAXDEPOSITFREQPERDAY)
        {
            Console.WriteLine("How Much would you want to deposit ? ");

            string userdepositAmount = Console.ReadLine();
            double depositValue;
            double currentTotalDeposit = 0;
            if (double.TryParse(userdepositAmount, out  depositValue) && depositValue <= MAXDEPOSITPERTRANSACTION)
            {
                currentTotalDeposit += depositValue;

                if (currentTotalDeposit <= MAXDEPOSITVALUEPERDAY)
                //                    userDepositAmount = depositValue;
                {
                    Console.WriteLine("you deposited {0} \nYour current Total Deposits is {1}\n", depositValue,currentTotalDeposit);
                    //Console.WriteLine("");
                                      
                }
                else
                {
                    Console.WriteLine("You have exceeded the maximum deposits value per day");
                }
            }
            else
            {
                Console.WriteLine("Sorry, You exceeded the maximum allowed deposit per Transaction\n");
            }

            
            depositFrequency = (depositFrequency + 1);
            SA.userMenu();
        }

    }


}