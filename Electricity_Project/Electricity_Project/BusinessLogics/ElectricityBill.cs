using System;
using System.Text.RegularExpressions;

namespace Electricity_Project.BusinessLogics
{
    public class ElectricityBill
    {
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get => consumerNumber;
            set
            {
                if (!Regex.IsMatch(value, @"^EB\d{5}$"))
                    throw new FormatException("Invalid Consumer Number");
                consumerNumber = value;
            }
        }

        public string ConsumerName { get => consumerName; set => consumerName = value; }
        public int UnitsConsumed { get => unitsConsumed; set => unitsConsumed = value; }
        public double BillAmount { get => billAmount; set => billAmount = value; }
    }

}