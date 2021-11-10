
namespace MinesweeperClone
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
            this.pnl_playArea = new System.Windows.Forms.Panel();
            this.lbl_timerDisplay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Clicks = new System.Windows.Forms.Label();
            this.lbl_winsCounter = new System.Windows.Forms.Label();
            this.lbl_lossesCounter = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pnl_playArea
            // 
            this.pnl_playArea.Location = new System.Drawing.Point(12, 12);
            this.pnl_playArea.Name = "pnl_playArea";
            this.pnl_playArea.Size = new System.Drawing.Size(500, 500);
            this.pnl_playArea.TabIndex = 0;
            // 
            // lbl_timerDisplay
            // 
            this.lbl_timerDisplay.AutoSize = true;
            this.lbl_timerDisplay.Location = new System.Drawing.Point(647, 52);
            this.lbl_timerDisplay.Name = "lbl_timerDisplay";
            this.lbl_timerDisplay.Size = new System.Drawing.Size(65, 15);
            this.lbl_timerDisplay.TabIndex = 1;
            this.lbl_timerDisplay.Text = "Time taken";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(555, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minesweeper";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clicks :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Wins : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Losses : ";
            // 
            // lbl_Clicks
            // 
            this.lbl_Clicks.AutoSize = true;
            this.lbl_Clicks.Location = new System.Drawing.Point(673, 81);
            this.lbl_Clicks.Name = "lbl_Clicks";
            this.lbl_Clicks.Size = new System.Drawing.Size(13, 15);
            this.lbl_Clicks.TabIndex = 7;
            this.lbl_Clicks.Text = "0";
            // 
            // lbl_winsCounter
            // 
            this.lbl_winsCounter.AutoSize = true;
            this.lbl_winsCounter.Location = new System.Drawing.Point(673, 112);
            this.lbl_winsCounter.Name = "lbl_winsCounter";
            this.lbl_winsCounter.Size = new System.Drawing.Size(13, 15);
            this.lbl_winsCounter.TabIndex = 8;
            this.lbl_winsCounter.Text = "0";
            // 
            // lbl_lossesCounter
            // 
            this.lbl_lossesCounter.AutoSize = true;
            this.lbl_lossesCounter.Location = new System.Drawing.Point(673, 142);
            this.lbl_lossesCounter.Name = "lbl_lossesCounter";
            this.lbl_lossesCounter.Size = new System.Drawing.Size(13, 15);
            this.lbl_lossesCounter.TabIndex = 9;
            this.lbl_lossesCounter.Text = "0";
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_reset.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_reset.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_reset.Location = new System.Drawing.Point(518, 451);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(194, 61);
            this.btn_reset.TabIndex = 10;
            this.btn_reset.Text = "Reset ";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(581, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Flag Cells";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(729, 526);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lbl_lossesCounter);
            this.Controls.Add(this.lbl_winsCounter);
            this.Controls.Add(this.lbl_Clicks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_timerDisplay);
            this.Controls.Add(this.pnl_playArea);
            this.Name = "Form1";
            this.Text = "MineSweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_playArea;
        private System.Windows.Forms.Label lbl_timerDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Clicks;
        private System.Windows.Forms.Label lbl_winsCounter;
        private System.Windows.Forms.Label lbl_lossesCounter;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

