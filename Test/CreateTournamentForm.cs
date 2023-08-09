using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace Test
{
    public partial class CreateTournamentForm : Form
    {
        List<Team> availableTeams = GlobalConfig.Connections[0].GetTeam_All();
        List<Team> selectedTeams = new List<Team>();
        List<Prize> selectedPrizes = new List<Prize>();


        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void CreateTournamentForm_Load(object sender, EventArgs e)
        {

        }

        private void WireUpLists()
        {
            selectedTeamDropDown.DataSource = null;
            selectedTeamDropDown.DataSource = availableTeams;
            selectedTeamDropDown.DisplayMember = "TeamName";

            teamsCompetingListBox.DataSource = null;
            teamsCompetingListBox.DataSource = selectedTeams;
            teamsCompetingListBox.DisplayMember = "TeamName";


            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            Team t = (Team)selectedTeamDropDown.SelectedItem;

            if (t != null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);

                WireUpLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm frm=new CreatePrizeForm();
            frm.Show();
        }
    }
}
