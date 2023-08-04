using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class Matchup
    {
        /// <summary>
        /// Represents the entries for the matchup
        /// </summary>
        public List<MatchupEntry> Entries { get; set; }

        /// <summary>
        /// Represents the winner of the match
        /// </summary>
        public Team Winner { get; set; }

        /// <summary>
        /// Represent nus ce
        /// </summary>
        public int MatchupRound { get; set; }

    }

}
