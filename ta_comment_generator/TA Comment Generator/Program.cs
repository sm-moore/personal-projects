using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA_Comment_Generator
{

    /// <summary>
    /// Keeps track of how many top-level forms are running. 
    /// </summary>
    class CommentGeneratorApplicationContext : ApplicationContext
    {
        // Number of open forms
        private int formCount = 0;

        // Singleton ApplicationContext
        private static CommentGeneratorApplicationContext appContext;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private CommentGeneratorApplicationContext()
        {
        }

        /// <summary>
        /// Returns the one DemoApplicationContext.
        /// </summary>
        public static CommentGeneratorApplicationContext getAppContext()
        {
            if (appContext == null)
            {
                appContext = new CommentGeneratorApplicationContext();
            }
            return appContext;
        }

        /// <summary>
        /// Runs the form
        /// </summary>
        public void RunForm(Form form)
        {
            // One more form is running
            formCount++;

            // When this form closes, we want to find out
            form.FormClosed += (o, e) => { if (--formCount <= 0) ExitThread(); };

            // Run the form
            form.Show();
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CommentGeneratorApplicationContext appContext = CommentGeneratorApplicationContext.getAppContext();
            appContext.RunForm(new CommentGeneratorGUI());
            Application.Run(appContext);
        }
    }
}
