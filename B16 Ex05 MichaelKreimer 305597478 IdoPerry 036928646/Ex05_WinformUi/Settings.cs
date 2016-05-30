using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_WinformUi
{
    public partial class Settings : Form
    {
        Button m_ButtonStart = new Button();
        Label m_LabelPlayers = new Label();
        Label m_LabelPlayer1 = new Label();
        Label m_LabelPlayer2 = new Label();
        Label m_LabelBoardSize = new Label();
        Label m_LabelCols = new Label();
        Label m_LabelRows = new Label();
        TextBox m_TextBoxPlayer1 = new TextBox();
        TextBox m_TextBoxPlayer2 = new TextBox();
        CheckBox m_CheckBoxPlayerHuman = new CheckBox();
        NumericUpDown m_NUDRows = new NumericUpDown();
        NumericUpDown m_NUDCols = new NumericUpDown();
        public Settings()
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

            InitControls();
        }

        private void InitControls()
        {
            this.Text = "Game Settings";
            this.Size = new Size(300, 300);
            m_ButtonStart.Text = "Start!";
            m_ButtonStart.Location = new Point(this.Size.Width - 100, this.Size.Height - 70);
            m_LabelPlayers.Text = "Players:";
            m_LabelPlayers.Font = new Font("Arial", 10, FontStyle.Bold);
            m_LabelPlayers.Location = new Point(20, 10);
            m_LabelPlayer1.Text = "Player 1:";
            m_LabelPlayer1.Location = new Point(m_LabelPlayers.Location.X + 30, m_LabelPlayers.Location.Y + 30);
            m_TextBoxPlayer1.Location = new Point(m_LabelPlayer1.Location.X + 100, m_LabelPlayer1.Location.Y);
            m_LabelPlayer2.Text = "Player 2:";
            m_LabelPlayer2.Location = new Point(m_LabelPlayer1.Location.X, m_LabelPlayer1.Location.Y + 30);
            m_TextBoxPlayer2.Location = new Point(m_TextBoxPlayer1.Location.X, m_LabelPlayer2.Location.Y);
            m_CheckBoxPlayerHuman.Location = new Point(m_LabelPlayer2.Location.X - 20, m_LabelPlayer2.Location.Y - 5);
            m_LabelBoardSize.Font = m_LabelPlayers.Font;
            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Location = new Point(m_LabelPlayers.Location.X , this.Size.Height / 3);
            m_LabelRows.Text = "Rows:";
            m_LabelRows.Location = new Point(m_LabelBoardSize.Location.X + 25, m_LabelBoardSize.Location.Y + 30);
            m_LabelCols.Text = "Cols:";
            m_LabelCols.Location = new Point(m_LabelRows.Location.X + 150, m_LabelRows.Location.Y);
            m_NUDCols.Minimum = m_NUDRows.Minimum = 4;
            m_NUDCols.Size = m_NUDRows.Size = new Size(40, 20);
            m_NUDCols.Maximum = m_NUDRows.Maximum = 8;
            m_NUDCols.Location = new Point(m_LabelCols.Location.X, m_LabelCols.Location.Y + 25);
            m_NUDRows.Location = new Point(m_LabelRows.Location.X, m_LabelRows.Location.Y + 25);
            addControls();
        }

        private void addControls()
        {
            this.Controls.Add(m_LabelPlayer1);
            this.Controls.Add(m_LabelPlayer2);
            this.Controls.Add(m_CheckBoxPlayerHuman);
            this.Controls.Add(m_ButtonStart);
            this.Controls.Add(m_LabelPlayers);
            this.Controls.Add(m_TextBoxPlayer1);
            this.Controls.Add(m_TextBoxPlayer2);
            this.Controls.Add(m_LabelBoardSize);
            this.Controls.Add(m_LabelRows);
            this.Controls.Add(m_LabelCols);
            this.Controls.Add(m_NUDRows);
            this.Controls.Add(m_NUDCols);
        }
    }
}
