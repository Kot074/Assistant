﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinFormHtmlEditor
{
    public partial class TinyMCE : UserControl
    {
        public TinyMCE()
        {
            InitializeComponent();
        }

        public object ActiveXInstance
        {
            get { return webBrowserControl.ActiveXInstance; }
        }

        /// <summary>
        /// HTML Content of TinyMCE editor
        /// </summary>
        public string HtmlContent
        {
            get
            {
                string content = string.Empty;
                if (webBrowserControl.Document != null)
                {
                    object html = webBrowserControl.Document.InvokeScript("GetContent");
                    content = html as string;
                }
                return content;
            }
            set
            {
                webBrowserControl.Document?.InvokeScript("SetContent", new object[] { value });
            }
        }
        
        /// <summary>
        /// Set tinyMCE to fullscreen mode
        /// </summary>
        public void SetFullscreen()
        {
            webBrowserControl.Document?.InvokeScript("tinyMCE.execCommand('mceFullScreen')");
        }

        /// <summary>
        /// Create editor instance
        /// </summary>
        public void CreateEditor(string content)
        {
            string htmTemplatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce/tinymceTemplate.htm").Replace('\\', '/');
            string htmPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce/tinymce.htm").Replace('\\', '/');
            byte[] contentBytes = Encoding.Default.GetBytes(content ?? "");
            string contentUTF8 = Encoding.UTF8.GetString(contentBytes);

            var fr = File.ReadAllText(htmTemplatePath);
            fr = fr.Replace("${content}", contentUTF8);

            File.WriteAllText(htmPath, fr, Encoding.UTF8);

            webBrowserControl.ScriptErrorsSuppressed = true;

            // Check if the main script used by the HTML page exists
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce\js\tinymce\tinymce.min.js")))
            {
                webBrowserControl.Url = new Uri(@"file:///" + htmPath);
            }
            else
            {
                MessageBox.Show("Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
