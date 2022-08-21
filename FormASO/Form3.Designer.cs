namespace WindowsFormsApp10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.musteri_kayit = new System.Windows.Forms.Button();
            this.servis_kayit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // musteri_kayit
            // 
            this.musteri_kayit.BackColor = System.Drawing.Color.Transparent;
            this.musteri_kayit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.musteri_kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musteri_kayit.Location = new System.Drawing.Point(200, 392);
            this.musteri_kayit.Margin = new System.Windows.Forms.Padding(2);
            this.musteri_kayit.Name = "musteri_kayit";
            this.musteri_kayit.Size = new System.Drawing.Size(198, 94);
            this.musteri_kayit.TabIndex = 0;
            this.musteri_kayit.UseVisualStyleBackColor = false;
            this.musteri_kayit.Click += new System.EventHandler(this.yeni_kayit_Click);
            // 
            // servis_kayit
            // 
            this.servis_kayit.BackColor = System.Drawing.Color.Transparent;
            this.servis_kayit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.servis_kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.servis_kayit.Location = new System.Drawing.Point(892, 311);
            this.servis_kayit.Margin = new System.Windows.Forms.Padding(2);
            this.servis_kayit.Name = "servis_kayit";
            this.servis_kayit.Size = new System.Drawing.Size(141, 62);
            this.servis_kayit.TabIndex = 2;
            this.servis_kayit.UseVisualStyleBackColor = false;
            this.servis_kayit.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(912, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 66);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.servis_kayit);
            this.Controls.Add(this.musteri_kayit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G Panel";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button musteri_kayit;
        private System.Windows.Forms.Button servis_kayit;
        private System.Windows.Forms.Button button1;
    }
}