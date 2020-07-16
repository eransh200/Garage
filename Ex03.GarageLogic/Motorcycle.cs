using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class Motorcycle : Vehicle
	{
		public const int k_LicenseTypeQLocation = 6;
		public const int k_EngineCapacityQLocation = 7;
        public const float k_MaxAirPressuer = 28;


        private Enums.eLicenseType m_LicenseType;
		private int m_EngineVolume;

        // C'tor
		public Motorcycle(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
		{
			m_WheelCollection = new Wheel[2];
			for (int i = 0; i < 2; i++)
			{
				m_WheelCollection[i] = new Wheel(k_MaxAirPressuer);
			}

		}

        // Set's all data members
        public override void Set(List<string> i_DataList)
        {
                base.Set(i_DataList);
                for (int i = 0; i < 2; i++)
                {
                    m_WheelCollection[i].ManufacturerName = i_DataList[k_WheelManufacturerQLocation];
                    m_WheelCollection[i].CurrentAirPressure = float.Parse(i_DataList[k_WheelAirPressureQLocation]);
                }

                m_LicenseType = (Enums.eLicenseType)Enum.Parse(typeof(Enums.eLicenseType), i_DataList[k_LicenseTypeQLocation]);
                m_EngineVolume = int.Parse(i_DataList[k_EngineCapacityQLocation]);
                if (m_MyEngine is FuelEngine)
                {
                    (m_MyEngine as FuelEngine).GasType = Enums.eGasType.Octan95;
                    (m_MyEngine as FuelEngine).MaxCapacity = 5.5f;
                    (m_MyEngine as FuelEngine).CurrentCapacity = m_EnergyLeft;
                }
                else
                {
                    (m_MyEngine as ElectricEngine).MaxCapacity = 1.6f;
                    (m_MyEngine as ElectricEngine).CurrentCapacity = m_EnergyLeft;
                }
        }

        // Add new question about the motorcycle, and return the list od question, overriding Vehicle SetQuestions method
        public override List<string> SetQuestions()
		{
			List<string> o_Questions = base.SetQuestions();

			o_Questions.Add("Licecne type: ");
			o_Questions.Add("Engine capacity:");
			
			return o_Questions;
		}

        // Get all members data in a string format, overriding Vehicle GatVehicleData method
        public override string GatVehicleData()
        {
            string o_MyData = base.GatVehicleData();

            o_MyData += string.Format(
@"License Type -          {0}
Engine volume -         {1} 
",
            m_LicenseType, m_EngineVolume);

            return o_MyData;
        }
    }
}
