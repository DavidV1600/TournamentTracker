using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {

        public static void CreateRounds(Tournament model)
        {
            List<Team> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds=FindNumberOfROunds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds,randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes,randomizedTeams));

            CreateOtherRounds(model, rounds);
        }

        private static void CreateOtherRounds(Tournament model, int numberOfRounds)
        {
            int round = 2;
            List<Matchup> previousRound = model.Rounds[0];
            List<Matchup> currentRound = new List<Matchup>();
            Matchup currMatchup= new Matchup();

            while(round<= numberOfRounds)
            {
                foreach (Matchup match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntry { ParentMatchup=match });

                    if(currMatchup.Entries.Count>1)
                    {
                        currMatchup.MatchupRound = round;
                        currentRound.Add(currMatchup);
                        currMatchup = new Matchup();
                    }
                }

                model.Rounds.Add(currentRound);
                previousRound = currentRound;
                currentRound=new List<Matchup>();
                round += 1;
            }
        }

        private static List<Matchup> CreateFirstRound(int byes, List<Team> teams)
        {
            List<Matchup> output = new List<Matchup>();
            Matchup curentModel = new Matchup();
            foreach (Team team in teams)
            {
                
                curentModel.Entries.Add(new MatchupEntry { TeamCompeting = team, TeamCompetingId = team.Id });

                if (byes > 0 || curentModel.Entries.Count > 1)
                {
                    curentModel.MatchupRound = 1;
                    output.Add(curentModel);
                    curentModel = new Matchup();
                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }
            return output;
        }


        private static int NumberOfByes(int rounds,int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for(int i=1; i<=rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;

            return output;
        }

        private static int FindNumberOfROunds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while(val<teamCount)
            {
                output += 1;

                val *= 2;
            }

            return output;
        }

        private static List<Team> RandomizeTeamOrder(List<Team> teams)
        {
            // cards.OrderBy(a => Guid.NewGuid()).ToList();
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
