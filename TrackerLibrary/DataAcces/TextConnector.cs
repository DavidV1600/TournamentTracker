using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAcces.TextHelpers;
namespace TrackerLibrary.DataAcces
{
    public class TextConnector : IDataConnection
    {
        public void CreatePerson(Person model)
        {
            List<Person> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            people.Add(model);

            people.SaveToPeopleFile();

        }

        public void CreatePrize(Prize model)
        {
            List<Prize> prizes= GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            int currentId = 1;
            if (prizes.Count > 0)
            {
              currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            prizes.Add(model);

            prizes.SaveToPrizeFile();

        }

        public void CreateTeam(Team model)
        {
            List<Team> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();

            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            teams.Add(model);

            teams.SaveToTeamFile();

        }

        public void CreateTournament(Tournament model)
        {
            List <Tournament>  tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModel(GlobalConfig.TeamFile,GlobalConfig.PeopleFile,GlobalConfig.PrizesFile);

            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundsToFile();

            tournaments.Add(model);

            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResults(model);
        }

        public List<Person> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public List<Team> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();
        }

        public List<Prize> GetPrize_All()
        {
            return GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();
        }

        public List<Tournament> GetTournament_All()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModel(GlobalConfig.TeamFile, GlobalConfig.PeopleFile, GlobalConfig.PrizesFile);
        }

        public void UpdateMatchup(Matchup model)
        {
            model.UpdateMatchupToFile();
        }
    }
}
