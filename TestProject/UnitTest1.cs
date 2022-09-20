using Cab_Invoice;

namespace TestProject
{
    public class Tests
    {
        CabInvoiceGenerator Invoice;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4, 3, RideStyle.Normal, 43)]
        [TestCase(10, 3, RideStyle.Premium, 156)]
        [TestCase(1, 2, RideStyle.Premium, 20)]
        [TestCase(0, 2, RideStyle.Premium, 20)]
        [TestCase(1, 0, RideStyle.Premium, 20)]
        public void Given_Dist_Time_RideStyle_Return_TotalFare_For_Single_Ride(int distance, int time, RideStyle rideStyle, double expected)
        {

            try
            {
                //Assembly
                Invoice = new CabInvoiceGenerator();
                Ride ride = new Ride(distance, time, rideStyle);
                ///Act
                double ActualFare = Invoice.CalculateFare(ride);
                ///Assert
                Assert.AreEqual(ActualFare, expected);
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [Test]
        public void Given_Dist_Time_RideStyle_Return_TotalFare_For_Multiple_Ride()
        {
            try
            {
                //Assembly
                Invoice = new CabInvoiceGenerator();
                Ride[] ride = { new Ride(5, 10, RideStyle.Normal), new Ride(10, 5, RideStyle.Premium) };
                ///Act
                double ActualFare = Invoice.CalculateFare(ride);
                ///Assert
                Assert.AreEqual(ActualFare, 220);
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [Test]
        public void Given_Dist_Time_RideStyle_Return_AvarageFare_For_Multiple_Ride()
        {
            try
            {
                //Assembly
                Invoice = new CabInvoiceGenerator();
                Ride[] ride = { new Ride(5, 10, RideStyle.Normal), new Ride(10, 5, RideStyle.Premium) };
                EnhancedInvoiceWithAvarageFare Expected = new EnhancedInvoiceWithAvarageFare(2, 220);
                ///Act
                object ActualFare = Invoice.CalculateAvarageFare(ride);
                ///Assert
                Assert.AreEqual(ActualFare, Expected);
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}