using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Refactored.MovieRental
{
    abstract class Price
    {
        public abstract int GetPriceCode();
        public abstract double GetCharge(int daysRented);
        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
