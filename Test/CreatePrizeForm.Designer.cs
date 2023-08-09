namespace Test
{
    partial class CreatePrizeForm
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
            createPrizeLabel = new Label();
            prizeNumberLabel = new Label();
            prizeNameLabel = new Label();
            prizeAmountLabel = new Label();
            orLabel = new Label();
            prizePercentageLabel = new Label();
            createPrizeButton = new Button();
            placeNumberValue = new TextBox();
            prizeAmountValue = new TextBox();
            prizePercentageValue = new TextBox();
            placeNameValue = new TextBox();
            SuspendLayout();
            // 
            // createPrizeLabel
            // 
            createPrizeLabel.AutoSize = true;
            createPrizeLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            createPrizeLabel.Location = new Point(71, 50);
            createPrizeLabel.Name = "createPrizeLabel";
            createPrizeLabel.Size = new Size(135, 31);
            createPrizeLabel.TabIndex = 0;
            createPrizeLabel.Text = "Create Prize";
            // 
            // prizeNumberLabel
            // 
            prizeNumberLabel.AutoSize = true;
            prizeNumberLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            prizeNumberLabel.Location = new Point(71, 128);
            prizeNumberLabel.Name = "prizeNumberLabel";
            prizeNumberLabel.Size = new Size(158, 31);
            prizeNumberLabel.TabIndex = 1;
            prizeNumberLabel.Text = "Place Number";
            // 
            // prizeNameLabel
            // 
            prizeNameLabel.AutoSize = true;
            prizeNameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            prizeNameLabel.Location = new Point(71, 212);
            prizeNameLabel.Name = "prizeNameLabel";
            prizeNameLabel.Size = new Size(135, 31);
            prizeNameLabel.TabIndex = 2;
            prizeNameLabel.Text = "Place Name";
            // 
            // prizeAmountLabel
            // 
            prizeAmountLabel.AutoSize = true;
            prizeAmountLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            prizeAmountLabel.Location = new Point(71, 286);
            prizeAmountLabel.Name = "prizeAmountLabel";
            prizeAmountLabel.Size = new Size(151, 31);
            prizeAmountLabel.TabIndex = 3;
            prizeAmountLabel.Text = "Prize Amount";
            // 
            // orLabel
            // 
            orLabel.AutoSize = true;
            orLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            orLabel.Location = new Point(216, 359);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(63, 31);
            orLabel.TabIndex = 4;
            orLabel.Text = "-OR-";
            // 
            // prizePercentageLabel
            // 
            prizePercentageLabel.AutoSize = true;
            prizePercentageLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            prizePercentageLabel.Location = new Point(71, 433);
            prizePercentageLabel.Name = "prizePercentageLabel";
            prizePercentageLabel.Size = new Size(183, 31);
            prizePercentageLabel.TabIndex = 5;
            prizePercentageLabel.Text = "Prize Percentage";
            // 
            // createPrizeButton
            // 
            createPrizeButton.Location = new Point(147, 490);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(225, 83);
            createPrizeButton.TabIndex = 6;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // placeNumberValue
            // 
            placeNumberValue.Location = new Point(292, 128);
            placeNumberValue.Name = "placeNumberValue";
            placeNumberValue.Size = new Size(125, 27);
            placeNumberValue.TabIndex = 7;
            // 
            // prizeAmountValue
            // 
            prizeAmountValue.Location = new Point(292, 290);
            prizeAmountValue.Name = "prizeAmountValue";
            prizeAmountValue.Size = new Size(125, 27);
            prizeAmountValue.TabIndex = 8;
            prizeAmountValue.Text = "0";
            // 
            // prizePercentageValue
            // 
            prizePercentageValue.Location = new Point(292, 439);
            prizePercentageValue.Name = "prizePercentageValue";
            prizePercentageValue.Size = new Size(125, 27);
            prizePercentageValue.TabIndex = 9;
            prizePercentageValue.Text = "0";
            // 
            // placeNameValue
            // 
            placeNameValue.Location = new Point(292, 212);
            placeNameValue.Name = "placeNameValue";
            placeNameValue.Size = new Size(125, 27);
            placeNameValue.TabIndex = 10;
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 597);
            Controls.Add(placeNameValue);
            Controls.Add(prizePercentageValue);
            Controls.Add(prizeAmountValue);
            Controls.Add(placeNumberValue);
            Controls.Add(createPrizeButton);
            Controls.Add(prizePercentageLabel);
            Controls.Add(orLabel);
            Controls.Add(prizeAmountLabel);
            Controls.Add(prizeNameLabel);
            Controls.Add(prizeNumberLabel);
            Controls.Add(createPrizeLabel);
            Name = "CreatePrizeForm";
            Text = "CreatePrizeForm";
            Load += CreatePrizeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createPrizeLabel;
        private Label prizeNumberLabel;
        private Label prizeNameLabel;
        private Label prizeAmountLabel;
        private Label orLabel;
        private Label prizePercentageLabel;
        private Button createPrizeButton;
        private TextBox placeNumberValue;
        private TextBox prizeAmountValue;
        private TextBox prizePercentageValue;
        private TextBox placeNameValue;
    }
}