
namespace Excel2Json
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowseFiles = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.ClearFile = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblSelectedFilePath = new System.Windows.Forms.Label();
            this.btnConvertToJson = new System.Windows.Forms.Button();
            this.chkGenerateJsonType = new System.Windows.Forms.CheckBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowseFiles
            // 
            this.btnBrowseFiles.Location = new System.Drawing.Point(36, 165);
            this.btnBrowseFiles.Name = "btnBrowseFiles";
            this.btnBrowseFiles.Size = new System.Drawing.Size(130, 40);
            this.btnBrowseFiles.TabIndex = 0;
            this.btnBrowseFiles.Text = "OpenFileDialog";
            this.btnBrowseFiles.UseVisualStyleBackColor = true;
            this.btnBrowseFiles.Click += new System.EventHandler(this.btnBrowseFiles_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(36, 118);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(450, 27);
            this.txtFilePath.TabIndex = 1;
            // 
            // ClearFile
            // 
            this.ClearFile.Location = new System.Drawing.Point(172, 165);
            this.ClearFile.Name = "ClearFile";
            this.ClearFile.Size = new System.Drawing.Size(72, 40);
            this.ClearFile.TabIndex = 2;
            this.ClearFile.Text = "Clear";
            this.ClearFile.UseVisualStyleBackColor = true;
            this.ClearFile.Click += new System.EventHandler(this.ClearFile_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFormTitle.Location = new System.Drawing.Point(36, 44);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(229, 25);
            this.lblFormTitle.TabIndex = 3;
            this.lblFormTitle.Text = "Excel to JSON Converter";
            // 
            // lblSelectedFilePath
            // 
            this.lblSelectedFilePath.AutoSize = true;
            this.lblSelectedFilePath.Location = new System.Drawing.Point(36, 87);
            this.lblSelectedFilePath.Name = "lblSelectedFilePath";
            this.lblSelectedFilePath.Size = new System.Drawing.Size(125, 20);
            this.lblSelectedFilePath.TabIndex = 4;
            this.lblSelectedFilePath.Text = "Selected file path";
            // 
            // btnConvertToJson
            // 
            this.btnConvertToJson.Location = new System.Drawing.Point(36, 289);
            this.btnConvertToJson.Name = "btnConvertToJson";
            this.btnConvertToJson.Size = new System.Drawing.Size(130, 40);
            this.btnConvertToJson.TabIndex = 5;
            this.btnConvertToJson.Text = "Convert to JSON";
            this.btnConvertToJson.UseVisualStyleBackColor = true;
            this.btnConvertToJson.Click += new System.EventHandler(this.btnConvertToJson_Click);
            // 
            // chkGenerateJsonType
            // 
            this.chkGenerateJsonType.AutoSize = true;
            this.chkGenerateJsonType.Location = new System.Drawing.Point(175, 298);
            this.chkGenerateJsonType.Name = "chkGenerateJsonType";
            this.chkGenerateJsonType.Size = new System.Drawing.Size(311, 24);
            this.chkGenerateJsonType.TabIndex = 6;
            this.chkGenerateJsonType.Text = "Generate individual JSON file for each row";
            this.chkGenerateJsonType.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(41, 251);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 20);
            this.lblResult.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 351);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.chkGenerateJsonType);
            this.Controls.Add(this.btnConvertToJson);
            this.Controls.Add(this.lblSelectedFilePath);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.ClearFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowseFiles);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFiles;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button ClearFile;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblSelectedFilePath;
        private System.Windows.Forms.Button btnConvertToJson;
        private System.Windows.Forms.CheckBox chkGenerateJsonType;
        private System.Windows.Forms.Label lblResult;
    }
}

