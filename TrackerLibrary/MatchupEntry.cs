using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntry
    {
        public Team TeamCompeting { get; set; }

        public double Score { get; set; }

        public Matchup ParentMatchup { get; set; }
    }
}
