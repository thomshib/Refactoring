using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Refactored.MovieRental
{
    public class Movie
    {
        public  const int CHILDRENS = 2;
        public   const int REGULAR = 0;
        public   const int NEW_RELEASE = 1;

        private string _title;
        //private int _priceCode;
        private Price _price;
        public Movie(String title, int priceCode)
        {
            _title = title;
            //_priceCode = priceCode;
            setPriceCode(priceCode);
        }
        public int getPriceCode()
        {
            //return _priceCode;
            return _price.GetPriceCode();
        }
        public void setPriceCode(int arg)
        {
            //_priceCode = arg;

            switch(arg)
            {
                case REGULAR:
                    _price = new RegularPrice();
                    break;
                case CHILDRENS:
                    _price = new ChildrensPrice();
                    break;
                case NEW_RELEASE:
                    _price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentException("Incorrect Price Code");

            }
        }
        public String getTitle()
        {
            return _title;
        }

        public double GetCharge(int daysRented)
        {
            /*
            double result = 0;
            switch (getPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;

            */

            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if ((getPriceCode() == Movie.NEW_RELEASE)
              &&
              (daysRented > 1))
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

    }
}
