using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM
{
    public class Validator
    {
        // Validates that user inputs an integer in a valid range. Outputs the valid integer or recurse and ask the user to enter again.
        public static void IsInRangeIndex(string choice, int minVal, int maxVal, out int x)
        {
            int num;
            try
            {
                num = Convert.ToInt32(choice);
                if (num >= minVal && num <= maxVal)
                {
                    x = num - 1;
                    return;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Please enter a number {minVal}-{maxVal}.");
                x = 0;
                IsInRangeIndex(Console.ReadLine(), minVal, maxVal, out x);
            }
        }       
    }
}
