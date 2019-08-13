using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.UnRefactored
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
                    var totalAmount = 0.0;
                    double volumeCredits = 0.0;
                    string result = $"Statement for ${ invoice.Customer.Name}\n";

                    //const format = new Intl.NumberFormat("en­US", style: "currency", currency: "USD", minimumFractionDigits: 2 }).format;

                    foreach(var perf in invoice.performances) {

                        var play = this.plays[perf.playID];
                        double thisAmount = 0;
                        switch(play.Type) {

                            case "tragedy":
                                thisAmount = 40000;
                                if (perf.audience > 30) {
                                        thisAmount += 1000 * (perf.audience - 30);
                                    }
                                break;

                            case "comedy":
                                thisAmount = 30000;
                                if (perf.audience > 20) {
                                    thisAmount += 10000 + 500 * (perf.audience - 20);
                                }
                                thisAmount += 300 * perf.audience;
                                break;

                            default:
                                throw new ArgumentException($"unknown type: { play.Type}");
                            }

                            // add volume credits
                            volumeCredits += Math.Max(perf.audience - 30, 0);

                            // add extra credit for every ten comedy attendees
                            if ("comedy" == play.Type) volumeCredits += Math.Floor(perf.audience / 5.0);

                                // print line for this order
                                result += $"{play.Name}: ${thisAmount/100} (${perf.audience} seats)\n";
                                totalAmount += thisAmount;
                            }
                            result += "Amount owed is ${format(totalAmount/100)}\n";
                            result += "You earned ${volumeCredits} credits\n";
                            return result;
                    }

    }
}
