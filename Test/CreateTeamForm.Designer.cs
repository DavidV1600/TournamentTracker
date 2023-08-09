namespace Test
{
    partial class CreateTeamForm
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
            createTeamLabel = new Label();
            teamNameLabel = new Label();
            selectTeamMemberLabel = new Label();
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            emailLabel = new Label();
            cellphoneLabel = new Label();
            teamNameValue = new TextBox();
            firstNameValue = new TextBox();
            lastNameValue = new TextBox();
            emailValue = new TextBox();
            cellphoneValue = new TextBox();
            selectTeamMemberDropDown = new ComboBox();
            deleteMembersListBox = new ListBox();
            addTeamButton = new Button();
            createMemberButton = new Button();
            removeSelectedMembersButton = new Button();
            addMemberGroupBox = new GroupBox();
            createTeamButton = new Button();
            addMemberGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // createTeamLabel
            // 
            createTeamLabel.AutoSize = true;
            createTeamLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            createTeamLabel.Location = new Point(36, 22);
            createTeamLabel.Name = "createTeamLabel";
            createTeamLabel.Size = new Size(140, 31);
            createTeamLabel.TabIndex = 0;
            createTeamLabel.Text = "Create Team";
            // 
            // teamNameLabel
            // 
            teamNameLabel.AutoSize = true;
            teamNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            teamNameLabel.Location = new Point(36, 70);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.Size = new Size(135, 31);
            teamNameLabel.TabIndex = 1;
            teamNameLabel.Text = "Team Name";
            teamNameLabel.Click += label2_Click;
            // 
            // selectTeamMemberLabel
            // 
            selectTeamMemberLabel.AutoSize = true;
            selectTeamMemberLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            selectTeamMemberLabel.Location = new Point(36, 148);
            selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            selectTeamMemberLabel.Size = new Size(228, 31);
            selectTeamMemberLabel.TabIndex = 2;
            selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(15, 46);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(124, 31);
            firstNameLabel.TabIndex = 3;
            firstNameLabel.Text = "First Name";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(15, 91);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(122, 31);
            lastNameLabel.TabIndex = 4;
            lastNameLabel.Text = "Last Name";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.Location = new Point(15, 136);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(70, 31);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "Email";
            emailLabel.Click += label6_Click;
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cellphoneLabel.Location = new Point(15, 188);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new Size(117, 31);
            cellphoneLabel.TabIndex = 6;
            cellphoneLabel.Text = "Cellphone";
            // 
            // teamNameValue
            // 
            teamNameValue.Location = new Point(36, 118);
            teamNameValue.Name = "teamNameValue";
            teamNameValue.Size = new Size(281, 27);
            teamNameValue.TabIndex = 7;
            // 
            // firstNameValue
            // 
            firstNameValue.Location = new Point(156, 47);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(125, 27);
            firstNameValue.TabIndex = 8;
            // 
            // lastNameValue
            // 
            lastNameValue.Location = new Point(156, 97);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(125, 27);
            lastNameValue.TabIndex = 9;
            // 
            // emailValue
            // 
            emailValue.Location = new Point(156, 151);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(125, 27);
            emailValue.TabIndex = 10;
            // 
            // cellphoneValue
            // 
            cellphoneValue.Location = new Point(156, 194);
            cellphoneValue.Name = "cellphoneValue";
            cellphoneValue.Size = new Size(125, 27);
            cellphoneValue.TabIndex = 11;
            // 
            // selectTeamMemberDropDown
            // 
            selectTeamMemberDropDown.FormattingEnabled = true;
            selectTeamMemberDropDown.Location = new Point(36, 195);
            selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            selectTeamMemberDropDown.Size = new Size(281, 28);
            selectTeamMemberDropDown.TabIndex = 12;
            // 
            // deleteMembersListBox
            // 
            deleteMembersListBox.FormattingEnabled = true;
            deleteMembersListBox.ItemHeight = 20;
            deleteMembersListBox.Location = new Point(392, 70);
            deleteMembersListBox.Name = "deleteMembersListBox";
            deleteMembersListBox.Size = new Size(316, 424);
            deleteMembersListBox.TabIndex = 13;
            // 
            // addTeamButton
            // 
            addTeamButton.Location = new Point(89, 239);
            addTeamButton.Name = "addTeamButton";
            addTeamButton.Size = new Size(175, 29);
            addTeamButton.TabIndex = 14;
            addTeamButton.Text = "Add Team Member";
            addTeamButton.UseVisualStyleBackColor = true;
            addTeamButton.Click += addTeamButton_Click;
            // 
            // createMemberButton
            // 
            createMemberButton.Location = new Point(79, 249);
            createMemberButton.Name = "createMemberButton";
            createMemberButton.Size = new Size(149, 49);
            createMemberButton.TabIndex = 15;
            createMemberButton.Text = "Create Member";
            createMemberButton.UseVisualStyleBackColor = true;
            createMemberButton.Click += createMemberButton_Click;
            // 
            // removeSelectedMembersButton
            // 
            removeSelectedMembersButton.Location = new Point(724, 274);
            removeSelectedMembersButton.Name = "removeSelectedMembersButton";
            removeSelectedMembersButton.Size = new Size(221, 89);
            removeSelectedMembersButton.TabIndex = 16;
            removeSelectedMembersButton.Text = "Remove Selected";
            removeSelectedMembersButton.UseVisualStyleBackColor = true;
            removeSelectedMembersButton.Click += removeSelectedMembersButton_Click;
            // 
            // addMemberGroupBox
            // 
            addMemberGroupBox.Controls.Add(firstNameLabel);
            addMemberGroupBox.Controls.Add(lastNameLabel);
            addMemberGroupBox.Controls.Add(createMemberButton);
            addMemberGroupBox.Controls.Add(emailLabel);
            addMemberGroupBox.Controls.Add(cellphoneLabel);
            addMemberGroupBox.Controls.Add(cellphoneValue);
            addMemberGroupBox.Controls.Add(firstNameValue);
            addMemberGroupBox.Controls.Add(emailValue);
            addMemberGroupBox.Controls.Add(lastNameValue);
            addMemberGroupBox.Location = new Point(36, 289);
            addMemberGroupBox.Name = "addMemberGroupBox";
            addMemberGroupBox.Size = new Size(338, 326);
            addMemberGroupBox.TabIndex = 17;
            addMemberGroupBox.TabStop = false;
            addMemberGroupBox.Text = "Add New Member";
            // 
            // createTeamButton
            // 
            createTeamButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            createTeamButton.Location = new Point(392, 511);
            createTeamButton.Name = "createTeamButton";
            createTeamButton.Size = new Size(316, 104);
            createTeamButton.TabIndex = 18;
            createTeamButton.Text = "Create Team";
            createTeamButton.UseVisualStyleBackColor = true;
            createTeamButton.Click += createTeamButton_Click;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 677);
            Controls.Add(createTeamButton);
            Controls.Add(addMemberGroupBox);
            Controls.Add(removeSelectedMembersButton);
            Controls.Add(addTeamButton);
            Controls.Add(deleteMembersListBox);
            Controls.Add(selectTeamMemberDropDown);
            Controls.Add(teamNameValue);
            Controls.Add(selectTeamMemberLabel);
            Controls.Add(teamNameLabel);
            Controls.Add(createTeamLabel);
            Name = "CreateTeamForm";
            Text = "CreateTeamForm";
            addMemberGroupBox.ResumeLayout(false);
            addMemberGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createTeamLabel;
        private Label teamNameLabel;
        private Label selectTeamMemberLabel;
        private Label firstNameLabel;
        private Label lastNameLabel;
        private Label emailLabel;
        private Label cellphoneLabel;
        private TextBox teamNameValue;
        private TextBox firstNameValue;
        private TextBox lastNameValue;
        private TextBox emailValue;
        private TextBox cellphoneValue;
        private ComboBox selectTeamMemberDropDown;
        private ListBox deleteMembersListBox;
        private Button addTeamButton;
        private Button createMemberButton;
        private Button removeSelectedMembersButton;
        private GroupBox addMemberGroupBox;
        private Button createTeamButton;
    }
}