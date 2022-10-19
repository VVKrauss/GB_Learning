namespace Homework_7_2
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonEnterNumber = new System.Windows.Forms.Button();
            this.labelMainText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGenerateNumber = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(779, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(14, 16);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "?";
            this.labelInfo.Click += new System.EventHandler(this.labelInfo_Click);
            // 
            // buttonEnterNumber
            // 
            this.buttonEnterNumber.Location = new System.Drawing.Point(18, 9);
            this.buttonEnterNumber.Name = "buttonEnterNumber";
            this.buttonEnterNumber.Size = new System.Drawing.Size(749, 37);
            this.buttonEnterNumber.TabIndex = 1;
            this.buttonEnterNumber.Text = "Ввести число";
            this.buttonEnterNumber.UseVisualStyleBackColor = true;
            this.buttonEnterNumber.Visible = false;
            this.buttonEnterNumber.Click += new System.EventHandler(this.buttonEnterNumber_Click);
            // 
            // labelMainText
            // 
            this.labelMainText.AutoSize = true;
            this.labelMainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainText.Location = new System.Drawing.Point(202, 33);
            this.labelMainText.Name = "labelMainText";
            this.labelMainText.Size = new System.Drawing.Size(405, 22);
            this.labelMainText.TabIndex = 2;
            this.labelMainText.Text = "Введённое число больше/меньше загаданного";
            this.labelMainText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMainText.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonEnterNumber);
            this.panel1.Location = new System.Drawing.Point(12, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 55);
            this.panel1.TabIndex = 3;
            // 
            // buttonGenerateNumber
            // 
            this.buttonGenerateNumber.Location = new System.Drawing.Point(278, 67);
            this.buttonGenerateNumber.Name = "buttonGenerateNumber";
            this.buttonGenerateNumber.Size = new System.Drawing.Size(257, 65);
            this.buttonGenerateNumber.TabIndex = 4;
            this.buttonGenerateNumber.Text = "Загадать число";
            this.buttonGenerateNumber.UseVisualStyleBackColor = true;
            this.buttonGenerateNumber.Click += new System.EventHandler(this.buttonGenerateNumber_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 196);
            this.Controls.Add(this.labelMainText);
            this.Controls.Add(this.buttonGenerateNumber);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelInfo);
            this.Name = "Form1";
            this.Text = "Угадай число";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonEnterNumber;
        private System.Windows.Forms.Label labelMainText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGenerateNumber;
    }
}

