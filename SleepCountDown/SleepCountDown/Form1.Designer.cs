namespace SleepCountDown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sleepRadioButton = new System.Windows.Forms.RadioButton();
            this.hibernateRadioButton = new System.Windows.Forms.RadioButton();
            this.startStopButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // sleepRadioButton
            // 
            this.sleepRadioButton.AutoSize = true;
            this.sleepRadioButton.Checked = true;
            this.sleepRadioButton.Location = new System.Drawing.Point(24, 90);
            this.sleepRadioButton.Name = "sleepRadioButton";
            this.sleepRadioButton.Size = new System.Drawing.Size(65, 21);
            this.sleepRadioButton.TabIndex = 3;
            this.sleepRadioButton.TabStop = true;
            this.sleepRadioButton.Text = "Sleep";
            this.sleepRadioButton.UseVisualStyleBackColor = true;
            this.sleepRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // hibernateRadioButton
            // 
            this.hibernateRadioButton.AutoSize = true;
            this.hibernateRadioButton.Location = new System.Drawing.Point(24, 117);
            this.hibernateRadioButton.Name = "hibernateRadioButton";
            this.hibernateRadioButton.Size = new System.Drawing.Size(91, 21);
            this.hibernateRadioButton.TabIndex = 4;
            this.hibernateRadioButton.Text = "Hibernate";
            this.hibernateRadioButton.UseVisualStyleBackColor = true;
            this.hibernateRadioButton.CheckedChanged += new System.EventHandler(this.hibernateRadioButton_CheckedChanged);
            // 
            // startStopButton
            // 
            this.startStopButton.BackgroundImage = global::SleepCountDown.Properties.Resources.Haruna;
            this.startStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startStopButton.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startStopButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startStopButton.Location = new System.Drawing.Point(133, 90);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(112, 48);
            this.startStopButton.TabIndex = 5;
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(37, 35);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(202, 22);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SleepCountDown.Properties.Resources.FormBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(265, 163);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.hibernateRadioButton);
            this.Controls.Add(this.sleepRadioButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(283, 210);
            this.MinimumSize = new System.Drawing.Size(283, 210);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SLEEP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton sleepRadioButton;
        private System.Windows.Forms.RadioButton hibernateRadioButton;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

