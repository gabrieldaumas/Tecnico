namespace Jogo
{
    partial class Fase2
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.FraseRimaLabel = new System.Windows.Forms.Label();
            this.PontosBox = new System.Windows.Forms.PictureBox();
            this.IntervaloLabel = new System.Windows.Forms.Label();
            this.iDFraseLabel = new System.Windows.Forms.Label();
            this.ContadorLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.ProximaFaseButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PontosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProximaFaseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::Jogo.Properties.Resources.close;
            this.button1.Location = new System.Drawing.Point(956, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 50);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // FraseRimaLabel
            // 
            this.FraseRimaLabel.AutoSize = true;
            this.FraseRimaLabel.BackColor = System.Drawing.Color.Transparent;
            this.FraseRimaLabel.Font = new System.Drawing.Font("Western Bang Bang", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FraseRimaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FraseRimaLabel.Location = new System.Drawing.Point(321, 9);
            this.FraseRimaLabel.Name = "FraseRimaLabel";
            this.FraseRimaLabel.Size = new System.Drawing.Size(396, 67);
            this.FraseRimaLabel.TabIndex = 18;
            this.FraseRimaLabel.Text = "Camarão Rima com?";
            // 
            // PontosBox
            // 
            this.PontosBox.BackColor = System.Drawing.Color.Transparent;
            this.PontosBox.Image = global::Jogo.Properties.Resources.Pontos;
            this.PontosBox.Location = new System.Drawing.Point(771, 512);
            this.PontosBox.Name = "PontosBox";
            this.PontosBox.Size = new System.Drawing.Size(204, 48);
            this.PontosBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PontosBox.TabIndex = 17;
            this.PontosBox.TabStop = false;
            // 
            // IntervaloLabel
            // 
            this.IntervaloLabel.AutoSize = true;
            this.IntervaloLabel.BackColor = System.Drawing.Color.Transparent;
            this.IntervaloLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.IntervaloLabel.Location = new System.Drawing.Point(55, 531);
            this.IntervaloLabel.Name = "IntervaloLabel";
            this.IntervaloLabel.Size = new System.Drawing.Size(35, 13);
            this.IntervaloLabel.TabIndex = 14;
            this.IntervaloLabel.Text = "label3";
            // 
            // iDFraseLabel
            // 
            this.iDFraseLabel.AutoSize = true;
            this.iDFraseLabel.BackColor = System.Drawing.Color.Transparent;
            this.iDFraseLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iDFraseLabel.Location = new System.Drawing.Point(302, 26);
            this.iDFraseLabel.Name = "iDFraseLabel";
            this.iDFraseLabel.Size = new System.Drawing.Size(13, 13);
            this.iDFraseLabel.TabIndex = 13;
            this.iDFraseLabel.Text = "1";
            this.iDFraseLabel.UseMnemonic = false;
            // 
            // ContadorLabel
            // 
            this.ContadorLabel.AutoSize = true;
            this.ContadorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ContadorLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ContadorLabel.Location = new System.Drawing.Point(692, 531);
            this.ContadorLabel.Name = "ContadorLabel";
            this.ContadorLabel.Size = new System.Drawing.Size(25, 13);
            this.ContadorLabel.TabIndex = 12;
            this.ContadorLabel.Text = "100";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick_1);
            // 
            // timer4
            // 
            // 
            // ProximaFaseButton
            // 
            this.ProximaFaseButton.BackColor = System.Drawing.Color.Transparent;
            this.ProximaFaseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProximaFaseButton.Image = global::Jogo.Properties.Resources.Tente_Novamente_2;
            this.ProximaFaseButton.Location = new System.Drawing.Point(305, 405);
            this.ProximaFaseButton.Name = "ProximaFaseButton";
            this.ProximaFaseButton.Size = new System.Drawing.Size(426, 97);
            this.ProximaFaseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ProximaFaseButton.TabIndex = 20;
            this.ProximaFaseButton.TabStop = false;
            this.ProximaFaseButton.Visible = false;
            this.ProximaFaseButton.Click += new System.EventHandler(this.ProximaFaseButton_Click);
            // 
            // Fase2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Jogo.Properties.Resources.floresta2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1017, 572);
            this.Controls.Add(this.ProximaFaseButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FraseRimaLabel);
            this.Controls.Add(this.PontosBox);
            this.Controls.Add(this.IntervaloLabel);
            this.Controls.Add(this.iDFraseLabel);
            this.Controls.Add(this.ContadorLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fase2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fase2";
            this.Load += new System.EventHandler(this.Fase2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PontosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProximaFaseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FraseRimaLabel;
        private System.Windows.Forms.PictureBox PontosBox;
        private System.Windows.Forms.Label IntervaloLabel;
        private System.Windows.Forms.Label iDFraseLabel;
        private System.Windows.Forms.Label ContadorLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.PictureBox ProximaFaseButton;
    }
}