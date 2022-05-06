
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
            this.difficultyRadioButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.hardRadioButton = new System.Windows.Forms.RadioButton();
            this.easyRadioButton = new System.Windows.Forms.RadioButton();
            this.mediumRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).BeginInit();
            this.difficultyRadioButtonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.resetButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.boardPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gameOverLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.difficultyRadioButtonsGroupBox, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(994, 691);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // resetButton
            // 
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resetButton.Location = new System.Drawing.Point(798, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(193, 81);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPictureBox.Location = new System.Drawing.Point(3, 3);
            this.boardPictureBox.Name = "boardPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.boardPictureBox, 3);
            this.boardPictureBox.Size = new System.Drawing.Size(789, 685);
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
            this.gameOverLabel.Location = new System.Drawing.Point(798, 339);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(193, 352);
            this.gameOverLabel.TabIndex = 2;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOverLabel.Visible = false;
            // 
            // difficultyRadioButtonsGroupBox
            // 
            this.difficultyRadioButtonsGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.difficultyRadioButtonsGroupBox.Controls.Add(this.hardRadioButton);
            this.difficultyRadioButtonsGroupBox.Controls.Add(this.easyRadioButton);
            this.difficultyRadioButtonsGroupBox.Controls.Add(this.mediumRadioButton);
            this.difficultyRadioButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.difficultyRadioButtonsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.difficultyRadioButtonsGroupBox.Location = new System.Drawing.Point(798, 90);
            this.difficultyRadioButtonsGroupBox.Name = "difficultyRadioButtonsGroupBox";
            this.difficultyRadioButtonsGroupBox.Size = new System.Drawing.Size(193, 246);
            this.difficultyRadioButtonsGroupBox.TabIndex = 3;
            this.difficultyRadioButtonsGroupBox.TabStop = false;
            this.difficultyRadioButtonsGroupBox.Text = "Difficulty";
            // 
            // hardRadioButton
            // 
            this.hardRadioButton.AutoSize = true;
            this.hardRadioButton.Checked = true;
            this.hardRadioButton.Location = new System.Drawing.Point(15, 99);
            this.hardRadioButton.Name = "hardRadioButton";
            this.hardRadioButton.Size = new System.Drawing.Size(79, 29);
            this.hardRadioButton.TabIndex = 3;
            this.hardRadioButton.TabStop = true;
            this.hardRadioButton.Text = "Hard";
            this.hardRadioButton.UseVisualStyleBackColor = true;
            this.hardRadioButton.CheckedChanged += new System.EventHandler(this.hardRadioButton_CheckedChanged);
            // 
            // easyRadioButton
            // 
            this.easyRadioButton.AutoSize = true;
            this.easyRadioButton.Location = new System.Drawing.Point(15, 29);
            this.easyRadioButton.Name = "easyRadioButton";
            this.easyRadioButton.Size = new System.Drawing.Size(81, 29);
            this.easyRadioButton.TabIndex = 2;
            this.easyRadioButton.Text = "Easy";
            this.easyRadioButton.UseVisualStyleBackColor = true;
            this.easyRadioButton.CheckedChanged += new System.EventHandler(this.easyRadioButton_CheckedChanged);
            // 
            // mediumRadioButton
            // 
            this.mediumRadioButton.AutoSize = true;
            this.mediumRadioButton.Location = new System.Drawing.Point(15, 64);
            this.mediumRadioButton.Name = "mediumRadioButton";
            this.mediumRadioButton.Size = new System.Drawing.Size(109, 29);
            this.mediumRadioButton.TabIndex = 1;
            this.mediumRadioButton.Text = "Medium";
            this.mediumRadioButton.UseVisualStyleBackColor = true;
            this.mediumRadioButton.CheckedChanged += new System.EventHandler(this.mediumRadioButton_CheckedChanged);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 691);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "GameForm";
            this.Text = "Five in a Row";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).EndInit();
            this.difficultyRadioButtonsGroupBox.ResumeLayout(false);
            this.difficultyRadioButtonsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox boardPictureBox;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.GroupBox difficultyRadioButtonsGroupBox;
        private System.Windows.Forms.RadioButton hardRadioButton;
        private System.Windows.Forms.RadioButton easyRadioButton;
        private System.Windows.Forms.RadioButton mediumRadioButton;
    }
}

