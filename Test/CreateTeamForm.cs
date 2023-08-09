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
    public partial class CreateTeamForm : Form
    {
        private List<Person> availableTeamMembers = GlobalConfig.Connections[0].GetPerson_All();
        private List<Person> selectedTeamMembers = new List<Person>();

        public CreateTeamForm()
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            deleteMembersListBox.DataSource = null;

            deleteMembersListBox.DataSource = selectedTeamMembers;
            deleteMembersListBox.DisplayMember = "FullName";
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            availableTeamMembers.Add(new Person { FirstName = "David", LastName = "John" });

            selectedTeamMembers.Add(new Person { FirstName = "John", LastName = "Bravo" });
            selectedTeamMembers.Add(new Person { FirstName = "Din", LastName = "Bin" });
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Person p = new Person();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.Email = emailValue.Text;
                p.CellPhone = cellphoneValue.Text;

                p = GlobalConfig.Connections[0].CreatePerson(p);//Am folosit 0 pentru conexiunea cu sql

                selectedTeamMembers.Add(p);

                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";


            }
            else
            {
                MessageBox.Show("You need to fill al the fields!");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (emailValue.Text.Length == 0)
            {
                return false;
            }
            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            Person p = (Person)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void removeSelectedMembersButton_Click(object sender, EventArgs e)
        {
            Person p = (Person)deleteMembersListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (teamNameValue.Text.Length > 0)
            {
                Team t = new Team();
                t.TeamName = teamNameValue.Text;
                t.TeamMembers = selectedTeamMembers;

                t = GlobalConfig.Connections[0].CreateTeam(t);

            }
        }
    }
}
