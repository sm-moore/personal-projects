namespace TA_Comment_Generator
{
    partial class NewCheckBoxPopUp
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
            this.displayValueBox = new System.Windows.Forms.TextBox();
            this.commentGeneratedBox = new System.Windows.Forms.RichTextBox();
            this.DisplayValueLabel = new System.Windows.Forms.Label();
            this.commentGeneratedLabel = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // displayValueBox
            // 
            this.displayValueBox.Location = new System.Drawing.Point(12, 69);
            this.displayValueBox.Name = "displayValueBox";
            this.displayValueBox.Size = new System.Drawing.Size(408, 31);
            this.displayValueBox.TabIndex = 0;
            // 
            // commentGeneratedBox
            // 
            this.commentGeneratedBox.Location = new System.Drawing.Point(12, 151);
            this.commentGeneratedBox.Name = "commentGeneratedBox";
            this.commentGeneratedBox.Size = new System.Drawing.Size(408, 179);
            this.commentGeneratedBox.TabIndex = 1;
            this.commentGeneratedBox.Text = "";
            // 
            // DisplayValueLabel
            // 
            this.DisplayValueLabel.AutoSize = true;
            this.DisplayValueLabel.Location = new System.Drawing.Point(12, 41);
            this.DisplayValueLabel.Name = "DisplayValueLabel";
            this.DisplayValueLabel.Size = new System.Drawing.Size(320, 25);
            this.DisplayValueLabel.TabIndex = 2;
            this.DisplayValueLabel.Text = "Name of Check Box (displayed):";
            // 
            // commentGeneratedLabel
            // 
            this.commentGeneratedLabel.AutoSize = true;
            this.commentGeneratedLabel.Location = new System.Drawing.Point(12, 123);
            this.commentGeneratedLabel.Name = "commentGeneratedLabel";
            this.commentGeneratedLabel.Size = new System.Drawing.Size(216, 25);
            this.commentGeneratedLabel.TabIndex = 3;
            this.commentGeneratedLabel.Text = "Comment Generated:";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(257, 336);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(163, 43);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // NewCheckBoxPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 391);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.commentGeneratedLabel);
            this.Controls.Add(this.DisplayValueLabel);
            this.Controls.Add(this.commentGeneratedBox);
            this.Controls.Add(this.displayValueBox);
            this.Name = "NewCheckBoxPopUp";
            this.Text = "NewCheckBoxPopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox displayValueBox;
        private System.Windows.Forms.RichTextBox commentGeneratedBox;
        private System.Windows.Forms.Label DisplayValueLabel;
        private System.Windows.Forms.Label commentGeneratedLabel;
        private System.Windows.Forms.Button acceptButton;
    }
}