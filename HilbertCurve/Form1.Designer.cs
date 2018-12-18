using System.Drawing;

namespace HilbertCurve
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.NormalButton = new System.Windows.Forms.RadioButton();
            this.RGBButton = new System.Windows.Forms.RadioButton();
            this.RainbowButton = new System.Windows.Forms.RadioButton();
            this.OtherRainbowButton = new System.Windows.Forms.RadioButton();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 152);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(653, 294);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 5;
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(653, 345);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(104, 45);
            this.trackBar4.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(589, 294);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 13);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Spacing";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(589, 345);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.Size = new System.Drawing.Size(58, 13);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Iteration";
            // 
            // NormalButton
            // 
            this.NormalButton.AutoSize = true;
            this.NormalButton.Checked = true;
            this.NormalButton.Location = new System.Drawing.Point(661, 61);
            this.NormalButton.Name = "NormalButton";
            this.NormalButton.Size = new System.Drawing.Size(58, 17);
            this.NormalButton.TabIndex = 11;
            this.NormalButton.TabStop = true;
            this.NormalButton.Text = "Normal";
            this.NormalButton.UseVisualStyleBackColor = true;
            // 
            // RGBButton
            // 
            this.RGBButton.AutoSize = true;
            this.RGBButton.Location = new System.Drawing.Point(661, 84);
            this.RGBButton.Name = "RGBButton";
            this.RGBButton.Size = new System.Drawing.Size(48, 17);
            this.RGBButton.TabIndex = 12;
            this.RGBButton.TabStop = true;
            this.RGBButton.Text = "RGB";
            this.RGBButton.UseVisualStyleBackColor = true;
            // 
            // RainbowButton
            // 
            this.RainbowButton.AutoSize = true;
            this.RainbowButton.Location = new System.Drawing.Point(661, 107);
            this.RainbowButton.Name = "RainbowButton";
            this.RainbowButton.Size = new System.Drawing.Size(67, 17);
            this.RainbowButton.TabIndex = 13;
            this.RainbowButton.TabStop = true;
            this.RainbowButton.Text = "Rainbow";
            this.RainbowButton.UseVisualStyleBackColor = true;
            // 
            // OtherRainbowButton
            // 
            this.OtherRainbowButton.AutoSize = true;
            this.OtherRainbowButton.Location = new System.Drawing.Point(661, 130);
            this.OtherRainbowButton.Name = "OtherRainbowButton";
            this.OtherRainbowButton.Size = new System.Drawing.Size(96, 17);
            this.OtherRainbowButton.TabIndex = 14;
            this.OtherRainbowButton.TabStop = true;
            this.OtherRainbowButton.Text = "Other Rainbow";
            this.OtherRainbowButton.UseVisualStyleBackColor = true;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(653, 396);
            this.trackBar2.Maximum = 4;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 15;
            this.trackBar2.Value = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(589, 396);
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox3.Size = new System.Drawing.Size(58, 13);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "Thickness";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(653, 217);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 20);
            this.textBox4.TabIndex = 17;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(653, 243);
            this.trackBar3.Maximum = 256;
            this.trackBar3.Minimum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(104, 45);
            this.trackBar3.TabIndex = 18;
            this.trackBar3.Value = 1;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox5.Location = new System.Drawing.Point(589, 243);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(58, 13);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Threads";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(653, 191);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(104, 20);
            this.textBox6.TabIndex = 20;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox7.Location = new System.Drawing.Point(555, 217);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(77, 13);
            this.textBox7.TabIndex = 21;
            this.textBox7.Text = "Time To Draw";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox8.Location = new System.Drawing.Point(555, 191);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(92, 13);
            this.textBox8.TabIndex = 22;
            this.textBox8.Text = "Time To Calculate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 453);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.OtherRainbowButton);
            this.Controls.Add(this.RainbowButton);
            this.Controls.Add(this.RGBButton);
            this.Controls.Add(this.NormalButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "HilbertCurve";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton NormalButton;
        private System.Windows.Forms.RadioButton RGBButton;
        private System.Windows.Forms.RadioButton RainbowButton;
        private System.Windows.Forms.RadioButton OtherRainbowButton;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}

