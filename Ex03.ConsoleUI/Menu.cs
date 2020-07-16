using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    // $G$ CSS-999 (-4) The Class must have an access modifier.
    class Menu
	{
        private readonly List<string> r_MenuList = new List<string>(); 

        // Main menu
		public void SetStartMenu()
		{
			r_MenuList.Add("To add a new vehicle to the Garage                     press 1");
			r_MenuList.Add("To show a list of all of the vehicles in the garage    press 2");
            r_MenuList.Add("To Change specific vehicle status                      press 3");
            r_MenuList.Add("To inflate all wheels in a specific vehicle to maximum press 4");
            r_MenuList.Add("To add fuel to a specific vehicle                      press 5");
            r_MenuList.Add("To Charge a specific electric vehicle                  press 6");
            r_MenuList.Add("To show all specific vehicle data                      press 7");
            r_MenuList.Add("To exit                                                press 8");
        }

        // Vehicle types menu
        public void SetVehicleMenu()
		{
			r_MenuList.Add("Fuel Car            press 1");
			r_MenuList.Add("Electric Car        press 2");
			r_MenuList.Add("Fuel Motocycle      press 3");
			r_MenuList.Add("Electric Motocycle  press 4");
			r_MenuList.Add("Truck               press 5");

		}

        // Print any menu to the screen
        public void ShowMenu()
        {
            foreach (string massage in r_MenuList)
            {
                Console.WriteLine(massage);
            }

        }
    }
}

