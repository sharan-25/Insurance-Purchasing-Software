using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class User : Person
    {
        public int UsertId;     
        private string passwordCode;
        public List<InsuranceAgreement> agreements = new List<InsuranceAgreement>(); //  creating list of InsuranceAgreement data type
        public int year; // current year
        public double totalMoneyUser = 0; // total money collected by user
        public double totalPayoutUser = 0; // per year
        public int count = 0;
        public double totalPayoutsFromCanceledAgreements = 0; // per year
        public User(int id,int currentYear) //Constructor
        {
            UsertId = id;
            Console.Write("Enter the user name: ");
            string userName = stringCheck();
            name = userName;
            year = currentYear;
            Console.Write("Enter user passcode(in digit) 6 digits only: ");
            passwordCode = passcodeCheck();
        }
        
        public void mainmenu() // for main menu
        {
            Console.Write("Enter user passcode: ");
            string passcode = passcodeCheck();
            if (passcode != passwordCode)
            {
                Console.WriteLine("Incorrect passcode. Access Denied.");
                return;
            }
            while (true)
            {
                menu();
                int choice = readInt();
                Console.WriteLine();
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        totalMoneyDisplay();
                        break;
                    case 2:
                        receiveNewApplications();
                        break;
                    case 3:
                        displayInsuranceAgreements();
                        break;
                    case 4:
                        displayFinancialBreakdown();
                        break;
                    case 5:
                        breakInsuranceAgreements();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            }
        }
        public void menu() // for displaying menu
        {
            Console.WriteLine("Current Year: " + year);
            Console.WriteLine("User name: " + name);
            Console.WriteLine("1. For displaying total money");
            Console.WriteLine("2. Receive new applications");
            Console.WriteLine("3. See all current insurance agreements");
            Console.WriteLine("4. See financial breakdown");
            Console.WriteLine("5. Break insurance agreement");
            Console.WriteLine("0. Return to main menu");
            Console.Write("Enter your choice (1-6): ");
        }
        private int readInt() // for int data validation
        {
            int data = 0;
            bool valid = true;
            while (valid)
            {
                try
                {
                    data = int.Parse(Console.ReadLine());
                    valid = false;
                }
                catch (FormatException)
                {
                    Console.Write("Please enter an integer: ");
                    valid = true;
                }
            }
            return data;
        }
        private string stringCheck() // for checking that string have only alphabets
        {
            string data = " ";
            bool loop = true;
            while (loop)
            {
                data = Console.ReadLine();
                if (string.IsNullOrEmpty(data))
                {
                    Console.Write("Please enter the alphabets value only: ");
                    loop = true;
                }
                else
                {
                    bool check = true;
                    for (int i = 0; i < data.Length; i++) // Checking every element from string whether it is alphabet or not
                    {
                        char c = data[i];
                        if (!Char.IsLetter(c)) // if element is not alphabet then ask user again and breaking the for loop
                        {
                            check = false;
                            Console.Write("Please enter the alphabets value only: ");
                            break;
                        }
                    }
                    if (check) // if string is not null and it only contains alphabet then it is valid input. And breaking while loop
                    {
                        loop = false;
                    }
                }
            }
            return data;
        }
        private string passcodeCheck() // for checking that string have only alphabets
        {
            string data = " ";
            bool loop = true;
            while (loop)
            {
                data = Console.ReadLine();
                if (string.IsNullOrEmpty(data))
                {
                    Console.Write("Please enter the 6 digit only: ");
                    loop = true;
                }
                else if (data.Length != 6)
                {
                    Console.Write("Please enter the 6 digit only: ");
                }
                else
                {
                    bool check = true;
                    for (int i = 0; i < data.Length; i++) // Checking every element from string whether it is alphabet or not
                    { 
                        char c = data[i];
                        if (!Char.IsDigit(c)) // if element is not digit then ask user again and breaking the for loop
                        {
                            check = false;
                            Console.Write("Please enter the alphabets value only: ");
                            break;
                        }
                    }
                    if (check) // if string is not null and it only contains 6 digit then it is valid input. And breaking while loop
                    {
                        loop = false;
                    }
                }
            }
            return data;
        }
        public void totalMoneyDisplay() // for displaying total money collected by user
        {
            Console.WriteLine("Total Money made by this user = " + totalMoneyUser);
        }
        public void receiveNewApplications() // for generating 6 different application
        {
            if (agreements.Count == 20)
            {
                Console.WriteLine("User already have 20 Insurance Agreements. Rseach to limit");
                return;
            }
            Console.WriteLine("New Insurance applications:");
            //Generating new applications and storing it in newApplications list
            List<InsuranceAgreement> newApplication = new List<InsuranceAgreement>();
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                //generating new 6 objects
                newApplication.Add(new InsuranceAgreement(random.Next()));
            }
            while (newApplication.Count != 0)
            {
                bool cancel = menuNewApplication(newApplication);

                if (newApplication.Count == 0)
                {
                    Console.WriteLine("All 6 applications are over");
                    break;
                }

                if (cancel)
                {
                    break;
                }
            }
        }
        public bool menuNewApplication(List<InsuranceAgreement> newApplication) // for displaying generated application
        {
            //Displaying new generated applications
            for (int i = 0; i < newApplication.Count; i++)
            {
                Console.WriteLine((i + 1) + ".\nClient: " + newApplication[i].client.name);
                Console.WriteLine("Yearly Fee: " + newApplication[i].yearlyFee);
                Console.WriteLine("Risk: " + newApplication[i].risk);
                Console.WriteLine("Insurance amount: " + newApplication[i].insuranceAmount);
                Console.WriteLine();
            }

            //Ask user to accpet an application
            int choose;
            Console.Write("Select an application to accept (0 to cancel): ");
            choose = readInt();
            Console.WriteLine();

            if (choose >= 1 && choose <= newApplication.Count)
            {
                agreements.Add(newApplication[choose - 1]);//adding the selected application in agreements list
                totalMoneyUser += newApplication[choose - 1].yearlyFee; // adding yearly Fee in total Money
                newApplication.RemoveAt(choose - 1); // removing the selected application from the menu 
                count++; // counting the number of clients
                return false;
            }
            else if (choose != 0)
            {
                Console.WriteLine("Invalid choice.");
                return false;
            }
            return true;
        }
        public void displayInsuranceAgreements() //for displaying all Insurance Agreements
        {
            if (agreements.Count == 0) // if user have no agreements then can't perform this function
            {
                Console.WriteLine("You have no insurance agreements.");
                return;
            }

            Console.WriteLine("No.\tClient\t\tYearly Fee\tRisk\tInsurance Amount\t\tNet Profit");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            for (int i = 0; i < agreements.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t" + agreements[i].client.name + "\t\t" + agreements[i].yearlyFee + "\t\t" + agreements[i].risk + "%\t" + agreements[i].insuranceAmount + "\t\t\t" + agreements[i].GetNetProfit());
            }
        }
        public double payoutChance() // Randomly get which client made claim
        {
            double totalPayouts = 0;
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].risk >= new Random().Next(1, 101) && agreements[i].isClaimed == false)
                {
                    agreements[i].totalPayout = agreements[i].insuranceAmount;
                    totalPayouts += agreements[i].totalPayout;
                    Console.WriteLine("Claim Paid for " + agreements[i].client.name + ": $" + agreements[i].insuranceAmount);
                    totalMoneyUser -= agreements[i].totalPayout;
                    agreements[i].isClaimed = true;
                }
            }
            return totalPayouts;
        }
        public void displayFinancialBreakdown() //For Financial Breakdown
        {
            if (agreements.Count == 0) // if user have no agreements then can't perform this function
            {
                Console.WriteLine("You have no insurance agreements.");
                return;
            }
            double totalNetProfit = 0;

            totalPayoutUser += payoutChance();

            Console.WriteLine("Total Payouts from Claims: $" + totalPayoutUser);

            Console.WriteLine("Total Payouts from Cancelled Agreement: $" + totalPayoutsFromCanceledAgreements);

            Console.WriteLine("Total income made : $" + totalMoneyUser);

            for (int i = 0; i < agreements.Count; i++)
            {
                totalNetProfit = agreements[i].GetNetProfit();
            }
            Console.WriteLine("Total breakdown of net profit per year: $" + totalNetProfit);

            double averageNetProfit = totalNetProfit / count;

            Console.WriteLine("Average net profit: $" + averageNetProfit);
        }
        public void breakInsuranceAgreements() //For break agreements
        {
            if (count == 0) // if user have no agreements then can't perform this function
            {
                Console.WriteLine("You have no insurance agreements.");
                return;
            }

            int choose = 0;
            while (true)
            {
                displayInsuranceAgreements();
                Console.Write("Enter the agreement number which you want to break (0 to cancel) :");
                choose = readInt();
                Console.WriteLine();

                if (choose >= 1 && choose <= agreements.Count)
                {
                    //double breakPay = agreements[choose-1].insuranceAmount;
                    totalPayoutsFromCanceledAgreements += agreements[choose - 1].yearlyFee * 10; // adding the payout in totalPayoutsFromCanceledAgreements
                    totalMoneyUser -= agreements[choose - 1].yearlyFee * 10; //Removing the payout from total Money
                    Console.WriteLine("You have to pay " + agreements[choose - 1].yearlyFee * 10 + " to " + agreements[choose - 1].client.name);
                    agreements.RemoveAt(choose - 1); // removing the selected application from the agreements
                }
                else if (choose == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
                Console.WriteLine();
            }
        }
        public void moveTimeForward(int nextYear)//for moving forward in year
        {
            totalPayoutUser += payoutChance();
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].isClaimed == true)
                {
                    Console.WriteLine("Paid $" + agreements[i].totalPayout + " to " + agreements[i].client.name + " for a claim on " + year);
                    agreements[i].isClaimed = false;
                    agreements[i].totalPayout = 0;
                }
                agreements[i].nextYearlyFee();
            }
            Console.WriteLine("Total amount of claims in year " + year + " from this user = " + totalPayoutUser);
            Console.WriteLine("Total money collected in year " + year + " from this user = " + totalMoneyUser);
            totalPayoutsFromCanceledAgreements = 0;
            totalPayoutUser = 0;
            count = agreements.Count;
            
            year = nextYear;
        }
        public void yearlyFeeNext() // for increasing yearly fee for next year
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                totalMoneyUser += agreements[i].yearlyFee;
            }
        }
    }
}
