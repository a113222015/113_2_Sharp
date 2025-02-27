namespace Tutorial_4_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distanceTextBox = new TextBox();
            gasTextBox = new TextBox();
            averageLabel = new Label();
            calcuateButton = new Button();
            exitButton = new Button();
            logListBox = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(76, 56);
            label1.Name = "label1";
            label1.Size = new Size(143, 24);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(76, 125);
            label2.Name = "label2";
            label2.Size = new Size(143, 24);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(76, 188);
            label3.Name = "label3";
            label3.Size = new Size(124, 24);
            label3.TabIndex = 2;
            label3.Text = "您的平均油耗";
            // 
            // distanceTextBox
            // 
            distanceTextBox.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            distanceTextBox.Location = new Point(254, 56);
            distanceTextBox.Name = "distanceTextBox";
            distanceTextBox.Size = new Size(100, 32);
            distanceTextBox.TabIndex = 3;
            // 
            // gasTextBox
            // 
            gasTextBox.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            gasTextBox.Location = new Point(254, 117);
            gasTextBox.Name = "gasTextBox";
            gasTextBox.Size = new Size(100, 32);
            gasTextBox.TabIndex = 4;
            // 
            // averageLabel
            // 
            averageLabel.BorderStyle = BorderStyle.Fixed3D;
            averageLabel.Location = new Point(254, 173);
            averageLabel.Name = "averageLabel";
            averageLabel.Size = new Size(114, 39);
            averageLabel.TabIndex = 5;
            averageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calcuateButton
            // 
            calcuateButton.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            calcuateButton.Location = new Point(76, 260);
            calcuateButton.Name = "calcuateButton";
            calcuateButton.Size = new Size(106, 41);
            calcuateButton.TabIndex = 6;
            calcuateButton.Text = "計算";
            calcuateButton.UseVisualStyleBackColor = true;
            calcuateButton.Click += calcuateButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exitButton.Location = new Point(268, 260);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(100, 41);
            exitButton.TabIndex = 7;
            exitButton.Text = "離開";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // logListBox
            // 
            logListBox.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            logListBox.FormattingEnabled = true;
            logListBox.ItemHeight = 24;
            logListBox.Location = new Point(406, 57);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(187, 244);
            logListBox.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(442, 320);
            button1.Name = "button1";
            button1.Size = new Size(115, 39);
            button1.TabIndex = 9;
            button1.Text = "總平均油耗";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 442);
            Controls.Add(button1);
            Controls.Add(logListBox);
            Controls.Add(exitButton);
            Controls.Add(calcuateButton);
            Controls.Add(averageLabel);
            Controls.Add(gasTextBox);
            Controls.Add(distanceTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distanceTextBox;
        private TextBox gasTextBox;
        private Label averageLabel;
        private Button calcuateButton;
        private Button exitButton;
        private ListBox logListBox;
        private Button button1;
    }
}
