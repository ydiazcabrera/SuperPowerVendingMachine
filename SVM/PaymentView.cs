using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SVM
{
    class PaymentView
    {
        // When user want to pay with a check
        public static void PayCheck()
        {
            string pattern = "^\\d{4}$";
            Regex rgx = new Regex(pattern);
            Console.Write($" Your total is: ${MenuView.FinalTotal} Please enter a check number: ");
            string userInput = Console.ReadLine().Trim();
            bool isMatch = rgx.IsMatch(userInput);
            
            // If the user enters a valid check number, print a receipt
            if(isMatch)               
            {
                ReceiptView.PrintReciept(VendingMachine.PurchasedItems); // final case
            }
            else
            {
                Console.WriteLine($"Your total is: ${MenuView.FinalTotal}. Please enter a valid chack number as a 4 digit integer. Please try again.");
                PayCheck();
            }
        }

        // When user want to pay with a credit card
        public static void PayCredit()
        {
            Console.Write($"Your total is: ${MenuView.FinalTotal}.");

            Regex ccNumRgx = new Regex("^\\d{16}$");
            Regex cvvRgx = new Regex("^\\d{3}$");
            Regex monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            Regex yearCheck = new Regex(@"^20[0-9]{2}$");

            bool validCcNum = false;
            bool validCvv = false;
            bool validExp = false;

            // Validate CCNum
            while (!validCcNum)
            {
                Console.Write("Please insert your credit card number: ");
                string ccNum = Console.ReadLine();
                bool isMatchCcNum = ccNumRgx.IsMatch(ccNum);

                if (isMatchCcNum)
                {
                    validCcNum = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Credit card must be 16 digits long and have no spaces.");
                }
            }

            //Validate CVV
            while (!validCvv)
            {
                Console.Write("Please enter your CVV: ");
                string cvv = Console.ReadLine();
                bool isMatchCvv = cvvRgx.IsMatch(cvv);

                if (isMatchCvv)
                {
                    validCvv = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. CVV must be 3 digits long and have no spaces.");
                }
            }

            // Validate ExpDate
            while (! validExp)
            {
                Console.Write("Please enter your expiration date: ");

                string expiryDate = Console.ReadLine();
                string[] dateParts = expiryDate.Split('/'); //expiry date in from MM/yyyy   

                // Validate month
                try
                {
                    if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) // <3 - 6>
                    {
                        Console.WriteLine("Invalid input. Please input as MM/YYYY"); // ^ check date format is valid as "MM/yyyy"
                    }
                    else
                    {
                        validExp = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please input as MM/YYYY");
                }

                // Validate that the date entered makes sense in the context of today's date 
                int year = int.Parse(dateParts[1]);
                int month = int.Parse(dateParts[0]);
                int lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
                DateTime cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);
                // check expiry greater than today & within next 6 years <7, 8>>
                Console.WriteLine(cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
            }
            
            // If all fields are valid, print receipt.
            if (validCcNum && validCvv && validExp)
            {
                ReceiptView.PrintReciept(VendingMachine.PurchasedItems); // final case
            }
        }

        // If the user wants to pay cash.
        public static void PayCash()
        {
            bool enoughCash = false;
            decimal cash = 0;

            while (!enoughCash)
            {
                Console.Write("Please insert cash: ");
                decimal.TryParse(Console.ReadLine(), out cash);

                if ((double)cash > MenuView.FinalTotal)
                {
                    enoughCash = true;
                }
                else
                {
                    Console.WriteLine("You didn't enter enough cash.");
                }
            }

            // set number of decimal places in user input to the decimalPlaces 
            int decimalPlaces = BitConverter.GetBytes(decimal.GetBits(cash)[3])[2];

            if(decimalPlaces != 0 && decimalPlaces != 2 || cash == 0)
            {
                Console.WriteLine("Invalid Input. Enter currency formatted as $dd.cc Please try again.");
                PayCash();
            }

            // If the user enters a valid amount of cash, print receipt.
            else
            {
                Console.Clear();
                Console.WriteLine($"You paid: ${cash}. The total is ${MenuView.FinalTotal}. Here is your change: ${cash - (decimal)MenuView.FinalTotal} ");
                ReceiptView.PrintReciept(VendingMachine.PurchasedItems); // final case
            }
        }
    }
}
