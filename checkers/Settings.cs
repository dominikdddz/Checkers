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
    public partial class Settings : Form
    {
        public bool isCorrect { get; set; }
        public string boardSize { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public bool ShowMoves { get; set; }
        public bool ForceJump { get; set; }
        public bool IsWhiteTurn { get; set; }
        public bool IsAiPlay { get; set; }


        public Settings()
        {
            InitializeComponent();
            comboBoxBoardSizePvP.SelectedIndex = 0;
            comboBoxFirstMovePvP.SelectedIndex = 0;
            comboBoxBoardSizePvE.SelectedIndex = 0;
            comboBoxFirstMovePvE.SelectedIndex = 0;
        }

        private void ButtonStartPvP(object sender, EventArgs e)
        {
            if (CheckSettingsPvP() == true)
            {
                boardSize = comboBoxBoardSizePvP.Text;
                IsWhiteTurn = WhichTurn(comboBoxFirstMovePvP.Text);
                Player1Name = textBoxPlayer1PvP.Text;
                Player2Name = textBoxPlayer2PvP.Text;
                ShowMoves = checkBoxShowMovesPvP.Checked;
                ForceJump = checkBoxForceJumpPvP.Checked;
                IsAiPlay = false;
                this.Close();
            }
        }
        private void ButtonStartPvE(object sender, EventArgs e)
        {
            if (CheckSettingsPvE() == true)
            {
                boardSize = comboBoxBoardSizePvE.Text;
                IsWhiteTurn = WhichTurn(comboBoxFirstMovePvE.Text);
                Player1Name = textBoxPlayer1PvE.Text;
                Player2Name = "Computer";
                ShowMoves = checkBoxShowMovesPvE.Checked;
                ForceJump = checkBoxForceJumpPvE.Checked;
                IsAiPlay = true;
                this.Close();
            }

        }

        private bool CheckSettingsPvP()
        {
            labelErrorPvP.Visible = false;
            isCorrect = false;
            if (CheckPlayerName(textBoxPlayer1PvP, 1, true) == true)
                isCorrect = true;
            else
                return isCorrect;
            isCorrect = false;
            if (CheckPlayerName(textBoxPlayer2PvP, 2, true) == true)
                isCorrect = true;
            else
                return isCorrect;
            return isCorrect;
        }
        private bool CheckSettingsPvE()
        {
            labelErrorPvP.Visible = false;
            isCorrect = false;
            if (CheckPlayerName(textBoxPlayer1PvP, 1, false) == true)
                isCorrect = true;
            return isCorrect;
        }

        private bool CheckPlayerName(TextBox Player, int Number, bool isPvP)
        {
            if (Player.Text == "")
            {
                if (isPvP == true)
                {
                    labelErrorPvP.Text = "Player " + Number + " name is empty!";
                    labelErrorPvP.Visible = true;
                    return false;
                }
                else
                {
                    labelErrorPvE.Text = "Player " + Number + " name is empty!";
                    labelErrorPvE.Visible = true;
                    return false;
                }
            }
            else if (Player.Text.Length > 10)
            {
                if (isPvP == true)
                {
                    labelErrorPvP.Text = "Player  " + Number + " name is too long!\n(max 15 words)";
                    labelErrorPvP.Visible = true;
                    return false;
                }
                else
                {
                    labelErrorPvE.Text = "Player  " + Number + " name is too long!\n(max 15 words)";
                    labelErrorPvE.Visible = true;
                    return false;
                }
            }
            return true;
        }
        private bool WhichTurn(string firstStart)
        {
            if (firstStart == "Player 1" || firstStart == "Player")
                return true;
            else
                return false;
        }
    }
}
