using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM
{
    class VendingMachine
    {
        public List<Power> Powers { get; set; }
        public static List<Power> PurchasedItems { get; set; }
        
        // Take in list of powers and the list of BoughtPowers to update the running total.
        public VendingMachine(List<Power> powers, List<Power> BoughtPowers)
        {
            Powers = powers;
            PurchasedItems = BoughtPowers;
        }

        // Method initiates program
        public void WelcomeAction()
        {
            Console.WriteLine("Welcome to the Super Powers Store!");
            MenuView.DisplayMenu(Powers, PurchasedItems);
            Console.ReadKey();
        }

        // Calculate the final total by adding tax to the running total
        public static void CalculateTotal()
        {
            double total = Math.Round(MenuView.SubTotal * 1.06, 2);
            MenuView.FinalTotal = Math.Round(total, 2);
        }

        // Updates subtotal each time user buys something
        public static double CalculateSubTotal(int quantity, Power power)
        {
            double total = Math.Round(power.Price * (double)quantity, 2);
            MenuView.SubTotal += total;
            return total;
        }       
    }
}

//Write a cash register or self-service terminal for some kind of retail location.Obvious choices include a small store, a coffee shop, or a fast food restaurant.
//Your solution must include some kind of a product class with a name, category, description, and price for each item.
//12 items minimum; stored in a list.

//Present a menu to the user and let them choose an item (by number or letter).
//Allow the user to choose a quantity for the item ordered.

//Give the user a line total(item price * quantity).

//Either through the menu or a separate question, allow them to re-display the menu and to complete the purchase.
//Give the subtotal, sales tax, and grand total.  (Remember rounding issues the Math library will be handy!)
//Ask for payment type—cash, credit, or check
//For cash, ask for amount tendered and provide change.
//For check, get the check number.
//For credit, get the credit card number, expiration, and CVV.
//At the end, display a receipt with all items ordered, subtotal, grand total, and appropriate payment info.
//Return to the original menu for a new order.  (Hint: you’ll want an array or List to keep track of what’s been ordered!)

//// Updates subtotal each time user buys something
//public double CalculateSubTotal(int index, int quantity)
//{
//    double price= Powers[index].Price;
//    double total = Math.Round(price * quantity, 2);
//    MenuView.SubTotal += total;
//    return total;
//}
