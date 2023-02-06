using DLLee.Models;
using DLLee.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//DLLee: A free & open source .NET binary analyzer
//Copyright Fresh Software LLC (www.freshsoftware.com)
//Released under the MIT license



namespace DLLee
{
    public partial class Form1 : Form
    {

        public string ExePath;

        public string[] args;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

        public void stat(string text)
        {
            string s = (text + "\r\n");
            textBox1.AppendText(s);
            Console.WriteLine(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strExeFile =  Assembly.GetExecutingAssembly().Location;
            ExePath = Path.GetDirectoryName(strExeFile);
            txtFolderPath.Text = ExePath;                                    //set default folder to current folder
            HandleCommandLineArgs();
        }

        private void HandleCommandLineArgs()
        {
            if (this.args == null) return;                  //nothing passed in

            bool scanNow = false;                           //if true, scan immediately
            for (int i =0; i < this.args.Count(); i++)
            {
                string arg = this.args[i];

                //check first argument for file/folder to scan.
                if (i==0)
                {
                    //folder passed in
                    string folder = arg;
                    bool dirExists = Directory.Exists(folder);
                    bool fileExists = File.Exists(folder);

                    if (fileExists & !dirExists)
                    {
                        //its a file not a folder, set to folder
                        arg = Path.GetDirectoryName(arg);
                    }

                    //if we end up with a valid folder, use it as default
                    if (Directory.Exists(arg))
                    {
                        txtFolderPath.Text = arg;
                    }                   
                }


                //Check recursive parameter
                if (arg.Contains("/recursive"))
                {
                    chkRecursive.Checked = true;
                }

                //Check scannow paramter
                if (arg.Contains("/scannow"))
                {
                    scanNow = true;
                }
            }

            //Perform the scan immediately, if requested
            if (scanNow)
            {
                ScanNow();
            }
                                   
        }

        private string GetDLLinfoAsText(string path_to_file)
        {
            string result;

            var HasDebuggableAttribute = false;
            var IsJITOptimized = false;
            var IsJITTrackingEnabled = false;
            var BuildType = "";
            var DebugOutput = "";

            var ReflectedAssembly = Assembly.LoadFile(path_to_file);
            object[] attribs = ReflectedAssembly.GetCustomAttributes(typeof(DebuggableAttribute), false);

            // If the 'DebuggableAttribute' is not found then it is definitely an OPTIMIZED build
            if (attribs.Length > 0)
            {
                // Just because the 'DebuggableAttribute' is found doesn't necessarily mean
                // it's a DEBUG build; we have to check the JIT Optimization flag
                // i.e. it could have the "generate PDB" checked but have JIT Optimization enabled
                DebuggableAttribute debuggableAttribute = attribs[0] as DebuggableAttribute;
                if (debuggableAttribute != null)
                {
                    HasDebuggableAttribute = true;
                    IsJITOptimized = !debuggableAttribute.IsJITOptimizerDisabled;

                    // IsJITTrackingEnabled - Gets a value that indicates whether the runtime will track information during code generation for the debugger.
                    IsJITTrackingEnabled = debuggableAttribute.IsJITTrackingEnabled;
                    BuildType = debuggableAttribute.IsJITOptimizerDisabled ? "Debug" : "Release";

                    // check for Debug Output "full" or "pdb-only"
                    DebugOutput = (debuggableAttribute.DebuggingFlags &
                                    DebuggableAttribute.DebuggingModes.Default) !=
                                    DebuggableAttribute.DebuggingModes.None
                                    ? "Full" : "pdb-only";
                }
            }
            else
            {
                IsJITOptimized = true;
                BuildType = "Release";
            }

            result = "File: " + path_to_file + "\r\n";
            result += ($"{nameof(HasDebuggableAttribute)}: {HasDebuggableAttribute}") + "\r\n";
            result += ($"{nameof(IsJITOptimized)}: {IsJITOptimized}") + "\r\n";
            result += ($"{nameof(IsJITTrackingEnabled)}: {IsJITTrackingEnabled}") + "\r\n";
            result += ($"{nameof(BuildType)}: {BuildType}") + "\r\n";
            result += ($"{nameof(DebugOutput)}: {DebugOutput}") + "\r\n";

            return result;
        }

        private void btnAnalyzeFolder_Click(object sender, EventArgs e)
        {
            ScanNow();
        }

        public void ScanNow()
        {
            DLLinfoEngine dle = new DLLinfoEngine();
            List<DLLinformation> dlls = dle.GetDLLinfoForAFolder(txtFolderPath.Text, chkRecursive.Checked);

            listView1.Items.Clear();
            listView1.BeginUpdate();
            foreach (DLLinformation di in dlls)
            {
                ListViewItem li = new ListViewItem();

                if ((chkHideErroneous.Checked) && !String.IsNullOrEmpty(di.exception_info))
                {
                    stat(di.filename + " was skipped due error: " + di.exception_info);
                    continue;
                }

                string filename = Path.GetFileName(di.filename);
                string folder = Path.GetDirectoryName(di.filename);
                folder = @"\" + Path.GetRelativePath(txtFolderPath.Text, folder) + "\\";   //this overwrites any definition above

                li.Text = folder;
                li.SubItems.Add(filename); //filename
                li.SubItems.Add(di.SizeInKB.ToString("###,###,##0") + "KB"); //size

                li.SubItems.Add(di.DebugOutput); //filename
                li.SubItems.Add(di.IsJITOptimized.ToString());
                li.SubItems.Add(di.procArch);

                li.SubItems.Add(di.CodeSigned.ToString());
                li.SubItems.Add(di.CodeSignerName);
                listView1.Items.Add(li);
            }

            listView1.EndUpdate();

            AutoSizeColumns();
        }

        private void btnBrowseFolders_Click(object sender, EventArgs e)
        {
            PickFolder2();
            ScanNow();
        }

        private void PickFolder()
        {
            openFileDialog1.Title = "Pick folder or .EXE hosting the app";
            openFileDialog1.FileName = "";

            ; if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //process
                txtFolderPath.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        private void PickFolder2()
        {
            folderBrowserDialog1.SelectedPath = ExePath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //process
                txtFolderPath.Text = Path.GetDirectoryName(folderBrowserDialog1.SelectedPath);
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AutoSizeColumns()
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


        #region "Dark Mode"
            //todo...
        #endregion

    }
}
