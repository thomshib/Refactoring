using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring.Refactored
{
    
        public class PlayLists
        {
            List<Play> plays;
            public PlayLists()
            {
                plays = new List<Play>();
                plays.Add(new Play { Name = "Hamlet", Type = "tragedy" });
                plays.Add(new Play { Name = "As You Like It", Type = "comedy" });
                plays.Add(new Play { Name = "Othello", Type = "tragedy" });

            }

            public Play this[string playId]
            {
                get
                {
                    return plays.Where(item => item.Name == playId).FirstOrDefault();

                }


            }
        }
    
}
