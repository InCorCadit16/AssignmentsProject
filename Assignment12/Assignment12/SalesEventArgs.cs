using System;
using System.Collections.Generic;
using System.Text;


namespace PublisherSolution
{
    public class SalesEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public double DefaultPrice { get; set; }
        public double SaleInPercents { get; set; }
        public double SalePrice { get{ return DefaultPrice - (DefaultPrice * SaleInPercents / 100); } }

        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return new StringBuilder().Append($"Product Name: {ProductName}\n")
                                       .Append($"Default Price: {DefaultPrice}\n")
                                       .Append($"Sale in Percents: {SaleInPercents}%\n")
                                       .Append($"Sale Price: {SalePrice}\n")
                                       .Append($"End Date: {EndTime}\n")
                                        .ToString();
        }
    }
}
