namespace checkers
{
    partial class HelloForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelloForm));
            groupBox1 = new GroupBox();
            checkBoxShowMoves = new CheckBox();
            comboBoxFirstMove = new ComboBox();
            label4 = new Label();
            comboBoxBoardSize = new ComboBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            textBoxPlayer2 = new TextBox();
            textBoxPlayer1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            labelError = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxShowMoves);
            groupBox1.Controls.Add(comboBoxFirstMove);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(comboBoxBoardSize);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(8, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(208, 187);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game Settings";
            // 
            // checkBoxShowMoves
            // 
            checkBoxShowMoves.AutoSize = true;
            checkBoxShowMoves.Checked = true;
            checkBoxShowMoves.CheckState = CheckState.Checked;
            checkBoxShowMoves.Location = new Point(7, 146);
            checkBoxShowMoves.Name = "checkBoxShowMoves";
            checkBoxShowMoves.Size = new Size(93, 19);
            checkBoxShowMoves.TabIndex = 4;
            checkBoxShowMoves.Text = "Show moves";
            checkBoxShowMoves.UseVisualStyleBackColor = true;
            // 
            // comboBoxFirstMove
            // 
            comboBoxFirstMove.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFirstMove.FormattingEnabled = true;
            comboBoxFirstMove.Items.AddRange(new object[] { "Player 1", "Player 2" });
            comboBoxFirstMove.Location = new Point(7, 107);
            comboBoxFirstMove.Name = "comboBoxFirstMove";
            comboBoxFirstMove.Size = new Size(121, 23);
            comboBoxFirstMove.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 89);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 2;
            label4.Text = "First Move:";
            // 
            // comboBoxBoardSize
            // 
            comboBoxBoardSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBoardSize.FormattingEnabled = true;
            comboBoxBoardSize.Items.AddRange(new object[] { "8x8" });
            comboBoxBoardSize.Location = new Point(7, 49);
            comboBoxBoardSize.MaxDropDownItems = 3;
            comboBoxBoardSize.Name = "comboBoxBoardSize";
            comboBoxBoardSize.Size = new Size(121, 23);
            comboBoxBoardSize.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 31);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 0;
            label3.Text = "Board Size:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxPlayer2);
            groupBox2.Controls.Add(textBoxPlayer1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(222, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(208, 142);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Players Settings";
            // 
            // textBoxPlayer2
            // 
            textBoxPlayer2.Location = new Point(6, 107);
            textBoxPlayer2.Name = "textBoxPlayer2";
            textBoxPlayer2.Size = new Size(133, 23);
            textBoxPlayer2.TabIndex = 4;
            textBoxPlayer2.Text = "Player 2";
            // 
            // textBoxPlayer1
            // 
            textBoxPlayer1.ForeColor = SystemColors.MenuText;
            textBoxPlayer1.Location = new Point(6, 49);
            textBoxPlayer1.Name = "textBoxPlayer1";
            textBoxPlayer1.Size = new Size(133, 23);
            textBoxPlayer1.TabIndex = 3;
            textBoxPlayer1.Text = "Player 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 89);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Player 2 Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 31);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 1;
            label1.Text = "Player 1 Name:";
            // 
            // labelError
            // 
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(0, 198);
            labelError.Name = "labelError";
            labelError.Size = new Size(438, 36);
            labelError.TabIndex = 5;
            labelError.Text = "Nazwa jest zbyt długa";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(176, 237);
            button1.Name = "button1";
            button1.Size = new Size(74, 31);
            button1.TabIndex = 4;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // HelloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(438, 280);
            Controls.Add(labelError);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HelloForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Checkers";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox comboBoxBoardSize;
        private ComboBox comboBoxFirstMove;
        private Label label4;
        private TextBox textBoxPlayer2;
        private TextBox textBoxPlayer1;
        private Label labelError;
        private CheckBox checkBoxShowMoves;
    }
}