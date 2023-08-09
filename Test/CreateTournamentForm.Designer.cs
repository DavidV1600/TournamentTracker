namespace Test
{
    partial class CreateTournamentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            createTournamentLabel = new Label();
            entryFeeValue = new TextBox();
            tournamentNameValue = new TextBox();
            tournamentNameLabel = new Label();
            entryFeeLabel = new Label();
            selectTeamLabel = new Label();
            teamsLabel = new Label();
            prizesLabel = new Label();
            teamsCompetingListBox = new ListBox();
            prizesListBox = new ListBox();
            createPrizeButton = new Button();
            createTournamentButton = new Button();
            addTeamButton = new Button();
            deleteSelectedTeamsButton = new Button();
            deleteSelectedPrizesButton = new Button();
            createNewTeamLink = new LinkLabel();
            selectedTeamDropDown = new ComboBox();
            SuspendLayout();
            // 
            // createTournamentLabel
            // 
            createTournamentLabel.AutoSize = true;
            createTournamentLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            createTournamentLabel.Location = new Point(85, 57);
            createTournamentLabel.Name = "createTournamentLabel";
            createTournamentLabel.Size = new Size(208, 31);
            createTournamentLabel.TabIndex = 0;
            createTournamentLabel.Text = "Create Tournament";
            // 
            // entryFeeValue
            // 
            entryFeeValue.Location = new Point(220, 261);
            entryFeeValue.Name = "entryFeeValue";
            entryFeeValue.Size = new Size(105, 27);
            entryFeeValue.TabIndex = 8;
            entryFeeValue.Text = "0";
            // 
            // tournamentNameValue
            // 
            tournamentNameValue.Location = new Point(85, 184);
            tournamentNameValue.Name = "tournamentNameValue";
            tournamentNameValue.Size = new Size(237, 27);
            tournamentNameValue.TabIndex = 9;
            // 
            // tournamentNameLabel
            // 
            tournamentNameLabel.AutoSize = true;
            tournamentNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentNameLabel.Location = new Point(85, 127);
            tournamentNameLabel.Name = "tournamentNameLabel";
            tournamentNameLabel.Size = new Size(203, 31);
            tournamentNameLabel.TabIndex = 10;
            tournamentNameLabel.Text = "Tournament Name";
            // 
            // entryFeeLabel
            // 
            entryFeeLabel.AutoSize = true;
            entryFeeLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            entryFeeLabel.Location = new Point(85, 255);
            entryFeeLabel.Name = "entryFeeLabel";
            entryFeeLabel.Size = new Size(107, 31);
            entryFeeLabel.TabIndex = 11;
            entryFeeLabel.Text = "Entry Fee";
            // 
            // selectTeamLabel
            // 
            selectTeamLabel.AutoSize = true;
            selectTeamLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            selectTeamLabel.Location = new Point(85, 356);
            selectTeamLabel.Name = "selectTeamLabel";
            selectTeamLabel.Size = new Size(135, 31);
            selectTeamLabel.TabIndex = 12;
            selectTeamLabel.Text = "Select Team";
            // 
            // teamsLabel
            // 
            teamsLabel.AutoSize = true;
            teamsLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            teamsLabel.Location = new Point(453, 57);
            teamsLabel.Name = "teamsLabel";
            teamsLabel.Size = new Size(171, 31);
            teamsLabel.TabIndex = 13;
            teamsLabel.Text = "Teams / Players";
            // 
            // prizesLabel
            // 
            prizesLabel.AutoSize = true;
            prizesLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            prizesLabel.Location = new Point(453, 338);
            prizesLabel.Name = "prizesLabel";
            prizesLabel.Size = new Size(73, 31);
            prizesLabel.TabIndex = 14;
            prizesLabel.Text = "Prizes";
            // 
            // teamsCompetingListBox
            // 
            teamsCompetingListBox.FormattingEnabled = true;
            teamsCompetingListBox.ItemHeight = 20;
            teamsCompetingListBox.Location = new Point(453, 111);
            teamsCompetingListBox.Name = "teamsCompetingListBox";
            teamsCompetingListBox.Size = new Size(269, 204);
            teamsCompetingListBox.TabIndex = 15;
            // 
            // prizesListBox
            // 
            prizesListBox.FormattingEnabled = true;
            prizesListBox.ItemHeight = 20;
            prizesListBox.Location = new Point(453, 372);
            prizesListBox.Name = "prizesListBox";
            prizesListBox.Size = new Size(269, 204);
            prizesListBox.TabIndex = 17;
            // 
            // createPrizeButton
            // 
            createPrizeButton.Location = new Point(126, 543);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(135, 54);
            createPrizeButton.TabIndex = 18;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // createTournamentButton
            // 
            createTournamentButton.Location = new Point(355, 605);
            createTournamentButton.Name = "createTournamentButton";
            createTournamentButton.Size = new Size(269, 77);
            createTournamentButton.TabIndex = 19;
            createTournamentButton.Text = "Create Tournament";
            createTournamentButton.UseVisualStyleBackColor = true;
            // 
            // addTeamButton
            // 
            addTeamButton.Location = new Point(126, 460);
            addTeamButton.Name = "addTeamButton";
            addTeamButton.Size = new Size(135, 60);
            addTeamButton.TabIndex = 20;
            addTeamButton.Text = "Add Team";
            addTeamButton.UseVisualStyleBackColor = true;
            addTeamButton.Click += addTeamButton_Click;
            // 
            // deleteSelectedTeamsButton
            // 
            deleteSelectedTeamsButton.Location = new Point(769, 172);
            deleteSelectedTeamsButton.Name = "deleteSelectedTeamsButton";
            deleteSelectedTeamsButton.Size = new Size(150, 62);
            deleteSelectedTeamsButton.TabIndex = 21;
            deleteSelectedTeamsButton.Text = "Delete Selected";
            deleteSelectedTeamsButton.UseVisualStyleBackColor = true;
            // 
            // deleteSelectedPrizesButton
            // 
            deleteSelectedPrizesButton.Location = new Point(769, 416);
            deleteSelectedPrizesButton.Name = "deleteSelectedPrizesButton";
            deleteSelectedPrizesButton.Size = new Size(150, 67);
            deleteSelectedPrizesButton.TabIndex = 22;
            deleteSelectedPrizesButton.Text = "Delete Selected";
            deleteSelectedPrizesButton.UseVisualStyleBackColor = true;
            // 
            // createNewTeamLink
            // 
            createNewTeamLink.AutoSize = true;
            createNewTeamLink.Location = new Point(239, 365);
            createNewTeamLink.Name = "createNewTeamLink";
            createNewTeamLink.Size = new Size(86, 20);
            createNewTeamLink.TabIndex = 23;
            createNewTeamLink.TabStop = true;
            createNewTeamLink.Text = "Create New";
            // 
            // selectedTeamDropDown
            // 
            selectedTeamDropDown.FormattingEnabled = true;
            selectedTeamDropDown.Location = new Point(85, 416);
            selectedTeamDropDown.Name = "selectedTeamDropDown";
            selectedTeamDropDown.Size = new Size(237, 28);
            selectedTeamDropDown.TabIndex = 24;
            // 
            // CreateTournamentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 705);
            Controls.Add(selectedTeamDropDown);
            Controls.Add(createNewTeamLink);
            Controls.Add(deleteSelectedPrizesButton);
            Controls.Add(deleteSelectedTeamsButton);
            Controls.Add(addTeamButton);
            Controls.Add(createTournamentButton);
            Controls.Add(createPrizeButton);
            Controls.Add(prizesListBox);
            Controls.Add(teamsCompetingListBox);
            Controls.Add(prizesLabel);
            Controls.Add(teamsLabel);
            Controls.Add(selectTeamLabel);
            Controls.Add(entryFeeLabel);
            Controls.Add(tournamentNameLabel);
            Controls.Add(tournamentNameValue);
            Controls.Add(entryFeeValue);
            Controls.Add(createTournamentLabel);
            Name = "CreateTournamentForm";
            Text = "CreateTournamentForm";
            Load += CreateTournamentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createTournamentLabel;
        private TextBox entryFeeValue;
        private TextBox tournamentNameValue;
        private Label tournamentNameLabel;
        private Label entryFeeLabel;
        private Label selectTeamLabel;
        private Label teamsLabel;
        private Label prizesLabel;
        private ListBox teamsCompetingListBox;
        private ListBox prizesListBox;
        private Button createPrizeButton;
        private Button createTournamentButton;
        private Button addTeamButton;
        private Button deleteSelectedTeamsButton;
        private Button deleteSelectedPrizesButton;
        private LinkLabel createNewTeamLink;
        private ComboBox selectedTeamDropDown;
    }
}