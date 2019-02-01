using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comment_Generator_Model;
using System.Threading;

namespace TA_Comment_Generator
{
    public partial class CommentGeneratorGUI : Form
    {
        private string special_order_comments;
        //private string percent_Of_Grade_Analysis_Doc_Is_Worth = "30%";
        private CommentGenerator cg;
        private List<CheckBox> checkBoxes;
        private bool unsavedChanges = false;
        private string currentFileName = "";
        private static string CG_EXT = ".cg"; 
        private static string DEFAULT_FILTER = "CommentGenerator Files (*.cg)|*.cg|All Files|*.*";
        private static string HELP_MENU_MESSAGE = "To use the comment creation tool simply type the comment you'd like to generate in the text box.\nThe format is this:\n\n"
                + "Text displayed next to check box\nComment generated when check box is clicked.\n\nBe sure to only include the text you'd like generated in the comment box.";
        private static string SAVE_BEFORE_MESSAGE = "There may be unsaved changes in your comment generator." +
            "\nWould you like to save?";

        public CommentGeneratorGUI()
        {
            cg = new CommentGenerator();
            InitializeComponent();
            UpdateDisplay();
        }

        /// <summary>
        /// Creates a checkbox for every comment in the commentGenerator. 
        /// </summary>
        private void UpdateDisplay()
        {
            checkBoxes = new List<CheckBox>();
            ClearDisplay();

            int height = 1;
            int width = checkBoxPanel.Width - 5;
            int padding = 10;
            int i = 0;

            foreach (string display in cg.getAllCommentDisplays())
            {
                CheckBox ckb = CreateCheckBox(display, height, padding, width, i);
                checkBoxPanel.Controls.Add(ckb);
                checkBoxes.Add(ckb);
                height += 22;
                i++;
            }
        }

        /// <summary>
        /// Clears elements from the display. This includes clearing the comment generated as well as
        /// removing all check boxes. 
        /// </summary>
        private void ClearDisplay()
        {
            checkBoxPanel.Controls.Clear();
            commentTxtBox.Clear();
            commentTxtBox.ReadOnly = true;
            customCommentBox.Clear();
        }

        /// <summary>
        /// Creates a checkbox with the given properties. 
        /// </summary>
        private CheckBox CreateCheckBox(string Text, int height, int padding, int width, int tabIndex)
        {
            CheckBox ckb = new CheckBox();
            ckb.Text = Text;
            ckb.TabIndex = tabIndex;
            ckb.AutoCheck = true;
            ckb.Bounds = new Rectangle(10, 20 + padding + height, width, 22);
            return ckb;
        }

        /// <summary>
        /// Generates the comment and displays it in the comment text box to the user. 
        /// </summary>
        private void generate_comment_Click(object sender, EventArgs e)
        {
            commentTxtBox.Clear();  
            string comment = "";
            foreach (CheckBox box in checkBoxes)
            {
                if (box.Checked == true) 
                {
                    //TODO: Add comment priority check here. 
                    comment += cg.GetComment(box.Text) + "\n";
                }
            }

            //Add what is in the comment text box to the generated comment
            comment += customCommentBox.Text + "\n";

            //TODO: Add an ending message?
            //comment += "Please come see me in office hours if you have any questions about grading."; //An ending message. 
            commentTxtBox.Text = comment;

            //Set the comment box to be editable so that users can edit inside the app. 
            commentTxtBox.ReadOnly = false;
        }


        /// <summary>
        /// Clear all of the check boxes and the comment text box. 
        /// </summary>
        private void clear_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cbox in checkBoxes)
            {
                cbox.Checked = false;
            }
            commentTxtBox.Clear();
            commentTxtBox.ReadOnly = true;

            if(keepCustomOnClearBox.Checked == false)
            {
                customCommentBox.Clear();
            }
        }

        /// <summary>
        /// Opens an exisiting cg file. 
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //is user has unsaved changes, prompt to save them.
            if (unsavedChanges == true)
            {
                Save();
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = CG_EXT;
            dlg.Filter = DEFAULT_FILTER; 
 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentFileName = dlg.FileName;
                cg = cg.ReadXml(currentFileName);
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Adds a new check box and comment.
        /// </summary>
        private void addCheckBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCheckBoxPopUp newBox = new NewCheckBoxPopUp();
            newBox.ShowDialog(this);
            //How do I know which button was pressed?? If canceled I dont want to do anything!!
            if (newBox.accepted)
            {
                cg.AddComment(newBox.display, newBox.hidden);
                UpdateDisplay();
                unsavedChanges = true;
            }
        }


        /// <summary>
        /// Displays information about how to use the app to the user. 
        /// </summary>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(HELP_MENU_MESSAGE);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        /// <summary>
        /// Called before close(). Asks the user to save any unsaved changes. 
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //If the file should be closed, close it. 
            if (UnsavedChangesDialog() == true)
            {
                base.OnFormClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// if the form has unsaved changes, prompts the user to either save, not save, or cancel. 
        /// If save, save the file and return true. 
        /// If not save, do nothing and return true.
        /// if cancel, do nothing and return false.
        /// </summary>
        /// <returns>Returns false if user cancels dialog. True otherwise. </returns>
        private bool UnsavedChangesDialog()
        {
            if (unsavedChanges)
            {
                DialogResult result = MessageBox.Show(SAVE_BEFORE_MESSAGE,
                    "Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Save();
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return true;
                }
                else
                {
                    //if canceled return false. 
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Saves the current spreadsheet file by prompting the user with a SaveFileDialog box.  
        /// </summary>
        private void SaveFileDialog()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.DefaultExt = CG_EXT; //default file extension
            dlg.Filter = DEFAULT_FILTER; //display only .cg files or All Files. 
            //Open the given file. 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentFileName = dlg.FileName;
                cg.WriteXml(dlg.FileName);
                unsavedChanges = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// Saves the file to the currentFileName if one has been set. Otherwise performs a "save as".
        /// </summary>
        private void Save()
        {
            if (currentFileName.Equals(""))
            {
                //User has not done a "save as" yet. They need to name their file!  
                SaveFileDialog();
            }
            else
            {
                cg.WriteXml(currentFileName);
                unsavedChanges = false;
            }
        }
    }
}
