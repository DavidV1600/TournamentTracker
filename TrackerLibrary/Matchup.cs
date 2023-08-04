using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class Matchup
    {
        public List<MatchupEntry> Entries { get; set; }

        public Team Winner { get; set; }

        public int MatchupRound { get; set; }
    }

}
