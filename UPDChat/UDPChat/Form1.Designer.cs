namespace UDPChat
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
            this.nuPort = new System.Windows.Forms.NumericUpDown();
            this.txtAllMess = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tb_IP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuPort)).BeginInit();
            this.SuspendLayout();
            // 
            // nuPort
            // 
            this.nuPort.Location = new System.Drawing.Point(259, 22);
            this.nuPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nuPort.Name = "nuPort";
            this.nuPort.Size = new System.Drawing.Size(80, 26);
            this.nuPort.TabIndex = 1;
            this.nuPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // txtAllMess
            // 
            this.txtAllMess.Location = new System.Drawing.Point(40, 70);
            this.txtAllMess.Multiline = true;
            this.txtAllMess.Name = "txtAllMess";
            this.txtAllMess.Size = new System.Drawing.Size(716, 314);
            this.txtAllMess.TabIndex = 2;
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(40, 399);
            this.txtMes.Multiline = true;
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(580, 39);
            this.txtMes.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(637, 399);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(119, 39);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(383, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(137, 26);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(40, 21);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(156, 26);
            this.tb_IP.TabIndex = 6;
            this.tb_IP.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAllMess);
            this.Controls.Add(this.nuPort);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nuPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nuPort;
        private System.Windows.Forms.TextBox txtAllMess;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tb_IP;
    }
}

