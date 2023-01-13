
namespace UPI
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIm = new System.Windows.Forms.TextBox();
            this.txtloz = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnregist = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnne = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1730, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1637, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Korisničko ime:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(1637, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lozinka:";
            // 
            // txtIm
            // 
            this.txtIm.Location = new System.Drawing.Point(1641, 189);
            this.txtIm.Name = "txtIm";
            this.txtIm.Size = new System.Drawing.Size(124, 22);
            this.txtIm.TabIndex = 6;
            // 
            // txtloz
            // 
            this.txtloz.Location = new System.Drawing.Point(1641, 282);
            this.txtloz.Name = "txtloz";
            this.txtloz.PasswordChar = '*';
            this.txtloz.Size = new System.Drawing.Size(117, 22);
            this.txtloz.TabIndex = 7;
            this.txtloz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtloz_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1641, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 61);
            this.button1.TabIndex = 8;
            this.button1.Text = "Prijavi se";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1637, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nemate račun:";
            // 
            // btnregist
            // 
            this.btnregist.BackColor = System.Drawing.Color.White;
            this.btnregist.Location = new System.Drawing.Point(1641, 541);
            this.btnregist.Name = "btnregist";
            this.btnregist.Size = new System.Drawing.Size(124, 61);
            this.btnregist.TabIndex = 10;
            this.btnregist.Text = "Registrirajte se";
            this.btnregist.UseVisualStyleBackColor = false;
            this.btnregist.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(1634, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 37);
            this.label4.TabIndex = 11;
            this.label4.Text = "FastFood-Dostava";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-168, -162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1776, 1300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnne
            // 
            this.btnne.BackColor = System.Drawing.Color.White;
            this.btnne.ForeColor = System.Drawing.Color.White;
            this.btnne.Image = ((System.Drawing.Image)(resources.GetObject("btnne.Image")));
            this.btnne.Location = new System.Drawing.Point(1740, 281);
            this.btnne.Name = "btnne";
            this.btnne.Size = new System.Drawing.Size(25, 26);
            this.btnne.TabIndex = 13;
            this.btnne.Text = "button2";
            this.btnne.UseVisualStyleBackColor = false;
            this.btnne.Click += new System.EventHandler(this.button2_Click_3);
            this.btnne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnne_MouseDown);
            this.btnne.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnne_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 721);
            this.Controls.Add(this.btnne);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnregist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtloz);
            this.Controls.Add(this.txtIm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "b";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIm;
        private System.Windows.Forms.TextBox txtloz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnregist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnne;
    }
}

