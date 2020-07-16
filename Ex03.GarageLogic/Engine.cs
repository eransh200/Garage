using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public const float k_MinAmountToAdd = 0;

        protected float m_MaxCapacity;
		protected float m_CurrentCapacity;
        protected float m_CapacityInPrecentege;

        // Get/Set methods for m_MaxCapacity
        public float MaxCapacity
		{
			get
			{
				return m_MaxCapacity;
			}

			set
			{
                if (value <= 0)
                {
                    throw new ValueOutOfRangeException("Max energy", 0, m_MaxCapacity);
                }
                else
                {
                    m_MaxCapacity = value;
                }
            }

		}

        // Get/Set methods for m_CurrentCapacity
        public float CurrentCapacity
		{
			get
			{
                return m_CurrentCapacity;
			}
            set
            {
                if (value < k_MinAmountToAdd || value > m_MaxCapacity)
                {
                    throw new ValueOutOfRangeException("Energy", k_MinAmountToAdd, m_MaxCapacity);
                }
                else
                {
                    m_CurrentCapacity = value;
                    m_CapacityInPrecentege = (value / m_MaxCapacity) * 100;
                }

            }

		}

        public float CapacityInPrecentege
        {
            get
            {
                return m_CapacityInPrecentege;
            }

        }

    }
}
