using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrackerLibrary.Models;
using System.Reflection;

namespace TrackerLibrary.DataAcces.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string FileName)//PrizeModel.csv
        {
            //C:\data\TournamentTracker
            return $"C:/data/TournamentTracker//{FileName}";//cre ca trebe \ nu /
        }

        public static List<string> LoadFile(this string file)
        {
            if(!File.Exists(file))
            {
                return new List<string>() ;
            }
            return File.ReadAllLines(file).ToList();
        }

        public static List<Prize> ConvertToPrizeModel(this List<string> lines)
        {
            List<Prize> output= new List<Prize>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');

                Prize p =new Prize();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName= cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]); 
                p.PrizePercentage = double.Parse(cols[4]);

                output.Add(p);

                
            }
            return output;
        }

        public static List<Person> ConvertToPersonModel(this List<string> lines)
        {
            List<Person> output= new List<Person>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                Person p =new Person();

                p.Id= int.Parse(cols[0]);
                p.FirstName = cols[1] ;
                p.LastName = cols[2] ;
                p.Email = cols[3] ;
                p.CellPhone = cols[4] ;

                output.Add(p);
            }
            return output;
        }

        public static void SaveToPrizeFile(this List<Prize> models, string fileName)
        {
            List<string> lines= new List<string>();

            foreach(Prize p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPeopleFile(this List<Person> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Person p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.Email},{p.CellPhone}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<Team> models, string fileName)
        {
            List<string> lines =new List<string>();

            foreach (Team t in models)
            {
                lines.Add(t.Id + "," + t.TeamName + "," + ConvertPeopleListToString(t.TeamMembers));
            }

            File.WriteAllLines (fileName.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<Tournament> models, string fileName)
        {
            List<string> lines=new List<string>();

            foreach (Tournament tm in models)
            {
                lines.Add(tm.Id + "," + tm.TournamentName + "," + tm.EntryFee + "," +
                    ConvertTeamListToString(tm.EnteredTeams) + "," +
                    ConvertPrizeListToString(tm.Prizes) + "," +
                    ConvertRoundListToString(tm.Rounds));

            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveRoundsToFile(this Tournament model, string matchupFile, string matchupEntryFile)
        {
            foreach (List<Matchup> round in model.Rounds)
            {
                foreach(Matchup matchup in round)
                {

                    matchup.SaveMatchupToFile(matchupFile,matchupEntryFile);

                }
            }
        }

        public static void SaveEntryToFile(this MatchupEntry entry, string matchupEntryFile)
        {
            List<MatchupEntry> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();

            int curentId = 1;

            if(entries.Count>0)
            {
                curentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }

            entry.Id= curentId;
            entries.Add(entry);

            List<string> lines = new List<string>();

            foreach (MatchupEntry e in entries)
            {
                string parent = "";
                if(e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (e.TeamCompeting!= null)
                {
                    teamCompeting = e.TeamCompeting.Id.ToString();
                }

                lines.Add(e.Id + "," + teamCompeting + "," + e.Score + "," + parent);
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
            
        }

        public static void UpdateEntryToFile(this MatchupEntry entry)
        {
            List<MatchupEntry> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();
            MatchupEntry oldEntry = new MatchupEntry();

            foreach(MatchupEntry me in entries)
            {
                if(me.Id == entry.Id)
                {
                    oldEntry = me;
                }
            }

            entries.Remove(oldEntry);

            entries.Add(entry);

            List<string> lines = new List<string>();

            foreach (MatchupEntry e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (e.TeamCompeting != null)
                {
                    teamCompeting = e.TeamCompeting.Id.ToString();
                }

                lines.Add(e.Id + "," + teamCompeting + "," + e.Score + "," + parent);
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);

        }

        public static void UpdateMatchupToFile(this Matchup matchup)
        {
            List<Matchup> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            Matchup oldMatchup = new Matchup();

            foreach (Matchup m in matchups)
            {
                if(m.Id ==  matchup.Id)
                {
                    oldMatchup = m;
                }
            }

            matchups.Remove(oldMatchup);
            matchups.Add(matchup);

            foreach (MatchupEntry entry in matchup.Entries)
            {
                entry.UpdateEntryToFile();
            }

            List<string> lines = new List<string>();

            foreach (Matchup m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add(m.Id + "," + ConvertMatchupEntryToString(m.Entries) + "," + winner + "," + m.MatchupRound);
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }




        public static void SaveMatchupToFile(this Matchup matchup, string matchupFile, string matchupEntryFile)
        {
            List<Matchup> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            int currentId = 1;

            if(matchups.Count>0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            matchup.Id = currentId;

            matchups.Add(matchup);

            foreach (MatchupEntry entry in matchup.Entries)
            {
                entry.SaveEntryToFile(matchupEntryFile);
            }

            List<string> lines = new List<string>();

            foreach (Matchup m in matchups)
            {
                string winner = "";
                if(m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add(m.Id + "," + ConvertMatchupEntryToString(m.Entries) + "," + winner + ","+ m.MatchupRound);
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static Team LookupTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();

            foreach (string team in teams)
            {
                string[] cols=team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModel(GlobalConfig.PeopleFile).First();
                }
            }

            return null;
        }

        public static Matchup LookupMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

            foreach (string  matchup in matchups)
            {
                string[] cols=matchup.Split(",");

                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModel().First();
                }
            }

            return null;
        }

        public static List<MatchupEntry> ConvertToMatchupEntryModel(this List<string> lines)
        {
            List<MatchupEntry> output=  new List<MatchupEntry>();

            foreach (string line in lines)
            {
                string[] cols= line.Split(',');

                MatchupEntry me =new MatchupEntry();
                me.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    me.TeamCompeting = null;
                }
                else
                {
                    me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
                }
                
                me.Score = double.Parse(cols[2]);
                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    me.ParentMatchup = LookupMatchupById(int.Parse(cols[3]));
                }
                else
                {
                    me.ParentMatchup = null;
                }

                output.Add(me);
            }

            return output;
        }

        public static List<MatchupEntry> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntry> output= new List<MatchupEntry>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries=new List<string>();

            foreach (string id in ids)
            {
                foreach( string entry in entries)
                {
                    string[] cols = entry.Split(",");

                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }

            output= matchingEntries.ConvertToMatchupEntryModel();

            return output;
        }

        public static List<Matchup> ConvertToMatchupModel(this List<string> lines)
        {
            List<Matchup> output = new List<Matchup>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Matchup p = new Matchup();
                p.Id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModels(cols[1]);

                if (cols[2].Length == 0)
                {
                    p.Winner = null;
                }
                else
                {
                    p.Winner = LookupTeamById(int.Parse(cols[2]));
                }
                p.MatchupRound = int.Parse(cols[3]);


                output.Add(p);


            }
            return output;
        }

        private static string ConvertRoundListToString(List<List<Matchup>> rounds)
        {
            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<Matchup> r in rounds)
            {
                output += ConvertMatchupListToString(r) + "|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertMatchupListToString(List<Matchup> matchups)
        {
            string output = "";

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (Matchup m in matchups)
            {
                output += m.Id + "|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertMatchupEntryToString(List<MatchupEntry> entries)
        {
            string output = "";

            if (entries.Count == 0)
            {
                return "";
            }

            foreach (MatchupEntry me in entries)
            {
                output += me.Id + "|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPrizeListToString(List<Prize> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (Prize p in prizes)
            {
                output += p.Id + "|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertTeamListToString(List<Team> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (Team t in teams)
            {
                output += t.Id + "|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPeopleListToString(List<Person> people)
        {
            string output = "";

            if(people.Count ==0)
            {
                return "";
            }

            foreach (Person p in people)
            {
                output += p.Id + "|";
            }

            output=output.Substring(0, output.Length - 1);

            return output;
        }

        public static List<Team> ConvertToTeamModel(this List<string> lines,string peopleFileName)
        {
            //id,team name, list of id separated by the pipe
            //3,Echipa 1,1|3|5
            List<Team> output=new List<Team>();
            List<Person> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Team t=new Team();
                t.Id = int.Parse(cols[0]);
                t.TeamName= cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(t);
            }

            return output;
        }

        public static List<Tournament> ConvertToTournamentModel(this List<string> lines, string teamFileName, string peopleFileName, string prizesFileName)
        {
            //id,TournamentName,EntryFee,(id|id|id) Entered Teams, (id|id|id Prizes), (Rounds  id^id^id|id^id^id|)
            List<Tournament>output=new List<Tournament>();
            List<Team> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModel(peopleFileName);
            List<Prize> prizes = prizesFileName.FullFilePath().LoadFile().ConvertToPrizeModel();
            List<Matchup> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            foreach(string line in lines)
            {
                string[] cols = line.Split(",");
                Tournament tm = new Tournament();
                tm.Id= int.Parse(cols[0]);
                tm.TournamentName= cols[1];
                tm.EntryFee= decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split("|");
                foreach (string id in teamIds)
                {
                    //t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                    tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                if (cols[4].Length > 0)
                {
                    string[] prizeIds = cols[4].Split("|");

                    foreach (string id in prizeIds)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    }

                }
                string[] rounds = cols[5].Split("|");
                

                foreach (string round in rounds)
                {
                    List<Matchup> ms = new List<Matchup>();
                    string[] msText = round.Split("^");
                    
                    foreach (string matchupTextId in msText)
                    {
                        ms.Add(matchups.Where(x => x.Id == int.Parse(matchupTextId)).First());
                    }
                    tm.Rounds.Add(ms);
                }

                //TO DO Capture Rounds Inforation
                output.Add(tm);

            }

            return output;
        }
    }
}
