namespace Task_Planing.Forms.MenuDialogs
{
    partial class CreateTaskDialog
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
            this.darkTitle1 = new DarkUI.Controls.DarkTitle();
            this.darkTextBox1 = new DarkUI.Controls.DarkTextBox();
            this.darkTitle2 = new DarkUI.Controls.DarkTitle();
            this.darkTitle3 = new DarkUI.Controls.DarkTitle();
            this.Normal_radiobox = new DarkUI.Controls.DarkRadioButton();
            this.Hight_radiobox = new DarkUI.Controls.DarkRadioButton();
            this.Low_radiobox = new DarkUI.Controls.DarkRadioButton();
            this.ok_bt = new DarkUI.Controls.DarkButton();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // darkTitle1
            // 
            this.darkTitle1.AutoSize = true;
            this.darkTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTitle1.Location = new System.Drawing.Point(13, 13);
            this.darkTitle1.Name = "darkTitle1";
            this.darkTitle1.Size = new System.Drawing.Size(80, 17);
            this.darkTitle1.TabIndex = 0;
            this.darkTitle1.Text = "Task Name";
            // 
            // darkTextBox1
            // 
            this.darkTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox1.Location = new System.Drawing.Point(100, 13);
            this.darkTextBox1.Name = "darkTextBox1";
            this.darkTextBox1.Size = new System.Drawing.Size(169, 23);
            this.darkTextBox1.TabIndex = 1;
            // 
            // darkTitle2
            // 
            this.darkTitle2.AutoSize = true;
            this.darkTitle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTitle2.Location = new System.Drawing.Point(12, 55);
            this.darkTitle2.Name = "darkTitle2";
            this.darkTitle2.Size = new System.Drawing.Size(38, 17);
            this.darkTitle2.TabIndex = 2;
            this.darkTitle2.Text = "Date";
            // 
            // darkTitle3
            // 
            this.darkTitle3.AutoSize = true;
            this.darkTitle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTitle3.Location = new System.Drawing.Point(12, 98);
            this.darkTitle3.Name = "darkTitle3";
            this.darkTitle3.Size = new System.Drawing.Size(63, 17);
            this.darkTitle3.TabIndex = 4;
            this.darkTitle3.Text = "Prioritize";
            // 
            // Normal_radiobox
            // 
            this.Normal_radiobox.AutoSize = true;
            this.Normal_radiobox.Location = new System.Drawing.Point(99, 98);
            this.Normal_radiobox.Name = "Normal_radiobox";
            this.Normal_radiobox.Size = new System.Drawing.Size(58, 17);
            this.Normal_radiobox.TabIndex = 5;
            this.Normal_radiobox.TabStop = true;
            this.Normal_radiobox.Text = "Normal";
            // 
            // Hight_radiobox
            // 
            this.Hight_radiobox.AutoSize = true;
            this.Hight_radiobox.Location = new System.Drawing.Point(178, 98);
            this.Hight_radiobox.Name = "Hight_radiobox";
            this.Hight_radiobox.Size = new System.Drawing.Size(50, 17);
            this.Hight_radiobox.TabIndex = 6;
            this.Hight_radiobox.TabStop = true;
            this.Hight_radiobox.Text = "Hight";
            // 
            // Low_radiobox
            // 
            this.Low_radiobox.AutoSize = true;
            this.Low_radiobox.Location = new System.Drawing.Point(249, 98);
            this.Low_radiobox.Name = "Low_radiobox";
            this.Low_radiobox.Size = new System.Drawing.Size(45, 17);
            this.Low_radiobox.TabIndex = 7;
            this.Low_radiobox.TabStop = true;
            this.Low_radiobox.Text = "Low";
            // 
            // ok_bt
            // 
            this.ok_bt.AutoSize = true;
            this.ok_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_bt.Location = new System.Drawing.Point(99, 139);
            this.ok_bt.Name = "ok_bt";
            this.ok_bt.Padding = new System.Windows.Forms.Padding(5);
            this.ok_bt.Size = new System.Drawing.Size(105, 37);
            this.ok_bt.TabIndex = 8;
            this.ok_bt.Text = "Ok";
            this.ok_bt.Click += new System.EventHandler(this.ok_bt_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox1.Location = new System.Drawing.Point(99, 55);
            this.maskedTextBox1.Mask = "00/00/0000 90:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(170, 23);
            this.maskedTextBox1.TabIndex = 9;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // CreateTaskDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 203);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.ok_bt);
            this.Controls.Add(this.Low_radiobox);
            this.Controls.Add(this.Hight_radiobox);
            this.Controls.Add(this.Normal_radiobox);
            this.Controls.Add(this.darkTitle3);
            this.Controls.Add(this.darkTitle2);
            this.Controls.Add(this.darkTextBox1);
            this.Controls.Add(this.darkTitle1);
            this.Name = "CreateTaskDialog";
            this.Text = "CreateTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTitle darkTitle1;
        private DarkUI.Controls.DarkTitle darkTitle2;
        private DarkUI.Controls.DarkTitle darkTitle3;
        private DarkUI.Controls.DarkButton ok_bt;
        public DarkUI.Controls.DarkTextBox darkTextBox1;
        public DarkUI.Controls.DarkRadioButton Normal_radiobox;
        public DarkUI.Controls.DarkRadioButton Hight_radiobox;
        public DarkUI.Controls.DarkRadioButton Low_radiobox;
        public System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}