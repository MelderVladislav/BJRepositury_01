namespace BlackJack
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.TwoPlayersBtn = new System.Windows.Forms.Button();
            this.ThreePlayersBtn = new System.Windows.Forms.Button();
            this.FourPlayersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TwoPlayersBtn
            // 
            this.TwoPlayersBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TwoPlayersBtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TwoPlayersBtn.ForeColor = System.Drawing.Color.White;
            this.TwoPlayersBtn.Location = new System.Drawing.Point(77, 54);
            this.TwoPlayersBtn.Name = "TwoPlayersBtn";
            this.TwoPlayersBtn.Size = new System.Drawing.Size(133, 33);
            this.TwoPlayersBtn.TabIndex = 0;
            this.TwoPlayersBtn.Text = "2 игрока";
            this.TwoPlayersBtn.UseVisualStyleBackColor = false;
            this.TwoPlayersBtn.Click += new System.EventHandler(this.TwoPlayersBtn_Click);
            // 
            // ThreePlayersBtn
            // 
            this.ThreePlayersBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ThreePlayersBtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThreePlayersBtn.ForeColor = System.Drawing.Color.White;
            this.ThreePlayersBtn.Location = new System.Drawing.Point(77, 109);
            this.ThreePlayersBtn.Name = "ThreePlayersBtn";
            this.ThreePlayersBtn.Size = new System.Drawing.Size(133, 33);
            this.ThreePlayersBtn.TabIndex = 1;
            this.ThreePlayersBtn.Text = "3 игрока";
            this.ThreePlayersBtn.UseVisualStyleBackColor = false;
            this.ThreePlayersBtn.Click += new System.EventHandler(this.ThreePlayersBtn_Click);
            // 
            // FourPlayersBtn
            // 
            this.FourPlayersBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FourPlayersBtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FourPlayersBtn.ForeColor = System.Drawing.Color.White;
            this.FourPlayersBtn.Location = new System.Drawing.Point(77, 167);
            this.FourPlayersBtn.Name = "FourPlayersBtn";
            this.FourPlayersBtn.Size = new System.Drawing.Size(133, 33);
            this.FourPlayersBtn.TabIndex = 2;
            this.FourPlayersBtn.Text = "4 игрока";
            this.FourPlayersBtn.UseVisualStyleBackColor = false;
            this.FourPlayersBtn.Click += new System.EventHandler(this.FourPlayersBtn_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(290, 277);
            this.Controls.Add(this.FourPlayersBtn);
            this.Controls.Add(this.ThreePlayersBtn);
            this.Controls.Add(this.TwoPlayersBtn);
            this.Name = "MenuForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TwoPlayersBtn;
        private System.Windows.Forms.Button ThreePlayersBtn;
        private System.Windows.Forms.Button FourPlayersBtn;
    }
}