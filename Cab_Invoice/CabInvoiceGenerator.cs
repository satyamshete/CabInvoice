﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cab_Invoice.CabInvoiceException;

namespace Cab_Invoice
{
    public class CabInvoiceGenerator
    {
        public double CalculateFare(Ride ride)
        {
            if (ride.Distance <= 0)
            {
                throw new CabInvoiceException(CabException.Zero_Distance, "Distance should be above zero");
            }
            else if (ride.Time <= 0)
            {
                throw new CabInvoiceException(CabException.Zero_Time, "Time should be above zero");
            }
            else
            {
                double Totalfare = ride.Distance * ride.Cost_Per_Km + ride.Time * ride.Cost_Per_Min;
                return Math.Max(Totalfare, ride.Min_Fare);
            }
        }
        public double CalculateFare(Ride[] ride)
        {
            double Totalfare = 0;
            foreach (var item in ride)
            {
                Totalfare += CalculateFare(item);
            }
            return (Totalfare);
        }
        public EnhancedInvoiceWithAvarageFare CalculateAvarageFare(Ride[] ride)
        {
            double Totalfare = 0;
            foreach (var item in ride)
            {
                Totalfare += CalculateFare(item);
            }
            return (new EnhancedInvoiceWithAvarageFare(ride.Length, Totalfare));
        }
    }
}
