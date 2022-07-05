using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsEditorCore.Forms
{
    public partial class TextInputForm : Form
    {
        private string _text;
        public string Value
        {
            get => _text;
        }
        public TextInputForm()
        {
            InitializeComponent();
        }

        public TextInputForm(string text) : this()
        {
            txtInput.Text = text;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            _text = txtInput.Text;
            this.Close();
        }
    }
}
