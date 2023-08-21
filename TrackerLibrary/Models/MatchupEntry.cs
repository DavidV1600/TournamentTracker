using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntry
    {
        public int Id { get; set; }

        public int MatchupId { get; set; }

        public int ParentMatchupId { get; set; }

        public int TeamCompetingId { get; set; }

        public double Score { get; set; }

        public Team TeamCompeting { get; set; }

        public Matchup ParentMatchup { get; set; }
    }
}
