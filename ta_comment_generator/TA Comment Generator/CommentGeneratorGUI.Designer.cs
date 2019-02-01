using System.Windows.Forms;
using System.Collections.Generic;

namespace TA_Comment_Generator
{
    partial class CommentGeneratorGUI
    {
        /// <summary>
        /// Create a list of check boxes so that I can iterate through them later. It is important that they get added in order. 
        /// </summary>
        List<CheckBox> checkboxes = new List<CheckBox> ();


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
            this.generate_comment = new System.Windows.Forms.Button();
            this.commentTxtBox = new System.Windows.Forms.RichTextBox();
            this.customCommentsLabel = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.CommentBoxPanel = new System.Windows.Forms.Panel();
            this.checkBoxPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.HelpButton = new System.Windows.Forms.Button();
            this.fileManageMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItemNonClick = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCheckBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customCommentBox = new System.Windows.Forms.RichTextBox();
            this.keepCustomOnClearBox = new System.Windows.Forms.CheckBox();
            this.CommentBoxPanel.SuspendLayout();
            this.buttonLayoutPanel.SuspendLayout();
            this.fileManageMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // generate_comment
            // 
            this.generate_comment.Location = new System.Drawing.Point(190, 6);
            this.generate_comment.Margin = new System.Windows.Forms.Padding(6);
            this.generate_comment.Name = "generate_comment";
            this.generate_comment.Size = new System.Drawing.Size(254, 44);
            this.generate_comment.TabIndex = 9;
            this.generate_comment.Text = "generate comment";
            this.generate_comment.UseVisualStyleBackColor = true;
            this.generate_comment.Click += new System.EventHandler(this.generate_comment_Click);
            // 
            // commentTxtBox
            // 
            this.commentTxtBox.AccessibleName = "comment";
            this.commentTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentTxtBox.Location = new System.Drawing.Point(0, 221);
            this.commentTxtBox.Margin = new System.Windows.Forms.Padding(6);
            this.commentTxtBox.Name = "commentTxtBox";
            this.commentTxtBox.ReadOnly = true;
            this.commentTxtBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.commentTxtBox.Size = new System.Drawing.Size(441, 431);
            this.commentTxtBox.TabIndex = 10;
            this.commentTxtBox.Text = "";
            // 
            // customCommentsLabel
            // 
            this.customCommentsLabel.AutoSize = true;
            this.customCommentsLabel.Location = new System.Drawing.Point(6, 8);
            this.customCommentsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.customCommentsLabel.Name = "customCommentsLabel";
            this.customCommentsLabel.Size = new System.Drawing.Size(224, 25);
            this.customCommentsLabel.TabIndex = 11;
            this.customCommentsLabel.Text = "Add custom comment:";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(456, 6);
            this.clear.Margin = new System.Windows.Forms.Padding(6);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(150, 44);
            this.clear.TabIndex = 12;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // CommentBoxPanel
            // 
            this.CommentBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentBoxPanel.Controls.Add(this.keepCustomOnClearBox);
            this.CommentBoxPanel.Controls.Add(this.customCommentBox);
            this.CommentBoxPanel.Controls.Add(this.commentTxtBox);
            this.CommentBoxPanel.Controls.Add(this.customCommentsLabel);
            this.CommentBoxPanel.Location = new System.Drawing.Point(529, 46);
            this.CommentBoxPanel.Margin = new System.Windows.Forms.Padding(6);
            this.CommentBoxPanel.Name = "CommentBoxPanel";
            this.CommentBoxPanel.Size = new System.Drawing.Size(441, 652);
            this.CommentBoxPanel.TabIndex = 25;
            // 
            // checkBoxPanel
            // 
            this.checkBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPanel.Location = new System.Drawing.Point(12, 46);
            this.checkBoxPanel.Name = "checkBoxPanel";
            this.checkBoxPanel.Size = new System.Drawing.Size(508, 652);
            this.checkBoxPanel.TabIndex = 29;
            // 
            // buttonLayoutPanel
            // 
            this.buttonLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLayoutPanel.Controls.Add(this.HelpButton);
            this.buttonLayoutPanel.Controls.Add(this.generate_comment);
            this.buttonLayoutPanel.Controls.Add(this.clear);
            this.buttonLayoutPanel.Location = new System.Drawing.Point(12, 724);
            this.buttonLayoutPanel.Name = "buttonLayoutPanel";
            this.buttonLayoutPanel.Size = new System.Drawing.Size(959, 67);
            this.buttonLayoutPanel.TabIndex = 30;
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(6, 6);
            this.HelpButton.Margin = new System.Windows.Forms.Padding(6);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(172, 44);
            this.HelpButton.TabIndex = 28;
            this.HelpButton.Text = "Help!";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // fileManageMenuStrip
            // 
            this.fileManageMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.fileManageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItemNonClick,
            this.insertLabelToolStripMenuItem,
            this.addCheckBoxToolStripMenuItem});
            this.fileManageMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.fileManageMenuStrip.Name = "fileManageMenuStrip";
            this.fileManageMenuStrip.Size = new System.Drawing.Size(988, 40);
            this.fileManageMenuStrip.TabIndex = 31;
            this.fileManageMenuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(86, 36);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItemNonClick
            // 
            this.saveToolStripMenuItemNonClick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.saveToolStripMenuItemNonClick.Name = "saveToolStripMenuItemNonClick";
            this.saveToolStripMenuItemNonClick.Size = new System.Drawing.Size(77, 36);
            this.saveToolStripMenuItemNonClick.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // insertLabelToolStripMenuItem
            // 
            this.insertLabelToolStripMenuItem.Name = "insertLabelToolStripMenuItem";
            this.insertLabelToolStripMenuItem.Size = new System.Drawing.Size(144, 36);
            this.insertLabelToolStripMenuItem.Text = "Insert label";
            // 
            // addCheckBoxToolStripMenuItem
            // 
            this.addCheckBoxToolStripMenuItem.Name = "addCheckBoxToolStripMenuItem";
            this.addCheckBoxToolStripMenuItem.Size = new System.Drawing.Size(264, 36);
            this.addCheckBoxToolStripMenuItem.Text = "Create New Comment";
            this.addCheckBoxToolStripMenuItem.Click += new System.EventHandler(this.addCheckBoxToolStripMenuItem_Click);
            // 
            // customCommentBox
            // 
            this.customCommentBox.Location = new System.Drawing.Point(3, 36);
            this.customCommentBox.Name = "customCommentBox";
            this.customCommentBox.Size = new System.Drawing.Size(438, 176);
            this.customCommentBox.TabIndex = 12;
            this.customCommentBox.Text = "";
            // 
            // keepCustomOnClearBox
            // 
            this.keepCustomOnClearBox.AutoSize = true;
            this.keepCustomOnClearBox.Location = new System.Drawing.Point(262, 4);
            this.keepCustomOnClearBox.Name = "keepCustomOnClearBox";
            this.keepCustomOnClearBox.Size = new System.Drawing.Size(143, 29);
            this.keepCustomOnClearBox.TabIndex = 13;
            this.keepCustomOnClearBox.Text = "don\'t clear";
            this.keepCustomOnClearBox.UseVisualStyleBackColor = true;
            // 
            // CommentGeneratorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 802);
            this.Controls.Add(this.buttonLayoutPanel);
            this.Controls.Add(this.checkBoxPanel);
            this.Controls.Add(this.CommentBoxPanel);
            this.Controls.Add(this.fileManageMenuStrip);
            this.MainMenuStrip = this.fileManageMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(935, 835);
            this.Name = "CommentGeneratorGUI";
            this.Text = "Comment Generator";
            this.CommentBoxPanel.ResumeLayout(false);
            this.CommentBoxPanel.PerformLayout();
            this.buttonLayoutPanel.ResumeLayout(false);
            this.fileManageMenuStrip.ResumeLayout(false);
            this.fileManageMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generate_comment;
        private System.Windows.Forms.RichTextBox commentTxtBox;
        private System.Windows.Forms.Label customCommentsLabel;
        private System.Windows.Forms.Button clear;
        private Panel CommentBoxPanel;
        private FlowLayoutPanel checkBoxPanel;
        private FlowLayoutPanel buttonLayoutPanel;
        private Button HelpButton;
        private MenuStrip fileManageMenuStrip;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItemNonClick;
        private ToolStripMenuItem insertLabelToolStripMenuItem;
        private ToolStripMenuItem addCheckBoxToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private RichTextBox customCommentBox;
        private CheckBox keepCustomOnClearBox;
    }
}


