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
        public Prize CreatePrize(Prize model)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Tournaments;Integrated Security=True";
            SqlConnection conn=new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO dbo.Prizes (PlaceNumber,PlaceName,PrizeAmount,PrizePercentage) VALUES" +
                "(" + model.PlaceNumber + ",'" + model.PlaceName + "'," + model.PrizeAmount + "," + model.PrizePercentage + ")";
            //MERGE ASTA DE SUS NU TRE SA PUI LA ID VALOARE
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return model;

        }
    }

}
