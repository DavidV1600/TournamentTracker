using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrackerLibrary.Models;

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
            }

            return output;
        }
    }
}
