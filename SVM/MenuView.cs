using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SVM
{
    class MenuView
    {
        public static double SubTotal { get; set; }
        public static double FinalTotal { get; set; } = Math.Round(0.00, 2);

        // Displays menu of powers for sale
        public static void DisplayMenu(List<Power> powers, List<Power> BoughtPower)
        {
            Console.WriteLine($"Total Purchases: {SubTotal}\n");
            for(int i = 0; i < powers.Count; i++)
            {
                Console.WriteLine($"Power {i+1}: {AddSpaces(powers[i].Name)} {AddSpaces(powers[i].Category)} {AddSpaces(powers[i].Price)}");
            }

            // User chooses to buy power or checkout.
            int choice;
            Console.WriteLine("Please select:");
            Console.WriteLine("1) Buy" +
                "\n2) Checkout");
            Validator.IsInRangeIndex(Console.ReadLine(), 1, 2, out choice);

            if(choice == 0)
            {
                int index;
                Console.WriteLine();
                Console.WriteLine("Select index of the power you'd like.");
                Validator.IsInRangeIndex(Console.ReadLine(), 1, powers.Count, out index);
                // Display more info on the power and allow user to buy
                PurchaseView.Purchase(powers[index], powers, BoughtPower);
            }
            else if(choice == 1)
            {
                // User can't checkout with nothing in the cart.
                if(BoughtPower.Count == 0)
                {
                    Console.WriteLine("There is nothing in your cart. Any key to return...");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMenu(powers, BoughtPower);
                }
                else
                {
                    Console.Clear();
                    // Display contents of the shopping cart
                    ReceiptView.PrintCart(BoughtPower, powers);
                }
            }
        }

        // Formatting for the main menu
        public static object AddSpaces(double price)
        {
            string input = String.Format("{0:N2}", price);
            int spaces = 30 - input.Length;
            for (int i = 0; i < spaces; i++)
            {
                input += " ";
            }
            return input;
        }

        // Formatting for the main menu
        public static string AddSpaces(string input)
        {
            int spaces = 30 - input.Length;
            for (int i = 0; i < spaces; i++)
            {
                input += " ";
            }
            return input;
        }
    }
}
