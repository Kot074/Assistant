using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsEditor.Forms
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            tinyMceEditor.CreateEditor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tinyMceEditor.HtmlContent);
        }
    }
}
