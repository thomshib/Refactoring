using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Refactored.MovieRental
{
   public class Customer
    {
        private String _name;
        private List<Rental> _rentals = new List<Rental>();
        public Customer(String name)
        {
            _name = name;
        }
        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }
        public String getName()
        {
            return _name;
        }


        public String statement()
        {
            //double totalAmount = 0;
            //int frequentRenterPoints = 0;
            var rentals = _rentals.GetEnumerator();
            String result = "Rental Record for " + getName() + "\n";
            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = rentals.Current;
                //determine amounts for each line
                //thisAmount = AmountFor(each);

                //thisAmount = each.GetCharge();

                //// add frequent renter points               
                //frequentRenterPoints++;

                //// add bonus for a two day new release rental
                //if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE)
                //&&
                //each.getDaysRented() > 1) frequentRenterPoints++;

                //frequentRenterPoints += each.GetFrequentRenterPoints();

                //show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + each.GetCharge().ToString() + "\n";    
                //totalAmount += thisAmount;
            }
            //add footer lines
            //result += "Amount owed is " +totalAmount.ToString() +  "\n";
            result += "Amount owed is " + GetTotalCharge().ToString() + "\n";

            //result += "You earned " + frequentRenterPoints.ToString()   + " frequent renter points";
            result += "You earned " + GetFrequentRenterPoints().ToString() + " frequent renter points";
            return result;
        }



        private double AmountFor(Rental input)
        {
            /*
            double result = 0;
            
            //determine amounts for each line
            switch (input.getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (input.getDaysRented() > 2)
                        result += (input.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += input.getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (input.getDaysRented() > 3)
                        result += (input.getDaysRented() - 3) * 1.5;
                    break;
            }
            

            return result;
            */

            return input.GetCharge();
        }

        private double GetTotalCharge()
        {
            var rentals = _rentals.GetEnumerator();
            double result = 0;
            while (rentals.MoveNext())
            {
               
                Rental each = rentals.Current;
                result += each.GetCharge();

               
            }

            return result;
        }

        private int GetFrequentRenterPoints()
        {
            var rentals = _rentals.GetEnumerator();
            int result = 0;
            while (rentals.MoveNext())
            {

                Rental each = rentals.Current;
                result += each.GetFrequentRenterPoints();


            }

            return result;
        }


    }
  }
