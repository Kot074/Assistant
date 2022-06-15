namespace WinFormHtmlEditor
{
  partial class TinyMCE
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.webBrowserControl = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserControl
            // 
            this.webBrowserControl.AllowWebBrowserDrop = false;
            this.webBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserControl.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserControl.Location = new System.Drawing.Point(0, 0);
            this.webBrowserControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowserControl.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowserControl.Name = "webBrowserControl";
            this.webBrowserControl.ScrollBarsEnabled = false;
            this.webBrowserControl.Size = new System.Drawing.Size(654, 415);
            this.webBrowserControl.TabIndex = 0;
            // 
            // TinyMCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowserControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TinyMCE";
            this.Size = new System.Drawing.Size(654, 415);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser webBrowserControl;
  }
}
