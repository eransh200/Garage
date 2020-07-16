using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
	public class GarageLogicManager
	{

		private Dictionary<string, Vehicle> m_ListOfVehicles = new Dictionary<string, Vehicle>();

        // Get method for m_ListOfVehicles
        public Dictionary<string, Vehicle> ListOfVechicles
		{
			get
			{
				return m_ListOfVehicles;
			}

        }

        // Throws exception if garage is still empy and try to be used
        public void IsGarageEmpty()
        {
            if (m_ListOfVehicles.Count == 0)
            {
                throw new Exception("There are no vehicle in the garage yet.");
            }
        }

        // Set all vehicle data , throws exception if vehicle not found 
        public void SetVehicleData(string LicseneNumber, List<string> i_DataList)
        {
            IsGarageEmpty();
            Vehicle vehicle = m_ListOfVehicles[LicseneNumber];

            vehicle.Set(i_DataList);
        }

        // Returns a list of question about the vehicle, if vehicle not found throws exception
        public List<string> GetListOfQuestion(string LicseneNumber)
        {
            IsGarageEmpty();
            Vehicle vehicle = m_ListOfVehicles[LicseneNumber];

            if (vehicle == null)
            {
                {
                    throw new Exception("We don't have this vehicle in our garage, sorry.");
                }
            }
            else
            {
                return m_ListOfVehicles[LicseneNumber].SetQuestions();
            }

        }

        // Add new vehicle by type to the vehicle list, if the vehicle all ready exist, change his status to InRepair 
        public void AddNewVehicle(string i_LicenseNumber, Enums.eVehicleType i_VehicleKind)
        {

            Vehicle NewVehicle;

            if (m_ListOfVehicles.ContainsKey(i_LicenseNumber)) 
			{
                m_ListOfVehicles[i_LicenseNumber].VehicleStatus = Enums.eVehicleStatus.InRepair;

                throw new Exception("Vehicle all ready exist, status changed to in repair");
			}
			else
			{
				NewVehicle = VehicleCreator.CreateNewVehicle(i_LicenseNumber, i_VehicleKind);
				m_ListOfVehicles.Add(i_LicenseNumber, NewVehicle);
			}

		}

        // Return List of all license number
		public List<string> GetListOfAllVehiclesLicenseNumber()
		{
            IsGarageEmpty();
            List<string> o_ListOfLicenseNumber = new List<string>();

			foreach (KeyValuePair<string, Vehicle> item in m_ListOfVehicles)
			{
				o_ListOfLicenseNumber.Add(item.Key);
			}

			return o_ListOfLicenseNumber;
		}

        // Return list of vehicle by there status
		public List<string> GetListOfVehiclesByKind(Enums.eVehicleStatus i_VehicleStatus)
        {
            IsGarageEmpty();
            List<string> o_ListOfLicenseNumber = new List<string>();

			foreach (KeyValuePair<string, Vehicle> item in m_ListOfVehicles)
			{
				if (item.Value.VehicleStatus == i_VehicleStatus)
				{
					o_ListOfLicenseNumber.Add(item.Key);
                }

            }

            if (o_ListOfLicenseNumber.Count == 0)
            {
                throw new Exception("There are no vehicle with this status in the garage");
            }

			return o_ListOfLicenseNumber;
		}

        // Change vehicle status by license, throws exception if the vehicle not found
		public void ChangeVehicleStatus(string i_LicenseNumber, Enums.eVehicleStatus i_VehicleSatus)
		{
            IsGarageEmpty();
            if ((m_ListOfVehicles.ContainsKey(i_LicenseNumber)) == true)
            {
                (m_ListOfVehicles[i_LicenseNumber].VehicleStatus) = i_VehicleSatus;
            }
            else
            {
                throw new Exception("We don't have this vehicle in our garage, sorry.");
            }
        }

        // Inflate all wheels in the vehicle to max, if vehicle not found throws exception
		public void InflateWheelsToTheMaximum(string i_LicenseNumber)
		{
            IsGarageEmpty();

            if ((m_ListOfVehicles.ContainsKey(i_LicenseNumber)) == true)
            {
                Vehicle vehicle = m_ListOfVehicles[i_LicenseNumber];

                foreach (Wheel wheel in vehicle.CollectionWheels)
                {
                    wheel.InflateWheel(wheel.MaximalAirPressure - wheel.CurrentAirPressure);
                }
                
            }
            else
            {
                throw new Exception("We don't have this vehicle in our garage, sorry.");
            }

        }

        // Add fuel in the vehicle to max, if vehicle not found throws exception
        public void AddFuel(string i_LicenseNumber,float i_FuelToAdd, Enums.eGasType i_GasType)
		{
            IsGarageEmpty();
            if (!(m_ListOfVehicles.ContainsKey(i_LicenseNumber)))
            {
                throw new Exception("We don't have this vehicle in our garage, sorry.");
            }

            Vehicle vehicle = m_ListOfVehicles[i_LicenseNumber];

            if (!(vehicle.MyEngine is FuelEngine))
            {
                throw new Exception("This is not a fuel driven car, please select another option");
            }
            else
            {
                (vehicle.MyEngine as FuelEngine).AddFuel(i_FuelToAdd, i_GasType);
            }
        }


        // $G$ CSS-013 (-5) Bad variable name (should be in the form of: i_CamelCase).
        // ChargeBattery battery in the vehicle, if vehicle not found throws exception
        public void ChargeBattery(string i_LicenseNumber, float i_numberOfHours)
		{
            IsGarageEmpty();

            if (!(m_ListOfVehicles.ContainsKey(i_LicenseNumber)))
            {
                {
                    throw new Exception("We don't have this vehicle in our garage, sorry.");
                }
            }
            Vehicle vehicle = m_ListOfVehicles[i_LicenseNumber];

            if (!(vehicle.MyEngine is ElectricEngine))
            {
                throw new Exception("This is not a fuel driven car, please select another option");
            }
            else
            {
                (vehicle.MyEngine as ElectricEngine).ChargeBattery(i_numberOfHours);
            }
        }

        // Return specific vehicle string with all of his data
        public string GetVehicleData(string i_LicesneNumber)
        {
            IsGarageEmpty();
            string o_VehicleData;

            if (!m_ListOfVehicles.ContainsKey(i_LicesneNumber))
            {
                throw new Exception("We don't have this vehicle in our garage, sorry.");
            }
            else
            {
                o_VehicleData = m_ListOfVehicles[i_LicesneNumber].GatVehicleData();
            }

            return o_VehicleData;
        }  
    }
}
