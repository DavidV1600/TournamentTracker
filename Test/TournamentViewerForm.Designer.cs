namespace Test
{
    partial class TournamentViewerForm
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
            tournamentLabel = new Label();
            tournamentNameLabel = new Label();
            roundLabel = new Label();
            teamOneLabel = new Label();
            score1Label = new Label();
            vsLabel = new Label();
            teamTwoLabel = new Label();
            score2Label = new Label();
            unplayedOnlyCheckBox = new CheckBox();
            matchupListBox = new ListBox();
            roundValue = new ComboBox();
            score1Value = new TextBox();
            score2Value = new TextBox();
            scoreButton = new Button();
            SuspendLayout();
            // 
            // tournamentLabel
            // 
            tournamentLabel.AutoSize = true;
            tournamentLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentLabel.Location = new Point(56, 46);
            tournamentLabel.Name = "tournamentLabel";
            tournamentLabel.Size = new Size(141, 31);
            tournamentLabel.TabIndex = 0;
            tournamentLabel.Text = "Tournament:";
            // 
            // tournamentNameLabel
            // 
            tournamentNameLabel.AutoSize = true;
            tournamentNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentNameLabel.Location = new Point(203, 46);
            tournamentNameLabel.Name = "tournamentNameLabel";
            tournamentNameLabel.Size = new Size(97, 31);
            tournamentNameLabel.TabIndex = 1;
            tournamentNameLabel.Text = "<none>";
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            roundLabel.Location = new Point(56, 112);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(85, 31);
            roundLabel.TabIndex = 2;
            roundLabel.Text = "Round:";
            // 
            // teamOneLabel
            // 
            teamOneLabel.AutoSize = true;
            teamOneLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            teamOneLabel.Location = new Point(424, 187);
            teamOneLabel.Name = "teamOneLabel";
            teamOneLabel.Size = new Size(116, 31);
            teamOneLabel.TabIndex = 3;
            teamOneLabel.Text = "Team One";
            // 
            // score1Label
            // 
            score1Label.AutoSize = true;
            score1Label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            score1Label.Location = new Point(424, 236);
            score1Label.Name = "score1Label";
            score1Label.Size = new Size(75, 31);
            score1Label.TabIndex = 4;
            score1Label.Text = "Score:";
            // 
            // vsLabel
            // 
            vsLabel.AutoSize = true;
            vsLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            vsLabel.Location = new Point(534, 300);
            vsLabel.Name = "vsLabel";
            vsLabel.Size = new Size(58, 31);
            vsLabel.TabIndex = 5;
            vsLabel.Text = "-VS-";
            // 
            // teamTwoLabel
            // 
            teamTwoLabel.AutoSize = true;
            teamTwoLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            teamTwoLabel.Location = new Point(424, 352);
            teamTwoLabel.Name = "teamTwoLabel";
            teamTwoLabel.Size = new Size(115, 31);
            teamTwoLabel.TabIndex = 6;
            teamTwoLabel.Text = "Team Two";
            // 
            // score2Label
            // 
            score2Label.AutoSize = true;
            score2Label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            score2Label.Location = new Point(424, 410);
            score2Label.Name = "score2Label";
            score2Label.Size = new Size(75, 31);
            score2Label.TabIndex = 7;
            score2Label.Text = "Score:";
            // 
            // unplayedOnlyCheckBox
            // 
            unplayedOnlyCheckBox.AutoSize = true;
            unplayedOnlyCheckBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            unplayedOnlyCheckBox.Location = new Point(138, 183);
            unplayedOnlyCheckBox.Name = "unplayedOnlyCheckBox";
            unplayedOnlyCheckBox.Size = new Size(187, 35);
            unplayedOnlyCheckBox.TabIndex = 8;
            unplayedOnlyCheckBox.Text = "Unplayed Only";
            unplayedOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchupListBox
            // 
            matchupListBox.FormattingEnabled = true;
            matchupListBox.ItemHeight = 20;
            matchupListBox.Location = new Point(56, 236);
            matchupListBox.Name = "matchupListBox";
            matchupListBox.Size = new Size(269, 224);
            matchupListBox.TabIndex = 9;
            // 
            // roundValue
            // 
            roundValue.FormattingEnabled = true;
            roundValue.Location = new Point(174, 118);
            roundValue.Name = "roundValue";
            roundValue.Size = new Size(151, 28);
            roundValue.TabIndex = 10;
            // 
            // score1Value
            // 
            score1Value.Location = new Point(525, 240);
            score1Value.Name = "score1Value";
            score1Value.Size = new Size(125, 27);
            score1Value.TabIndex = 11;
            // 
            // score2Value
            // 
            score2Value.Location = new Point(525, 416);
            score2Value.Name = "score2Value";
            score2Value.Size = new Size(125, 27);
            score2Value.TabIndex = 12;
            // 
            // scoreButton
            // 
            scoreButton.Location = new Point(634, 291);
            scoreButton.Name = "scoreButton";
            scoreButton.Size = new Size(143, 56);
            scoreButton.TabIndex = 13;
            scoreButton.Text = "Score";
            scoreButton.UseVisualStyleBackColor = true;
            // 
            // TournamentViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 495);
            Controls.Add(scoreButton);
            Controls.Add(score2Value);
            Controls.Add(score1Value);
            Controls.Add(roundValue);
            Controls.Add(matchupListBox);
            Controls.Add(unplayedOnlyCheckBox);
            Controls.Add(score2Label);
            Controls.Add(teamTwoLabel);
            Controls.Add(vsLabel);
            Controls.Add(score1Label);
            Controls.Add(teamOneLabel);
            Controls.Add(roundLabel);
            Controls.Add(tournamentNameLabel);
            Controls.Add(tournamentLabel);
            Name = "TournamentViewerForm";
            Text = "TournamentViewerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tournamentLabel;
        private Label tournamentNameLabel;
        private Label roundLabel;
        private Label teamOneLabel;
        private Label score1Label;
        private Label vsLabel;
        private Label teamTwoLabel;
        private Label score2Label;
        private CheckBox unplayedOnlyCheckBox;
        private ListBox matchupListBox;
        private ComboBox roundValue;
        private TextBox score1Value;
        private TextBox score2Value;
        private Button scoreButton;
    }
}