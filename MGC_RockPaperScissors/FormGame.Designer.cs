namespace MGC_RockPaperScissors
{
    partial class FormGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGame = new System.Windows.Forms.TextBox();
            this.btnScissor = new System.Windows.Forms.Button();
            this.btnPaper = new System.Windows.Forms.Button();
            this.btnRock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(134, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rock Paper Scissors";
            // 
            // txtGame
            // 
            this.txtGame.AcceptsTab = true;
            this.txtGame.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGame.Location = new System.Drawing.Point(12, 66);
            this.txtGame.Multiline = true;
            this.txtGame.Name = "txtGame";
            this.txtGame.ReadOnly = true;
            this.txtGame.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGame.Size = new System.Drawing.Size(697, 486);
            this.txtGame.TabIndex = 4;
            this.txtGame.TabStop = false;
            // 
            // btnScissor
            // 
            this.btnScissor.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnScissor.Location = new System.Drawing.Point(528, 558);
            this.btnScissor.Name = "btnScissor";
            this.btnScissor.Size = new System.Drawing.Size(177, 56);
            this.btnScissor.TabIndex = 6;
            this.btnScissor.Text = "Scissor";
            this.btnScissor.UseVisualStyleBackColor = true;
            this.btnScissor.Click += new System.EventHandler(this.btnScissor_Click);
            // 
            // btnPaper
            // 
            this.btnPaper.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPaper.Location = new System.Drawing.Point(273, 558);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(177, 56);
            this.btnPaper.TabIndex = 7;
            this.btnPaper.Text = "Paper";
            this.btnPaper.UseVisualStyleBackColor = true;
            this.btnPaper.Click += new System.EventHandler(this.btnPaper_Click);
            // 
            // btnRock
            // 
            this.btnRock.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRock.Location = new System.Drawing.Point(12, 558);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(177, 56);
            this.btnRock.TabIndex = 8;
            this.btnRock.Text = "Rock";
            this.btnRock.UseVisualStyleBackColor = true;
            this.btnRock.Click += new System.EventHandler(this.btnRock_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 626);
            this.Controls.Add(this.btnRock);
            this.Controls.Add(this.btnPaper);
            this.Controls.Add(this.btnScissor);
            this.Controls.Add(this.txtGame);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGame;
        private System.Windows.Forms.Button btnScissor;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Button btnRock;
    }
}