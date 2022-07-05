
namespace NewsEditorCore.Forms
{
    partial class CollectionToSaleForm
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
            this.btnCollectionCancel = new System.Windows.Forms.Button();
            this.btnSaveCollection = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDocument = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtImageLink = new System.Windows.Forms.TextBox();
            this.txtDocumentLink = new System.Windows.Forms.TextBox();
            this.bntImageLoad = new System.Windows.Forms.Button();
            this.btnDocumentLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCollectionCancel
            // 
            this.btnCollectionCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollectionCancel.Location = new System.Drawing.Point(416, 144);
            this.btnCollectionCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCollectionCancel.Name = "btnCollectionCancel";
            this.btnCollectionCancel.Size = new System.Drawing.Size(150, 30);
            this.btnCollectionCancel.TabIndex = 7;
            this.btnCollectionCancel.Text = "Отмена";
            this.btnCollectionCancel.UseVisualStyleBackColor = true;
            this.btnCollectionCancel.Click += new System.EventHandler(this.BtnCollectionCancelClick);
            // 
            // btnSaveCollection
            // 
            this.btnSaveCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCollection.Location = new System.Drawing.Point(258, 144);
            this.btnSaveCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveCollection.Name = "btnSaveCollection";
            this.btnSaveCollection.Size = new System.Drawing.Size(150, 30);
            this.btnSaveCollection.TabIndex = 7;
            this.btnSaveCollection.Text = "Сохранить";
            this.btnSaveCollection.UseVisualStyleBackColor = true;
            this.btnSaveCollection.Click += new System.EventHandler(this.BtnSaveCollectionClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 15);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Название: ";
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(12, 85);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(67, 15);
            this.lblDocument.TabIndex = 8;
            this.lblDocument.Text = "Документ: ";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(12, 47);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(89, 15);
            this.lblImage.TabIndex = 8;
            this.lblImage.Text = "Изображение: ";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(107, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(459, 23);
            this.txtTitle.TabIndex = 9;
            // 
            // txtImageLink
            // 
            this.txtImageLink.Location = new System.Drawing.Point(107, 44);
            this.txtImageLink.Name = "txtImageLink";
            this.txtImageLink.Size = new System.Drawing.Size(377, 23);
            this.txtImageLink.TabIndex = 9;
            // 
            // txtDocumentLink
            // 
            this.txtDocumentLink.Location = new System.Drawing.Point(107, 82);
            this.txtDocumentLink.Name = "txtDocumentLink";
            this.txtDocumentLink.Size = new System.Drawing.Size(377, 23);
            this.txtDocumentLink.TabIndex = 9;
            // 
            // bntImageLoad
            // 
            this.bntImageLoad.Location = new System.Drawing.Point(491, 41);
            this.bntImageLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntImageLoad.Name = "bntImageLoad";
            this.bntImageLoad.Size = new System.Drawing.Size(75, 30);
            this.bntImageLoad.TabIndex = 10;
            this.bntImageLoad.Text = "Загрузить";
            this.bntImageLoad.UseVisualStyleBackColor = true;
            this.bntImageLoad.Click += new System.EventHandler(this.BntImageLoadClick);
            // 
            // btnDocumentLoad
            // 
            this.btnDocumentLoad.Location = new System.Drawing.Point(491, 77);
            this.btnDocumentLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDocumentLoad.Name = "btnDocumentLoad";
            this.btnDocumentLoad.Size = new System.Drawing.Size(75, 30);
            this.btnDocumentLoad.TabIndex = 11;
            this.btnDocumentLoad.Text = "Загрузить";
            this.btnDocumentLoad.UseVisualStyleBackColor = true;
            this.btnDocumentLoad.Click += new System.EventHandler(this.BtnDocumentLoadClick);
            // 
            // CollectionToSaleForm
            // 
            this.AcceptButton = this.btnSaveCollection;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCollectionCancel;
            this.ClientSize = new System.Drawing.Size(578, 186);
            this.Controls.Add(this.btnDocumentLoad);
            this.Controls.Add(this.bntImageLoad);
            this.Controls.Add(this.txtDocumentLink);
            this.Controls.Add(this.txtImageLink);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblDocument);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSaveCollection);
            this.Controls.Add(this.btnCollectionCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CollectionToSaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сборник";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCollectionCancel;
        private System.Windows.Forms.Button btnSaveCollection;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtImageLink;
        private System.Windows.Forms.TextBox txtDocumentLink;
        private System.Windows.Forms.Button bntImageLoad;
        private System.Windows.Forms.Button btnDocumentLoad;
    }
}