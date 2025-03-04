namespace TimeKeeper
{
    partial class CompareFinger
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
            this.txtIPx = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtNumber1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIPx
            // 
            this.txtIPx.AutoSize = true;
            this.txtIPx.Location = new System.Drawing.Point(29, 23);
            this.txtIPx.Name = "txtIPx";
            this.txtIPx.Size = new System.Drawing.Size(24, 20);
            this.txtIPx.TabIndex = 0;
            this.txtIPx.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(93, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(112, 22);
            this.txtIP.TabIndex = 1;
            // 
            // txtNumber1
            // 
            this.txtNumber1.Location = new System.Drawing.Point(305, 20);
            this.txtNumber1.Name = "txtNumber1";
            this.txtNumber1.Size = new System.Drawing.Size(112, 22);
            this.txtNumber1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // txtNumber2
            // 
            this.txtNumber2.Location = new System.Drawing.Point(510, 20);
            this.txtNumber2.Name = "txtNumber2";
            this.txtNumber2.Size = new System.Drawing.Size(112, 22);
            this.txtNumber2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompareFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 109);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNumber2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtIPx);
            this.Name = "CompareFinger";
            this.Text = "CompareFinger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtIPx;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtNumber1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumber2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}