namespace checkers
{
    partial class AppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainBoard = new PictureBox();
            Player1ScoreLabel = new Label();
            Player2ScoreLabel = new Label();
            Player1NameLabel = new Label();
            Player2NameLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            Player2Turn = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            Player1Turn = new Label();
            PLayerWinText = new Label();
            ((System.ComponentModel.ISupportInitialize)mainBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // mainBoard
            // 
            mainBoard.BackColor = SystemColors.ActiveCaptionText;
            mainBoard.Location = new Point(12, 12);
            mainBoard.Name = "mainBoard";
            mainBoard.Size = new Size(600, 600);
            mainBoard.TabIndex = 0;
            mainBoard.TabStop = false;
            // 
            // Player1ScoreLabel
            // 
            Player1ScoreLabel.AutoSize = true;
            Player1ScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Player1ScoreLabel.Location = new Point(727, 112);
            Player1ScoreLabel.Name = "Player1ScoreLabel";
            Player1ScoreLabel.Size = new Size(19, 21);
            Player1ScoreLabel.TabIndex = 1;
            Player1ScoreLabel.Text = "0";
            // 
            // Player2ScoreLabel
            // 
            Player2ScoreLabel.AutoSize = true;
            Player2ScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Player2ScoreLabel.Location = new Point(727, 301);
            Player2ScoreLabel.Name = "Player2ScoreLabel";
            Player2ScoreLabel.Size = new Size(19, 21);
            Player2ScoreLabel.TabIndex = 2;
            Player2ScoreLabel.Text = "0";
            // 
            // Player1NameLabel
            // 
            Player1NameLabel.AutoSize = true;
            Player1NameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Player1NameLabel.Location = new Point(666, 84);
            Player1NameLabel.Name = "Player1NameLabel";
            Player1NameLabel.Size = new Size(89, 28);
            Player1NameLabel.TabIndex = 3;
            Player1NameLabel.Text = "Player 1";
            // 
            // Player2NameLabel
            // 
            Player2NameLabel.AutoSize = true;
            Player2NameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Player2NameLabel.Location = new Point(666, 273);
            Player2NameLabel.Name = "Player2NameLabel";
            Player2NameLabel.Size = new Size(89, 28);
            Player2NameLabel.TabIndex = 4;
            Player2NameLabel.Text = "Player 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(675, 112);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 5;
            label1.Text = "Score:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(675, 301);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 6;
            label2.Text = "Score:";
            // 
            // Player2Turn
            // 
            Player2Turn.AutoSize = true;
            Player2Turn.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Player2Turn.ForeColor = SystemColors.MenuHighlight;
            Player2Turn.Location = new Point(642, 245);
            Player2Turn.Name = "Player2Turn";
            Player2Turn.Size = new Size(127, 28);
            Player2Turn.TabIndex = 7;
            Player2Turn.Text = "YOUR TURN";
            Player2Turn.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.white;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(671, 136);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 75);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.black;
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Location = new Point(671, 325);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(75, 75);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // Player1Turn
            // 
            Player1Turn.AutoSize = true;
            Player1Turn.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Player1Turn.ForeColor = SystemColors.MenuHighlight;
            Player1Turn.Location = new Point(642, 56);
            Player1Turn.Name = "Player1Turn";
            Player1Turn.Size = new Size(127, 28);
            Player1Turn.TabIndex = 10;
            Player1Turn.Text = "YOUR TURN";
            Player1Turn.Visible = false;
            // 
            // PLayerWinText
            // 
            PLayerWinText.AutoSize = true;
            PLayerWinText.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            PLayerWinText.Location = new Point(234, 292);
            PLayerWinText.Name = "PLayerWinText";
            PLayerWinText.Size = new Size(149, 30);
            PLayerWinText.TabIndex = 11;
            PLayerWinText.Text = "Player1 is win!";
            PLayerWinText.Visible = false;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 625);
            Controls.Add(PLayerWinText);
            Controls.Add(Player1Turn);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Player2Turn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Player2NameLabel);
            Controls.Add(Player1NameLabel);
            Controls.Add(Player2ScoreLabel);
            Controls.Add(Player1ScoreLabel);
            Controls.Add(mainBoard);
            Name = "AppForm";
            Text = "checkers";
            Load += UpdateGameBoard;
            ((System.ComponentModel.ISupportInitialize)mainBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox mainBoard;
        private Label Player1ScoreLabel;
        private Label Player2ScoreLabel;
        private Label Player1NameLabel;
        private Label Player2NameLabel;
        private Label label1;
        private Label label2;
        private Label Player2Turn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label Player1Turn;
        private Label PLayerWinText;
    }
}