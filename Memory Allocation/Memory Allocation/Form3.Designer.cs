namespace Memory_Allocation
{
    partial class Form3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.worst_fit = new System.Windows.Forms.RadioButton();
            this.best_fit = new System.Windows.Forms.RadioButton();
            this.first_fit = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.deallocate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.processid = new System.Windows.Forms.Label();
            this.newprocess = new System.Windows.Forms.RadioButton();
            this.oldprocess = new System.Windows.Forms.RadioButton();
            this.compact = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 67);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(624, 208);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of segments :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(237, 23);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "View memory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.worst_fit);
            this.groupBox1.Controls.Add(this.best_fit);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.first_fit);
            this.groupBox1.Location = new System.Drawing.Point(41, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 135);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allocation Method ";
            // 
            // worst_fit
            // 
            this.worst_fit.AutoSize = true;
            this.worst_fit.Location = new System.Drawing.Point(34, 98);
            this.worst_fit.Name = "worst_fit";
            this.worst_fit.Size = new System.Drawing.Size(85, 21);
            this.worst_fit.TabIndex = 2;
            this.worst_fit.TabStop = true;
            this.worst_fit.Text = "Worst Fit";
            this.worst_fit.UseVisualStyleBackColor = true;
            this.worst_fit.CheckedChanged += new System.EventHandler(this.worst_fit_CheckedChanged);
            // 
            // best_fit
            // 
            this.best_fit.AutoSize = true;
            this.best_fit.Location = new System.Drawing.Point(33, 65);
            this.best_fit.Name = "best_fit";
            this.best_fit.Size = new System.Drawing.Size(76, 21);
            this.best_fit.TabIndex = 1;
            this.best_fit.TabStop = true;
            this.best_fit.Text = "Best Fit";
            this.best_fit.UseVisualStyleBackColor = true;
            // 
            // first_fit
            // 
            this.first_fit.AutoSize = true;
            this.first_fit.Location = new System.Drawing.Point(34, 36);
            this.first_fit.Name = "first_fit";
            this.first_fit.Size = new System.Drawing.Size(75, 21);
            this.first_fit.TabIndex = 0;
            this.first_fit.TabStop = true;
            this.first_fit.Text = "First Fit";
            this.first_fit.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 94);
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
            this.deallocate.Click += new System.EventHandler(this.deallocate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.processid);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.deallocate);
            this.groupBox2.Controls.Add(this.newprocess);
            this.groupBox2.Controls.Add(this.oldprocess);
            this.groupBox2.Location = new System.Drawing.Point(41, 461);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 132);
            this.groupBox2.TabIndex = 10;
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
            // compact
            // 
            this.compact.Location = new System.Drawing.Point(425, 641);
            this.compact.Name = "compact";
            this.compact.Size = new System.Drawing.Size(178, 45);
            this.compact.TabIndex = 11;
            this.compact.Text = "Compact";
            this.compact.UseVisualStyleBackColor = true;
            this.compact.Click += new System.EventHandler(this.compact_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 641);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 45);
            this.button2.TabIndex = 12;
            this.button2.Text = "new process";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 738);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.compact);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.Text = "Segments";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton worst_fit;
        private System.Windows.Forms.RadioButton best_fit;
        private System.Windows.Forms.RadioButton first_fit;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button deallocate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label processid;
        private System.Windows.Forms.RadioButton newprocess;
        private System.Windows.Forms.RadioButton oldprocess;
        private System.Windows.Forms.Button compact;
        private System.Windows.Forms.Button button2;
    }
}