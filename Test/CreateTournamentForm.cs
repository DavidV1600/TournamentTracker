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
using TrackerUI;

namespace Test
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequestor
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
            prizesListBox.DisplayMember = "PlaceName";
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
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();


        }

        public void PrizeComplete(Prize model)
        {
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(Team model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        private void deleteSelectedTeamsButton_Click(object sender, EventArgs e)
        {
            Team t = (Team)teamsCompetingListBox.SelectedItem;
            if (t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);

                WireUpLists();
            }
        }

        private void removeSelectedPrizesButton_Click(object sender, EventArgs e)
        {
            Prize p = (Prize)prizesListBox.SelectedItem;
            if (p != null)
            {
                selectedPrizes.Remove(p);

                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            decimal fee = 0;
            bool feeAcceptable=decimal.TryParse(entryFeeValue.Text, out fee);

            if(!feeAcceptable)
            {
                MessageBox.Show("You need to enter a valid fee!","Invalid fee",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            Tournament tm=new Tournament();

            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;
            tm.Prizes = selectedPrizes;
            tm.EnteredTeams = selectedTeams;

            //WireUpLists();

            TournamentLogic.CreateRounds(tm);

            GlobalConfig.Connections[0].CreateTournament(tm);

            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
            this.Close();
        }
    }
}
