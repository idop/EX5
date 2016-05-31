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
        public Settings()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get
            {
                return TextBoxPlayer1.Text;
            }
        }
        public string Player2Name
        {
            get
            {
                return TextBoxPlayer2.Text;
            }
        }
        public int Rows
        {
            get
            {
                return (int)nUDRows.Value;
            }
        }
        public int Cols
        {
            get
            {
                return (int)nUDCols.Value;
            }
        }
        public bool HumanPlaying
        {
            get
            {
                return CheckBoxIsHuman.Checked;
            }
        }

        private void CheckBoxIsHuman_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBoxIsHuman.Checked)
            {
                TextBoxPlayer2.Enabled = true;
                TextBoxPlayer2.Text = String.Empty;
            }
            else 
            {
                TextBoxPlayer2.Enabled = false;
                TextBoxPlayer2.Text = "[Computer]";
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
