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
        public static void UpdateTournamentResults(Tournament tournament)
        {
            int startingRound = tournament.CheckCurrentRound();
            List<Matchup> toScore = new List<Matchup>();

            foreach (List<Matchup> round in tournament.Rounds)
            {
                foreach (Matchup rm in round)
                {
                    if(rm.Winner == null && (rm.Entries.Any(x => x.Score !=0) || rm.Entries.Count ==1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            MarkWinnersInMatchups(toScore);

            AdvanceWinners(toScore,tournament);

            toScore.ForEach(x => GlobalConfig.Connections[0].UpdateMatchup(x));

            int endingRound = tournament.CheckCurrentRound();

            if(endingRound > startingRound)
            {
                //Mail the Players
                //tournament.AlertUsersToNewRound();
                //Uncomment When emailing is ready
            }
        }

        public static void AlertUsersToNewRound(this Tournament tournament)
        {
            int currentRoundNumber = tournament.CheckCurrentRound();
            List<Matchup> currentRound = tournament.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

            foreach (Matchup matchup in currentRound)
            {
                foreach (MatchupEntry me in matchup.Entries)
                {
                    foreach (Person p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }

        private static void AlertPersonToNewRound(Person p, string teamName, MatchupEntry competitor)
        {
            if(p.Email.Length ==0)
            {
                return;
            }

            string fromAdress = "david.voinescu20030616@gmail.com";
            string toAdress = "";
            string subject = "";
            StringBuilder body = new StringBuilder();

            if(competitor != null)
            {
                subject = "You have a new matchup with " + competitor.TeamCompeting.TeamName;
                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine("Have a great time!");
                body.AppendLine("~Tournament Tracker");
            }
            else
            {
                subject = "You have a bye this round";
                body.AppendLine("Enjoy your free round win (you have a bye)");
                body.AppendLine("~Tournament Tracker");
            }

            toAdress = p.Email;

            EmailLogic.SendEmail(fromAdress, toAdress, subject, body.ToString());
        }

        private static int CheckCurrentRound(this Tournament model)
        {
            int output = 1;

            foreach (List<Matchup> round in model.Rounds)
            {
                if(round.All(x => x.Winner != null))
                {
                    output += 1;
                }
            }

            if (output == model.Rounds.Count+1)
            {
                CompleteTournament(model);
            }
            return output - 1;
            //CAREFULL HERE
        }

        private static void CompleteTournament(Tournament model)
        {
            Team winners = model.Rounds.Last().First().Winner;
            Team runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;

            if(model.Prizes.Count > 0)
            {
                decimal totalIncome = model.EnteredTeams.Count() * model.EntryFee;
                Prize firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                Prize secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if(firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrizePayout(totalIncome);
                }
                if(secondPlacePrize != null)
                {
                    runnerUpPrize = secondPlacePrize.CalculatePrizePayout(totalIncome);
                }
            }

            model.CompleteTournament();
        }

        private static decimal CalculatePrizePayout (this Prize prize, decimal totalIncome)
        {
            decimal output = 0;
            if(prize.PrizeAmount > 0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome , Convert.ToDecimal(prize.PrizePercentage/100));
            }

            return output;
        }

        private static void AdvanceWinners(List<Matchup> toScore, Tournament tournament)
        {
            foreach (Matchup m in toScore)
            {
                foreach(List<Matchup> round in tournament.Rounds)
                {
                    foreach (Matchup rm in round)
                    {
                        foreach(MatchupEntry me in rm.Entries)
                        {
                            if(me.ParentMatchup != null)
                            {
                                if(me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connections[0].UpdateMatchup(rm);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MarkWinnersInMatchups(List<Matchup> toScore)
        {
            foreach(Matchup m in toScore)
            {
                if(m.Entries.Count==1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                if (m.Entries[0].Score > m.Entries[1].Score)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                }
                else if (m.Entries[0].Score < m.Entries[1].Score)
                {
                    m.Winner = m.Entries[1].TeamCompeting;
                }
                else
                {
                    throw new Exception("Ties aren't allowed as the final result");
                }
            }
        }

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
