using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA_Comment_Generator
{
    public partial class NewCheckBoxPopUp : Form
    {
        public string display;
        public string hidden;
        public bool accepted = false;

        public NewCheckBoxPopUp()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            //Send info back to other form...
            display = displayValueBox.Text;
            hidden = commentGeneratedBox.Text;
            accepted = true;
            Close();
        }
    }
}
