namespace Jogo
{
    partial class AdicionarFrase
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.temabox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.frase1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.frase2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.frase3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tag = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Jogo.Properties.Resources.title;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(591, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // temabox
            // 
            this.temabox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.temabox.FormattingEnabled = true;
            this.temabox.Items.AddRange(new object[] {
            "Selecione um Tema"});
            this.temabox.Location = new System.Drawing.Point(212, 103);
            this.temabox.Name = "temabox";
            this.temabox.Size = new System.Drawing.Size(164, 21);
            this.temabox.TabIndex = 30;
            this.temabox.SelectedIndexChanged += new System.EventHandler(this.temabox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(171, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Western Bang Bang", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Frase 1:";
            // 
            // frase1
            // 
            this.frase1.Location = new System.Drawing.Point(197, 171);
            this.frase1.Name = "frase1";
            this.frase1.Size = new System.Drawing.Size(204, 20);
            this.frase1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Western Bang Bang", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Frase 2:";
            // 
            // frase2
            // 
            this.frase2.Location = new System.Drawing.Point(197, 208);
            this.frase2.Name = "frase2";
            this.frase2.Size = new System.Drawing.Size(204, 20);
            this.frase2.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Western Bang Bang", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(130, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Frase 3:";
            // 
            // frase3
            // 
            this.frase3.Location = new System.Drawing.Point(197, 244);
            this.frase3.Name = "frase3";
            this.frase3.Size = new System.Drawing.Size(204, 20);
            this.frase3.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Adicionar Frases";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(173, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tag";
            this.label5.Visible = false;
            // 
            // tag
            // 
            this.tag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tag.FormattingEnabled = true;
            this.tag.Items.AddRange(new object[] {
            "Seleciona uma Rima"});
            this.tag.Location = new System.Drawing.Point(212, 130);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(164, 21);
            this.tag.TabIndex = 39;
            this.tag.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Voltar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdicionarFrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Jogo.Properties.Resources.sunrise_desert_cactus_vector_illustration;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.frase3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frase2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.frase1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.temabox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdicionarFrase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox temabox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox frase1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox frase2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox frase3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tag;
        private System.Windows.Forms.Button button2;
    }
}