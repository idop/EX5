using Ex05_GameUtils;
using Ex05_Logic;
using Ex05_WinformUi;
using System;
using System.Collections.Generic;

namespace B16_Ex05
{
    internal class GameManager
    {
        private const int k_NumberOfPlayers = 2;
        private GameBoard m_GameBoard;
        private UIManager m_UIManager = new UIManager();
        private GameUtils.eGameMode m_GameMode;
        private int m_TurnNumber = 0;
        private bool m_PlayerWantsToPlay = true;
        private bool m_CurrentGameEnded = false;
        private Player[] m_Players = new Player[2];

        public void Start()
        {
            m_UIManager.Settings.ShowDialog();
            if (m_UIManager.Settings.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                init();
            }
            //TODO
       //     playGame();
        }
        private void init()
        {
            initializeGameBoard();
            initializeGameMode();
            initializePlayers();
        }

        private void initializeGameBoard()
        {
            int rows = m_UIManager.Settings.Rows;
            int cols = m_UIManager.Settings.Cols;
            m_GameBoard = new GameBoard(rows, cols);
        }

        private void initializeGameMode()
        {
            m_GameMode = m_UIManager.Settings.HumanPlaying ? GameUtils.eGameMode.PlayerVsPlayer : GameUtils.eGameMode.PlayerVsAi;
        }

        private void initializePlayers()
        {
            m_Players[GameUtils.v_FirstPlayerIndex] = new Player(GameUtils.v_FirstPlayerIndex);
            m_Players[GameUtils.v_SecondPlayerIndex] = new Player(GameUtils.v_SecondPlayerIndex);
        }

        private void playGame()
        {
            while (m_PlayerWantsToPlay)
            {
                while (!m_CurrentGameEnded)
                {
                    playTurn();
                    checkBoardStatus();
                    ++m_TurnNumber;
                }
                checkIfPlayerWantsToPlayAnotherGame();
            }


        }

        private void checkBoardStatus()
        {
            if (m_PlayerWantsToPlay)
            {
                GameBoard.eBoardStatus boardStatus = m_GameBoard.BoardStatus;
                if (boardStatus != GameBoard.eBoardStatus.NextPlayerCanPlay)
                {
                    if (boardStatus == GameBoard.eBoardStatus.PlayerWon)
                    {
                        m_Players[m_TurnNumber % 2].Score++;
                        m_UIManager.DeclareWinner(m_Players[m_TurnNumber % 2].Name);
                        m_UIManager.PresentCurrentScore(m_Players[0].Name, m_Players[0].Score, m_Players[1].Name, m_Players[1].Score);

                    }
                    else if (boardStatus == GameBoard.eBoardStatus.Draw)
                    {
                        m_UIManager.DeclareDraw();
                        m_UIManager.PresentCurrentScore(m_Players[0].Name, m_Players[0].Score, m_Players[1].Name, m_Players[1].Score);
                    }

                    m_CurrentGameEnded = true;
                }
            }
            else
            {
                m_Players[(m_TurnNumber + 1) % 2].Score++;
                m_UIManager.DeclareForfit(m_Players[m_TurnNumber % 2].Name);
                m_UIManager.PresentCurrentScore(m_Players[0].Name, m_Players[0].Score, m_Players[1].Name, m_Players[1].Score);
                m_CurrentGameEnded = true;
            }
        }

        private void checkIfPlayerWantsToPlayAnotherGame()
        {

            m_PlayerWantsToPlay = m_UIManager.CheckIfPplayerWantsToPlayAnotherGame();
            if (m_PlayerWantsToPlay)
            {
                playAnotherLevel();
            }
        }

        private void playTurn()
        {
            if (m_TurnNumber % 2 == 0 || m_GameMode == GameUtils.eGameMode.PlayerVsPlayer)
            {
                playHumanTurn();
            }
            else
            {
                playComputerTurn();
            }

        }

        private void playHumanTurn()
        {
            GameBoard.eBoardSquare playerSquare = m_TurnNumber % 2 == 0 ? GameBoard.eBoardSquare.Player1Square : GameBoard.eBoardSquare.Player2Square;
            m_PlayerWantsToPlay = m_UIManager.GetMoveFormUser(m_Players[m_TurnNumber % 2].Name, playerSquare, m_GameBoard);
        }

        private void playComputerTurn()
        {
            Ai ai = new Ai();
            int nextMove = ai.GetNextMove(m_GameBoard);
            m_GameBoard.TryToSetColumnSquare(nextMove, GameBoard.eBoardSquare.Player2Square);
        }

        private void playAnotherLevel()
        {
            m_TurnNumber = 0;
            m_CurrentGameEnded = false;
            m_GameBoard.ClearBoard();
        }
    }
}