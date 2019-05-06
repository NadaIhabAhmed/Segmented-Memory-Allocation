namespace Memory_Allocation
{
    partial class Form5
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
            this.compact = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.processid = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.deallocate = new System.Windows.Forms.Button();
            this.newprocess = new System.Windows.Forms.RadioButton();
            this.oldprocess = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // compact
            // 
            this.compact.Location = new System.Drawing.Point(496, 669);
            this.compact.Name = "compact";
            this.compact.Size = new System.Drawing.Size(178, 45);
            this.compact.TabIndex = 17;
            this.compact.Text = "Compact";
            this.compact.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.processid);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.deallocate);
            this.groupBox2.Controls.Add(this.newprocess);
            this.groupBox2.Controls.Add(this.oldprocess);
            this.groupBox2.Location = new System.Drawing.Point(50, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 132);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deallocation";
            // 
            // processid
            // 
            this.processid.AutoSize = true;
            this.processid.Location = new System.Drawing.Point(34, 99);
            this.processid.Name = "processid";
            this.processid.Size = new System.Drawing.Size(88, 17);
            this.processid.TabIndex = 13;
            this.processid.Text = "Process ID : ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(195, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 22);
            this.textBox2.TabIndex = 11;
            // 
            // deallocate
            // 
            this.deallocate.Location = new System.Drawing.Point(384, 51);
            this.deallocate.Name = "deallocate";
            this.deallocate.Size = new System.Drawing.Size(178, 46);
            this.deallocate.TabIndex = 12;
            this.deallocate.Text = "Deallocate";
            this.deallocate.UseVisualStyleBackColor = true;
            // 
            // newprocess
            // 
            this.newprocess.AutoSize = true;
            this.newprocess.Location = new System.Drawing.Point(34, 51);
            this.newprocess.Name = "newprocess";
            this.newprocess.Size = new System.Drawing.Size(111, 21);
            this.newprocess.TabIndex = 1;
            this.newprocess.TabStop = true;
            this.newprocess.Text = "New Process";
            this.newprocess.UseVisualStyleBackColor = true;
            // 
            // oldprocess
            // 
            this.oldprocess.AutoSize = true;
            this.oldprocess.Location = new System.Drawing.Point(34, 24);
            this.oldprocess.Name = "oldprocess";
            this.oldprocess.Size = new System.Drawing.Size(106, 21);
            this.oldprocess.TabIndex = 0;
            this.oldprocess.TabStop = true;
            this.oldprocess.Text = "Old Process";
            this.oldprocess.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 396);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "View memory";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(246, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Number of segments :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 81);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(624, 208);
            this.dataGridView1.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(50, 330);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 42);
            this.button4.TabIndex = 20;
            this.button4.Text = "first fit";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(202, 330);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 42);
            this.button3.TabIndex = 21;
            this.button3.Text = "best fit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(360, 330);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 42);
            this.button5.TabIndex = 22;
            this.button5.Text = "worst fit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 764);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.compact);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compact;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label processid;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button deallocate;
        private System.Windows.Forms.RadioButton newprocess;
        private System.Windows.Forms.RadioButton oldprocess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
    }
}