using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM
{
    class PurchaseView
    {
        // Display more info to user and allow them to buy the power and / or go back to the main menu
        public static void Purchase(Power power, List<Power> powers, List<Power> BoughtPowers)
        {
            Console.Clear();
            Console.WriteLine($"Power name:         {power.Name}" +
                            $"\nCategory:           {power.Category}" +
                            $"\nDescription:        {power.Description}" +
                            $"\nPrice:              {Math.Round(power.Price, 2)}");
            Console.WriteLine("\nPlease select an action:" +
                              "\n1) Buy" +
                              "\n2) Main Menu");

            int index = 0;
            Validator.IsInRangeIndex(Console.ReadLine(), 1, 2, out index);

            if (index == 0) // user selects "1"
            {
                while (true)
                {
                    Console.WriteLine("How many would you like to buy?" +
                        "\n\nEnter quantity or enter 'M' for main menu:");

                    int quantity = 0;
                    string uChoice = Console.ReadLine().ToUpper();
                    if (uChoice == "M")
                    {
                        Console.Clear();
                        // If user changes their mind, they can return to Main Menu without buying the power.
                        MenuView.DisplayMenu(powers, BoughtPowers);
                        break;
                    }
                    else
                    {
                        if (int.TryParse(uChoice, out quantity))
                        {
                            if (quantity == 0)
                            {
                                Console.WriteLine("Back to Main Menu.");
                                MenuView.DisplayMenu(powers, BoughtPowers);
                                break;
                            }
                            else if (quantity > 0)
                            {
                                // If the user buys something, update the SubTotal and add the bought power to the list BoughtPowers
                                // and return to Main Menu.
                                double total = VendingMachine.CalculateSubTotal(quantity, power);

                                for(int i = 0; i < quantity; i++)
                                {
                                    BoughtPowers.Add(power);
                                }

                                Console.WriteLine($"Total purchase comes to ${total}. Press any key to return to main menu...");
                                Console.ReadKey();
                                Console.Clear();
                                MenuView.DisplayMenu(powers, BoughtPowers);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a positive whole number");
                                continue;
                            }
                        }
                    }
                }
            }
            // If the user doesn't want to buy the power after getting more info, they can go back to the Main Menu
            else if(index == 1) // user selects "2"
            {
                Console.Clear();
                MenuView.DisplayMenu(powers, BoughtPowers);
            }

            else // Should never get here...
            {
                Console.WriteLine("Error");
            }
        }
    }
}
