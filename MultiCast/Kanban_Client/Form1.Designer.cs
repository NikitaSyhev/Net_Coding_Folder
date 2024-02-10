namespace Kanban_client
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
            this.cb_business = new System.Windows.Forms.CheckBox();
            this.cb_News = new System.Windows.Forms.CheckBox();
            this.cb_Teammates = new System.Windows.Forms.CheckBox();
            this.cb_Alarm = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(20, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 624);
            this.textBox1.TabIndex = 0;
            // 
            // cb_business
            // 
            this.cb_business.AutoSize = true;
            this.cb_business.Location = new System.Drawing.Point(578, 177);
            this.cb_business.Name = "cb_business";
            this.cb_business.Size = new System.Drawing.Size(100, 24);
            this.cb_business.TabIndex = 1;
            this.cb_business.Text = "Business";
            this.cb_business.UseVisualStyleBackColor = true;
            this.cb_business.CheckedChanged += new System.EventHandler(this.cb_News_CheckedChanged);
            // 
            // cb_News
            // 
            this.cb_News.AutoSize = true;
            this.cb_News.Location = new System.Drawing.Point(578, 120);
            this.cb_News.Name = "cb_News";
            this.cb_News.Size = new System.Drawing.Size(74, 24);
            this.cb_News.TabIndex = 2;
            this.cb_News.Text = "News";
            this.cb_News.UseVisualStyleBackColor = true;
            this.cb_News.CheckedChanged += new System.EventHandler(this.cb_News_CheckedChanged);
            // 
            // cb_Teammates
            // 
            this.cb_Teammates.AutoSize = true;
            this.cb_Teammates.Location = new System.Drawing.Point(578, 243);
            this.cb_Teammates.Name = "cb_Teammates";
            this.cb_Teammates.Size = new System.Drawing.Size(119, 24);
            this.cb_Teammates.TabIndex = 3;
            this.cb_Teammates.Text = "Teammates";
            this.cb_Teammates.UseVisualStyleBackColor = true;
            this.cb_Teammates.CheckedChanged += new System.EventHandler(this.cb_News_CheckedChanged);
            // 
            // cb_Alarm
            // 
            this.cb_Alarm.AutoSize = true;
            this.cb_Alarm.Location = new System.Drawing.Point(578, 302);
            this.cb_Alarm.Name = "cb_Alarm";
            this.cb_Alarm.Size = new System.Drawing.Size(114, 36);
            this.cb_Alarm.TabIndex = 4;
            this.cb_Alarm.Text = "Alarm";
            this.cb_Alarm.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 692);
            this.Controls.Add(this.cb_Alarm);
            this.Controls.Add(this.cb_Teammates);
            this.Controls.Add(this.cb_News);
            this.Controls.Add(this.cb_business);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cb_business;
        private System.Windows.Forms.CheckBox cb_News;
        private System.Windows.Forms.CheckBox cb_Teammates;
        private System.Windows.Forms.CheckBox cb_Alarm;
    }
}

