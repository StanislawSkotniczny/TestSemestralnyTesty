using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRace
{
    public class RaceEntry
    {
        private const string ExistingDriver = "Driver {0} is already added.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string DriverAdded = "Driver {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";

        private Dictionary<string, UnitDriver> driver;

        public RaceEntry()
        {
            this.driver = new Dictionary<string, UnitDriver>();
        }

        public int Counter
            => this.driver.Count;

        public string AddDriver(UnitDriver driver)
        {
            if (driver == null)
            {
                throw new InvalidOperationException(DriverInvalid);
            }

            if (this.driver.ContainsKey(driver.Name))
            {
                throw new InvalidOperationException(string.Format(ExistingDriver, driver.Name));
            }

            this.driver.Add(driver.Name, driver);

            string result = string.Format(DriverAdded, driver.Name);

            return result;
        }

        public double CalculateAverageHorsePower()
        {
            if (this.driver.Count < MinParticipants)
            {
                throw new InvalidOperationException(string.Format(RaceInvalid, MinParticipants));
            }

            double averageHorsePower = this.driver
                .Values
                .Select(x => x.Car.HorsePower)
                .Average();

            return averageHorsePower;
        }
    }

    public class UnitDriver
    {
        private string name;

        public UnitDriver(string name, UnitCar car)
        {
            this.Name = name;
            this.Car = car;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value ?? throw new ArgumentNullException(nameof(Name), "Name cannot be null!");
            }
        }

        public UnitCar Car { get; }
    }

    public class UnitCar
    {
        public UnitCar(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model { get; }

        public int HorsePower { get; }

        public double CubicCentimeters { get; }
    }
}
