using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class ElectricEngine : Engine
	{
        // ChargeBattery battery method, throws exception if the amount to add is larger then the max capacity
        public void ChargeBattery(float i_NumberOfMinutes)
        {
            i_NumberOfMinutes /= 60;
            if (m_CurrentCapacity + (i_NumberOfMinutes) > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException("Minutes to charge", k_MinAmountToAdd, m_MaxCapacity);
            }
            else
			{
                m_CurrentCapacity += (i_NumberOfMinutes);
                m_CapacityInPrecentege = (m_CurrentCapacity / m_MaxCapacity) * 100;
            }
        }
	}
}
