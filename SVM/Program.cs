using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM
{
    class Program
    {
        static void Main(string[] args)
        {
            // 12 powers. This would come from database in the future. 
            Power p1 = new Power("Loch Ness Monster Summoning", 3.50, "Arcane", "Will summon a very moochy Loch Ness Monster. Beware, sometimes he shows up uninvited.");
            Power p2 = new Power("Laser Gun", 1337.00, "Physical", "This isn't a super power so much as it's a laser gun. The destruction it causes is super cool though.");
            Power p3 = new Power("Pooping Pennies", 1.00, "Physical", "In 100 days or so, this one pays for itself!");
            Power p4 = new Power("Reverse Telepathy", .30, "Mental", "Everybody can hear your thoughts. Never tip toe through tulips again!");
            Power p5 = new Power("Time Travel", 300.99, "Physical", "Travel to any time or era you wish.");
            Power p6 = new Power("Elastic Girl/Boy", 75.25, "Physical", "Stretch your limbs,torso and head to indefinite length without any harm to you.");
            Power p7 = new Power("Do Little", 50.00, "Mental", "Understand and speak to animals.");
            Power p8 = new Power("Shape Shifter", 127.88, "Physical", "Shift into any animal or object at will.");
            Power p9 = new Power("Ruminant", .99, "Physical", "Ability to digest leaves and grass. Never buy food again!");
            Power p10 = new Power("Conjure Objects at Will", 199.99, "Mental", "+- 50m location accuracy. Need a new car? Just make sure you are in an open field...");
            Power p11 = new Power("Ability to Memorize Movies", 10.49, "Mental", "Impress and annoy your friends with you movie choices and monolouges.");
            Power p12 = new Power("Slow Speed Flying", 1999.99, "Physical", "Ability to fly at 6mph, 100ft above the ground.");
            List<Power> powers = new List<Power>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 };

            // Initiate program by calling WelcomeAction();
            VendingMachine vendor = new VendingMachine(powers, new List<Power> ());
            vendor.WelcomeAction();
        }
    }
}
