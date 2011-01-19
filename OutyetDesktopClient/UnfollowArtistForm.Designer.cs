namespace OutyetDesktopClient
{
    partial class UnfollowArtistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnfollowArtistForm));
            this.label2 = new System.Windows.Forms.Label();
            this.artistBox = new System.Windows.Forms.TextBox();
            this.unfollowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artist:";
            // 
            // artistBox
            // 
            this.artistBox.Location = new System.Drawing.Point(65, 43);
            this.artistBox.Name = "artistBox";
            this.artistBox.Size = new System.Drawing.Size(162, 20);
            this.artistBox.TabIndex = 2;
            // 
            // unfollowButton
            // 
            this.unfollowButton.Image = global::OutyetDesktopClient.Properties.Resources.Cross;
            this.unfollowButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unfollowButton.Location = new System.Drawing.Point(233, 41);
            this.unfollowButton.Name = "unfollowButton";
            this.unfollowButton.Size = new System.Drawing.Size(75, 23);
            this.unfollowButton.TabIndex = 3;
            this.unfollowButton.Text = "Unfollow";
            this.unfollowButton.UseVisualStyleBackColor = true;
            this.unfollowButton.Click += new System.EventHandler(this.unfollowButton_Click);
            // 
            // UnfollowArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 105);
            this.Controls.Add(this.unfollowButton);
            this.Controls.Add(this.artistBox);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnfollowArtistForm";
            this.Text = "Unfollow artist";
            this.Load += new System.EventHandler(this.UnfollowArtistForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox artistBox;
        private System.Windows.Forms.Button unfollowButton;
    }
}