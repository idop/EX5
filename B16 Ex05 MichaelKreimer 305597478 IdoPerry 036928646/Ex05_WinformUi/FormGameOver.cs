using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_WinformUi
{
    public partial class FormGameOver : Form
    {
        public FormGameOver()
        {

            InitializeComponent();
        }
        public string GameOverText
        {
            get
            {
                return LabelDeclareResult.Text;
            }
            set
            {
                LabelDeclareResult.Text = value;
            }
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
