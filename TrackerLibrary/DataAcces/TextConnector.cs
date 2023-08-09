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
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";

        public Person CreatePerson(Person model)
        {
            List<Person> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model;
        }

        public Prize CreatePrize(Prize model)
        {
            List<Prize> prizes= PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            int currentId = 1;
            if (prizes.Count > 0)
            {
              currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            prizes.Add(model);

            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public Team CreateTeam(Team model)
        {
            List<Team> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);

            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            return model;
        }

        public List<Person> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public List<Team> GetTeam_All()
        {
            throw new NotImplementedException();
        }
    }
}
