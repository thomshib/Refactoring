﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.UnRefactored.MovieRental
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
    }
}
