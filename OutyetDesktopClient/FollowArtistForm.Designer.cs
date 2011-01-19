namespace OutyetDesktopClient
{
    partial class FollowArtistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FollowArtistForm));
            this.followButton = new System.Windows.Forms.Button();
            this.artistText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // followButton
            // 
            this.followButton.Image = global::OutyetDesktopClient.Properties.Resources.Tick;
            this.followButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.followButton.Location = new System.Drawing.Point(242, 71);
            this.followButton.Name = "followButton";
            this.followButton.Size = new System.Drawing.Size(75, 23);
            this.followButton.TabIndex = 7;
            this.followButton.Text = "Follow";
            this.followButton.UseVisualStyleBackColor = true;
            this.followButton.Click += new System.EventHandler(this.followButton_Click);
            // 
            // artistText
            // 
            this.artistText.Location = new System.Drawing.Point(74, 73);
            this.artistText.Name = "artistText";
            this.artistText.Size = new System.Drawing.Size(162, 20);
            this.artistText.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Artist:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.MaximumSize = new System.Drawing.Size(310, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "You can follow an artist (actor, actress, director, writer, producer) and your sp" +
                "ecial \"followed artist\" list will be showing all their latest releases.";
            // 
            // FollowArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 114);
            this.Controls.Add(this.followButton);
            this.Controls.Add(this.artistText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FollowArtistForm";
            this.Text = "Follow artist";
            this.Load += new System.EventHandler(this.FollowArtistForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button followButton;
        private System.Windows.Forms.TextBox artistText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}