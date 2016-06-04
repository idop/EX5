﻿using System;
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
        private int m_Player1Score;
        private int m_Player2Score;
        private int m_NumberOfRows;
        private int m_NumberOfColumns;
        private int m_TurnNumber = 0;
        private Settings m_FromSettings;
        private GameUtils.eGameMode m_GameMode;
        private GameManager m_GameManager;


        public FormGame()
        {
            m_FromSettings = new Settings();
            m_FromSettings.ShowDialog();
            initializeComponents();
        }

        private void initizliseGameSettingsValues()
        {
            m_NumberOfRows = m_FromSettings.Rows;
            m_NumberOfColumns = m_FromSettings.Cols;
            m_Player1Score = 0;
            m_Player2Score = 0;
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

        private void initializeComponents()
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
                    int temp = (k_ColumnSelectButtonHeight + k_Margin) + (k_Margin) * (j + 1) + k_BoardPieceButtonHeight * j;
                    buttonsBoardPiece[i, j].Top = (k_ColumnSelectButtonHeight + k_Margin) + (k_Margin) * (j + 1) + k_BoardPieceButtonHeight * j;
                    buttonsBoardPiece[i, j].Left = k_Margin * (i + 1) + k_ColumnSelectButtonWidth * i;
                    buttonsBoardPiece[i, j].Width = k_ColumnSelectButtonWidth;
                    buttonsBoardPiece[i, j].Height = k_BoardPieceButtonHeight;
                    buttonsBoardPiece[i, j].Enabled = false;
                    buttonsBoardPiece[i, j].FlatStyle = FlatStyle.Flat;
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

        private void buttonColumnSelect_Click(object sender, EventArgs e)
        {

            Button currentSelectedButton = sender as Button;
            PlayerMove playerMove = m_GameManager.PlayHumanTurn(int.Parse(currentSelectedButton.Text));
            updateFormWithUserAction(currentSelectedButton, playerMove);

            if (m_GameMode == GameUtils.eGameMode.PlayerVsAi)
            {
                playerMove = m_GameManager.PlayComputerTurn();
                updateFormWithUserAction(currentSelectedButton, playerMove);
            }
        }

        private void updateFormWithUserAction(Button i_CurrentSelectedButton, PlayerMove i_PlayerMove)
        {
            buttonsBoardPiece[i_PlayerMove.SelectedRow, i_PlayerMove.SelectedColumn].Text = i_PlayerMove.SquareSymbol.ToString();
            if (m_GameManager.IsColumnFull(i_PlayerMove.SelectedColumn))
            {
                i_CurrentSelectedButton.Enabled = false;
            }
            checkBoardStatus(i_PlayerMove.GameStatus);
            m_TurnNumber++;
        }

        private void checkBoardStatus(GameBoard.eBoardStatus i_gameStatus)
        {

            if (i_gameStatus != GameBoard.eBoardStatus.NextPlayerCanPlay)
            {
                if (i_gameStatus == GameBoard.eBoardStatus.PlayerWon)
                {
                    m_LabelPlayerScore[m_TurnNumber % 2].Text = string.Format("{0}",int.Parse(m_LabelPlayerScore[m_TurnNumber % 2].Text) +1);
                    DeclareWinner(m_LabelPlayerName[m_TurnNumber % 2].Text);

                }
                else if (i_gameStatus == GameBoard.eBoardStatus.Draw)
                {
                    DeclareDraw();
                }
            }
        }

        private void DeclareDraw()
        {
            throw new NotImplementedException();
        }

        private void DeclareWinner(string text)
        {
            throw new NotImplementedException();
        }
    }
}
