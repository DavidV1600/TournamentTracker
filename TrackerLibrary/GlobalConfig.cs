﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAcces;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {

        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";

        public static List<IDataConnection> Connections { get; private set; }= new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFiles)
        {
            if(database)
            {
                // TODO -Create Sql Connection
                SqlConnector sql =  new SqlConnector(); 
                Connections.Add(sql); 
            }

            if(textFiles)
            {
                // TODO -Create Text Connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }

    }
}
