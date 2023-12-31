﻿using System;
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
    public partial class TournamentViewerForm : Form
    {
        private Tournament tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<Matchup> selectedMatchups = new BindingList<Matchup>();

        public TournamentViewerForm(Tournament tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        private void Tournament_OnTournamentComplete(object? sender, DateTime e)
        {
            MessageBox.Show("Tournament Has Finished!");
            this.Close();
        }

        private void LoadFormData()
        {
            tournamentNameLabel.Text = tournament.TournamentName;
        }

        private void LoadRounds()
        {
            //rounds = new BindingList<int>();
            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<Matchup> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);

                }
            }

            LoadMatchups(1);
            //WireUpRoundLists();

            //roundsBinding.ResetBindings(false);
        }
        private void WireUpLists()
        {
            //matchupListBox.DataSource = null;
            roundDropDown.DataSource = rounds;

            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void LoadMatchups(int round)
        {

            foreach (List<Matchup> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (Matchup m in matchups)
                    {
                        if (m.Winner == null || !unplayedOnlyCheckBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }
            //WireUpMatchupsLists();
            //matchupsBinding.ResetBindings(false);
            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            teamOneLabel.Visible = isVisible;
            teamTwoLabel.Visible = isVisible;
            score1Label.Visible = isVisible;
            score2Label.Visible = isVisible;
            score1Value.Visible = isVisible;
            score2Value.Visible = isVisible;
            vsLabel.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        private void LoadMatchup(Matchup m)
        {

            for (int i = 0; i < m.Entries.Count; i++)
            {

                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        score1Value.Text = m.Entries[0].Score.ToString();

                        teamTwoLabel.Text = "<Bye>";
                        score2Value.Text = "0";
                    }
                    else
                    {
                        teamOneLabel.Text = "Not Yet Set";
                        score1Value.Text = "";
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        score2Value.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoLabel.Text = "Not Yet Set";
                        score2Value.Text = "";
                    }
                }
            }

        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedMatchups.Any()) // Check if there are selected matchups
            {
                LoadMatchup((Matchup)matchupListBox.SelectedItem);
            }
        }

        private void TournamentViewerForm_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {

        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);

        }

        private string ValidateData()
        {
            string output = "";

            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool score1Valid = double.TryParse(score1Value.Text, out teamOneScore);
            bool score2Valid = double.TryParse(score2Value.Text, out teamTwoScore);

            if(!score1Valid || !score2Valid)
            {
                output = "The Score for one of the teams is not valid";
            }
            if(teamOneScore == teamTwoScore)
            {
                output = "The score between the teams can't be a tie";
            }

            return output;
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            string errorMessage=ValidateData();
            if (errorMessage!="")
            {
                MessageBox.Show("Error Message: "+errorMessage);
                return;
            }

            Matchup m = (Matchup)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {

                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(score1Value.Text, out teamOneScore);

                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            //m.Entries[0].Score = 0;
                            MessageBox.Show("Please Enter a Valid Score for Team 1");
                            return;
                        }
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(score2Value.Text, out teamTwoScore);

                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            //m.Entries[0].Score = 0;
                            MessageBox.Show("Please Enter a Valid Score for Team 1");
                            return;
                        }
                    }

                }
            }
            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("The aplication had the following error " + ex.Message);
                return;
            }
            LoadMatchups((int)roundDropDown.SelectedItem);

            
        }
    }
}

