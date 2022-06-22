namespace ContourSearch
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SourcePictureBox = new System.Windows.Forms.PictureBox();
            this.OnlyContour = new System.Windows.Forms.PictureBox();
            this.labelBar = new System.Windows.Forms.Label();
            this.trackUncertaintyBar = new System.Windows.Forms.TrackBar();
            this.labelFon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlyContour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackUncertaintyBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SourcePictureBox
            // 
            this.SourcePictureBox.Location = new System.Drawing.Point(29, 38);
            this.SourcePictureBox.Name = "SourcePictureBox";
            this.SourcePictureBox.Size = new System.Drawing.Size(400, 300);
            this.SourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SourcePictureBox.TabIndex = 1;
            this.SourcePictureBox.TabStop = false;
            // 
            // OnlyContour
            // 
            this.OnlyContour.Location = new System.Drawing.Point(512, 38);
            this.OnlyContour.Name = "OnlyContour";
            this.OnlyContour.Size = new System.Drawing.Size(400, 300);
            this.OnlyContour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OnlyContour.TabIndex = 2;
            this.OnlyContour.TabStop = false;
            this.OnlyContour.Click += new System.EventHandler(this.OnlyContour_Click);
            // 
            // labelBar
            // 
            this.labelBar.AutoSize = true;
            this.labelBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.labelBar.ForeColor = System.Drawing.Color.LightSlateGray;
            this.labelBar.Location = new System.Drawing.Point(465, 375);
            this.labelBar.MaximumSize = new System.Drawing.Size(400, 3000);
            this.labelBar.MinimumSize = new System.Drawing.Size(20, 18);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(41, 29);
            this.labelBar.TabIndex = 3;
            this.labelBar.Text = "30";
            this.labelBar.Click += new System.EventHandler(this.Form1_Load);
            // 
            // trackUncertaintyBar
            // 
            this.trackUncertaintyBar.Location = new System.Drawing.Point(512, 375);
            this.trackUncertaintyBar.Maximum = 100;
            this.trackUncertaintyBar.Minimum = 5;
            this.trackUncertaintyBar.Name = "trackUncertaintyBar";
            this.trackUncertaintyBar.Size = new System.Drawing.Size(400, 45);
            this.trackUncertaintyBar.TabIndex = 4;
            this.trackUncertaintyBar.Value = 30;
            this.trackUncertaintyBar.Scroll += new System.EventHandler(this.trackUncertaintyBar_Scroll);
            // 
            // labelFon
            // 
            this.labelFon.AutoSize = true;
            this.labelFon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelFon.Location = new System.Drawing.Point(112, 355);
            this.labelFon.Name = "labelFon";
            this.labelFon.Size = new System.Drawing.Size(214, 20);
            this.labelFon.TabIndex = 5;
            this.labelFon.Text = "Фоном является ничего";
            this.labelFon.Click += new System.EventHandler(this.labelFon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(947, 441);
            this.Controls.Add(this.labelFon);
            this.Controls.Add(this.trackUncertaintyBar);
            this.Controls.Add(this.labelBar);
            this.Controls.Add(this.OnlyContour);
            this.Controls.Add(this.SourcePictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlyContour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackUncertaintyBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox SourcePictureBox;
        private System.Windows.Forms.PictureBox OnlyContour;
        private System.Windows.Forms.Label labelBar;
        private System.Windows.Forms.TrackBar trackUncertaintyBar;
        private System.Windows.Forms.Label labelFon;
    }
}

