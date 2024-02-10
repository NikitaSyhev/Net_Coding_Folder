namespace Kanban
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_News_Server = new System.Windows.Forms.CheckBox();
            this.cb_Business_Server = new System.Windows.Forms.CheckBox();
            this.cb_Team_Server = new System.Windows.Forms.CheckBox();
            this.cb_Alarm = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(500, 532);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 105);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_News_Server
            // 
            this.cb_News_Server.AutoSize = true;
            this.cb_News_Server.Location = new System.Drawing.Point(556, 201);
            this.cb_News_Server.Name = "cb_News_Server";
            this.cb_News_Server.Size = new System.Drawing.Size(74, 24);
            this.cb_News_Server.TabIndex = 2;
            this.cb_News_Server.Text = "News";
            this.cb_News_Server.UseVisualStyleBackColor = true;
            this.cb_News_Server.CheckedChanged += new System.EventHandler(this.cb_News_Server_CheckedChanged);
            // 
            // cb_Business_Server
            // 
            this.cb_Business_Server.AutoSize = true;
            this.cb_Business_Server.Location = new System.Drawing.Point(556, 248);
            this.cb_Business_Server.Name = "cb_Business_Server";
            this.cb_Business_Server.Size = new System.Drawing.Size(92, 24);
            this.cb_Business_Server.TabIndex = 3;
            this.cb_Business_Server.Text = "Busines";
            this.cb_Business_Server.UseVisualStyleBackColor = true;
            this.cb_Business_Server.CheckedChanged += new System.EventHandler(this.cb_News_Server_CheckedChanged);
            // 
            // cb_Team_Server
            // 
            this.cb_Team_Server.AutoSize = true;
            this.cb_Team_Server.Location = new System.Drawing.Point(556, 301);
            this.cb_Team_Server.Name = "cb_Team_Server";
            this.cb_Team_Server.Size = new System.Drawing.Size(119, 24);
            this.cb_Team_Server.TabIndex = 4;
            this.cb_Team_Server.Text = "Teammates";
            this.cb_Team_Server.UseVisualStyleBackColor = true;
            this.cb_Team_Server.CheckedChanged += new System.EventHandler(this.cb_News_Server_CheckedChanged);
            // 
            // cb_Alarm
            // 
            this.cb_Alarm.AutoSize = true;
            this.cb_Alarm.Location = new System.Drawing.Point(556, 353);
            this.cb_Alarm.Name = "cb_Alarm";
            this.cb_Alarm.Size = new System.Drawing.Size(76, 24);
            this.cb_Alarm.TabIndex = 5;
            this.cb_Alarm.Text = "Alarm";
            this.cb_Alarm.UseVisualStyleBackColor = true;
            this.cb_Alarm.CheckedChanged += new System.EventHandler(this.cb_News_Server_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 692);
            this.Controls.Add(this.cb_Alarm);
            this.Controls.Add(this.cb_Team_Server);
            this.Controls.Add(this.cb_Business_Server);
            this.Controls.Add(this.cb_News_Server);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cb_News_Server;
        private System.Windows.Forms.CheckBox cb_Business_Server;
        private System.Windows.Forms.CheckBox cb_Team_Server;
        private System.Windows.Forms.CheckBox cb_Alarm;
    }
}

