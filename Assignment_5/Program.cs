using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Assignment_5
{
    public class InsuranceCompany
    {
        public static int UserIDSsequence = 1; // for user Id
        public static int currentYear = DateTime.Now.Year; // for system year
        public static double totalMoneyCompany = 0;
    }
    internal class Program
    {
        public static List<User> users = new List<User>(); //  creating list of User data type
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Buying Software");
            bool loop = true;
            while (loop)
            {
                Random rd = new Random();
                menu();
                int choose = readInt();
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        newUser();
                        break;
                    case 2:
                        displayUser();
                        break;
                    case 3:
                        userAgreement();
                        break;
                    case 4:
                        totalMoneyCal();
                        Console.WriteLine("Total Money made by insurance company " + InsuranceCompany.totalMoneyCompany);
                        break;
                    case 5:
                        movingForward();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                Console.WriteLine();
            }
        }
        public static void menu() // for displaying menu
        {
            Console.WriteLine("Current Year: " + InsuranceCompany.currentYear);
            Console.WriteLine("1. For a new user");
            Console.WriteLine("2. For display user details");
            Console.WriteLine("3. For display insurance agreement");
            Console.WriteLine("4. For display total money made by insurance company");
            Console.WriteLine("5. For moving forward by one year");
            Console.WriteLine("0. For exit");
            Console.Write("Enter you choice: ");
        }
        public static int readInt() // for int data validation
        {
            int data = 0;
            bool valid = true;
            while (valid)
            {
                data = 1;
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
                if (data < 0)
                {
                    Console.WriteLine("Please enter positive integer");
                    valid = true;
                }
            }
            return data;
        }
        public static void newUser() // for creating new user
        {
            users.Add(new User(InsuranceCompany.UserIDSsequence,InsuranceCompany.currentYear));
            InsuranceCompany.UserIDSsequence++;
        }
        public static void displayUser() // for displaying user details
        {
            if (users.Count == 0) // if there is no user then can't perform this function
            {
                Console.WriteLine("No user entered yet.");
                return;
            }
            for (int i = 0; i < users.Count;i++)
            {
                Console.WriteLine("User ID: " + (i + 1) + " \t" + "User Name:" + users[i].name);
            }
        }
        public static void userAgreement() // for displaying user agreement menu
        {
            if (users.Count == 0) // if there is no user then can't perform this function
            {
                Console.WriteLine("No user entered yet");
                return;
            }
            displayUser();
            Console.Write("\nEnter the user number of which you want to see insurance agreements (0 for exit): ");
            int user = 0;
            while (true)
            {
                user = readInt();
                if (user >= 1 && user <= users.Count)
                {
                    break;
                }
                else if (user == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter valid user ID.");
                }
            }
            Console.WriteLine();
            users[user - 1].mainmenu();
        }
        public static void totalMoneyCal() // for calculate total money made by company
        {
            InsuranceCompany.totalMoneyCompany = 0;
            for (int i = 0; i < users.Count; i++)
            {
                InsuranceCompany.totalMoneyCompany += users[i].totalMoneyUser;
            }
        }
        public static void movingForward() // for moving forward by one year
        {
            Console.WriteLine("Report of year " + InsuranceCompany.currentYear);
            InsuranceCompany.currentYear++;
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine("For user " + users[i].name);
                users[i].moveTimeForward(InsuranceCompany.currentYear);
            }
            totalMoneyCal();
            Console.WriteLine("\nTotal Money made by insurance company in year " + (InsuranceCompany.currentYear - 1) + " is = " + InsuranceCompany.totalMoneyCompany);
            for (int i = 0; i < users.Count; i++)
            {
                users[i].yearlyFeeNext();
            }
            Console.WriteLine("\nMoving time forward to year: " + InsuranceCompany.currentYear);
        }
    }
}