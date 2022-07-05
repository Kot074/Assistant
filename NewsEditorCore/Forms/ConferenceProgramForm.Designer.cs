
namespace NewsEditorCore.Forms
{
    partial class ConferenceProgramForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDocument = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDocument = new System.Windows.Forms.TextBox();
            this.btnDocumentUpload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(391, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(235, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 15);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Название:";
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(12, 49);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(64, 15);
            this.lblDocument.TabIndex = 5;
            this.lblDocument.Text = "Документ:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(80, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(461, 23);
            this.txtTitle.TabIndex = 6;
            // 
            // txtDocument
            // 
            this.txtDocument.Location = new System.Drawing.Point(82, 46);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(377, 23);
            this.txtDocument.TabIndex = 7;
            // 
            // btnDocumentUpload
            // 
            this.btnDocumentUpload.Location = new System.Drawing.Point(466, 41);
            this.btnDocumentUpload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDocumentUpload.Name = "btnDocumentUpload";
            this.btnDocumentUpload.Size = new System.Drawing.Size(75, 30);
            this.btnDocumentUpload.TabIndex = 11;
            this.btnDocumentUpload.Text = "Загрузить";
            this.btnDocumentUpload.UseVisualStyleBackColor = true;
            this.btnDocumentUpload.Click += new System.EventHandler(this.BtnDocumentUploadClick);
            // 
            // ConferenceProgramForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(553, 144);
            this.Controls.Add(this.btnDocumentUpload);
            this.Controls.Add(this.txtDocument);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDocument);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConferenceProgramForm";
            this.Text = "Программа конференции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDocument;
        private System.Windows.Forms.Button btnDocumentUpload;
    }
}