using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_WinformUi
{
    class Controller
    {
        GameManager m_GameManager = new GameManager();

        internal void Start()
        {
            //m_GameManager.Start();
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
