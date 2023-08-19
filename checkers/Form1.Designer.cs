namespace checkers
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)mainBoard).BeginInit();
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 625);
            Controls.Add(mainBoard);
            Name = "Form1";
            Text = "checkers";
            Load += UpdateGameBoard;
            ((System.ComponentModel.ISupportInitialize)mainBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mainBoard;
    }
}