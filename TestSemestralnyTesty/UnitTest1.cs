using TheRace;


namespace TestSemestralnyTesty
{
    [TestClass]
    public class UnitTest1
    {
        private RaceEntry raceEntry;
        private UnitDriver driver1;
        private UnitDriver driver2;
        private UnitDriver driver3;


        [TestInitialize]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            driver1 = new UnitDriver("John", new UnitCar("Car1", 200, 2000));
            driver2 = new UnitDriver("Mike", new UnitCar("Car2", 180, 1800));
            driver3 = new UnitDriver("Bob", new UnitCar("Car3", 220, 2200));
        }

        [TestMethod]
        public void CounterKiedyJest0Kierowców()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }


        [TestMethod]
        public void DodanieKierowcyDoWyœcigu()
        {
            string result = raceEntry.AddDriver(driver1);

            Assert.AreEqual(1, raceEntry.Counter);
            Assert.AreEqual("Driver John added in race.", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DodanieKierowcyZwartosciaNull()
        {
            raceEntry.AddDriver(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DodanieJuzIstniej¹cegoKierwocy()
        {
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ObliczanieIlosciKMzmniejszailosciaKierowcowNi¿jestWymaganaPowinnoDacThrowInvalidOperationException()
        {
            raceEntry.AddDriver(driver1);
            raceEntry.CalculateAverageHorsePower();
        }

        [TestMethod]
        public void ObliczanieIloœciKMzilosciaKierowcówRownaMinimalnejLiczbieUczestnikow()
        {
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            double averageHorsePower = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(190, averageHorsePower);
        }

        [TestMethod]
        public void ObliczanieIloœciKMzilosciaKierowcówWiekszaOdMinimalnejLiczbieUczestnikow()
        {
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);

            double averageHorsePower = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(200, averageHorsePower);
        }
    }
}