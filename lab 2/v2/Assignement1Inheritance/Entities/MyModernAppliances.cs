using Assignement1Inheritance.Entities.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1Inheritance.Entities
{
    internal class MyModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");

            long itemNumber;

            string userInput = Console.ReadLine();
            if (!long.TryParse(userInput, out itemNumber))
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            Appliance foundAppliance = null;

            foreach (var appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("Enter brand to search for:");

           string enteredBrand = Console.ReadLine();

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance.Brand == enteredBrand)
                {
                    foundAppliances.Add(appliance);
                }
            }

            DisplayAppliencesFromList(foundAppliances, 0);

        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            Console.WriteLine("Enter number of doors: ");

            int numberOfDoors;
            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out numberOfDoors))
            {
                Console.WriteLine("Invalid number of doors.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Refrigerator refrigerator)
                {
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");

            Console.WriteLine("Enter grade:");
            string userInput = Console.ReadLine();

            string grade;
            if (userInput == "0")
            {
                grade = "Any";
            }
            else if (userInput == "1")
            {
                grade = "Residential";
            }
            else if (userInput == "2")
            {
                grade = "Commercial";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");

            Console.WriteLine("Enter voltage:");
            userInput = Console.ReadLine();

            int voltage;
            if (userInput == "0")
            {
                voltage = 0;
            }
            else if (userInput == "1")
            {
                voltage = 18;
            }
            else if (userInput == "2")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    if ((grade == "Any" || vacuum.Grade == grade) && (voltage == 0 || vacuum.Voltage == voltage))
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");

            Console.WriteLine("Enter room type:");
            string userInput = Console.ReadLine();

            char roomType;
            if (userInput == "0")
            {
                roomType = 'A';
            }
            else if (userInput == "1")
            {
                roomType = 'K';
            }
            else if (userInput == "2")
            {
                roomType = 'W';
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Microwave microwave)
                {
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            Console.WriteLine("Enter sound rating:");
            string userInput = Console.ReadLine();

            string soundRating;
            if (userInput == "0")
            {
                soundRating = "Any";
            }
            else if (userInput == "1")
            {
                soundRating = "Qt";
            }
            else if (userInput == "2")
            {
                soundRating = "Qr";
            }
            else if (userInput == "3")
            {
                soundRating = "Qu";
            }
            else if (userInput == "4")
            {
                soundRating = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher)
                {
                    if (soundRating == "Any" || dishwasher.SoundRating == soundRating)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.WriteLine("Enter type of appliance:");
            string applianceType = Console.ReadLine();

            Console.WriteLine("Enter number of appliances: ");
            string userInput = Console.ReadLine();

            int num;
            if (!int.TryParse(userInput, out num))
            {
                Console.WriteLine("Invalid number of appliances.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (applianceType == "0")
                {
                    foundAppliances.Add(appliance);
                }
                else if (applianceType == "1" && appliance is Refrigerator)
                {
                    foundAppliances.Add(appliance);
                }
                else if (applianceType == "2" && appliance is Vacuum)
                {
                    foundAppliances.Add(appliance);
                }
                else if (applianceType == "3" && appliance is Microwave)
                {
                    foundAppliances.Add(appliance);
                }
                else if (applianceType == "4" && appliance is Dishwasher)
                {
                    foundAppliances.Add(appliance);
                }
            }

            Random random = new Random();
            foundAppliances = foundAppliances.OrderBy(x => random.Next()).ToList();

            DisplayAppliancesFromList(foundAppliances.Take(num).ToList(), 0);
        }
    }
}
}
