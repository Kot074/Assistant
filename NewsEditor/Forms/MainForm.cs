using System;
using System.Windows.Forms;
using NewsEditor.Forms;

namespace NewsEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var editor = new EditorForm();
            editor.Show();
        }
    }
}
