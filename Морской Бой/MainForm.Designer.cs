namespace Морской_Бой
{
    partial class MainForm
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
            this.BattleFieldPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BattleFieldPB)).BeginInit();
            this.SuspendLayout();
            // 
            // BattleFieldPB
            // 
            this.BattleFieldPB.BackColor = System.Drawing.Color.YellowGreen;
            this.BattleFieldPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BattleFieldPB.Location = new System.Drawing.Point(0, 0);
            this.BattleFieldPB.Name = "BattleFieldPB";
            this.BattleFieldPB.Size = new System.Drawing.Size(784, 461);
            this.BattleFieldPB.TabIndex = 0;
            this.BattleFieldPB.TabStop = false;
            this.BattleFieldPB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BattleFieldPB_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.BattleFieldPB);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской Бой ";
            ((System.ComponentModel.ISupportInitialize)(this.BattleFieldPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox BattleFieldPB;
    }
}

