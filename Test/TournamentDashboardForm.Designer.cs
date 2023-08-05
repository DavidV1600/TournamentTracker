namespace Test
{
    partial class TournamentDashboardForm
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
            tournamentDashboardLabel = new Label();
            existingTournamentLabel = new Label();
            tournamentChosenValue = new ComboBox();
            loadTournamentButton = new Button();
            createTournamentButton = new Button();
            SuspendLayout();
            // 
            // tournamentDashboardLabel
            // 
            tournamentDashboardLabel.AutoSize = true;
            tournamentDashboardLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentDashboardLabel.Location = new Point(174, 45);
            tournamentDashboardLabel.Name = "tournamentDashboardLabel";
            tournamentDashboardLabel.Size = new Size(254, 31);
            tournamentDashboardLabel.TabIndex = 0;
            tournamentDashboardLabel.Text = "Tournament Dashboard";
            // 
            // existingTournamentLabel
            // 
            existingTournamentLabel.AutoSize = true;
            existingTournamentLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            existingTournamentLabel.Location = new Point(162, 122);
            existingTournamentLabel.Name = "existingTournamentLabel";
            existingTournamentLabel.Size = new Size(278, 31);
            existingTournamentLabel.TabIndex = 1;
            existingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // tournamentChosenValue
            // 
            tournamentChosenValue.FormattingEnabled = true;
            tournamentChosenValue.Location = new Point(226, 193);
            tournamentChosenValue.Name = "tournamentChosenValue";
            tournamentChosenValue.Size = new Size(151, 28);
            tournamentChosenValue.TabIndex = 2;
            // 
            // loadTournamentButton
            // 
            loadTournamentButton.Location = new Point(169, 287);
            loadTournamentButton.Name = "loadTournamentButton";
            loadTournamentButton.Size = new Size(264, 61);
            loadTournamentButton.TabIndex = 3;
            loadTournamentButton.Text = "Load Tournament";
            loadTournamentButton.UseVisualStyleBackColor = true;
            // 
            // createTournamentButton
            // 
            createTournamentButton.Location = new Point(169, 371);
            createTournamentButton.Name = "createTournamentButton";
            createTournamentButton.Size = new Size(264, 67);
            createTournamentButton.TabIndex = 4;
            createTournamentButton.Text = "Create Tournament";
            createTournamentButton.UseVisualStyleBackColor = true;
            // 
            // TournamentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 543);
            Controls.Add(createTournamentButton);
            Controls.Add(loadTournamentButton);
            Controls.Add(tournamentChosenValue);
            Controls.Add(existingTournamentLabel);
            Controls.Add(tournamentDashboardLabel);
            Name = "TournamentDashboardForm";
            Text = "TournamentDashboardForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tournamentDashboardLabel;
        private Label existingTournamentLabel;
        private ComboBox tournamentChosenValue;
        private Button loadTournamentButton;
        private Button createTournamentButton;
    }
}