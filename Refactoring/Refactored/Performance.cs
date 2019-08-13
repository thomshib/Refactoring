using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Refactored
{
    public class Performance
    {
        public string playID { get; set; }
        public int audience { get; set; }

        public Play Play { get; set; }

        public double Amount { get; set; }

        public double VolumeCredits { get; set; }

        public Performance EnrichPerformance(Performance perf)
        {
            return null;
        }

    }
}
