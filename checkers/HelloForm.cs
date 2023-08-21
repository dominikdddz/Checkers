using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{
    public partial class HelloForm : Form
    {
        public bool isCorrect { get; set; }
        public string boardSize { get; set; }
        public string firstStart { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }

        public HelloForm()
        {
            InitializeComponent();
            comboBoxBoardSize.SelectedIndex = 0;
            comboBoxFirstMove.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkSettings() == true)
            {
                boardSize = comboBoxBoardSize.Text;
                firstStart = comboBoxFirstMove.Text;
                Player1Name = textBoxPlayer1.Text;
                Player2Name = textBoxPlayer2.Text;
                this.Close();
            }
        }
        private bool checkSettings()
        {
            labelError.Visible = false;
            if (checkPlayerName(textBoxPlayer1, 1) == true)
            {
                isCorrect = true;
            }
            isCorrect = false;
            if (checkPlayerName(textBoxPlayer2, 2) == true)
            {
                isCorrect = true;
            }
            return isCorrect;
        }

        private bool checkPlayerName(TextBox Player, int Number)
        {
            if (Player.Text == "")
            {
                labelError.Text = "Player " + Number + " name is empty!";
                labelError.Visible = true;
                return false;
            }
            else if (Player.Text.Length > 15)
            {
                labelError.Text = "Player  " + Number + " name is too long!\n(max 15 words)";
                labelError.Visible = true;
                return false;
            }
            return true;
        }
    }
}
