using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Refactoring.Refactored
{
    public class Invoice
    {
        public Customer Customer { get; set; }
        public List<Performance> performances { get; set; }
        private PlayLists plays;


        public Invoice()
        {
            plays = new PlayLists();
        }
        public string Statement(Invoice invoice, PlayLists plays)
        {
            double totalAmount = 0.0;
            double volumeCredits = 0.0;
            string result = $"Statement for ${ invoice.Customer.Name}\n";

            // Gets a NumberFormatInfo associated with the en-US culture.
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            string currencyFormat = "C";



            //const format = new Intl.NumberFormat("en­US", style: "currency", currency: "USD", minimumFractionDigits: 2 }).format;

            foreach (var perf in invoice.performances)
            {

                //var play = this.plays[perf.playID];
                //double thisAmount = 0;
                //thisAmount = AmountFor(perf);

                //// add volume credits
                //volumeCredits += Math.Max(perf.audience - 30, 0);

                //// add extra credit for every ten comedy attendees
                //if ("comedy" == PlayFor(perf).Type) volumeCredits += Math.Floor(perf.audience / 5.0);

                volumeCredits += VolumeCreditFor(perf);

                // print line for this order
                result += $"{PlayFor(perf).Name}: $({Format(AmountFor(perf) / 100)} (${perf.audience} seats)\n";
                totalAmount += AmountFor(perf);
            }
            result += $"Amount owed is ${Format((totalAmount/100))}\n";
            result += $"You earned ${volumeCredits} credits\n";
            return result;
        }


        //Extract Method
        //public double AmountFor(Play play, Performance perf)

        //remove temp variable
        public double AmountFor(Performance perf)
        {
            double result = 0;
            switch (PlayFor(perf).Type)
            {

                case "tragedy":
                    result = 40000;
                    if (perf.audience > 30)
                    {
                        result += 1000 * (perf.audience - 30);
                    }
                    break;

                case "comedy":
                    result = 30000;
                    if (perf.audience > 20)
                    {
                        result += 10000 + 500 * (perf.audience - 20);
                    }
                    result += 300 * perf.audience;
                    break;

                default:
                    throw new ArgumentException($"unknown type: { PlayFor(perf).Type}");
            }

            return result;
        }

        //Extract Variable

        public Play PlayFor(Performance perf)
        {
            var play = this.plays[perf.playID];
            return play;
        }


        public double VolumeCreditFor(Performance perf)
        {
            double result = 0.0;

            // add volume credits
            result += Math.Max(perf.audience - 30, 0);

            // add extra credit for every ten comedy attendees
            if ("comedy" == PlayFor(perf).Type) result += Math.Floor(perf.audience / 5.0);

            return result;
        }

        public string Format(double input)
        {
           
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            string currencyFormat = "C";
            return input.ToString(currencyFormat, nfi);
        }
    }
}
