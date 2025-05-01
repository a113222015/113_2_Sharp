namespace Test_Average
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.averageScoreDescriptionLabel = new System.Windows.Forms.Label();
            this.lowScoreDescriptionLabel = new System.Windows.Forms.Label();
            this.highScoreDescriptionLabel = new System.Windows.Forms.Label();
            this.testScoresListBox = new System.Windows.Forms.ListBox();
            this.testScoresDescriptionLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.lowScoreLabel = new System.Windows.Forms.Label();
            this.averageScoreLabel = new System.Windows.Forms.Label();
            this.getScoresButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.sortedScoresListBox = new System.Windows.Forms.ListBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // averageScoreDescriptionLabel
            // 
            this.averageScoreDescriptionLabel.AutoSize = true;
            this.averageScoreDescriptionLabel.Location = new System.Drawing.Point(136, 98);
            this.averageScoreDescriptionLabel.Name = "averageScoreDescriptionLabel";
            this.averageScoreDescriptionLabel.Size = new System.Drawing.Size(53, 12);
            this.averageScoreDescriptionLabel.TabIndex = 9;
            this.averageScoreDescriptionLabel.Text = "平均分數";
            // 
            // lowScoreDescriptionLabel
            // 
            this.lowScoreDescriptionLabel.AutoSize = true;
            this.lowScoreDescriptionLabel.Location = new System.Drawing.Point(142, 65);
            this.lowScoreDescriptionLabel.Name = "lowScoreDescriptionLabel";
            this.lowScoreDescriptionLabel.Size = new System.Drawing.Size(53, 12);
            this.lowScoreDescriptionLabel.TabIndex = 8;
            this.lowScoreDescriptionLabel.Text = "最低分數";
            // 
            // highScoreDescriptionLabel
            // 
            this.highScoreDescriptionLabel.AutoSize = true;
            this.highScoreDescriptionLabel.Location = new System.Drawing.Point(140, 32);
            this.highScoreDescriptionLabel.Name = "highScoreDescriptionLabel";
            this.highScoreDescriptionLabel.Size = new System.Drawing.Size(53, 12);
            this.highScoreDescriptionLabel.TabIndex = 7;
            this.highScoreDescriptionLabel.Text = "最高分數";
            // 
            // testScoresListBox
            // 
            this.testScoresListBox.FormattingEnabled = true;
            this.testScoresListBox.ItemHeight = 12;
            this.testScoresListBox.Location = new System.Drawing.Point(12, 27);
            this.testScoresListBox.Name = "testScoresListBox";
            this.testScoresListBox.Size = new System.Drawing.Size(120, 88);
            this.testScoresListBox.TabIndex = 6;
            // 
            // testScoresDescriptionLabel
            // 
            this.testScoresDescriptionLabel.AutoSize = true;
            this.testScoresDescriptionLabel.Location = new System.Drawing.Point(12, 12);
            this.testScoresDescriptionLabel.Name = "testScoresDescriptionLabel";
            this.testScoresDescriptionLabel.Size = new System.Drawing.Size(53, 12);
            this.testScoresDescriptionLabel.TabIndex = 5;
            this.testScoresDescriptionLabel.Text = "測試分數";
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highScoreLabel.Location = new System.Drawing.Point(218, 27);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(100, 21);
            this.highScoreLabel.TabIndex = 10;
            this.highScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lowScoreLabel
            // 
            this.lowScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lowScoreLabel.Location = new System.Drawing.Point(218, 60);
            this.lowScoreLabel.Name = "lowScoreLabel";
            this.lowScoreLabel.Size = new System.Drawing.Size(100, 21);
            this.lowScoreLabel.TabIndex = 11;
            this.lowScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // averageScoreLabel
            // 
            this.averageScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.averageScoreLabel.Location = new System.Drawing.Point(218, 93);
            this.averageScoreLabel.Name = "averageScoreLabel";
            this.averageScoreLabel.Size = new System.Drawing.Size(100, 21);
            this.averageScoreLabel.TabIndex = 12;
            this.averageScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // getScoresButton
            // 
            this.getScoresButton.Location = new System.Drawing.Point(90, 138);
            this.getScoresButton.Name = "getScoresButton";
            this.getScoresButton.Size = new System.Drawing.Size(75, 21);
            this.getScoresButton.TabIndex = 13;
            this.getScoresButton.Text = "取得分數";
            this.getScoresButton.UseVisualStyleBackColor = true;
            this.getScoresButton.Click += new System.EventHandler(this.getScoresButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(171, 138);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 21);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // sortedScoresListBox
            // 
            this.sortedScoresListBox.FormattingEnabled = true;
            this.sortedScoresListBox.ItemHeight = 12;
            this.sortedScoresListBox.Location = new System.Drawing.Point(12, 180);
            this.sortedScoresListBox.Name = "sortedScoresListBox";
            this.sortedScoresListBox.Size = new System.Drawing.Size(120, 88);
            this.sortedScoresListBox.TabIndex = 15;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(171, 180);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 21);
            this.sortButton.TabIndex = 16;
            this.sortButton.Text = "排序";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(252, 180);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 21);
            this.deleteButton.TabIndex = 17;
            this.deleteButton.Text = "刪除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 280);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.sortedScoresListBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.getScoresButton);
            this.Controls.Add(this.averageScoreLabel);
            this.Controls.Add(this.lowScoreLabel);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.averageScoreDescriptionLabel);
            this.Controls.Add(this.lowScoreDescriptionLabel);
            this.Controls.Add(this.highScoreDescriptionLabel);
            this.Controls.Add(this.testScoresListBox);
            this.Controls.Add(this.testScoresDescriptionLabel);
            this.Name = "Form1";
            this.Text = "測試平均分數";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label averageScoreDescriptionLabel;
        private System.Windows.Forms.Label lowScoreDescriptionLabel;
        private System.Windows.Forms.Label highScoreDescriptionLabel;
        private System.Windows.Forms.ListBox testScoresListBox;
        private System.Windows.Forms.Label testScoresDescriptionLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label lowScoreLabel;
        private System.Windows.Forms.Label averageScoreLabel;
        private System.Windows.Forms.Button getScoresButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ListBox sortedScoresListBox;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button deleteButton; // 刪除按鍵
    }
}

