using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents the entries for the matchup
        /// </summary>
        public List<MatchupEntry> Entries { get; set; }= new List<MatchupEntry>();

        /// <summary>
        /// The id of the Winner team
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// Represents the winner of the match
        /// </summary>
        public Team Winner { get; set; }

        /// <summary>
        /// Represent nus ce
        /// </summary>
        public int MatchupRound { get; set; }

        public string DisplayName
        {
            get
            {
                string output = "";
                foreach ( MatchupEntry me in Entries )
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output == "")
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += " vs. " + me.TeamCompeting.TeamName;
                        }
                    }
                    else
                    {
                        output = "Matchup Not Determined Yet";
                        break;
                    }
                }

                return output;
            }
        }
    }

}
