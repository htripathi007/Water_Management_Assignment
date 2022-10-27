using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Water_Management_Assignment
{
    public class Program
    {
        int consumptionPerPerson;
        double unitCost;
        int waterConsumedByGuest = 0;
        int corporationWater;
        int borewellWater;
        int guest = 0;



        public double allotWater(int apartmentType, int corporationWater, int borewellWater)
        {
            if (apartmentType == 2)
            {
                consumptionPerPerson = 900;
            }
            else if (apartmentType == 3)
            {
                consumptionPerPerson = 1500;
            }



            unitCost = consumptionPerPerson / (corporationWater + borewellWater);
            return unitCost;
        }



        public int addGuest(int addGuest)
        {
            guest += addGuest;
            waterConsumedByGuest = guest * 10 * 30;
            return waterConsumedByGuest;
        }



        public string getBill()
        {
            int guestBill = 0;



            if (waterConsumedByGuest > 0 && waterConsumedByGuest <= 500)
            {
                guestBill = waterConsumedByGuest * 2;
            }
            if (waterConsumedByGuest > 500 && waterConsumedByGuest <= 1500)
            {
                guestBill = 500 * 2 + (waterConsumedByGuest - 500) * 3;
            }
            if (waterConsumedByGuest > 1500 && waterConsumedByGuest <= 3000)
            {
                guestBill = 500 * 2 + 1000 * 3 + (waterConsumedByGuest - 1500) * 5;
            }
            if (waterConsumedByGuest > 3000)
            {
                guestBill = 500 * 2 + 1000 * 3 + 1500 * 5 + (waterConsumedByGuest - 3000) * 8;
            }
            double totalBill = Math.Ceiling(unitCost * corporationWater * 1 + unitCost * borewellWater * 1.5 + guestBill);
            double totalWater = unitCost * corporationWater + unitCost * borewellWater + waterConsumedByGuest;
            totalWater = Math.Round(totalWater);
            return $"Total Water : {totalWater} L \nTotal Bill : Rs.{totalBill}";
        }
        public void runProgram(string input)
        {
            string[] strings = input.Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                string[] inputType = strings[i].Split(' ');
                if (inputType[0].ToUpper().Contains("ALLOT_WATER"))
                {
                    int apartmentType = Convert.ToInt32(inputType[1]);
                    string[] waterRatio = inputType[2].Split(':');
                    corporationWater = Convert.ToInt32(waterRatio[0]);
                    borewellWater = Convert.ToInt32(waterRatio[1]);
                    allotWater(apartmentType, corporationWater, borewellWater);
                }
                else if (inputType[0].ToUpper().Contains("ADD_GUESTS"))
                {
                    int guest = Convert.ToInt32(inputType[1]);
                    addGuest(guest);
                }
                else if (inputType[0].ToUpper().Contains("BILL"))
                {
                    Console.WriteLine(getBill());
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the file path : ");
            string path;
            path = Console.ReadLine();
            if (path.StartsWith("\""))
            {
                path = path.Remove(0, 1);
            }
            if (path.EndsWith("\""))
            {
                path = path.Remove(path.Length - 1, 1);
            }
            path = @"" + path;
            StreamReader sr = new StreamReader(path);
            string input = sr.ReadToEnd();
            Program program = new Program();
            program.runProgram(input);
            Console.ReadLine();
        }
    }
}