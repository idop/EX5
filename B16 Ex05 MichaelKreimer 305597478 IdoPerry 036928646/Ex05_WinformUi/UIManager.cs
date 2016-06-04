using System;
using System.Collections.Generic;
using System.Text;
using Ex05_GameUtils;
using Ex05_Logic;

namespace Ex05_WinformUi
{
    public class UIManager
    {
        FormSettings settings = new FormSettings();
        
        public UIManager()
        {

        }
        public FormSettings Settings
        {
            get
            {
                return settings;
            }
        }

        internal void DeclareForfit(string name)
        {
            throw new NotImplementedException();
        }

        internal void DeclareDraw()
        {
            throw new NotImplementedException();
        }

        internal void DeclareWinner(string name)
        {
            throw new NotImplementedException();
        }

        internal void PresentCurrentScore(string name1, int score1, string name2, int score2)
        {
            throw new NotImplementedException();
        }

        internal bool CheckIfPplayerWantsToPlayAnotherGame()
        {
            throw new NotImplementedException();
        }
        internal bool GetMoveFormUser(string name, GameBoard.eBoardSquare playerSquare, GameBoard m_GameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
