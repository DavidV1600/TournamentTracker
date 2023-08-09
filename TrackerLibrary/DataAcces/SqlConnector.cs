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

        public Person CreatePerson(Person model)
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.People (FirstName,LastName,EmailAdress,CellphoneNumber) VALUES" +
                "('"+model.FirstName+"',"+"'"+model.LastName+"'," + "'" + model.Email + "',"+"'" + model.CellPhone + "')";
            //MERGE ASTA DE SUS NU TRE SA PUI LA ID VALOARE
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return model;
        }

        public Prize CreatePrize(Prize model)
        {
            string connectionString = db;
            SqlConnection conn=new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.Prizes (PlaceNumber,PlaceName,PrizeAmount,PrizePercentage) VALUES" +
                "(" + model.PlaceNumber + ",'" + model.PlaceName + "'," + model.PrizeAmount + "," + model.PrizePercentage + ")";
            //MERGE ASTA DE SUS NU TRE SA PUI LA ID VALOARE
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();

            query = "SELECT COUNT(*) from dbo.People";
            cmd=new SqlCommand(query,conn);
            model.Id=(int)cmd.ExecuteScalar();
            conn.Close();
            return model;

        }

        public Team CreateTeam(Team model)
        {
            string connectionString = db;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.Teams (TeamName) VALUES" +
                "('" + model.TeamName + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "SELECT COUNT(*) from dbo.Teams";
            cmd = new SqlCommand(query, conn);
            model.Id = (int)cmd.ExecuteScalar();

            foreach (Person p in model.TeamMembers)
            {
                query = "INSERT INTO  dbo.TeamMembers (TeamId,PersonId) VALUES"+
                    "("+model.Id+","+p.Id+")";
                cmd= new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
            return model;
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
    }

}
