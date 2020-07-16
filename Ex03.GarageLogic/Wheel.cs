using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
		public class Wheel
	{
		private const float k_MinAmountToAdd = 0;

		private string m_ManufacturerName;
		private float m_CurrentAirPressure;


        // $G$ DSN-999 (-4) The "maximum air pressure" field should be readonly member of class wheel.
        private float m_MaximalAirPressure;

		// C'tor
		public Wheel(float i_MaximalAirPressure)
		{
			m_MaximalAirPressure = i_MaximalAirPressure;
		}

		// Get/Set for m_ManufacturerName
		public string ManufacturerName
		{
			get
			{
				return m_ManufacturerName;
			}

			set
			{
				m_ManufacturerName = value;
			}

		}

		// Get/Set for // Get/Set for
		public float MaximalAirPressure
		{
			get
			{
				return m_MaximalAirPressure;
			}

			set
			{
				m_MaximalAirPressure = value;
			}

		}

		// Get/Set for m_CurrentAirPressure
		public float CurrentAirPressure
		{
			get
			{
				return m_CurrentAirPressure;
			}

			set
			{
                if (value > m_MaximalAirPressure || value < k_MinAmountToAdd)
                {
                    throw new ValueOutOfRangeException("Max Air Pressure", k_MinAmountToAdd, m_MaximalAirPressure);
                }
                else
                {
                    m_CurrentAirPressure = value;
                }
            }

		}

		// Add air to CurrentAirPressure, throws exception if there is to much air to add
		public void InflateWheel(float i_AirPressure)
		{
			if (m_CurrentAirPressure + i_AirPressure > m_MaximalAirPressure || m_CurrentAirPressure + i_AirPressure < 0)
			{
				throw new ValueOutOfRangeException("Air Pressure", k_MinAmountToAdd, m_MaximalAirPressure);
			}
			else
			{
				m_CurrentAirPressure += i_AirPressure;
			}

		}
	}
}
