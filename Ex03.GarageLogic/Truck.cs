using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class Truck : Vehicle
	{
		public const int k_IsDangerousMaterialQLocation = 6;
		public const int k_TrunkCapacityQLocation = 7;
        public const float k_MaxAirPressuer = 26;

        private bool m_IsDangerousMaterial = true;
		private int m_TrunkCapacity = 0;

        // C'tor
		public Truck(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
		{
            m_WheelCollection = new Wheel[16];

			for (int i = 0; i < 16; i++)
			{
                m_WheelCollection[i] = new Wheel(k_MaxAirPressuer);
			}
		}
        
        // Set's all data members
        public override void Set(List<string> i_DataList)
		{
			base.Set(i_DataList);
            for (int i = 0; i < 4; i++)
			{
                m_WheelCollection[i].ManufacturerName = i_DataList[k_WheelManufacturerQLocation];
                m_WheelCollection[i].CurrentAirPressure = float.Parse(i_DataList[k_WheelAirPressureQLocation]);
			}

			m_TrunkCapacity = int.Parse(i_DataList[k_TrunkCapacityQLocation]);
            m_IsDangerousMaterial = bool.Parse(i_DataList[k_IsDangerousMaterialQLocation]);
            (m_MyEngine as FuelEngine).GasType = Enums.eGasType.Soler;
            (m_MyEngine as FuelEngine).MaxCapacity = 120;
            (m_MyEngine as FuelEngine).CurrentCapacity = m_EnergyLeft;
        }

        // Add new question about the Truck, and return the list od question, overriding Vehicle SetQuestions method
        public override List<string> SetQuestions()
		{
			List<string> o_Questions = base.SetQuestions();

			o_Questions.Add("Is the truck contain dangerous materials? enter true or false");
			o_Questions.Add("What is the trunk capacity:");

			return o_Questions;
		}

        // get all members data in a string format, overriding Vehicle GatVehicleData method
        public override string GatVehicleData()
        {
            string o_MyData = base.GatVehicleData();
            string containOrNot;

            if (m_IsDangerousMaterial == true)
            {
                containOrNot = "Contain";
            }
            else
            {
                containOrNot = "Not Contain";
            }

            o_MyData += string.Format(
@"Trunk capacity -         {0}
{1} dangerous materials",
            m_TrunkCapacity.ToString(), containOrNot);

            return o_MyData;
        }
    }
}
