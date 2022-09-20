using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice
{
    public enum RideStyle
    {
        Normal,
        Premium
    }
    public class Ride
    {
        public readonly int Min_Fare;
        public readonly int Cost_Per_Km;
        public readonly int Cost_Per_Min;
        public int Distance;
        public int Time;

        public Ride(int distance, int time, RideStyle rideStyle)
        {
            if (rideStyle == RideStyle.Normal)
            {
                this.Cost_Per_Min = 1;
                this.Min_Fare = 5;
                this.Cost_Per_Km = 10;
            }
            else
            {
                this.Cost_Per_Min = 2;
                this.Min_Fare = 20;
                this.Cost_Per_Km = 15;
            }
            this.Distance = distance;
            this.Time = time;
        }
    }
}
