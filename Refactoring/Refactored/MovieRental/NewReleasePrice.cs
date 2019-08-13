using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Refactored.MovieRental
{
    class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NEW_RELEASE;
        }
        public override double GetCharge(int daysRented)
        {
           

           return daysRented * 3;

         
        }
        public int GetFrequentRenterPoints(int daysRented)
        {
           

            return daysRented > 1 ? 2 : 1;
        }
    }
}
