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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            mainBoard = new PictureBox();
            PlayerWhiteScoreLabel = new Label();
            PlayerBlackScoreLabel = new Label();
            PlayerWhiteNameLabel = new Label();
            PlayerBlackNameLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            Player2Turn = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            PlayerWhiteTurn = new Label();
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
            // PlayerWhiteScoreLabel
            // 
            PlayerWhiteScoreLabel.AutoSize = true;
            PlayerWhiteScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerWhiteScoreLabel.Location = new Point(731, 365);
            PlayerWhiteScoreLabel.Name = "PlayerWhiteScoreLabel";
            PlayerWhiteScoreLabel.Size = new Size(19, 21);
            PlayerWhiteScoreLabel.TabIndex = 1;
            PlayerWhiteScoreLabel.Text = "0";
            // 
            // PlayerBlackScoreLabel
            // 
            PlayerBlackScoreLabel.AutoSize = true;
            PlayerBlackScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerBlackScoreLabel.Location = new Point(731, 171);
            PlayerBlackScoreLabel.Name = "PlayerBlackScoreLabel";
            PlayerBlackScoreLabel.Size = new Size(19, 21);
            PlayerBlackScoreLabel.TabIndex = 2;
            PlayerBlackScoreLabel.Text = "0";
            // 
            // PlayerWhiteNameLabel
            // 
            PlayerWhiteNameLabel.AutoSize = true;
            PlayerWhiteNameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerWhiteNameLabel.Location = new Point(670, 337);
            PlayerWhiteNameLabel.Name = "PlayerWhiteNameLabel";
            PlayerWhiteNameLabel.Size = new Size(89, 28);
            PlayerWhiteNameLabel.TabIndex = 3;
            PlayerWhiteNameLabel.Text = "Player 1";
            // 
            // PlayerBlackNameLabel
            // 
            PlayerBlackNameLabel.AutoSize = true;
            PlayerBlackNameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerBlackNameLabel.Location = new Point(670, 143);
            PlayerBlackNameLabel.Name = "PlayerBlackNameLabel";
            PlayerBlackNameLabel.Size = new Size(89, 28);
            PlayerBlackNameLabel.TabIndex = 4;
            PlayerBlackNameLabel.Text = "Player 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(679, 365);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 5;
            label1.Text = "Score:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(679, 171);
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
            Player2Turn.Location = new Point(646, 115);
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
            pictureBox1.Location = new Point(675, 389);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 75);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.black;
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Location = new Point(675, 195);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(75, 75);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // PlayerWhiteTurn
            // 
            PlayerWhiteTurn.AutoSize = true;
            PlayerWhiteTurn.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerWhiteTurn.ForeColor = SystemColors.MenuHighlight;
            PlayerWhiteTurn.Location = new Point(646, 309);
            PlayerWhiteTurn.Name = "PlayerWhiteTurn";
            PlayerWhiteTurn.Size = new Size(127, 28);
            PlayerWhiteTurn.TabIndex = 10;
            PlayerWhiteTurn.Text = "YOUR TURN";
            PlayerWhiteTurn.Visible = false;
            // 
            // PLayerWinText
            // 
            PLayerWinText.BackColor = Color.Transparent;
            PLayerWinText.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            PLayerWinText.ForeColor = Color.Black;
            PLayerWinText.Location = new Point(12, 264);
            PLayerWinText.Name = "PLayerWinText";
            PLayerWinText.Size = new Size(600, 61);
            PLayerWinText.TabIndex = 11;
            PLayerWinText.Text = "Player is win!";
            PLayerWinText.TextAlign = ContentAlignment.MiddleCenter;
            PLayerWinText.Visible = false;
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(806, 625);
            Controls.Add(PLayerWinText);
            Controls.Add(PlayerWhiteTurn);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Player2Turn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PlayerBlackNameLabel);
            Controls.Add(PlayerWhiteNameLabel);
            Controls.Add(PlayerBlackScoreLabel);
            Controls.Add(PlayerWhiteScoreLabel);
            Controls.Add(mainBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AppForm";
            Text = "Checkers";
            Load += UpdateGameBoard;
            ((System.ComponentModel.ISupportInitialize)mainBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox mainBoard;
        private Label PlayerWhiteScoreLabel;
        private Label PlayerBlackScoreLabel;
        private Label PlayerWhiteNameLabel;
        private Label PlayerBlackNameLabel;
        private Label label1;
        private Label label2;
        private Label Player2Turn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label PlayerWhiteTurn;
        private Label PLayerWinText;
    }
}