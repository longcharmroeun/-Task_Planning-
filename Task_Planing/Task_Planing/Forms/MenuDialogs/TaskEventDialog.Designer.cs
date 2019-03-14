namespace Task_Planing.Forms.MenuDialogs
{
    partial class TaskEventDialog
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
            this.Task_Label = new DarkUI.Controls.DarkTitle();
            this.Comment_Label = new DarkUI.Controls.DarkTitle();
            this.darkTitle3 = new DarkUI.Controls.DarkTitle();
            this.Ok_bt = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // darkTitle1
            // 
            this.darkTitle1.AutoSize = true;
            this.darkTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTitle1.Location = new System.Drawing.Point(13, 13);
            this.darkTitle1.Name = "darkTitle1";
            this.darkTitle1.Size = new System.Drawing.Size(102, 22);
            this.darkTitle1.TabIndex = 0;
            this.darkTitle1.Text = "TaskName:";
            // 
            // Task_Label
            // 
            this.Task_Label.AutoSize = true;
            this.Task_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Task_Label.Location = new System.Drawing.Point(121, 13);
            this.Task_Label.Name = "Task_Label";
            this.Task_Label.Size = new System.Drawing.Size(53, 22);
            this.Task_Label.TabIndex = 1;
            this.Task_Label.Text = "None";
            // 
            // Comment_Label
            // 
            this.Comment_Label.AutoSize = true;
            this.Comment_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comment_Label.Location = new System.Drawing.Point(120, 48);
            this.Comment_Label.Name = "Comment_Label";
            this.Comment_Label.Size = new System.Drawing.Size(53, 22);
            this.Comment_Label.TabIndex = 3;
            this.Comment_Label.Text = "None";
            // 
            // darkTitle3
            // 
            this.darkTitle3.AutoSize = true;
            this.darkTitle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTitle3.Location = new System.Drawing.Point(12, 48);
            this.darkTitle3.Name = "darkTitle3";
            this.darkTitle3.Size = new System.Drawing.Size(91, 22);
            this.darkTitle3.TabIndex = 2;
            this.darkTitle3.Text = "Comment:";
            // 
            // Ok_bt
            // 
            this.Ok_bt.AutoSize = true;
            this.Ok_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok_bt.Location = new System.Drawing.Point(70, 91);
            this.Ok_bt.Name = "Ok_bt";
            this.Ok_bt.Padding = new System.Windows.Forms.Padding(5);
            this.Ok_bt.Size = new System.Drawing.Size(127, 42);
            this.Ok_bt.TabIndex = 4;
            this.Ok_bt.Text = "Ok";
            this.Ok_bt.Click += new System.EventHandler(this.Ok_bt_Click);
            // 
            // TaskEventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 168);
            this.Controls.Add(this.Ok_bt);
            this.Controls.Add(this.Comment_Label);
            this.Controls.Add(this.darkTitle3);
            this.Controls.Add(this.Task_Label);
            this.Controls.Add(this.darkTitle1);
            this.Name = "TaskEventDialog";
            this.Text = "TaskEventDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTitle darkTitle1;
        private DarkUI.Controls.DarkTitle Task_Label;
        private DarkUI.Controls.DarkTitle Comment_Label;
        private DarkUI.Controls.DarkTitle darkTitle3;
        private DarkUI.Controls.DarkButton Ok_bt;
    }
}