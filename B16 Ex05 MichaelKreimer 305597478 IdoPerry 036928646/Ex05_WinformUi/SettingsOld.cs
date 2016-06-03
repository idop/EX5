using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_WinformUi
{
    public partial class SettingsOld : Form
    {
        Button m_ButtonStart = new Button();
        Label m_LabelPlayers = new Label();
        Label m_LabelPlayer1 = new Label();
        Label m_LabelPlayer2 = new Label();
        Label m_LabelBoardSize = new Label();
        Label m_LabelCols = new Label();
        Label m_LabelRows = new Label();
        TextBox m_TBPlayer1 = new TextBox();
        TextBox m_TBPlayer2 = new TextBox();
        CheckBox m_CBPlayerHuman = new CheckBox();
        NumericUpDown m_NUDRows = new NumericUpDown();
        NumericUpDown m_NUDCols = new NumericUpDown();
        public SettingsOld()
        {
            this.Text = "Game Settings";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            m_LabelPlayers.Text = "Players:";
            m_ButtonStart.Text = "Start";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = "Game Settings";
            this.Size = new Size(300, 300);
            InitControls();
        }

        private void InitControls()
        {
            initControl(m_ButtonStart, "Start!", Size.Width - 100, Size.Height - 70);
            initControl(m_LabelPlayers, "Players:", 20, 10);
            m_LabelPlayers.Font = new Font("Arial", 10, FontStyle.Bold);
            initControl(m_LabelPlayer1, "Player 1:", m_LabelPlayers.Location.X + 30, m_LabelPlayers.Location.Y + 30);
            initControl(m_TBPlayer1, String.Empty, m_LabelPlayer1.Location.X + 100, m_LabelPlayer1.Location.Y);
            initControl(m_LabelPlayer2, "Player 2:", m_LabelPlayer1.Location.X, m_LabelPlayer1.Location.Y + 30);
            initControl(m_TBPlayer2, "[Computer]", m_TBPlayer1.Location.X, m_LabelPlayer2.Location.Y);
            m_TBPlayer2.Enabled = false;
            initControl(m_CBPlayerHuman, String.Empty, m_LabelPlayer2.Location.X - 20, m_LabelPlayer2.Location.Y - 5);
            initControl(m_LabelBoardSize, "Board Size:", m_LabelPlayers.Location.X, Size.Height / 3);
            m_LabelBoardSize.Font = m_LabelPlayers.Font;
            initControl(m_LabelRows, "Rows:", m_LabelBoardSize.Location.X + 25, m_LabelBoardSize.Location.Y + 30);
            initControl(m_LabelCols, "Cols:", m_LabelRows.Location.X + 150, m_LabelRows.Location.Y);
            initControl(m_NUDCols, String.Empty, m_LabelCols.Location.X, m_LabelCols.Location.Y + 25);
            initControl(m_NUDRows, String.Empty, m_LabelRows.Location.X, m_LabelRows.Location.Y + 25);
            m_NUDCols.Minimum = m_NUDRows.Minimum = 4;
            m_NUDCols.Size = m_NUDRows.Size = new Size(40, 20);
            m_NUDCols.Maximum = m_NUDRows.Maximum = 8;
        }
        private void initControl(Control i_Label, string i_Text,int x,int y)
        {
            i_Label.Text = i_Text;
            i_Label.Location = new Point(x, y);
            Controls.Add(i_Label);
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
