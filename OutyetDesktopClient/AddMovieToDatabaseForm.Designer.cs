namespace OutyetDesktopClient
{
    partial class AddMovieToDatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMovieToDatabaseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yearBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.releaseDateBox = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.directorsBox = new System.Windows.Forms.TextBox();
            this.writersBox = new System.Windows.Forms.TextBox();
            this.castBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.producersBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(100, 29);
            this.titleBox.MaxLength = 50;
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(200, 20);
            this.titleBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year:";
            // 
            // yearBox
            // 
            this.yearBox.FormattingEnabled = true;
            this.yearBox.Location = new System.Drawing.Point(100, 55);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(78, 21);
            this.yearBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Release date:";
            // 
            // releaseDateBox
            // 
            this.releaseDateBox.Location = new System.Drawing.Point(100, 82);
            this.releaseDateBox.Name = "releaseDateBox";
            this.releaseDateBox.Size = new System.Drawing.Size(200, 20);
            this.releaseDateBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Directors:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Writers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cast:";
            // 
            // directorsBox
            // 
            this.directorsBox.Location = new System.Drawing.Point(100, 108);
            this.directorsBox.Multiline = true;
            this.directorsBox.Name = "directorsBox";
            this.directorsBox.Size = new System.Drawing.Size(200, 40);
            this.directorsBox.TabIndex = 3;
            // 
            // writersBox
            // 
            this.writersBox.Location = new System.Drawing.Point(100, 200);
            this.writersBox.Multiline = true;
            this.writersBox.Name = "writersBox";
            this.writersBox.Size = new System.Drawing.Size(200, 40);
            this.writersBox.TabIndex = 5;
            // 
            // castBox
            // 
            this.castBox.Location = new System.Drawing.Point(100, 246);
            this.castBox.Multiline = true;
            this.castBox.Name = "castBox";
            this.castBox.Size = new System.Drawing.Size(200, 80);
            this.castBox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(100, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "*Separate people with new lines.";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(284, 385);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(203, 385);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Producers:";
            // 
            // producersBox
            // 
            this.producersBox.Location = new System.Drawing.Point(100, 154);
            this.producersBox.Multiline = true;
            this.producersBox.Name = "producersBox";
            this.producersBox.Size = new System.Drawing.Size(200, 40);
            this.producersBox.TabIndex = 4;
            // 
            // AddMovieToDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 420);
            this.Controls.Add(this.producersBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.castBox);
            this.Controls.Add(this.writersBox);
            this.Controls.Add(this.directorsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.releaseDateBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddMovieToDatabaseForm";
            this.Text = "Add movie";
            this.Load += new System.EventHandler(this.AddMovieToDatabaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox yearBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker releaseDateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox directorsBox;
        private System.Windows.Forms.TextBox writersBox;
        private System.Windows.Forms.TextBox castBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox producersBox;
    }
}