
namespace Gomoku {
    partial class GameForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.resetButton = new System.Windows.Forms.Button();
            this.boardPictureBox = new System.Windows.Forms.PictureBox();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hardRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.mediumRadioButton = new System.Windows.Forms.RadioButton();
            this.easyRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonPvP = new System.Windows.Forms.RadioButton();
            this.radioButtonPvB = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.resetButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.boardPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gameOverLabel, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1534, 945);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // resetButton
            // 
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resetButton.Location = new System.Drawing.Point(1231, 4);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(299, 94);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPictureBox.Location = new System.Drawing.Point(4, 4);
            this.boardPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.boardPictureBox.Name = "boardPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.boardPictureBox, 4);
            this.boardPictureBox.Size = new System.Drawing.Size(1219, 937);
            this.boardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boardPictureBox.TabIndex = 1;
            this.boardPictureBox.TabStop = false;
            this.boardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPictureBox_Paint);
            this.boardPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.boardPictureBox_MouseClick);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.LightYellow;
            this.gameOverLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameOverLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameOverLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameOverLabel.Location = new System.Drawing.Point(1231, 534);
            this.gameOverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(299, 411);
            this.gameOverLabel.TabIndex = 2;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOverLabel.Visible = false;
            this.gameOverLabel.Click += new System.EventHandler(this.gameOverLabel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hardRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mediumRadioButton);
            this.panel1.Controls.Add(this.easyRadioButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(1231, 308);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 222);
            this.panel1.TabIndex = 4;
            // 
            // hardRadioButton
            // 
            this.hardRadioButton.AutoSize = true;
            this.hardRadioButton.Location = new System.Drawing.Point(32, 161);
            this.hardRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.hardRadioButton.Name = "hardRadioButton";
            this.hardRadioButton.Size = new System.Drawing.Size(106, 42);
            this.hardRadioButton.TabIndex = 3;
            this.hardRadioButton.Text = "Hard";
            this.hardRadioButton.UseVisualStyleBackColor = true;
            this.hardRadioButton.CheckedChanged += new System.EventHandler(this.hardRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Difficulty";
            // 
            // mediumRadioButton
            // 
            this.mediumRadioButton.AutoSize = true;
            this.mediumRadioButton.Location = new System.Drawing.Point(32, 110);
            this.mediumRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.mediumRadioButton.Name = "mediumRadioButton";
            this.mediumRadioButton.Size = new System.Drawing.Size(152, 42);
            this.mediumRadioButton.TabIndex = 1;
            this.mediumRadioButton.Text = "Medium";
            this.mediumRadioButton.UseVisualStyleBackColor = true;
            this.mediumRadioButton.CheckedChanged += new System.EventHandler(this.mediumRadioButton_CheckedChanged);
            // 
            // easyRadioButton
            // 
            this.easyRadioButton.AutoSize = true;
            this.easyRadioButton.Checked = true;
            this.easyRadioButton.Location = new System.Drawing.Point(32, 59);
            this.easyRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.easyRadioButton.Name = "easyRadioButton";
            this.easyRadioButton.Size = new System.Drawing.Size(99, 42);
            this.easyRadioButton.TabIndex = 2;
            this.easyRadioButton.TabStop = true;
            this.easyRadioButton.Text = "Easy";
            this.easyRadioButton.UseVisualStyleBackColor = true;
            this.easyRadioButton.CheckedChanged += new System.EventHandler(this.easyRadioButton_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonPvP);
            this.panel2.Controls.Add(this.radioButtonPvB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(1231, 106);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 194);
            this.panel2.TabIndex = 5;
            // 
            // radioButtonPvP
            // 
            this.radioButtonPvP.AutoSize = true;
            this.radioButtonPvP.Location = new System.Drawing.Point(32, 112);
            this.radioButtonPvP.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonPvP.Name = "radioButtonPvP";
            this.radioButtonPvP.Size = new System.Drawing.Size(247, 42);
            this.radioButtonPvP.TabIndex = 2;
            this.radioButtonPvP.Text = "Player vs Player";
            this.radioButtonPvP.UseVisualStyleBackColor = true;
            this.radioButtonPvP.CheckedChanged += new System.EventHandler(this.radioButtonPlayerVsPlayer_CheckedChanged);
            // 
            // radioButtonPvB
            // 
            this.radioButtonPvB.AutoSize = true;
            this.radioButtonPvB.Checked = true;
            this.radioButtonPvB.Location = new System.Drawing.Point(32, 61);
            this.radioButtonPvB.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonPvB.Name = "radioButtonPvB";
            this.radioButtonPvB.Size = new System.Drawing.Size(212, 42);
            this.radioButtonPvB.TabIndex = 1;
            this.radioButtonPvB.TabStop = true;
            this.radioButtonPvB.Text = "Player vs Bot";
            this.radioButtonPvB.UseVisualStyleBackColor = true;
            this.radioButtonPvB.CheckedChanged += new System.EventHandler(this.radioButtonPlayerVsBot_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mode";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 945);
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameForm";
            this.Text = "Five in a Row";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox boardPictureBox;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.RadioButton hardRadioButton;
        private System.Windows.Forms.RadioButton easyRadioButton;
        private System.Windows.Forms.RadioButton mediumRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonPvP;
        private System.Windows.Forms.RadioButton radioButtonPvB;
    }
}

