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
