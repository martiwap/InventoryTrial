using System;

namespace InventoryTrial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var itemInput = new InventoryItem();

            Console.WriteLine("| Let's get started!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| This console program will show you how the update quality value of the following items : ");
            Console.WriteLine("| (a) - Aged Brie");
            Console.WriteLine("| (b) - Christmas Crackers");
            Console.WriteLine("| (c) - Soap");
            Console.WriteLine("| (d) - Frozen Item");
            Console.WriteLine("| (e) - Fresh Item");
            Console.WriteLine("| (f) - Unknown Item");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| Please enter the letter corresponding to the item you want to update (make sure CapsLock is OFF) : ");

            var letterInput = Console.ReadLine();

            ValidateType(letterInput, itemInput);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| Now enter the sell-in value (in numbers) : ");

            var sellInInput = Console.ReadLine();
            while (!int.TryParse(sellInInput, out int inInt))
            {
                Console.WriteLine("| | | Please enter a valid number");
                sellInInput = Console.ReadLine();
            }
            itemInput.Item_SellDays = int.Parse(sellInInput); // should have been a tryParse


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| And the quality value (in numbers) : ");
            var qualityInput = Console.ReadLine();
            while (!int.TryParse(qualityInput, out int inInt))
            {
                Console.WriteLine("| | | Please enter a valid number");
                qualityInput = Console.ReadLine();
            }
            itemInput.Item_QualityValue = int.Parse(qualityInput);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| For how many days would you like to know the updated quality value? Enter the number of days ");

            var daysInput = Console.ReadLine();
            while (!int.TryParse(daysInput, out int inInt))
            {
                Console.WriteLine("| | | Please enter a valid number");
                daysInput = Console.ReadLine();
            }
            var days = int.Parse(daysInput);

            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("----------> Updating...");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");

            var lol = UpdateInventoryItem.Update_InventoryItem(itemInput, days);

            if (lol.ErrorOccured)
            {
                Console.WriteLine("| | |  Ops! " + lol.ErrorMessage + " | | | ");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("-----Updated------------------------------------------");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("| Item : " + lol.Item_Type.ToString());
                Console.WriteLine("| SellIn : " + lol.Item_SellDays.ToString());
                Console.WriteLine("| Quality : " + lol.Item_QualityValue.ToString());
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------");
            }

            Console.WriteLine("And we are done!");

            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");

            Console.WriteLine("Press 'q' the 'enter' to quit and exit the console.");
            while (Console.Read() != 'q') ;
            return;
        }

        public static void ValidateType(string letter, InventoryItem item)
        {
            switch (letter)
            {
                case "a":
                    item.Item_Type = InventoryTrial.ItemTypeEnum.AgedBrie;
                    break;
                case "b":
                    item.Item_Type = InventoryTrial.ItemTypeEnum.ChristmasCrackers;
                    break;
                case "c":
                    item.Item_Type = InventoryTrial.ItemTypeEnum.Soap;
                    break;
                case "d":
                    item.Item_Type = InventoryTrial.ItemTypeEnum.FrozenItem;
                    break;
                case "e":
                    item.Item_Type = InventoryTrial.ItemTypeEnum.FreshItem;
                    break;
                case "f":
                    item.Item_Type = InventoryTrial.ItemTypeEnum.NotValid;
                    break;
                default:
                    Console.WriteLine("Digit entered not valid");
                    Console.WriteLine("Enter the correct digit corresponding the item:");
                    var again = Console.ReadLine();
                    ValidateType(again, item);
                    return;
            }
        }
    }
}
