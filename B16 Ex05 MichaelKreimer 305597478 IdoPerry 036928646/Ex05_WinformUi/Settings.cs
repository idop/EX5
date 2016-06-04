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
                return CheckBoxIsHuman.Checked ? TextBoxPlayer2.Text: "Computer";
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
            this.Close();
            /* try
            {
                checkLegalSettings();
            }
            //catch (ArgumentOutOfRangeException)
            //{
            //    LabelError.Text = "Board size is not legal";
            //    LabelError.Visible = true;
            //}
            catch (ArgumentException)
            {
                LabelError.Text = "Names are not legal";
                LabelError.Visible = true;
            }*/
        }

        private void checkLegalSettings()
        {
            if (!isLegalSize(Rows) || !isLegalSize(Cols))
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (!isLegalNames())
            {
                throw new ArgumentException();
            }
        }

        private bool isLegalSize(int num)
        {
            return num >= 4 && num <= 10;
        }

        private bool isLegalNames()
        {
            return (Player1Name != null && Player2Name != null && Player1Name != Player2Name);
        }
    }
}
