using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05_Logic;
using Ex05_GameUtils;

namespace Ex05_WinformUi
{
    public partial class FormGame : Form
    {
        private const int k_Margin = 20;
        private const int k_ColumnSelectButtonWidth = 40;
        private const int k_ColumnSelectButtonHeight = 30;
        private const int k_BoardPieceButtonHeight = 40;
        private const int k_LabelHeight = 30;
        private const int k_LabelScoreWidth = 30;
        private const int k_LabelPlayerNameWidth = 40;
        private Button[] buttonsColumnsSelect;
        private Button[,] buttonsBoardPiece;
        private Label[] m_LabelPlayerName;
        private Label[] m_LabelPlayerScore;
        private int m_Player1Score = 0;
        private int m_Player2Score = 0;
        private int m_NumberOfRows;
        private int m_NumberOfColumns;
        private int m_TurnNumber = 0;
        private FormSettings m_FromSettings;
        private FormGameOver m_FormGameOver;
        private GameUtils.eGameMode m_GameMode;
        private GameManager m_GameManager;
      


        public FormGame()
        {
            m_FromSettings = new FormSettings();
            m_FormGameOver = new FormGameOver();
            m_FromSettings.ShowDialog();
            if (m_FromSettings.DialogResult == DialogResult.OK)
            {
                initializeComponent();
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void initizliseGameSettingsValues()
        {
            m_NumberOfRows = m_FromSettings.Rows;
            m_NumberOfColumns = m_FromSettings.Cols;
            m_GameMode = m_FromSettings.HumanPlaying ? GameUtils.eGameMode.PlayerVsPlayer : GameUtils.eGameMode.PlayerVsAi;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Width = (m_NumberOfColumns + 2) * k_Margin + k_ColumnSelectButtonWidth * m_NumberOfColumns;
            this.Height = (m_NumberOfRows + 4) * k_Margin + k_ColumnSelectButtonHeight + k_BoardPieceButtonHeight * m_NumberOfRows + k_LabelHeight;
        }

        private void initializePlayerInfoLabels()
        {
            m_LabelPlayerName = new Label[2];
            m_LabelPlayerName[0] = new Label();
            m_LabelPlayerName[0].Text = m_FromSettings.Player1Name + ":";
            m_LabelPlayerName[0].Height = k_LabelHeight;
            m_LabelPlayerName[0].Top = this.Height - k_Margin*2 - k_LabelHeight;
            m_LabelPlayerName[0].TextAlign = ContentAlignment.TopRight;
            m_LabelPlayerName[0].Width = this.Width / 2 - k_Margin - k_LabelScoreWidth;

            m_LabelPlayerName[1] = new Label();
            m_LabelPlayerName[1].Text = m_FromSettings.Player2Name + ":";
            m_LabelPlayerName[1].Height = k_LabelHeight;
            m_LabelPlayerName[1].Top = m_LabelPlayerName[0].Top;
            m_LabelPlayerName[1].TextAlign = ContentAlignment.TopRight;
            m_LabelPlayerName[1].Width = m_LabelPlayerName[0].Width;

            m_LabelPlayerScore = new Label[2];
            m_LabelPlayerScore[0] = new Label();
            m_LabelPlayerScore[0].Text = m_Player1Score.ToString();
            m_LabelPlayerScore[0].Height = k_LabelHeight;
            m_LabelPlayerScore[0].Width = k_LabelScoreWidth;
            m_LabelPlayerScore[0].Top = m_LabelPlayerName[0].Top;
            m_LabelPlayerScore[0].TextAlign = ContentAlignment.TopLeft;

            m_LabelPlayerScore[1] = new Label();
            m_LabelPlayerScore[1].Text = m_Player2Score.ToString();
            m_LabelPlayerScore[1].Height = k_LabelHeight;
            m_LabelPlayerScore[1].Width = k_LabelScoreWidth;
            m_LabelPlayerScore[1].Top = m_LabelPlayerName[0].Top;
            m_LabelPlayerScore[1].TextAlign = ContentAlignment.TopLeft;

            m_LabelPlayerName[0].Left = Math.Max((this.Width / 2) - k_Margin - m_LabelPlayerName[0].Width - m_LabelPlayerScore[0].Width, 0);
            this.Controls.Add(m_LabelPlayerName[0]);
            m_LabelPlayerScore[0].Left = m_LabelPlayerName[0].Left + m_LabelPlayerName[0].Width + 5;
            this.Controls.Add(m_LabelPlayerScore[0]);
            m_LabelPlayerName[1].Left = m_LabelPlayerScore[0].Left + m_LabelPlayerScore[0].Width + k_Margin;
            this.Controls.Add(m_LabelPlayerName[1]);
            m_LabelPlayerScore[1].Left = m_LabelPlayerName[1].Left + m_LabelPlayerName[1].Width ;
            this.Controls.Add(m_LabelPlayerScore[1]);
        }

        private void initializeComponent()
        {
            initizliseGameSettingsValues();
            initializeButtonsColumnsSelect();
            initializeButtonsBoardPiece();
            initializePlayerInfoLabels();
            initializeGameManager();
        }

        private void initializeGameManager()
        {
            m_GameManager = new GameManager(m_GameMode, m_NumberOfRows, m_NumberOfColumns);
        }

        private void initializeButtonsBoardPiece()
        {
            buttonsBoardPiece = new Button[m_NumberOfRows, m_NumberOfColumns];
            for (int i = m_NumberOfRows - 1; i >= 0 ; --i)
            {
                for (int j = m_NumberOfColumns - 1; j >= 0 ; --j)
                {
                    buttonsBoardPiece[i, j] = new Button();
                    buttonsBoardPiece[i, j].Top = (k_ColumnSelectButtonHeight + k_Margin) + (k_Margin) * (i + 1) + k_BoardPieceButtonHeight * i;
                    buttonsBoardPiece[i, j].Left = k_Margin * (j + 1) + k_ColumnSelectButtonWidth * j;
                    buttonsBoardPiece[i, j].Width = k_ColumnSelectButtonWidth;
                    buttonsBoardPiece[i, j].Height = k_BoardPieceButtonHeight;
                    buttonsBoardPiece[i, j].Cursor = Cursors.No;
                    buttonsBoardPiece[i, j].Font = new Font("Calibri", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    buttonsBoardPiece[i, j].Enabled = false;
                    this.Controls.Add(buttonsBoardPiece[i, j]);
                }
            }
        }

        private void initializeButtonsColumnsSelect()
        {
            buttonsColumnsSelect = new Button[m_NumberOfColumns];
            for (int i = 0; i < m_NumberOfColumns; ++i)
            {
                buttonsColumnsSelect[i] = new Button();
                buttonsColumnsSelect[i].Text = string.Format("{0}", i + 1);
                buttonsColumnsSelect[i].Top = k_Margin;
                buttonsColumnsSelect[i].Left = k_Margin * (i + 1) + k_ColumnSelectButtonWidth * i;
                buttonsColumnsSelect[i].Width = k_ColumnSelectButtonWidth;
                buttonsColumnsSelect[i].Height = k_ColumnSelectButtonHeight;
                buttonsColumnsSelect[i].Click += buttonColumnSelect_Click;
                this.Controls.Add(buttonsColumnsSelect[i]);
            }
        }
        private void resetAllComponents()
        {
            clearGUIBoard();
            for (int i = 0; i < m_NumberOfColumns; ++i)
            {
                buttonsColumnsSelect[i].Enabled = true;
            }
            m_GameManager.ResetGameBoard();
        }

        private void clearGUIBoard()
        {
            for (int i = m_NumberOfRows - 1; i >= 0; --i)
            {
                for (int j = m_NumberOfColumns - 1; j >= 0; --j)
                {
                    buttonsBoardPiece[i, j].Text = String.Empty;
                }
            }
        }

        private void buttonColumnSelect_Click(object sender, EventArgs e)
        {

            Button currentSelectedButton = sender as Button;
            PlayerMove playerMove = m_GameManager.PlayHumanTurn(int.Parse(currentSelectedButton.Text));
            updateFormWithUserAction(currentSelectedButton, playerMove);

            if (m_GameMode == GameUtils.eGameMode.PlayerVsAi & m_TurnNumber % 2 == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                buttonsColumnsSelect[m_GameManager.PlayComputerTurn()].PerformClick();
                this.Cursor = Cursors.Default;
            }
        }

        private void updateFormWithUserAction(Button i_CurrentSelectedButton, PlayerMove i_PlayerMove)
        {
            buttonsBoardPiece[i_PlayerMove.SelectedRow, i_PlayerMove.SelectedColumn].Text = i_PlayerMove.SquareSymbol.ToString();
            this.Refresh();
            if (m_GameManager.IsColumnFull(i_PlayerMove.SelectedColumn))
            {
                i_CurrentSelectedButton.Enabled = false;
            }
            checkBoardStatus(i_PlayerMove.GameStatus);
            m_TurnNumber++;
        }

        private void checkBoardStatus(GameBoard.eBoardStatus i_gameStatus)
        {
            string curPlayerName = m_LabelPlayerName[m_TurnNumber % 2].Text.TrimEnd(':');

            if (i_gameStatus != GameBoard.eBoardStatus.NextPlayerCanPlay)
            {
                if (i_gameStatus == GameBoard.eBoardStatus.PlayerWon)
                {
                    m_LabelPlayerScore[m_TurnNumber % 2].Text = string.Format("{0}",int.Parse(m_LabelPlayerScore[m_TurnNumber % 2].Text) +1);
                    DeclareWinner(curPlayerName);
                    increasePlayerScore(curPlayerName);

                }
                else if (i_gameStatus == GameBoard.eBoardStatus.Draw)
                {
                    DeclareDraw();
                }
                if (m_FormGameOver.DialogResult == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else if (m_FormGameOver.DialogResult == DialogResult.OK)
                {
                    resetAllComponents();
                }
            }
        }

        private void increasePlayerScore(string i_PlayerName)
        {
            if (i_PlayerName.Equals(m_FromSettings.Player1Name))
            {
                m_Player1Score++;
            }
            else
            {
                m_Player2Score++;
            }
        }

        private void DeclareDraw()
        {
            m_FormGameOver.GameOverText = String.Format(
 @"Tie!!
Another Round?");
            m_FormGameOver.ShowDialog();
        }

        private void DeclareWinner(string i_WinnerName)
        {
            m_FormGameOver.GameOverText = String.Format(
@"{0} Won!!
Another Round?", i_WinnerName);
            m_FormGameOver.ShowDialog();
        }


    }
}
