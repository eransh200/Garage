using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class Car : Vehicle
	{
		public const int k_CarColorQLocation = 6;
		public const int k_NumberOfDoorsQLocation = 7;
		public const int k_NumberOfWheels = 4;
        public const float k_MaxAirPressuer = 30;

		private Enums.eCarColor m_CarColor;
		private Enums.eNumberOfDoors m_NumberOfDoors;

		// C'tor
		public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber,i_Engine)
		{
			m_WheelCollection = new Wheel[4];
			for (int i = 0; i < 4; i++)
			{
				m_WheelCollection[i] = new Wheel(k_MaxAirPressuer);
			}

		}

		// Sets All the car members , overriding Vehicle Set method
		public override void Set(List<string> i_DataList)
		{
			base.Set(i_DataList);
			for (int i = 0; i < k_NumberOfWheels; i++)
			{
				m_WheelCollection[i].ManufacturerName = i_DataList[k_WheelManufacturerQLocation];
				m_WheelCollection[i].CurrentAirPressure = float.Parse(i_DataList[k_WheelAirPressureQLocation]);
			}

			m_CarColor =  (Enums.eCarColor)Enum.Parse(typeof(Enums.eCarColor), i_DataList[k_CarColorQLocation]);
			m_NumberOfDoors = (Enums.eNumberOfDoors)Enum.Parse(typeof(Enums.eNumberOfDoors), i_DataList[k_NumberOfDoorsQLocation]);
            if (m_MyEngine is FuelEngine)
            {
                (m_MyEngine as FuelEngine).GasType = Enums.eGasType.Octan96;
                (m_MyEngine as FuelEngine).MaxCapacity = 42;
                (m_MyEngine as FuelEngine).CurrentCapacity = m_EnergyLeft;
            }
            else
            {
                (m_MyEngine as ElectricEngine).MaxCapacity = 2.5f;
                (m_MyEngine as ElectricEngine).CurrentCapacity = m_EnergyLeft;
            }
        }

		// A list of questions about the car data members, overriding Vehicle SetQuestion method 
		public override List<string> SetQuestions()
		{
			List<string> o_Questions = base.SetQuestions();

			o_Questions.Add("Choose the color of the car: Yellow, White, Red or Black");
			o_Questions.Add("Choose the number of doors: Two, Three, Four or Five");

			return o_Questions;
		}

		// Get all members data in a string format, overriding Vehicle GatVehicleData method
		public override string GatVehicleData()
		{
			string o_MyData = base.GatVehicleData();
			
			o_MyData += string.Format(
@"Color -                 {0}
Number of Doors -       {1}",
			m_CarColor, m_NumberOfDoors);

			return o_MyData;
		}
	}
}
