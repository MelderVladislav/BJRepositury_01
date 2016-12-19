namespace BlackJack
{
    partial class SignUp
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
            this.btnSignUp = new System.Windows.Forms.Button();
            this.passwordConfirm = new System.Windows.Forms.TextBox();
            this.logIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTrue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(80, 201);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(138, 28);
            this.btnSignUp.TabIndex = 0;
            this.btnSignUp.Text = "Зарегистироваться";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // passwordConfirm
            // 
            this.passwordConfirm.Location = new System.Drawing.Point(51, 162);
            this.passwordConfirm.Name = "passwordConfirm";
            this.passwordConfirm.PasswordChar = '*';
            this.passwordConfirm.Size = new System.Drawing.Size(198, 20);
            this.passwordConfirm.TabIndex = 1;
            // 
            // logIn
            // 
            this.logIn.Location = new System.Drawing.Point(51, 51);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(198, 20);
            this.logIn.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // passwordTrue
            // 
            this.passwordTrue.Location = new System.Drawing.Point(51, 110);
            this.passwordTrue.Name = "passwordTrue";
            this.passwordTrue.PasswordChar = '*';
            this.passwordTrue.Size = new System.Drawing.Size(198, 20);
            this.passwordTrue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Подтвердите пароль";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordTrue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logIn);
            this.Controls.Add(this.passwordConfirm);
            this.Controls.Add(this.btnSignUp);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox passwordConfirm;
        private System.Windows.Forms.TextBox logIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTrue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}