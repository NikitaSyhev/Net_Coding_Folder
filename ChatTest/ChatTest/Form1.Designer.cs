namespace ChatTest
{
    partial class Form1
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
            this.PortText = new System.Windows.Forms.NumericUpDown();
            this.IPText = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MsgText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PortText)).BeginInit();
            this.SuspendLayout();
            // 
            // PortText
            // 
            this.PortText.Location = new System.Drawing.Point(189, 1);
            this.PortText.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(120, 26);
            this.PortText.TabIndex = 0;
            this.PortText.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // IPText
            // 
            this.IPText.Culture = new System.Globalization.CultureInfo("en-GB");
            this.IPText.Location = new System.Drawing.Point(3, 0);
            this.IPText.Mask = "###.###.###.###";
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(180, 26);
            this.IPText.TabIndex = 1;
            this.IPText.ValidatingType = typeof(int);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 52);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 319);
            this.textBox1.TabIndex = 3;
            // 
            // MsgText
            // 
            this.MsgText.Location = new System.Drawing.Point(12, 396);
            this.MsgText.Name = "MsgText";
            this.MsgText.Size = new System.Drawing.Size(398, 26);
            this.MsgText.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(449, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MsgText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IPText);
            this.Controls.Add(this.PortText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PortText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PortText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox MsgText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox IPText;
    }
}

