using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ DSN-999 (-10) It's not an object oriented programming to use only public methods in all of your solution.


    // $G$ CSS-999 (-4) The Class must have an access modifier.
    class GarageUserInteface
	{
		private readonly GarageLogicManager r_MyGarage = new GarageLogicManager();
		private readonly Menu r_StartMenu = new Menu(); 
		private readonly Menu r_VehicleMenu = new Menu();

		public enum eUserChoice
		{
			AddNewVehcile = 1,
			ShowVehcilesList, 
			ChangeVehicleStatus,
			AddAirPresuer, 
			AddFuel,  
			ChargeBattery,
			ShowVehicleData,
			Exit,
		}

		public void RunProgram()
		{
            int userChoice = 0;

            Console.WriteLine(
@"Hey and welcome to ^^^E & D BodyWork And Paint Shop^^^
Please select one of the option below to get things moving:" + Environment.NewLine);
            r_StartMenu.SetStartMenu();
			r_VehicleMenu.SetVehicleMenu();
			while (true)
			{ 
				r_StartMenu.ShowMenu();
				userChoice = GetInputChoiceFromTheUser();
				switch (userChoice)
				{
					case (int)eUserChoice.AddNewVehcile:
						{
							AddNewVehicleToTheGarage();
							break;
						}
					case (int)eUserChoice.ShowVehcilesList:
						{
							ShowListOfAllTheVehicles();
							break;
						}
					case (int)eUserChoice.ChangeVehicleStatus:
						{
							ChangeVehicleStatus();
							break;
						}

					case (int)eUserChoice.AddAirPresuer:
						{
							AddAirPressure();
							break;
						}
					case (int)eUserChoice.AddFuel:
						{
							AddFuel();
							break;
						}
					case (int)eUserChoice.ChargeBattery:
						{
							ChargeBattery();
							break;
						}
					case (int)eUserChoice.ShowVehicleData:
						{
							PrintVehicleData();
							break;
						}
					case (int)eUserChoice.Exit:
						{
							Console.WriteLine("Thank you for visiting ^^^E & D^^^ , see you soon!");
							Console.ReadKey();
							Environment.Exit(1);
							break;
						}
					default:
						{
							Console.WriteLine("Please select a valid option.");
							break;
						}

				}

				ReturnToMainMenu();
                Console.Clear();
			}

		}

		public void ReturnToMainMenu() 
		{
			Console.WriteLine("press any key to continue...");
            Console.ReadKey();
		}


        // $G$ CSS-999 (-5) local variables should be in the form oh camelCased
        // Convert user number input to int
        public int GetInputChoiceFromTheUser()
        {
            int o_UserChoice;
            bool check;

            check = int.TryParse(Console.ReadLine(), out o_UserChoice);

            return o_UserChoice;
        }

        // Convert user number input to eGasType
        public GarageLogic.Enums.eGasType StringToGasType(string i_String)
        {
            GarageLogic.Enums.eGasType o_result;
            bool check = true;

            check = Enum.TryParse<GarageLogic.Enums.eGasType>(i_String, out o_result);
            if (!check)
            {
                throw new ArgumentException("you choose the wrong gas Type, please try again");
            }

            return o_result;
        }

        // Reads license number from the user
        public string EnterLicenseNumber()
		{
			string o_licenseNumber;

			Console.WriteLine("please enter license number");
			o_licenseNumber = Console.ReadLine();

			return o_licenseNumber;
		}

		// Ask from the user to enter data about his vehicle, send it to garage logic
		public void AddNewVehicleToTheGarage()
		{
            Console.Clear();
            string licesneNumber = EnterLicenseNumber();
            GarageLogic.Enums.eVehicleType vehicleChoice;

            try
            {
               
                Console.Clear();
                r_VehicleMenu.ShowMenu();
                vehicleChoice = (GarageLogic.Enums.eVehicleType)GetInputChoiceFromTheUser();
                r_MyGarage.AddNewVehicle(licesneNumber, vehicleChoice);
                Console.Clear();
                List<string> questions = r_MyGarage.GetListOfQuestion(licesneNumber);
                List<string> userOutputAnswers = new List<string>();

                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine(string.Format("{0}", questions[i]));
                    userOutputAnswers.Add(Console.ReadLine());
                }

                r_MyGarage.SetVehicleData(licesneNumber, userOutputAnswers);
                Console.WriteLine("Vehicle added...");
            }
            // TODO - CHAECK ALL CATCH
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                r_MyGarage.ListOfVechicles.Remove(licesneNumber);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("you enter wrong value, please try again:");
                r_MyGarage.ListOfVechicles.Remove(licesneNumber);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                r_MyGarage.ListOfVechicles.Remove(licesneNumber);
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }

        }

		// Read what status of vehicle the user would like to see, ask the list from the garage manager, and print it to the screen
		//throws exception if the user entered a wrong status
		public void ShowListOfAllTheVehicles()
		{
			Console.Clear();
            try
            {
                string userAnswer;
                int index = 1;
                GarageLogic.Enums.eVehicleStatus status;

                Console.WriteLine(
                    @"choose one of the status: InRepair, Repaired or Paid , to show a list of all the vehicle on this status:");
                userAnswer = Console.ReadLine();
                status = (GarageLogic.Enums.eVehicleStatus) Enum.Parse(typeof(GarageLogic.Enums.eVehicleStatus),
                    userAnswer);
                List<string> vehiclesByType = r_MyGarage.GetListOfVehiclesByKind(status);
                foreach (string vehicleLicenseNumber in vehiclesByType)
                {
                    Console.WriteLine(string.Format("{0}. {1} -  {2}", index.ToString(), vehicleLicenseNumber, status));
                    index++;
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("you choose the wrong status, please try again");
                ShowListOfAllTheVehicles();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

		}

        // Ask the user to select new status from the user 
        public void ChangeVehicleStatus()
		{
			Console.Clear();
            try
            {
                Console.Clear();
                string userAnswer;
                GarageLogic.Enums.eVehicleStatus status;
                string licenseNumber = EnterLicenseNumber();

                Console.WriteLine(@"choose one of the status: InRepair, Repaired or Paid");
                userAnswer = Console.ReadLine();
                status = (GarageLogic.Enums.eVehicleStatus) Enum.Parse(typeof(GarageLogic.Enums.eVehicleStatus),
                    userAnswer);
                r_MyGarage.ChangeVehicleStatus(licenseNumber, status);
                Console.WriteLine("Status changed...");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("you choose the wrong status, please try again");
                ChangeVehicleStatus();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		   
		}

		// Ask the user how much air he would like to add a specific vehicle wheels
		public void AddAirPressure()
		{
            try
            {
                string licenseNumber = EnterLicenseNumber();

                r_MyGarage.InflateWheelsToTheMaximum(licenseNumber);
                Console.WriteLine("Air pressure filled...");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("please try again");
                AddAirPressure();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

		}

		// Ask the user how much fuel he would like to add to a specific vehicle
		public void AddFuel()
		{
			Console.Clear();
			try
			{
				float fuelToAdd = 0;
				string licenseNumber = EnterLicenseNumber();
				string userAnswer;
                GarageLogic.Enums.eGasType gasType;
                Console.WriteLine("Choose gas type to add: Soler, Octan95, Octan96 or Octan98:");
				userAnswer = Console.ReadLine();
				gasType = StringToGasType(userAnswer);
				Console.WriteLine("How much fuel you whould like to add?");
				fuelToAdd = float.Parse(Console.ReadLine()); 
				r_MyGarage.AddFuel(licenseNumber, fuelToAdd, gasType);
				Console.WriteLine("Fuel added...");
			}
			catch (FormatException)
			{
				Console.WriteLine("You didn't insert the amount of fuel in the form of numbers, please try again.");
				AddFuel();
			}

            catch (ArgumentException)
			{
				Console.WriteLine("you choose the wrong fuel type, please try again");
				AddFuel();
			}
			catch (ValueOutOfRangeException ex) 
			{
				Console.WriteLine(ex);
				AddFuel();
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
				ReturnToMainMenu();
			}

		}

		// Ask the user how many minute hw would like to add to a specific vehicle
		public void ChargeBattery()
		{
			Console.Clear();
            try
			{
				string licenseNumber = EnterLicenseNumber();
				float timeToCharge = 0;

				Console.WriteLine(@"How much minuets you would like to ChargeBattery?");
				timeToCharge = float.Parse(Console.ReadLine());
				r_MyGarage.ChargeBattery(licenseNumber, timeToCharge);
				Console.WriteLine("Battery charged...");
			}
			catch (FormatException)
			{
				Console.WriteLine("You didn't insert the amount of minuets in the form of numbers, please try again");
				ChargeBattery();
			}
			catch (ValueOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				ChargeBattery();
            }
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				ReturnToMainMenu();
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ReturnToMainMenu();
            }

        }

		// Ask the user to select a vehicle and print all his data to the screen
		public void PrintVehicleData()
		{
			string licenseNumber;
			string vehicleData;
			try
			{
				licenseNumber = EnterLicenseNumber();
				vehicleData = r_MyGarage.GetVehicleData(licenseNumber);
				Console.WriteLine(vehicleData);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				
			}

		}
	}
}
