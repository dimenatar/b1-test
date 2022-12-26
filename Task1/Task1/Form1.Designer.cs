namespace Task1
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
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.databaseValue = new System.Windows.Forms.TextBox();
            this.tableValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate 100 files in directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Unite files";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(412, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "symbols";
            // 
            // serverValue
            // 
            this.serverValue.Location = new System.Drawing.Point(653, 44);
            this.serverValue.Name = "serverValue";
            this.serverValue.Size = new System.Drawing.Size(116, 23);
            this.serverValue.TabIndex = 2;
            this.serverValue.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(653, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "server";
            // 
            // portValue
            // 
            this.portValue.Location = new System.Drawing.Point(653, 92);
            this.portValue.Name = "portValue";
            this.portValue.Size = new System.Drawing.Size(116, 23);
            this.portValue.TabIndex = 2;
            this.portValue.Text = "3306";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "port";
            // 
            // usernameValue
            // 
            this.usernameValue.Location = new System.Drawing.Point(653, 147);
            this.usernameValue.Name = "usernameValue";
            this.usernameValue.Size = new System.Drawing.Size(116, 23);
            this.usernameValue.TabIndex = 2;
            this.usernameValue.Text = "root";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(653, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "username";
            // 
            // passwordValue
            // 
            this.passwordValue.Location = new System.Drawing.Point(653, 202);
            this.passwordValue.Name = "passwordValue";
            this.passwordValue.Size = new System.Drawing.Size(116, 23);
            this.passwordValue.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "password";
            // 
            // databaseValue
            // 
            this.databaseValue.Location = new System.Drawing.Point(786, 44);
            this.databaseValue.Name = "databaseValue";
            this.databaseValue.Size = new System.Drawing.Size(116, 23);
            this.databaseValue.TabIndex = 2;
            this.databaseValue.Text = "task1";
            // 
            // tableValue
            // 
            this.tableValue.Location = new System.Drawing.Point(786, 92);
            this.tableValue.Name = "tableValue";
            this.tableValue.Size = new System.Drawing.Size(116, 23);
            this.tableValue.TabIndex = 2;
            this.tableValue.Text = "task1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(786, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "database";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(786, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "table";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(653, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Send files to db";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 334);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableValue);
            this.Controls.Add(this.databaseValue);
            this.Controls.Add(this.passwordValue);
            this.Controls.Add(this.usernameValue);
            this.Controls.Add(this.portValue);
            this.Controls.Add(this.serverValue);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private SaveFileDialog saveFileDialog1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private TextBox serverValue;
        private Label label2;
        private TextBox portValue;
        private Label label3;
        private TextBox usernameValue;
        private Label label4;
        private TextBox passwordValue;
        private Label label5;
        private TextBox databaseValue;
        private TextBox tableValue;
        private Label label6;
        private Label label7;
        private Button button3;
    }
}