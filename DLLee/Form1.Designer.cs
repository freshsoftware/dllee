
namespace DLLee
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAnalyzeFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colFolder = new System.Windows.Forms.ColumnHeader();
            this.colFilename = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colDebug = new System.Windows.Forms.ColumnHeader();
            this.colOptimized = new System.Windows.Forms.ColumnHeader();
            this.colBitness = new System.Windows.Forms.ColumnHeader();
            this.colSigned = new System.Windows.Forms.ColumnHeader();
            this.colCodeSigner = new System.Windows.Forms.ColumnHeader();
            this.btnBrowseFolders = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkHideErroneous = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnAnalyzeFolder
            // 
            this.btnAnalyzeFolder.Location = new System.Drawing.Point(1106, 6);
            this.btnAnalyzeFolder.Name = "btnAnalyzeFolder";
            this.btnAnalyzeFolder.Size = new System.Drawing.Size(84, 23);
            this.btnAnalyzeFolder.TabIndex = 0;
            this.btnAnalyzeFolder.Text = "Analyze";
            this.btnAnalyzeFolder.UseVisualStyleBackColor = true;
            this.btnAnalyzeFolder.Click += new System.EventHandler(this.btnAnalyzeFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(12, 460);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1178, 140);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder:";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(61, 6);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(726, 23);
            this.txtFolderPath.TabIndex = 3;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(825, 8);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(76, 19);
            this.chkRecursive.TabIndex = 4;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            this.chkRecursive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1202, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFolder,
            this.colFilename,
            this.colSize,
            this.colDebug,
            this.colOptimized,
            this.colBitness,
            this.colSigned,
            this.colCodeSigner});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1178, 419);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colFolder
            // 
            this.colFolder.Text = "Path";
            this.colFolder.Width = 360;
            // 
            // colFilename
            // 
            this.colFilename.Text = "Filename";
            this.colFilename.Width = 100;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 48;
            // 
            // colDebug
            // 
            this.colDebug.Text = "Debug";
            this.colDebug.Width = 55;
            // 
            // colOptimized
            // 
            this.colOptimized.Text = "Optimized";
            this.colOptimized.Width = 75;
            // 
            // colBitness
            // 
            this.colBitness.Text = "Bitness";
            // 
            // colSigned
            // 
            this.colSigned.Text = "Signed";
            // 
            // colCodeSigner
            // 
            this.colCodeSigner.Text = "Code Signer";
            this.colCodeSigner.Width = 150;
            // 
            // btnBrowseFolders
            // 
            this.btnBrowseFolders.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseFolders.Image")));
            this.btnBrowseFolders.Location = new System.Drawing.Point(787, 5);
            this.btnBrowseFolders.Name = "btnBrowseFolders";
            this.btnBrowseFolders.Size = new System.Drawing.Size(26, 25);
            this.btnBrowseFolders.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnBrowseFolders, "Pick folder...");
            this.btnBrowseFolders.UseVisualStyleBackColor = true;
            this.btnBrowseFolders.Click += new System.EventHandler(this.btnBrowseFolders_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkHideErroneous
            // 
            this.chkHideErroneous.AutoSize = true;
            this.chkHideErroneous.Location = new System.Drawing.Point(907, 8);
            this.chkHideErroneous.Name = "chkHideErroneous";
            this.chkHideErroneous.Size = new System.Drawing.Size(164, 19);
            this.chkHideErroneous.TabIndex = 8;
            this.chkHideErroneous.Text = "Hide DLLs with load errors";
            this.chkHideErroneous.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 636);
            this.Controls.Add(this.chkHideErroneous);
            this.Controls.Add(this.btnBrowseFolders);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAnalyzeFolder);
            this.Name = "Form1";
            this.Text = "DLLee";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnalyzeFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colFolder;
        private System.Windows.Forms.ColumnHeader colFilename;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colDebug;
        private System.Windows.Forms.ColumnHeader colOptimized;
        private System.Windows.Forms.ColumnHeader colBitness;
        private System.Windows.Forms.ColumnHeader colSigned;
        private System.Windows.Forms.Button btnBrowseFolders;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader colCodeSigner;
        private System.Windows.Forms.CheckBox chkHideErroneous;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

