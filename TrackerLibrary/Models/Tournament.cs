using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Tournament
    {
        /// <summary>
        /// Represents the name of the tournament
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Represents the entry fee for the tournament
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Represente the list of the teams in the competition
        /// </summary>
        public List<Team> EnteredTeams { get; set; } = new List<Team>();

        /// <summary>
        /// Represents the list of the available prizes
        /// </summary>
        public List<Prize> Prizes { get; set; } = new List<Prize>();

        /// <summary>
        /// Represents the rounds of the tournament
        /// </summary>
        public List<List<Matchup>> Rounds { get; set; } = new List<List<Matchup>>();
    }
}
