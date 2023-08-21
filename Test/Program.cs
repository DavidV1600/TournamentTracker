using MySqlConnector;
using System.Data.SqlClient;

namespace Test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            TrackerLibrary.GlobalConfig.InitializeConnections(true,false);//1-Sql, 2-Txt
            ApplicationConfiguration.Initialize();
            Application.Run(new TournamentDashboardForm());
        }
    }
}