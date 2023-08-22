using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAcces
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Data Source=.\\SQLEXPRESS;Initial Catalog=Tournaments;Integrated Security=True";

        public void CreatePerson(Person model)
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.People (FirstName,LastName,EmailAdress,CellphoneNumber) VALUES" +
                "('"+model.FirstName+"',"+"'"+model.LastName+"'," + "'" + model.Email + "',"+"'" + model.CellPhone + "')";
            //MERGE ASTA DE SUS NU TRE SA PUI LA ID VALOARE
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            query = "SELECT COUNT(*) from dbo.People";
            cmd =new SqlCommand(query, conn);
            model.Id=(int)cmd.ExecuteScalar();
            conn.Close();
        }

        public void CreatePrize(Prize model)
        {
            string connectionString = db;
            SqlConnection conn=new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.Prizes (PlaceNumber,PlaceName,PrizeAmount,PrizePercentage) VALUES" +
                "(" + model.PlaceNumber + ",'" + model.PlaceName + "'," + model.PrizeAmount + "," + model.PrizePercentage + ")";
            //MERGE ASTA DE SUS NU TRE SA PUI LA ID VALOARE
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();

            query = "SELECT COUNT(*) from dbo.Prizes";
            cmd=new SqlCommand(query,conn);
            model.Id=(int)cmd.ExecuteScalar();
            conn.Close();

        }

        public void CreateTeam(Team model)
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.Teams (TeamName) VALUES" +
                "('" + model.TeamName + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close() ;

            conn.Open() ;
            query = "SELECT COUNT(*) from dbo.Teams";
            cmd = new SqlCommand(query, conn);
            model.Id = (int)cmd.ExecuteScalar();
            conn.Close();

            conn.Open();
            foreach (Person p in model.TeamMembers)
            {
                query = "INSERT INTO  dbo.TeamMembers (TeamId,PersonId) VALUES"+
                    "("+model.Id+","+p.Id+")";
                cmd= new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }

        public void CreateTournament(Tournament model)
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //Should Write some SaveTournament function and others to write this code there
            string query = "INSERT INTO dbo.Tournaments (TournamentName,EntryFee) VALUES" +
                "('" + model.TournamentName + "',"+model.EntryFee+")";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            query = "SELECT COUNT(*) from dbo.Tournaments";
            cmd = new SqlCommand(query, conn);
            model.Id = (int)cmd.ExecuteScalar();

            foreach (Team t in model.EnteredTeams)
            {
                query = "INSERT INTO  dbo.TournamentEntries (TournamentId,TeamId) VALUES" +
                    "(" + model.Id + "," + t.Id + ")";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                /*query = "SELECT COUNT(*) from dbo.TournamentEntries";
                cmd = new SqlCommand(query, conn);
                t.Id = (int)cmd.ExecuteScalar();*/
            }
            


            foreach (Prize p in model.Prizes)
            {
                query = "INSERT INTO dbo.TournamentPrizes (TournamentId,PrizeId) VALUES"+
                    "("+model.Id +","+p.Id+")";
            }

            foreach (List<Matchup> round in model.Rounds)
            {
                foreach(Matchup matchup in round)
                {
                    query = "INSERT INTO  dbo.Matchups (MatchupRound,TournamentId) VALUES" +
                    "(" + matchup.MatchupRound + "," + model.Id + ")";
                    cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "SELECT COUNT(*) from dbo.Matchups";
                    cmd = new SqlCommand(query, conn);
                    matchup.Id = (int)cmd.ExecuteScalar();

                    foreach(MatchupEntry entry in matchup.Entries)
                    {
                        if(entry.TeamCompeting == null && entry.ParentMatchup==null)
                        {
                            query = "INSERT INTO  dbo.MatchupEntries (MatchupId) VALUES" +
                            "(" + matchup.Id +")";
                        }
                        else if(entry.TeamCompeting == null)
                        {
                            query = "INSERT INTO  dbo.MatchupEntries (MatchupId,ParentMatchupId) VALUES" +
                            "(" + matchup.Id + "," + entry.ParentMatchup.Id+")";
                        }
                        else if(entry.ParentMatchup == null)
                        {
                            query = "INSERT INTO  dbo.MatchupEntries (MatchupId,TeamCompetingId) VALUES" +
                            "(" + matchup.Id +","+ entry.TeamCompeting.Id+")";
                        }
                        else
                        {
                            query = "INSERT INTO  dbo.MatchupEntries (MatchupId,ParentMatchupId,TeamCompetingId) VALUES" +
                            "(" + matchup.Id + "," + entry.ParentMatchup.Id + "," + entry.TeamCompeting.Id + ")";
                        }
                        cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();

                        query = "SELECT COUNT(*) from dbo.MatchupEntries";
                        cmd = new SqlCommand(query, conn);
                        entry.Id = (int)cmd.ExecuteScalar();
                    }
                }
            }

            conn.Close();

            TournamentLogic.UpdateTournamentResults(model);
        }

        public List<Person> GetPerson_All()
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            List<Person> output;

            string query = "Select * from dbo.People";

            output=conn.Query<Person>(query).ToList();

            conn.Close();

            return output;
        }

        public List<Team> GetTeam_All()
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            List<Team> output;

            string query = "Select * from dbo.Teams";

            output = conn.Query<Team>(query).ToList();

            foreach(Team team in output)
            {
                query = "select p.* from dbo.TeamMembers m " +
                    "inner join dbo.People p on m.PersonId=p.id " +
                    "where m.TeamId="+team.Id;

                team.TeamMembers=conn.Query<Person>(query).ToList() ;
            }

            conn.Close() ;

            return output;
        }

        public List<Tournament> GetTournament_All()
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            List<Tournament> output;

            string query = "Select * from dbo.Tournaments";

            output = conn.Query<Tournament>(query).ToList();

            foreach (Tournament tournament in output)
            {
                query = "select p.* from dbo.Prizes p " +
                    "inner join dbo.TournamentPrizes t on p.id=t.PrizeId " +
                    "where t.TournamentId=" + tournament.Id;

                tournament.Prizes = conn.Query<Prize>(query).ToList();

                query= "select t.* from dbo.Teams t  " +
                    "inner join dbo.TournamentEntries e on t.id=e.TeamId "+
                    "where e.TournamentId=" + tournament.Id;

                tournament.EnteredTeams = conn.Query<Team>(query).ToList();

                foreach (Team team in tournament.EnteredTeams)
                {
                    query = "select p.* from dbo.TeamMembers m " +
                    "inner join dbo.People p on m.PersonId=p.id " +
                    "where m.TeamId=" + team.Id;
                    team.TeamMembers = conn.Query<Person>(query).ToList();
                }

                query = "select m.* from dbo.Matchups m " +
                "where m.TournamentId=" + tournament.Id+
                " order by MatchupRound";
                
                List<Matchup> matchups = conn.Query<Matchup>(query).ToList();

                foreach (Matchup m in matchups)
                {
                    query = "select * from dbo.MatchupEntries "+
                    "where MatchupId="+m.Id;

                    m.Entries = conn.Query<MatchupEntry>(query).ToList();

                    List<Team> allTeams = GetTeam_All();

                    if(m.WinnerId > 0)
                    {
                        m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                    }

                    foreach (var me in m.Entries)
                    {
                        if(me.TeamCompetingId > 0)
                        {
                            me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                        }

                        if(me.ParentMatchupId > 0)
                        {
                            me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupId).First();
                        }
                    }
                }
                List<Matchup> currRow = new List<Matchup>();
                int currRound = 1;
                foreach(Matchup m in matchups)
                {
                    if(m.MatchupRound >  currRound)
                    {
                        tournament.Rounds.Add(currRow);
                        currRow = new List<Matchup>();
                        currRound += 1;
                    }

                    currRow.Add(m);
                }

                tournament.Rounds.Add(currRow);
            }

            conn.Close();

            return output;
        }

        public void UpdateMatchup(Matchup model)
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "";
            SqlCommand cmd = new SqlCommand();

            if (model.Winner != null)
            {
                query = "update dbo.Matchups set WinnerId=" + model.Winner.Id + " where id=" + model.Id;
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            foreach (MatchupEntry me in model.Entries)
            {
                if (me.TeamCompeting != null)
                {
                    query = "update dbo.MatchupEntries set TeamCompetingId=" + me.TeamCompeting.Id + " , Score=" + me.Score + " where id=" + me.Id;
                    cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();

        }
    }

}
