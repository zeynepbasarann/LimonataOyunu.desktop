
namespace LimonataOyunu.desktop
{
    partial class AnaForm
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
            this.AdLabel = new System.Windows.Forms.Label();
            this.AdetLabel = new System.Windows.Forms.Label();
            this.SureLabel = new System.Windows.Forms.Label();
            this.AdtextBox = new System.Windows.Forms.TextBox();
            this.AdettextBox = new System.Windows.Forms.TextBox();
            this.SuretextBox = new System.Windows.Forms.TextBox();
            this.ScorButton = new System.Windows.Forms.Button();
            this.BilgiButton = new System.Windows.Forms.Button();
            this.Baslamabutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AdLabel
            // 
            this.AdLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.AdLabel.Location = new System.Drawing.Point(231, 117);
            this.AdLabel.Name = "AdLabel";
            this.AdLabel.Size = new System.Drawing.Size(106, 31);
            this.AdLabel.TabIndex = 3;
            this.AdLabel.Text = "ADINIZ:";
            // 
            // AdetLabel
            // 
            this.AdetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.AdetLabel.Location = new System.Drawing.Point(231, 168);
            this.AdetLabel.Name = "AdetLabel";
            this.AdetLabel.Size = new System.Drawing.Size(186, 32);
            this.AdetLabel.TabIndex = 4;
            this.AdetLabel.Text = "SİPARİŞ ADEDİ:";
            // 
            // SureLabel
            // 
            this.SureLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.SureLabel.Location = new System.Drawing.Point(231, 220);
            this.SureLabel.Name = "SureLabel";
            this.SureLabel.Size = new System.Drawing.Size(76, 32);
            this.SureLabel.TabIndex = 5;
            this.SureLabel.Text = "SÜRE:";
            // 
            // AdtextBox
            // 
            this.AdtextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.AdtextBox.Location = new System.Drawing.Point(423, 117);
            this.AdtextBox.Multiline = true;
            this.AdtextBox.Name = "AdtextBox";
            this.AdtextBox.Size = new System.Drawing.Size(113, 31);
            this.AdtextBox.TabIndex = 6;
            // 
            // AdettextBox
            // 
            this.AdettextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdettextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.AdettextBox.Location = new System.Drawing.Point(423, 168);
            this.AdettextBox.Multiline = true;
            this.AdettextBox.Name = "AdettextBox";
            this.AdettextBox.Size = new System.Drawing.Size(113, 32);
            this.AdettextBox.TabIndex = 7;
            // 
            // SuretextBox
            // 
            this.SuretextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SuretextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.SuretextBox.Location = new System.Drawing.Point(424, 220);
            this.SuretextBox.Multiline = true;
            this.SuretextBox.Name = "SuretextBox";
            this.SuretextBox.Size = new System.Drawing.Size(112, 32);
            this.SuretextBox.TabIndex = 8;
            // 
            // ScorButton
            // 
            this.ScorButton.BackColor = System.Drawing.Color.Yellow;
            this.ScorButton.Image = global::LimonataOyunu.desktop.Properties.Resources.Yıldız;
            this.ScorButton.Location = new System.Drawing.Point(452, 287);
            this.ScorButton.Name = "ScorButton";
            this.ScorButton.Size = new System.Drawing.Size(75, 52);
            this.ScorButton.TabIndex = 10;
            this.ScorButton.UseVisualStyleBackColor = false;
            this.ScorButton.Click += new System.EventHandler(this.ScorButton_Click);
            // 
            // BilgiButton
            // 
            this.BilgiButton.BackColor = System.Drawing.Color.Yellow;
            this.BilgiButton.Image = global::LimonataOyunu.desktop.Properties.Resources.BilgiButonu;
            this.BilgiButton.Location = new System.Drawing.Point(352, 287);
            this.BilgiButton.Name = "BilgiButton";
            this.BilgiButton.Size = new System.Drawing.Size(75, 52);
            this.BilgiButton.TabIndex = 9;
            this.BilgiButton.UseVisualStyleBackColor = false;
            this.BilgiButton.Click += new System.EventHandler(this.BilgiButton_Click_1);
            // 
            // Baslamabutton
            // 
            this.Baslamabutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Baslamabutton.BackColor = System.Drawing.Color.Yellow;
            this.Baslamabutton.Image = global::LimonataOyunu.desktop.Properties.Resources.BaslamaButonu;
            this.Baslamabutton.Location = new System.Drawing.Point(253, 287);
            this.Baslamabutton.Name = "Baslamabutton";
            this.Baslamabutton.Size = new System.Drawing.Size(75, 52);
            this.Baslamabutton.TabIndex = 0;
            this.Baslamabutton.UseVisualStyleBackColor = false;
            this.Baslamabutton.Click += new System.EventHandler(this.Baslamabutton_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScorButton);
            this.Controls.Add(this.BilgiButton);
            this.Controls.Add(this.SuretextBox);
            this.Controls.Add(this.AdettextBox);
            this.Controls.Add(this.AdtextBox);
            this.Controls.Add(this.SureLabel);
            this.Controls.Add(this.AdetLabel);
            this.Controls.Add(this.AdLabel);
            this.Controls.Add(this.Baslamabutton);
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LİMONATA";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label AdLabel;
        private System.Windows.Forms.Label AdetLabel;
        private System.Windows.Forms.Label SureLabel;
        private System.Windows.Forms.TextBox AdtextBox;
        private System.Windows.Forms.TextBox AdettextBox;
        private System.Windows.Forms.TextBox SuretextBox;
        private System.Windows.Forms.Button Baslamabutton;
        private System.Windows.Forms.Button BilgiButton;
        private System.Windows.Forms.Button ScorButton;
    }
}

