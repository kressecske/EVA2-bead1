namespace Labyrinth.View
{
    partial class GameWindow
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
            this.newGameButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gameTable = new System.Windows.Forms.Panel();
            this.pauseButton = new System.Windows.Forms.Button();
            this.gameTimeText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(30, 12);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(133, 12);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load Level";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gameTable
            // 
            this.gameTable.Location = new System.Drawing.Point(30, 60);
            this.gameTable.Name = "gameTable";
            this.gameTable.Size = new System.Drawing.Size(200, 100);
            this.gameTable.TabIndex = 3;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(371, 9);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause Game";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // gameTimeText
            // 
            this.gameTimeText.BackColor = System.Drawing.Color.White;
            this.gameTimeText.Enabled = false;
            this.gameTimeText.Location = new System.Drawing.Point(472, 12);
            this.gameTimeText.Name = "gameTimeText";
            this.gameTimeText.Size = new System.Drawing.Size(100, 20);
            this.gameTimeText.TabIndex = 5;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.gameTimeText);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.gameTable);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.newGameButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameWindow";
            this.Text = "Labyrinth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel gameTable;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TextBox gameTimeText;
    }
}