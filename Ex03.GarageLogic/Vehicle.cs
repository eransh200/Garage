using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		// Consts
		public const int k_ModelQLocation = 0;
		public const int k_OwnerNameQLocation = 1;
		public const int k_OwnerPhoneQLocation = 2;
		public const int k_EnergyLeftQLocation = 3;
		public const int k_WheelManufacturerQLocation = 4;
		public const int k_WheelAirPressureQLocation = 5;

		// Data members
		protected string m_LicenseNumber;
		protected string m_Model;
		protected string m_OwnerOfVehicle;
		protected string m_OwnerPhoneNumber;
		protected Enums.eVehicleStatus m_VehicleStatus = Enums.eVehicleStatus.InRepair;
		protected Engine m_MyEngine;
		protected float m_EnergyLeft;
		protected Wheel[] m_WheelCollection;

		// C'tor
		protected Vehicle(string i_LicenseNumber, Engine i_Engine)
		{
			m_MyEngine = i_Engine;
			m_LicenseNumber = i_LicenseNumber;
		}

		// Get method for m_WheelCollection
		public Wheel[] CollectionWheels
		{
			get
			{
				return m_WheelCollection;
			}
		}

		// Get method for m_MyEngine
		public Engine MyEngine
		{
			get
			{
				return m_MyEngine;
			}
		}

		// Get/Set method for m_VehicleStatus
		public Enums.eVehicleStatus VehicleStatus
		{
			get
			{
				return m_VehicleStatus;
			}

			set
			{
				m_VehicleStatus = value;
			}

		}

        // TODO -DELETE?
        //// Convert string to float and throw's the right exception if needed
        //public float StringToFloat(string i_String)
        //{
        //	float o_result;
        //	bool check;
        //	string userAnswer;

        //	userAnswer = Console.ReadLine();
        //	check = float.TryParse(userAnswer, out o_result);
        //	if (!check)
        //	{
        //		throw new Exception("Your input is not a number, please try again");
        //	}

        //	return o_result;
        //}

        // Set the base Vehicle data members, virtual method over ride in each one of the inherited classes

        public virtual void Set(List<string> i_DataList)
		{
			m_Model = i_DataList[k_ModelQLocation];
			m_OwnerOfVehicle = i_DataList[k_OwnerNameQLocation];
			m_OwnerPhoneNumber = i_DataList[k_OwnerPhoneQLocation];
			m_EnergyLeft = float.Parse(i_DataList[k_EnergyLeftQLocation]);
		}

		//  Add new question for basic vehicle, virtual method over ride in each one of the inherited classes
		public virtual List<string> SetQuestions()
		{
			List<string> o_Questions = new List<string>();

			o_Questions.Add("Please type the model of the car");
			o_Questions.Add("Owners Name:");
			o_Questions.Add("Owners Phone:");
			o_Questions.Add("How much Fuel / Electricity left:");
			o_Questions.Add("Who is your wheel manufacturer?");
			o_Questions.Add("What is your current wheel pressure?");

			return o_Questions;
		}

		// Get all vehicle members data in a string format, virtual method over ride in each one of the inherited classes
		public virtual string GatVehicleData()
		{
			string o_MyData;
			string engineType;

			if (m_MyEngine is FuelEngine)
			{
				engineType = string.Format("Fuel");
			}
			else
			{
				engineType = string.Format("Electric");
			}

			o_MyData = string.Format(@"
License Number -        {0}
Model -                 {1}
Owner Name -            {2}
Phone Number-           {3}
Status -                {4}
Wheels manufacturer -   {5}
Wheels air pressure -   {6}
Engine Type -           {7}
Current Energy -        {8}
",
            m_LicenseNumber, m_Model, m_OwnerOfVehicle, m_OwnerPhoneNumber, m_VehicleStatus, m_WheelCollection[0].ManufacturerName,
            m_WheelCollection[0].CurrentAirPressure.ToString(), engineType, m_MyEngine.CurrentCapacity.ToString());

			return o_MyData;
		}
	}
}
