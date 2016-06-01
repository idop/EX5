namespace Ex05_WinformUi
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.CheckBoxIsHuman = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            this.LabelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TextBoxPlayer1
            // 
            resources.ApplyResources(this.TextBoxPlayer1, "TextBoxPlayer1");
            this.TextBoxPlayer1.Name = "TextBoxPlayer1";
            // 
            // TextBoxPlayer2
            // 
            resources.ApplyResources(this.TextBoxPlayer2, "TextBoxPlayer2");
            this.TextBoxPlayer2.Name = "TextBoxPlayer2";
            // 
            // CheckBoxIsHuman
            // 
            resources.ApplyResources(this.CheckBoxIsHuman, "CheckBoxIsHuman");
            this.CheckBoxIsHuman.Name = "CheckBoxIsHuman";
            this.CheckBoxIsHuman.UseVisualStyleBackColor = true;
            this.CheckBoxIsHuman.CheckedChanged += new System.EventHandler(this.CheckBoxIsHuman_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ButtonStart
            // 
            resources.ApplyResources(this.ButtonStart, "ButtonStart");
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // nUDRows
            // 
            resources.ApplyResources(this.nUDRows, "nUDRows");
            this.nUDRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nUDCols
            // 
            resources.ApplyResources(this.nUDCols, "nUDCols");
            this.nUDCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // LabelError
            // 
            resources.ApplyResources(this.LabelError, "LabelError");
            this.LabelError.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LabelError.ForeColor = System.Drawing.Color.Red;
            this.LabelError.Name = "LabelError";
            // 
            // Settings
            // 
            this.AcceptButton = this.ButtonStart;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.LabelError);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckBoxIsHuman);
            this.Controls.Add(this.TextBoxPlayer2);
            this.Controls.Add(this.TextBoxPlayer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxPlayer1;
        private System.Windows.Forms.TextBox TextBoxPlayer2;
        private System.Windows.Forms.CheckBox CheckBoxIsHuman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.NumericUpDown nUDRows;
        private System.Windows.Forms.NumericUpDown nUDCols;
        private System.Windows.Forms.Label LabelError;
    }
}