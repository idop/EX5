using Ex05_GameUtils;
using Ex05_WinformUi;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ex05_Logic
{
    public class GameManager
    {
        private const int k_NumberOfPlayers = 2;
        private GameBoard m_GameBoard;
        private GameUtils.eGameMode m_GameMode;
        private int m_TurnNumber = 0;
        private bool m_PlayerWantsToPlay = true;
        private bool m_CurrentGameEnded = false;

        public GameManager(GameUtils.eGameMode i_GameMode , int i_rows, int i_Columns)
        {
            m_GameMode = i_GameMode;
            m_GameBoard = new GameBoard(i_rows, i_Columns);

        }
        //TODO Delete
        /*
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

                }*/

        public PlayerMove PlayHumanTurn(int i_NextMove)
        {
            GameBoard.eBoardSquare playerSquare = m_TurnNumber % 2 == 0 ? GameBoard.eBoardSquare.Player1Square : GameBoard.eBoardSquare.Player2Square;
            return  new PlayerMove(m_GameBoard.SetColumnSquare(i_NextMove, playerSquare),i_NextMove, playerSquare, m_GameBoard.BoardStatus);
        }

        public PlayerMove PlayComputerTurn()
        {
            GameBoard.eBoardSquare playerSquare = GameBoard.eBoardSquare.Player2Square;
            Ai ai = new Ai();
            int nextMove = ai.GetNextMove(m_GameBoard);
            return new PlayerMove(m_GameBoard.SetColumnSquare(nextMove, playerSquare), nextMove, playerSquare, m_GameBoard.BoardStatus);
        }

        public bool IsColumnFull(int i_selectedColumn)
        {
            return m_GameBoard.IsColumnFull(i_selectedColumn);
        }
        /*
private void playAnotherLevel()
{
   m_TurnNumber = 0;
   m_CurrentGameEnded = false;
   m_GameBoard.ClearBoard();
}*/
    }
}