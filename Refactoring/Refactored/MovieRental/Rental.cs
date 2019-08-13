using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Refactored.MovieRental
{
    public class Rental
    {

        private Movie _movie;
        private int _daysRented;
        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
        public int getDaysRented()
        {
            return _daysRented;
        }
        public Movie getMovie()
        {
            return _movie;
        }

        public double GetCharge()
        {
            /*
            double result = 0;


            switch (getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (getDaysRented() > 2)
                        result += (getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (getDaysRented() > 3)
                        result += (getDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
            */
            return _movie.GetCharge(_daysRented);
        }

        public int GetFrequentRenterPoints()
        {
            /*
            if ((getMovie().getPriceCode() == Movie.NEW_RELEASE)
              &&
              getDaysRented() > 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
            */

            return _movie.GetFrequentRenterPoints(_daysRented);
        }
    }
}
