using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntry
    {
        /// <summary>
        /// Represents one team in the matchup.
        /// </summary>
        public Team TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score for this particular team.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Representes the matchup that this team came
        /// </summary>
        public Matchup ParentMatchup { get; set; }
    }
}
