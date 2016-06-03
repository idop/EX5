using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_WinformUi
{
    public partial class FormGame : Form
    {
        private const int k_Margin = 20;
        private const int k_ColumnSelectButtonWidth = 40;
        private const int k_ColumnSelectButtonHeight = 30;
        private const int k_BoardPieceButtonHeight = 40;
        private const int k_LabelHeight = 40;
        private Button[] buttonsColumnsSelect;
        private Button[,] buttonsBoardPiece;
        private int m_NumberOfRows;
        private int m_NumberOfColumns;


        public FormGame()
        {
            InitializeComponent();
        }

        public FormGame(int i_NumberOfRows, int i_NumberOfColumns)
        {
            m_NumberOfRows = i_NumberOfRows;
            m_NumberOfColumns = i_NumberOfColumns;
            initializeComponents();
            
        }

        private void initializeComponents()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Width = (m_NumberOfColumns + 2) * k_Margin + k_ColumnSelectButtonWidth * m_NumberOfColumns;
            this.Height = (m_NumberOfRows + 4) * k_Margin + k_ColumnSelectButtonHeight + k_BoardPieceButtonHeight * m_NumberOfRows + k_LabelHeight;
            initializeButtonsColumnsSelect();
            initializeButtonsBoardPiece();
        }

        private void initializeButtonsBoardPiece()
        {
            buttonsBoardPiece = new Button[m_NumberOfRows, m_NumberOfColumns];
            for (int i = 0; i < m_NumberOfRows; i++)
            {
                for (int j = 0; j < m_NumberOfColumns; j++)
                {
                    buttonsBoardPiece[i, j] = new Button();
                    buttonsBoardPiece[i, j].Top = (k_ColumnSelectButtonHeight + k_Margin) + (k_Margin) * (j + 1) + k_BoardPieceButtonHeight * j;
                    buttonsBoardPiece[i, j].Left = k_Margin * (i + 1) + k_ColumnSelectButtonWidth * i;
                    buttonsBoardPiece[i, j].Width = k_ColumnSelectButtonWidth;
                    buttonsBoardPiece[i, j].Height = k_BoardPieceButtonHeight;
                    buttonsBoardPiece[i, j].Enabled = false;
                    buttonsBoardPiece[i, j].FlatStyle = FlatStyle.Flat;
                    this.Controls.Add(buttonsBoardPiece[i, j]);
                }
            }
        }

        private void initializeButtonsColumnsSelect()
        {
            buttonsColumnsSelect = new Button[m_NumberOfColumns];
            for (int i = 0; i < m_NumberOfColumns; ++i)
            {
                buttonsColumnsSelect[i] = new Button();
                buttonsColumnsSelect[i].Text = string.Format("{0}", i + 1);
                buttonsColumnsSelect[i].Top = k_Margin;
                buttonsColumnsSelect[i].Left = k_Margin * (i + 1) + k_ColumnSelectButtonWidth * i;
                buttonsColumnsSelect[i].Width = k_ColumnSelectButtonWidth;
                buttonsColumnsSelect[i].Height = k_ColumnSelectButtonHeight;
                buttonsColumnsSelect[i].Click += buttonColumnSelect_Click;
                this.Controls.Add(buttonsColumnsSelect[i]);
            }
        }

        private void buttonColumnSelect_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
