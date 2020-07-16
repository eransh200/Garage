using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class FuelEngine : Engine
	{
        private Enums.eGasType m_GasType;

		// Get/Set method for m_GasType
		public Enums.eGasType GasType
		{
			get
			{
				return m_GasType;
			}
			set
			{
				m_GasType = value;
			}

		}

		// Add fuel method, throws exception if the amount to add is larger then the max capacity, or the gas type is not valid
		public void AddFuel(float i_FuelToAdd , Enums.eGasType i_GasType)
		{
			if (i_GasType != m_GasType)
			{
				throw new ArgumentException("{0} type do not match to this vehicle" , i_GasType.ToString());
			}
			else if (i_FuelToAdd + m_CurrentCapacity > m_MaxCapacity)
			{
				throw new ValueOutOfRangeException("Fuel", k_MinAmountToAdd, m_MaxCapacity);
			}
			else
			{
				m_CurrentCapacity += i_FuelToAdd;
                m_CapacityInPrecentege = (m_CurrentCapacity / m_MaxCapacity) * 100;
            }

        }
	}
}
